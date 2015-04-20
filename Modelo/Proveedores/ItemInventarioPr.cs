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

namespace Proveedores
{
    public class ItemInventarioPr : InstrumentalPr
    {
        public List<Enumerado> tipoEnum = new List<Enumerado>() { new Enumerado("M", "MATERIALES"), new Enumerado("S", "SERVICIOS") };

        #region VARIABLES
        private static ItemInventarioPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ItemInventarioPr Instancia { get { if (instancia == null) instancia = new ItemInventarioPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        public ItemInventarioPr()
        { }

        #region CARGAS DE REGISTROS
        public iteminventario Registro(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<iteminventario> Registros(string expresion = null, params object[] parametros)
        {
            List<iteminventario> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.itemsinventarios.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.descripcion).ToList();
            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(iteminventario item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<iteminventario> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(iteminventario item)
        {
            return item.BorrarObjetoT();
        }
        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
                objetoGrid.Columns.AddRange(ColumnasGrid());

            objetoGrid.CancelEdit();
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colTipo"]).DataSource = tipoEnum;

            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            objetoGrid.Tag = "0";
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewComboBoxExColumn colTipo = new DataGridViewComboBoxExColumn()
            {
                Name = "colTipo",
                HeaderText = "Tipo.",
                DataPropertyName = "Tipo",
                ValueMember = "IdChr",
                DisplayMember = "Texto",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewCheckBoxColumn colGrabaIva = new DataGridViewCheckBoxColumn()
            {
                Name = "colGrabaIva",
                HeaderText = "Graba Iva",
                DataPropertyName = "GrabaIva",
                Width = 50
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
                colTipo,
                colDescripcion,
                colPrecio,
                colGrabaIva,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
