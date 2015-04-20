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
    public class EstadoFacturaPr
    {
        #region VARIABLES
        private static EstadoFacturaPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static EstadoFacturaPr Instancia { get { if (instancia == null) instancia = new EstadoFacturaPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public EstadoFacturaPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public estadosfactura RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<estadosfactura> Registros(string expresion = null, params object[] parametros)
        {
            List<estadosfactura> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.estadosfacturas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.id).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(estadosfactura item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<estadosfactura> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(estadosfactura item)
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
