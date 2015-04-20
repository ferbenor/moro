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
    public class UnidadMedidaPr
    {
        #region VARIABLES
        private static UnidadMedidaPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static UnidadMedidaPr Instancia { get { if (instancia == null) instancia = new UnidadMedidaPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public UnidadMedidaPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public unidaddemedida RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<unidaddemedida> Registros(string expresion = null, params object[] parametros)
        {
            List<unidaddemedida> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.unidadesdemedidas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION
        public int Grabar(unidaddemedida item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<unidaddemedida> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(unidaddemedida item)
        {
            return item.BorrarObjetoT();
        }
        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID

        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<unidaddemedida>.ToBindingList(this.Registros("order by id"));
        }
        
        #endregion ARMAR GRID
    }
}
