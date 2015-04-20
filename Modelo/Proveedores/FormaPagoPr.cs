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
    public class FormaPagoPr
    {
        #region VARIABLES
        private static FormaPagoPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static FormaPagoPr Instancia { get { if (instancia == null) instancia = new FormaPagoPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public FormaPagoPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        
        public formapago RegistroPorId(string unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<formapago> RegistrosActivos()
        {
            return this.Registros("activo == @0", true);
        }

        public List<formapago> Registros(string expresion = null, params object[] parametros)
        {
            List<formapago> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.formaspagos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(formapago item)
        {
            return item.GrabarObjetoT<formapago, string>(null);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<formapago> items)
        {
            int i;
            i = items.GrabarListaT<formapago, string>(null);
            if (i == 0)
                throw new Exception("Error de concurrencia, por favor vuelva a realizar la transaccion.");
            return i;
        }

        public int Borrar(formapago item)
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
            objetoGrid.CancelEdit();
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<formapago>.ToBindingList(this.Registros());
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
                HeaderText = "Descripcion.",
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
