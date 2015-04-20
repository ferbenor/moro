using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using Estructura;
using CollectionLoaders;
using System.Linq.Dynamic;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.SqlQuery;
using System.Collections;

namespace Proveedores
{
    public class UsuarioPr
    {
        #region VARIABLES
        private static UsuarioPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static UsuarioPr Instancia { get { if (instancia == null) instancia = new UsuarioPr(); return instancia; } set { instancia = value; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public UsuarioPr()
        { }

        #endregion CONSTRUCTORES

        #region CARGAS PARA ASIGNACION

        public static List<usuario> RegistrosCombo()
        {
            List<usuario> lista;
            using (ispDB db = new ispDB())
            {
                lista = db.usuarios.Where(x => x.activo == true).Select(x => x.Relacionar(x.fkpersona)).ToList();
            }
            return lista;
        }

        public static void RegistrosDetalle(DataGridView objetoGrid, usuario unUsuario)
        {
            using (ispDB db = new ispDB())
            {
                unUsuario.fkusuariosperfiles =
                    (from m in db.perfiles
                     from p in db.usuariosperfiles
                     .Where(x => x.idperfil == m.id && (x.idusuario == unUsuario.id || x.idusuario == null)).DefaultIfEmpty()
                     orderby m.descripcion
                     select new usuarioperfil()
                     {
                         fkperfile = m,
                         idperfil = m.id,
                         fkusuario = unUsuario,
                         idusuario = unUsuario.id,
                         Asignado = (p.idperfil == null ? false : true)
                     }).ToList();
            }
            unUsuario.fkusuariosperfiles.CargarGrid(objetoGrid);
        }

        #endregion CARGAS PARA ASIGNACION

        #region FUNCIONES CARGA DE OBJETOS

        public List<usuario> RegistrosActivos()
        {
            return Registros("activo == @0", true);
        }

        public usuario RegistroPorLogin(string unaClave)
        {
            General.ipLocal = null;
            return Registros("clave == @0", General.CifrarClave(unaClave)).SingleOrDefault();
        }

        public usuario Registro(short unId)
        {
            return Registros("id == @0", unId).SingleOrDefault();
        }

        public List<usuario> Registros(string expresion = null, params object[] parametros)
        {
            List<usuario> registros = null;
            using (ispDB db = new ispDB())
            {
                if (General.ipLocal == null)
                    General.ipLocal = db.QueryProc<string>("inet_client_addr()").Single();
                registros = db.usuarios.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).GroupJoin(
                db.usuariosperfiles, x => x.id, y => y.idusuario, (x, y) => new usuario()
                {
                    id = x.id,
                    idpersona = x.idpersona,
                    loginusuario = x.loginusuario,
                    multisesion = x.multisesion,
                    ReseteaClave = x.ReseteaClave,
                    activo = x.activo,
                    administrador = x.administrador,
                    clave = x.clave,
                    descripcion = x.descripcion,
                    diasvigencia = x.diasvigencia,
                    fechacambio = x.fechacambio,
                    fechacreacion = x.fechacreacion,
                    fkpersona = x.fkpersona,
                    MenusAsignados = (y.Count() == 0 ? false : true)
                }).ToList();
            }

            return registros;
        }

        public List<usuario> RegistrosPerfiles(usuario unUsuario)
        {
            List<usuario> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.usuarios.Where(x => x.id == unUsuario.id).Select(x =>
                    //CONYUGE, PERSONA, ESTADOSPERSONA
                    x.Relacionar(
                        x.fkpersona
                    ).Relacionar(x.fkusuariosperfiles
                    )).ToList();
            }

            return registros;
        }

        #endregion FUNCIONES CARGA DE OBJETOS

