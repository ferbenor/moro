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
    public class EmpresaPr
    {
        #region VARIABLES

        private static EmpresaPr instancia = null;

        #endregion VARIABLES

        #region PROPIEDADES

        public static EmpresaPr Instancia { get { if (instancia == null) instancia = new EmpresaPr(); return instancia; } set { instancia = value; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public EmpresaPr() { }

        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS

        public empresa RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<empresa> Registros(string expresion = null, params object[] parametros)
        {
            List<empresa> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.empresas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.nombre).Select(x =>
                x.Relacionar(x.fkpersonascontador, x.fkpersonasgerente)).ToList();
            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(empresa item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<empresa> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(empresa item)
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
            objetoGrid.Columns["colGerenteBoton"].Visible = !objetoGrid.ReadOnly;
            objetoGrid.Columns["colContadorBoton"].Visible = !objetoGrid.ReadOnly;
            //CARGA DE LISTAS
            this.Registros().CargarGrid(objetoGrid);
        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 6 || e.ColumnIndex == 8) && e.RowIndex > -1)
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
                if (columna == 5 || columna == 6 || columna == 7 || columna == 8)
                {
                    switch (columna)
                    {
                        case 5:
                            columna = 6;
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
                HeaderText = "Id.",
                DataPropertyName = "Id",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombre.",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colIdentificacion = new DataGridViewTextBoxColumn()
            {
                Name = "colIdentificacion",
                HeaderText = "Identificacion.",
                DataPropertyName = "Identificacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colRazonSocial = new DataGridViewTextBoxColumn()
            {
                Name = "colRazonSocial",
                HeaderText = "RazonSocial.",
                DataPropertyName = "RazonSocial",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colNombreComercial = new DataGridViewTextBoxColumn()
            {
                Name = "colNombreComercial",
                HeaderText = "NombreComercial.",
                DataPropertyName = "NombreComercial",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewButtonXColumn colGerenteBoton = new DataGridViewButtonXColumn()
            {
                Name = "colGerenteBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colGerente",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colGerenteBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colGerente = new DataGridViewTextBoxColumn()
            {
                Name = "colGerente",
                HeaderText = "Gerente.",
                DataPropertyName = "fkpersonasgerente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewButtonXColumn colContadorBoton = new DataGridViewButtonXColumn()
            {
                Name = "colContadorBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colContador",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colContadorBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colContador = new DataGridViewTextBoxColumn()
            {
                Name = "colContador",
                HeaderText = "Contador",
                DataPropertyName = "fkpersonascontador",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colObligadoContabilidad = new DataGridViewCheckBoxColumn()
            {
                Name = "colObligadoContabilidad",
                HeaderText = "ObligadoContabilidad",
                DataPropertyName = "obligadocontabilidad",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colContribuyenteEspecial = new DataGridViewTextBoxColumn()
            {
                Name = "colContribuyenteEspecial",
                HeaderText = "ContribuyenteEspecial",
                DataPropertyName = "ContribuyenteEspecial",
                MaxInputLength = 5,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "activo",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            //DataGridViewImageColumn colLogo = new DataGridViewImageColumn()
            //{
            //    Name = "colLogo",
            //    HeaderText = "Logo",
            //    DataPropertyName = "logo",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //};

            //DataGridViewButtonXColumn colImagenBoton = new DataGridViewButtonXColumn()
            //{
            //    Name = "colImagenBoton",
            //    HeaderText = "<-",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            //    Tag = "colLogo",
            //    Image = General.Imagenes.Images["Listar.ico"],
            //    ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            //};
            //colImagenBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

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
                colNombre,
                colIdentificacion,
                colRazonSocial,
                colNombreComercial,
                colGerente,
                colGerenteBoton,
                colContador,
                colContadorBoton,
                colObligadoContabilidad,
                colContribuyenteEspecial,
                colActivo,
                //colLogo,
                //colImagenBoton,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
