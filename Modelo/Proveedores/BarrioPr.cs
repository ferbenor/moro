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
    public class BarrioPr
    {
        #region VARIABLES
        
        private static BarrioPr instancia = null;

        #endregion VARIABLES

        #region PROPIEDADES
        public static BarrioPr Instancia { get { if (instancia == null) instancia = new BarrioPr(); return instancia; } set { instancia = value; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public BarrioPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public barrio RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<barrio> Registros(string expresion = null, params object[] parametros)
        {
            List<barrio> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.barrios.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).Select(x=> x.Relacionar(x.fkparroquia.Relacionar(x.fkparroquia.fkcantone.Relacionar(x.fkparroquia.fkcantone.fkprovincia)))).ToList();
            }
            
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(barrio item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<barrio> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(barrio item)
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
                    objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
                    objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
                    objetoGrid.ForeColor = System.Drawing.Color.Black;
                    objetoGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
                objetoGrid.Columns["colParroquiaBoton"].Visible = !objetoGrid.ReadOnly;
            }
            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    DataGridViewColumn campo = (DataGridViewColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.BuscarParroquia();
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.BeginEdit(false);
                        campo.DataGridView.CurrentRow.Cells["colParroquia"].Value = ParroquiaPr.Instancia.RegistroPorId((int)objeto);
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
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 2)
                {
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(3, ((DataGridView)sender).CurrentCell.RowIndex));
                }
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 60
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Barrio.",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };


            DataGridViewTextBoxColumn colParroquia = new DataGridViewTextBoxColumn()
            {
                Name = "colParroquia",
                HeaderText = "Parroquia",
                DataPropertyName = "fkparroquia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewButtonXColumn colParroquiaBoton = new DataGridViewButtonXColumn()
            {
                Name = "colParroquiaBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colParroquia",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colParroquiaBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "activo",
                SortMode = DataGridViewColumnSortMode.Automatic,
                Width = 60
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
                colNombre,
                colParroquia,
                colParroquiaBoton,
                colActivo,
                colModificado
             };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