        #region FUNCIONES DE GESTION
        /// <summary>
        /// Graba un objeto de tipo usuario
        /// </summary>
        /// <param name="item">Objeto a ser guardado</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(usuario item)
        {
            int i = 0;
            if (item.fkusuariosperfiles != null)
            {
                IEnumerable<usuarioperfil> items = item.fkusuariosperfiles.Where(x => x.Asignado == true);
                i = items.GrabarDetalle("idusuario == @0", item.id);
            }
            else
            {
                item.fechacambio = Sql.DateTime;
                if (item.ReseteaClave)
                    item.clave = General.CifrarClave(item.loginusuario + " " + item.loginusuario);
                i = item.GrabarObjetoT(x => (short?)x.id ?? 0);
            }
            return i;

            //int i = 0;
            //using (ispDB db = new ispDB())
            //{
            //    try
            //    {
            //        db.BeginTransaction();
            //        if (item.id == 0)
            //        {
            //            item.id = db.usuarios.Max(y => y.id);
            //            item.id++;
            //        }
            //        item.fechacambio = Sql.DateTime;
            //        if (item.ReseteaClave)
            //            item.clave = General.CifrarClave(item.loginusuario + " " + item.loginusuario);

            //        i = db.InsertOrReplace(item);
            //        db.CommitTransaction();
            //    }
            //    catch (Exception)
            //    {
            //        db.RollbackTransaction();
            //        throw;
            //    }

            //}
            //return i;
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<usuario> items)
        {

            int total = items.Count();
            for (int ix = 0; ix < total; ix++)
            {
                usuario item = items.ElementAt(ix);
                if (item.ReseteaClave)
                    item.clave = General.CifrarClave(item.loginusuario + " " + item.loginusuario);
            }

            return items.GrabarListaT(x => (short?)x.id ?? 0);
            //if (i == 0)
            //    throw new Exception("Error de concurrencia, por favor vuelva a realizar la transaccion.");
            //return i;
        }

        /// <summary>
        /// Borra y objeto de tipo usuario
        /// </summary>
        /// <param name="item">Objeto a ser borrado</param>
        /// <returns>Numero de registros afectados</returns>
        public int Borrar(usuario item)
        {
            item.activo = false;
            return item.GrabarObjetoT(x => (short?)x.id ?? 0);
        }

        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
                if (!objetoGrid.ReadOnly)
                {
                    objetoGrid.CellValidating += new DataGridViewCellValidatingEventHandler(objetoGrid_CellValidating);
                    objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
                    objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
                    objetoGrid.ForeColor = System.Drawing.Color.Black;
                }
                objetoGrid.Columns["colIdeBoton"].Visible = !objetoGrid.ReadOnly;
                objetoGrid.Columns["colReseteaClave"].Visible = !objetoGrid.ReadOnly;
            }

