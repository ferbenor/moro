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
    public class ParametroGeneralPr : InstrumentalPr
    {

        #region VARIABLES
        private static ParametroGeneralPr instancia;

        ColeccionParametros parametrosGenerales;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ParametroGeneralPr Instancia { get { if (instancia == null) instancia = new ParametroGeneralPr(); return instancia; } set { instancia = value; } }

        public ColeccionParametros ParametrosGenerales
        {
            get { if (this.parametrosGenerales == null) this.parametrosGenerales = new ColeccionParametros(Registros()); return this.parametrosGenerales; }
            set { this.parametrosGenerales = value; }
        }
        #endregion PROPIEDADES

        public ParametroGeneralPr()
        { }


        #region CARGAS DE REGISTROS
        public parametrogeneral RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<parametrogeneral> Registros(string expresion = null, params object[] parametros)
        {
            List<parametrogeneral> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.parametrosgenerales.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.nombre).ToList();
            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(parametrogeneral item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<parametrogeneral> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(parametrogeneral item)
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
                /*if (!objetoGrid.ReadOnly)
                { }*/
            }
            //CARGA DE LISTAS
            objetoGrid.CancelEdit();
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

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombre.",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colValorString = new DataGridViewTextBoxColumn()
            {
                Name = "colValorString",
                HeaderText = "Valor.",
                DataPropertyName = "ValorString",
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
                colValorString,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID

    }
}
