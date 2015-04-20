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
    public class CantonPr
    {
        #region VARIABLES
        private static CantonPr instancia = null;
        private List<provincia> listaProvincia;
        #endregion VARIABLES

        #region PROPIEDADES
        public static CantonPr Instancia { get { if (instancia == null) instancia = new CantonPr(); return instancia; } set { instancia = value; } }

        public List<provincia> ListaProvincia
        {
            get { if (this.listaProvincia == null) this.listaProvincia = ProvinciaPr.Instancia.Registros(); return listaProvincia; }
            set { listaProvincia = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public CantonPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public canton RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<canton> Registros(string expresion = null, params object[] parametros)
        {
            List<canton> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaProvincia = db.provincias.ToList();
                registros = db.cantones.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }

            for (int ix = 0; ix < registros.Count; ix++)
            {
                canton item = registros[ix];
                item = CargarRelaciones(item);
            }
            return registros;
        }
        private canton CargarRelaciones(canton unObjeto)
        {
            int ix;
            ix = ListaProvincia.FindIndex(x => x.id == unObjeto.idprovincia);
            if (ix > -1)
                unObjeto.fkprovincia = ListaProvincia[ix];

            return unObjeto;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(canton item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<canton> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(canton item)
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
            //objetoGrid.DataSource = SoporteList<canton>.ToBindingList(this.Registros());
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colIdProvincia"]).DataSource = ListaProvincia;
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 60
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Ciudad.",
                DataPropertyName = "Nombre",
                Width = 250
            };

            DataGridViewComboBoxExColumn colIdProvincia = new DataGridViewComboBoxExColumn()
            {
                Name = "colIdProvincia",
                HeaderText = "Provincia.",
                DataPropertyName = "fkprovincia",
                ValueMember = "Objeto",
                DisplayMember = "nombre",
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
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
                colIdProvincia,
                colModificado
             };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