            //CARGA DE LISTAS
            objetoGrid.CancelEdit();

            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<usuario>.ToBindingList(this.Registros(expresion, parametros));

        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.BuscarPersona();
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.BeginEdit(false);
                        campo.DataGridView.CurrentRow.Cells["colPersona"].Value = (persona)objeto;
                        campo.DataGridView.EndEdit();
                    }
                    else
                        campo.DataGridView.EndEdit();
                }
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message.ToString());
            }
        }

        void objetoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && ((DataGridView)sender).ReadOnly == false)
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 1 || ((DataGridView)sender).CurrentCell.ColumnIndex == 2)
                {
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(2, ((DataGridView)sender).CurrentCell.RowIndex));
                }
        }

        void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
            {
                persona objeto = null;
                if (grid.CurrentCell.ColumnIndex == 1)
                {
                    objeto = PersonaPr.Instancia.RegistroPorIdentificacion(grid.EditingControl.Text);
                    if (objeto == null)
                        grid.CurrentRow.Cells["colPersona"].Value = null;
                    else
                        grid.CurrentRow.Cells["colPersona"].Value = objeto;
                    if (objeto == null)
                    {
                        General.Mensaje(General.itemNoEncontrado);
                        e.Cancel = true;
                    }
                }
            }
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colIdUsuario = new DataGridViewTextBoxColumn()
            {
                Name = "colIdUsuario",
                HeaderText = "Id",
                DataPropertyName = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdUsuario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            /*DataGridViewTextBoxDropDownColumn colIdentificacion = new DataGridViewTextBoxDropDownColumn()
            {
                Name = "colIdentificacion",
                HeaderText = "Identificacion",
                DataPropertyName = "Identificacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            };*/
            /*colIdentificacion.MaxInputLength = 13;
            //colIdentificacion.ButtonCustomClick += colIdentificacion_ButtonCustomClick;
            colIdentificacion.ButtonDropDownClick += new EventHandler<System.ComponentModel.CancelEventArgs>(colIdentificacion_ButtonDropDownClick);
            //colIdentificacion.ButtonCustom.Visible = true;
            colIdentificacion.ButtonDropDown.Visible = true;
            //colIdentificacion.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            colIdentificacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            colIdentificacion.ButtonDropDown.Image = General.Imagenes.Images["Listar.ico"];
            colIdentificacion.Tag = "colDescripcion";
            colIdentificacion.ButtonDropDown.ItemReference.Focusable = true;
            */
            DataGridViewTextBoxColumn colIdentificacion = new DataGridViewTextBoxColumn()
            {
                Name = "colIdentificacion",
                HeaderText = "Identificacion.",
                DataPropertyName = "identificacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colDescripcion"
            };

            DataGridViewButtonXColumn colIdeBoton = new DataGridViewButtonXColumn()
            {
                Name = "colIdeBoton",
                HeaderText = "->",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colIdentificacion",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colIdeBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colPersona = new DataGridViewTextBoxColumn()
            {
                Name = "colPersona",
                HeaderText = "Cliente",
                DataPropertyName = "fkpersona",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            };
            colPersona.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn()
            {
                Name = "colDescripcion",
                HeaderText = "Descripcion",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colDescripcion.MaxInputLength = 40;

            DataGridViewCheckBoxColumn colAdministrador = new DataGridViewCheckBoxColumn()
            {
                Name = "colAdministrador",
                HeaderText = "Administrador",
                DataPropertyName = "Administrador",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewIntegerInputColumn colDiasVigencia = new DataGridViewIntegerInputColumn()
            {
                Name = "colDiasVigencia",
                HeaderText = "VigenciaClave",
                DataPropertyName = "DiasVigencia",
                MinValue = 0,
                MaxValue = 360,
                MaxInputLength = 2,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                ToolTipText = "Dias de vigencia de la clave"
            };
            colDiasVigencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDiasVigencia.ShowUpDown = true;

            DataGridViewDateTimeInputColumn colFechaCambioChr = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaCambioChr",
                HeaderText = "Modificado",
                DataPropertyName = "FechaCambioChr",
                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd",
                MinDate = new DateTime(1920, 02, 01),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colLoginUsuario = new DataGridViewTextBoxColumn()
            {
                Name = "colLoginUsuario",
                HeaderText = "Login",
                DataPropertyName = "loginusuario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "Activo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewCheckBoxColumn colReseteaClave = new DataGridViewCheckBoxColumn()
            {
                Name = "colReseteaClave",
                HeaderText = "Resetea clave",
                DataPropertyName = "ReseteaClave",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewDateTimeInputColumn colFechaCreacionChr = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaCreacionChr",
                HeaderText = "Creado",
                DataPropertyName = "FechaCreacionChr",
                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd",
                MinDate = new DateTime(1901, 02, 01),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colIdUsuario,
                //colIdentificacion,
                colIdentificacion,
                colIdeBoton,
                colPersona,
                colDescripcion,
                colLoginUsuario,
                colDiasVigencia,
                colAdministrador,
                colActivo,
                colFechaCreacionChr,
                colFechaCambioChr,
                colReseteaClave,
                colModificado
            };
            return listaColumnas;
        }

        void colIdentificacion_ButtonDropDownClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)sender;
            campo.DataGridView.BeginEdit(false);
            if (!campo.DataGridView.IsCurrentCellDirty)
                campo.DataGridView.NotifyCurrentCellDirty(true);
            object objeto = BuscarListaPr.BuscarPersona();
            if (objeto != null)
            {
                campo.DataGridView.NotifyCurrentCellDirty(false);
                campo.DataGridView.CurrentRow.Cells["colPersona"].Value = (persona)objeto;
                campo.DataGridView.EndEdit();
            }
        }

        void colIdentificacion_ButtonCustomClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)sender;
            object objeto = BuscarListaPr.BuscarPersona();
            if (objeto != null)
            {
                campo.DataGridView.BeginEdit(true);
                campo.DataGridView.CurrentRow.Cells["colPersona"].Value = (persona)objeto;
                campo.DataGridView.EndEdit();
            }
        }


        #endregion ARMAR GRID
    }

}
