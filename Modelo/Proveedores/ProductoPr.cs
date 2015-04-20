using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;

using ModeloDB;
using LinqToDB;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace Proveedores
{
    public class ProductoPr
    {
        #region VARIABLES
        private static ProductoPr instancia = null;
        private List<unidaddemedida> listaUnidadMedida;
        private List<marca> listaMarca;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ProductoPr Instancia { get { if (instancia == null) instancia = new ProductoPr(); return instancia; } set { instancia = value; } }
        public List<unidaddemedida> ListaUnidadMedida
        {
            get { if (this.listaUnidadMedida == null) this.listaUnidadMedida = UnidadMedidaPr.Instancia.Registros(); return listaUnidadMedida; }
            set { listaUnidadMedida = value; }
        }
        public List<marca> ListaMarca
        {
            get { if (this.listaMarca == null) this.listaMarca = MarcaPr.Instancia.Registros(); return listaMarca; }
            set { listaMarca = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ProductoPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public producto RegistroPorCodigo(string unCodigo)
        {
            return this.Registros("codigo == @0", unCodigo).SingleOrDefault();
        }
        public List<producto> Registros(string expresion = null, params object[] parametros)
        {
            List<producto> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaUnidadMedida = db.unidadesdemedidas.Where(x => x.activo == true).ToList();
                registros = db.productos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).Select(x => x.Relacionar(x.fkmarca)).ToList();
            }
            for (int ix = 0; ix < registros.Count; ix++)
            {
                producto item = registros[ix];
                item = CargarRelaciones(item);
            }
            return registros;
        }
        private producto CargarRelaciones(producto unObjeto)
        {
            int ix;
            ix = ListaUnidadMedida.FindIndex(x => x.id == unObjeto.idunidaddemedida);
            if (ix > -1)
                unObjeto.fkunidadesdemedida = ListaUnidadMedida[ix];
            return unObjeto;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION
        public int Grabar(producto item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<producto> items)
        {
            return items.GrabarListaT(x => x.id);
        }
        public int Borrar(producto item)
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
                objetoGrid.Columns["colMarcaBoton"].Visible = !objetoGrid.ReadOnly;
            }
            //CARGA DE LISTAS
            objetoGrid.CancelEdit();
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colIdUnidadDeMedida"]).DataSource = ListaUnidadMedida;
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<cuentacontable>.ToBindingList(this.RegistrosPeriodo(General.periodoActual));
            objetoGrid.Tag = "0";
        }
        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[2].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    campo.DataGridView.BeginEdit(false);
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.Buscar("Marcas", "marcas", "activo = 't'", "id as \"ID\", descripcion as \"Descripcion\"");
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.CurrentRow.Cells["colMarca"].Value = (marca)objeto;
                        campo.DataGridView.EndEdit();
                        campo.DataGridView.InvalidateCell(campo.DataGridView.CurrentRow.Cells[2]);
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
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(2, ((DataGridView)sender).CurrentCell.RowIndex));
        }
        void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
            {
                if (grid.CurrentCell.ColumnIndex == 2)
                {
                    producto objeto = null;
                    objeto = RegistroPorCodigo(grid.EditingControl.Text);
                    if (objeto == null)
                        grid.CurrentRow.Cells["colMarca"].Value = null;
                    else
                        grid.CurrentRow.Cells["colMarca"].Value = objeto;
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
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn()
            {
                Name = "colDescripcion",
                HeaderText = "Descripción.",
                DataPropertyName = "Descripcion",
                MaxInputLength = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewComboBoxExColumn colIdUnidadDeMedida = new DataGridViewComboBoxExColumn()
            {
                Name = "colIdUnidadDeMedida",
                HeaderText = "Medida.",
                DataPropertyName = "fkunidadesdemedida",
                ValueMember = "Objeto",
                DisplayMember = "descripcion",
                FlatStyle = FlatStyle.Flat,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewButtonXColumn colMarcaBoton = new DataGridViewButtonXColumn()
            {
                Name = "colMarcaBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colMarca",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colMarcaBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colMarca = new DataGridViewTextBoxColumn()
            {
                Name = "colMarca",
                HeaderText = "Marca",
                DataPropertyName = "fkmarca",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colMarca.ReadOnly = true;

            DataGridViewTextBoxColumn colUtilidadPrecio1 = new DataGridViewTextBoxColumn()
            {
                Name = "colUtilidadPrecio1",
                HeaderText = "Utilidad 01",
                DataPropertyName = "UtilidadPrecio1",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colUtilidadPrecio1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colPrecio1 = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio1",
                HeaderText = "Precio 01",
                DataPropertyName = "Precio1",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colUtilidadPrecio2 = new DataGridViewTextBoxColumn()
            {
                Name = "colUtilidadPrecio2",
                HeaderText = "Utilidad 02",
                DataPropertyName = "UtilidadPrecio2",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colUtilidadPrecio2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colPrecio2 = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio2",
                HeaderText = "Precio 02",
                DataPropertyName = "Precio2",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colUtilidadPrecio3 = new DataGridViewTextBoxColumn()
            {
                Name = "colUtilidadPrecio3",
                HeaderText = "Utilidad 03",
                DataPropertyName = "UtilidadPrecio3",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colUtilidadPrecio3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colPrecio3 = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio3",
                HeaderText = "Precio 03",
                DataPropertyName = "Precio3",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colUtilidadPrecio4 = new DataGridViewTextBoxColumn()
            {
                Name = "colUtilidadPrecio4",
                HeaderText = "Utilidad 04",
                DataPropertyName = "UtilidadPrecio4",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colUtilidadPrecio4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colPrecio4 = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio4",
                HeaderText = "Precio 04",
                DataPropertyName = "Precio4",
                MaxInputLength = 10,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colUltimoCosto = new DataGridViewTextBoxColumn()
            {
                Name = "colUltimoCosto",
                HeaderText = "UltimoCosto",
                DataPropertyName = "UltimoCosto",
                MaxInputLength = 8,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colUltimoCosto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewCheckBoxColumn colCheque = new DataGridViewCheckBoxColumn()
            {
                Name = "colCheque",
                HeaderText = "Cheque",
                DataPropertyName = "Cheque",
            };

            DataGridViewCheckBoxColumn colMonedero = new DataGridViewCheckBoxColumn()
            {
                Name = "colMonedero",
                HeaderText = "Monedero",
                DataPropertyName = "Monedero",
            };

            DataGridViewCheckBoxColumn colCorriente = new DataGridViewCheckBoxColumn()
            {
                Name = "colCorriente",
                HeaderText = "Corriente",
                DataPropertyName = "Corriente",
            };

            DataGridViewCheckBoxColumn colDiferido = new DataGridViewCheckBoxColumn()
            {
                Name = "colDiferido",
                HeaderText = "Diferido",
                DataPropertyName = "Diferido",
            };

            DataGridViewCheckBoxColumn colCreditoEmpresarial = new DataGridViewCheckBoxColumn()
            {
                Name = "colCreditoEmpresarial",
                HeaderText = "Empresarial",
                DataPropertyName = "CreditoEmpresarial",
            };

            DataGridViewCheckBoxColumn colCreditoPersonal = new DataGridViewCheckBoxColumn()
            {
                Name = "colCreditoPersonal",
                HeaderText = "Personal",
                DataPropertyName = "CreditoPersonal",
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
                colMarca,
                colMarcaBoton,
                colDescripcion,
                colIdUnidadDeMedida,
                colUtilidadPrecio1,
                colPrecio1,
                colUtilidadPrecio2,
                colPrecio2,
                colUtilidadPrecio3,
                colPrecio3,
                colUtilidadPrecio4,
                colPrecio4,
                colUltimoCosto,
                colCheque,
                colMonedero,
                colCorriente,
                colDiferido,
                colCreditoEmpresarial,
                colCreditoPersonal,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}