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
    public class EstadoPersonaPr
    {
        #region VARIABLES
        private static EstadoPersonaPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static EstadoPersonaPr Instancia { get { if (instancia == null) instancia = new EstadoPersonaPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public EstadoPersonaPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public estadopersona RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<estadopersona> Registros(string expresion = null, params object[] parametros)
        {
            List<estadopersona> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.estadospersonas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(estadopersona item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<estadopersona> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(estadopersona item)
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
            //objetoGrid.DataSource = SoporteList<estadopersona>.ToBindingList(this.Registros("order by id"));

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
                HeaderText = "Estado.",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colAbreviatura = new DataGridViewTextBoxColumn()
            {
                Name = "colAbreviatura",
                HeaderText = "Abreviatura.",
                DataPropertyName = "Abreviatura",
                MaxInputLength = 1,
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
                colAbreviatura,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
