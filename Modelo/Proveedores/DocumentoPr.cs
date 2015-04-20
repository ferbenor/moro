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
    public class DocumentoPr
    {
        #region VARIABLES
        private static DocumentoPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static DocumentoPr Instancia { get { if (instancia == null) instancia = new DocumentoPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public DocumentoPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public documento RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<documento> Registros(string expresion = null, params object[] parametros)
        {
            List<documento> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.documentos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(documento item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<documento> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(documento item)
        {
            return item.BorrarObjetoT();
        }

        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
                objetoGrid.Columns.AddRange(ColumnasGrid());
            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<documento>.ToBindingList(this.Registros("order by id"));
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
                Name = "colNombre",
                HeaderText = "Descripción.",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colContenido = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Contenido.",
                DataPropertyName = "Contenido",
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
                colDescripcion,
                colContenido,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
