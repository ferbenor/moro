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
    public class ParroquiaPr
    {
        #region VARIABLES
        private static ParroquiaPr instancia = null;
        private List<canton> listaCanton;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ParroquiaPr Instancia { get { if (instancia == null) instancia = new ParroquiaPr(); return instancia; } set { instancia = value; } }

        public List<canton> ListaCanton
        {
            get { if (this.listaCanton == null) this.listaCanton = CantonPr.Instancia.Registros(); return listaCanton; }
            set { listaCanton = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ParroquiaPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public parroquia RegistroPorId(int unId)
        {
            
            return this.Registros("id == @0", unId).SingleOrDefault();
        }
        public List<parroquia> Registros(string expresion = null, params object[] parametros)
        {
            List<parroquia> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaCanton = db.cantones.Select(x=> x.Relacionar(x.fkprovincia)).ToList();
                registros = db.parroquias.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).ToList();
            }
            
            for (int ix = 0; ix < registros.Count; ix++)
            {
                parroquia item = registros[ix];
                item = CargarRelaciones(item);
            }
            return registros;
        }
        private parroquia CargarRelaciones(parroquia unObjeto)
        {
            int ix;
            ix = ListaCanton.FindIndex(x => x.id == unObjeto.idcanton);
            if (ix > -1)
                unObjeto.fkcantone = ListaCanton[ix];

            return unObjeto;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(parroquia item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<parroquia> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(parroquia item)
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
            //objetoGrid.DataSource = SoporteList<parroquia>.ToBindingList(this.Registros());
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colIdCanton"]).DataSource = ListaCanton;
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
                HeaderText = "Parroquia.",
                DataPropertyName = "Nombre",
                Width = 450
            };

            DataGridViewComboBoxExColumn colIdCanton = new DataGridViewComboBoxExColumn()
            {
                Name = "colIdCanton",
                HeaderText = "Canton.",
                DataPropertyName = "fkcantone",
                ValueMember = "Objeto",
                DisplayMember = "nombrecompleto",
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewCheckBoxColumn colEsUrbano = new DataGridViewCheckBoxColumn()
            {
                Name = "colEsUrbano",
                HeaderText = "Urbano",
                DataPropertyName = "EsUrbano",
                Width = 60
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
                colIdCanton,
                colEsUrbano,
                colModificado
             };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
