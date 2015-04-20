using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using LinqToDB;
using LinqToDB.Data;
using System.Linq.Dynamic;
using CollectionLoaders;

namespace Proveedores
{
    public class CuentaContablePr : InstrumentalPr
    {

        #region VARIABLES
        private static CuentaContablePr instancia = null;
        List<cuentacontable> listaPadres;
        #endregion VARIABLES

        #region PROPIEDADES
        public static CuentaContablePr Instancia { get { if (instancia == null) instancia = new CuentaContablePr(); return instancia; } set { instancia = value; } }

        public List<cuentacontable> ListaPadres
        {
            get { if (this.listaPadres == null) this.listaPadres = Registros(); return listaPadres; }
            set { listaPadres = value; }
        }
        #endregion PROPIEDADES

        public CuentaContablePr()
        { }

        #region FUNCIONES REGISTRO
        public List<cuentacontable> RegistrosAuxGrupo()
        {
            return Registros("esgrupo == true ");
        }

        public cuentacontable RegistroPorId(int unId)
        {
            return Registros("id == @0 ", unId).SingleOrDefault();
        }

        public cuentacontable RegistroPorCodigo(string unCodigo)
        {
            return Registros("codigo == @0 && esgrupo == @1", unCodigo, false).SingleOrDefault();
        }

        public List<cuentacontable> RegistrosPeriodo(int unPeriodo)
        {
            return Registros("periodo == @0", unPeriodo);
        }

        public List<cuentacontable> Registros(string expresion = null, params object[] parametros)
        {
            List<cuentacontable> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaPadres = db.cuentascontables.Where(x => x.esgrupo == true).ToList();
                this.ListaPadres =
                    (from p in db.cuentascontables
                     from c in db.cuentascontables.Where(x => x.idpadre == p.id)
                     select p).ToList();

                registros = db.cuentascontables.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.codigo).ToList();
            }

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }

            return registros;
        }

        private cuentacontable CargarRelaciones(cuentacontable unObjeto)
        {
            int ix;
            ix = ListaPadres.FindIndex(x => x.id == unObjeto.idpadre);
            if (ix > -1)
            {
                unObjeto.Padre = listaPadres[ix];
                unObjeto.codigopadre = ListaPadres[ix].codigo;
            }

            return unObjeto;
        }

        private void CargarListas()
        {
            this.ListaPadres = Registros("esgrupo == true");
        }
        #endregion FUNCIONES REGISTRO

        #region FUNCIONES DE GESTION

        public int Grabar(cuentacontable item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<cuentacontable> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(cuentacontable item)
        {
            return item.BorrarObjetoT();
        }
        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
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
                objetoGrid.Columns["colPadreBoton"].Visible = !objetoGrid.ReadOnly;
            }

            //CARGA DE LISTAS

            objetoGrid.CancelEdit();
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<cuentacontable>.ToBindingList(this.RegistrosPeriodo(General.periodoActual));
            objetoGrid.Tag = "0";


        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 && e.RowIndex > -1)
                {
                    DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[4].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    campo.DataGridView.BeginEdit(false);
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarCuenta();
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.CurrentRow.Cells["colPadre"].Value = (cuentacontable)objeto;
                        campo.DataGridView.EndEdit();
                        campo.DataGridView.InvalidateCell(campo.DataGridView.CurrentRow.Cells[3]);
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
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 3 || ((DataGridView)sender).CurrentCell.ColumnIndex == 4)
                {
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(4, ((DataGridView)sender).CurrentCell.RowIndex));
                }
        }

        void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
            {
                if (grid.CurrentCell.ColumnIndex == 3)
                {
                    cuentacontable objeto = null;
                    objeto = RegistroPorCodigo(grid.EditingControl.Text);
                    if (objeto == null)
                        grid.CurrentRow.Cells["colPadre"].Value = null;
                    else
                        grid.CurrentRow.Cells["colPadre"].Value = objeto;
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
            //DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            //{
            //    Name = "colId",
            //    HeaderText = "Id",
            //    DataPropertyName = "Id",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //};
            //colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn()
            {
                Name = "colCodigo",
                HeaderText = "Código.",
                DataPropertyName = "codigo",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colPeriodo = new DataGridViewTextBoxColumn()
            {
                Name = "colPeriodo",
                HeaderText = "Periodo.",
                DataPropertyName = "periodo",
                MaxInputLength = 20,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPeriodo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombre.",
                DataPropertyName = "nombre",
                MaxInputLength = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };


            DataGridViewCheckBoxColumn colEsGrupo = new DataGridViewCheckBoxColumn()
            {
                Name = "colEsGrupo",
                HeaderText = "Grupo",
                DataPropertyName = "esgrupo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            //DataGridViewTextBoxColumn colDebitoInicial = new DataGridViewTextBoxColumn()
            //{
            //    Name = "colDebitoInicial",
            //    HeaderText = "DebitoInicial",
            //    DataPropertyName = "DebitoInicial",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //};
            //colDebitoInicial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //DataGridViewTextBoxColumn colCreditoInicial = new DataGridViewTextBoxColumn()
            //{
            //    Name = "colCreditoInicial",
            //    HeaderText = "CreditoInicial",
            //    DataPropertyName = "CreditoInicial",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //};
            //colCreditoInicial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewDateTimeInputColumn colFechaApertura = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaApertura",
                HeaderText = "Aperturada",
                DataPropertyName = "fechaapertura",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm:ss",
                MinDate = new DateTime(1901, 02, 01),
            };
            colFechaApertura.ButtonDropDown.Visible = true;
            colFechaApertura.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            colFechaApertura.AutoAdvance = true;
            colFechaApertura.MonthCalendar.TodayButtonVisible = true;

            DataGridViewTextBoxColumn colCodigoPadre = new DataGridViewTextBoxColumn()
            {
                Name = "colCodigoPadre",
                HeaderText = "CódigoPadre",
                DataPropertyName = "codigopadre",
                MaxInputLength = 20,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colEsGrupo",

            };

            DataGridViewButtonXColumn colPadreBoton = new DataGridViewButtonXColumn()
            {
                Name = "colPadreBoton",
                HeaderText = "->",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colCodigoPadre",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colPadreBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colPadre = new DataGridViewTextBoxColumn()
            {
                Name = "colPadre",
                HeaderText = "CuentaPadre",
                DataPropertyName = "Padre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            //colPadre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colPadre.ReadOnly = true;

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                //colId,
                colCodigo,
                colNombre,
                colPeriodo,
                colCodigoPadre,
                colPadreBoton,
                colPadre,
                colEsGrupo,
                //colDebitoInicial,
                //colCreditoInicial,
                colFechaApertura,
                colModificado
            };
            return listaColumnas;
        }

        private object BuscarCuenta()
        {
            return BuscarListaPr.Buscar("CuentasGrupo", "cuentascontables", "esgrupo = 't' and periodo = " + General.periodoActual + " and (codigo like @nombre or upper(nombre) like @nombre )", "id as \"ID\", codigo as \"Codigo\", nombre as \"Nombre\"");
        }
        #endregion ARMAR GRID
    }
}
