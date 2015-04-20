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
    public class EstadoOrdenPedidoPr
    {
        #region VARIABLES
        private static EstadoOrdenPedidoPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static EstadoOrdenPedidoPr Instancia { get { if (instancia == null) instancia = new EstadoOrdenPedidoPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public EstadoOrdenPedidoPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public estadoordenpedido RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<estadoordenpedido> Registros(string expresion = null, params object[] parametros)
        {
            List<estadoordenpedido> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.estadosordenespedidos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.id).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(estadoordenpedido item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<estadoordenpedido> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(estadoordenpedido item)
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
            //objetoGrid.DataSource = SoporteList<estadoordenpedido>.ToBindingList(this.Registros());
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn()
            {
                Name = "colDescripcion",
                HeaderText = "Estado.",
                DataPropertyName = "descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo.",
                DataPropertyName = "activo",
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
                colActivo,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
