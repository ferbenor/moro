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
    public class TipoContablePr
    {
        #region VARIABLES
        private static TipoContablePr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static TipoContablePr Instancia { get { if (instancia == null) instancia = new TipoContablePr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public TipoContablePr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public tipocontable RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<tipocontable> Registros(string expresion = null, params object[] parametros)
        {
            List<tipocontable> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.tiposcontables.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION
        public int Grabar(tipocontable item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<tipocontable> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(tipocontable item)
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
            //objetoGrid.DataSource = SoporteList<tipocontable>.ToBindingList(this.Registros());
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
                HeaderText = "Tipo.",
                DataPropertyName = "Descripcion",
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
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
