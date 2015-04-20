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
    public class ProvinciaPr
    {
        #region VARIABLES
        private static ProvinciaPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ProvinciaPr Instancia { get { if (instancia == null) instancia = new ProvinciaPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ProvinciaPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public provincia RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<provincia> Registros(string expresion = null, params object[] parametros)
        {
            List<provincia> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.provincias.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(provincia item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<provincia> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(provincia item)
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
            }

            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<provincia>.ToBindingList(this.Registros());
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

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Provincia.",
                DataPropertyName = "Nombre",
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
                colNombre,
                colModificado
             };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
