using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;

using ModeloDB;
using LinqToDB;
using System.Linq.Dynamic;

namespace Proveedores
{
    public class SucursalPr
    {
        #region VARIABLES

        private static SucursalPr instancia = null;
        private List<empresa> lsEmpresa;
        public List<operadoratelefonia> lsOperadoras;
        #endregion VARIABLES

        #region PROPIEDADES

        public static SucursalPr Instancia { get { if (instancia == null) instancia = new SucursalPr(); return instancia; } set { instancia = value; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public SucursalPr() { }

        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS

        public sucursal RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<sucursal> Registros(string expresion = null, params object[] parametros)
        {
            List<sucursal> registros = null;
            using (ispDB db = new ispDB())
            {
                this.lsEmpresa = db.empresas.OrderBy(x => x.nombre).ToList();
                this.lsOperadoras = db.operadorastelefonias.OrderBy(x => x.nombre).ToList();

                //registros = db.oficinas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.nombre).Select(x =>
                //x.Relacionar(x.fkbarrio).Relacionar(x.fkpersona)).ToList();

                registros = db.sucursales.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                     .GroupJoin(
                        db.telefonossucursales.DefaultIfEmpty(), x => x.id, y => y.idsucursal, (x, y) => x.Relacionar(y.ToList()).Relacionar(x.fkbarrio).Relacionar(x.fkpersona)).ToList();

                //RELACIONAMOS EMPRESAS Y OPERADORAS TELEFONICAS
                registros = registros.Join(this.lsEmpresa, x => x.idempresa, y => y.id, (x, y) => x.Relacionar(y)).ToList();

                for (int i = 0; i < registros.Count; i++)
                {
                    sucursal item = registros[i];
                    item.fktelefonossucursal = item.fktelefonossucursal.Join(this.lsOperadoras, x => x.idoperadoratelefonia, y => y.id, (x, y) => x.Relacionar(y)).ToList();
                }

            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(sucursal item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<sucursal> items)
        {
            int i = 0; int n = 0;
            items = items.Where(x => x.Modificado == true).ToList();
            if (items.Count() == 0)
                return 0;
            using (ispDB db = new ispDB())
            {
                try
                {

                    db.BeginTransaction();
                    n = db.sucursales.Max(x => (int?)x.id) ?? 1;
                    foreach (var item in items)
                    {
                        if (item.id == 0)
                            item.id = ++n;
                        i = db.InsertOrReplace(item);
                        db.telefonossucursales.Where(x => x.idsucursal == item.id).Delete();
                        foreach (var item1 in item.fktelefonossucursal)
                        {
                            if (item1.idsucursal == 0)
                                item1.idsucursal = item.id;
                            db.Insert(item1);
                        }
                    }
                    db.CommitTransaction();

                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            if (i == 0)
                throw new Exception("Error de concurrencia, por favor vuelva a realizar la transaccion.");
            return i;
        }

        public int Borrar(sucursal item)
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
                objetoGrid.CellValidating += new DataGridViewCellValidatingEventHandler(objetoGrid_CellValidating);
                objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
                objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
                objetoGrid.ForeColor = System.Drawing.Color.Black;
                objetoGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            }
            objetoGrid.Columns["colBarrioBoton"].Visible = !objetoGrid.ReadOnly;
            objetoGrid.Columns["colEncargadoBoton"].Visible = !objetoGrid.ReadOnly;
            //CARGA DE LISTAS
            this.Registros().CargarGrid(objetoGrid);
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colEmpresa"]).DataSource = this.lsEmpresa;
        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 5 || e.ColumnIndex == 8) && e.RowIndex > -1)
                {
                    DataGridViewColumn campo = ((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()] as DataGridViewTextBoxColumn;
                    if (campo == null)
                        campo = ((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()] as DataGridViewImageColumn;

                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);

                    object objeto = null;

                    if (e.ColumnIndex == 5)
                    {
                        objeto = BuscarListaPr.BuscarBarrio();
                        if (objeto != null)
                            objeto = BarrioPr.Instancia.RegistroPorId((int)objeto);
                    }
                    else if (e.ColumnIndex == 8)
                        objeto = BuscarListaPr.BuscarPersona();

                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.BeginEdit(false);
                        campo.DataGridView.CurrentRow.Cells[campo.Name].Value = objeto;
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
            {
                int columna = ((DataGridView)sender).CurrentCell.ColumnIndex;
                if (columna == 4 || columna == 5 || columna == 7 || columna == 8)
                {
                    switch (columna)
                    {
                        case 4:
                            columna = 5;
                            break;
                        case 7:
                            columna = 8;
                            break;
                    }
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(columna, ((DataGridView)sender).CurrentCell.RowIndex));
                }
            }
        }

        void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
            {
                if (grid.CurrentCell.ColumnIndex == 0)
                {
                    producto objeto = null;
                    objeto = ProductoPr.Instancia.RegistroPorCodigo(grid.EditingControl.Text);
                    if (objeto == null)
                        grid.CurrentRow.Cells["colGerente"].Value = null;
                    else
                        grid.CurrentRow.Cells["colGerente"].Value = objeto;
                    if (objeto == null)
                    {
                        General.Mensaje(General.itemNoEncontrado);
                        e.Cancel = true;
                    }
                }
            }
            grid.InvalidateRow(grid.CurrentRow.Index);
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewComboBoxExColumn colEmpresa = new DataGridViewComboBoxExColumn()
            {
                Name = "colEmpresa",
                HeaderText = "Empresa",
                DataPropertyName = "fkempresa",
                ValueMember = "Objeto",
                DisplayMember = "nombre",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombre.",
                DataPropertyName = "Nombre",
                MaxInputLength = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colCodigoEstablecimiento = new DataGridViewTextBoxColumn()
            {
                Name = "colCodigoEstablecimiento",
                HeaderText = "CodigoEstablecimiento.",
                DataPropertyName = "CodigoEstablecimiento",
                MaxInputLength = 3,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colCodigoEstablecimiento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colBarrio = new DataGridViewTextBoxColumn()
            {
                Name = "colBarrio",
                HeaderText = "Barrio.",
                DataPropertyName = "fkbarrio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colBarrio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewButtonXColumn colBarrioBoton = new DataGridViewButtonXColumn()
            {
                Name = "colBarrioBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colBarrio",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colBarrioBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn()
            {
                Name = "colDireccion",
                HeaderText = "Direccion.",
                DataPropertyName = "Direccion",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colEncargado = new DataGridViewTextBoxColumn()
            {
                Name = "colEncargado",
                HeaderText = "Encargado.",
                DataPropertyName = "fkpersona",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewButtonXColumn colEncargadoBoton = new DataGridViewButtonXColumn()
            {
                Name = "colEncargadoBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colEncargado",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colEncargadoBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));


            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn()
            {
                Name = "colCorreo",
                HeaderText = "Correo",
                DataPropertyName = "Correo",
                MaxInputLength = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn()
            {
                Name = "colTelefono",
                HeaderText = "Telefono",
                DataPropertyName = "telefono",
                MaxInputLength = 13,
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
                colId,
                colEmpresa,
                colNombre,
                colCodigoEstablecimiento,
                colBarrio,
                colBarrioBoton,
                colDireccion,
                colEncargado,
                colEncargadoBoton,
                colCorreo,
                colTelefono,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
