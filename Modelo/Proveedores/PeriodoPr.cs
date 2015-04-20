using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using Estructura;
using CollectionLoaders;
using LinqToDB;
using LinqToDB.Data;
using System.Linq.Dynamic;

namespace Proveedores
{
    public class PeriodoPr : InstrumentalPr
    {
        #region VARIABLES
        private static PeriodoPr instancia = null;

        private List<Mes> listaMeses;
        #endregion VARIABLES

        #region PROPIEDADES
        public static PeriodoPr Instancia { get { if (instancia == null) instancia = new PeriodoPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        public PeriodoPr()
        { listaMeses = new Mes().ListaMeses(); }

        public static bool PeriodoCerrado(short unAnio, short unMes)
        {
            fraccionperiodo periodo = PeriodoPr.Instancia.RegistroPorId(unAnio, unMes);
            return periodo.cerrado;
        }

        public fraccionperiodo RegistroPorId(short unAnio, short unMes)
        {
            return this.Registros("fkperiodo.anio == @0 && mes == @1", unAnio, unMes).SingleOrDefault();
        }

        public List<fraccionperiodo> RegistrosDePeriodos()
        {
            //List<CamposTabla> lp = new List<CamposTabla>();
            //return Consultar("select distinct anio, cast(1 as smallint) as mes, cast(false as boolean) as cerrado from periodos order by anio desc", lp, TipoCargaSubObjetosEnum.Ninguno);
            List<fraccionperiodo> lista;
            using (ispDB db = new ispDB())
            {
                lista = db.periodos.Select(x => new fraccionperiodo() { fkperiodo = x, mes = 1, cerrado = false }).Distinct().OrderBy(x => x).ToList();
            }
            return lista;
        }

        public List<fraccionperiodo> Registros(string expresion = null, params object[] parametros)
        {
            List<fraccionperiodo> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.fraccionesperiodos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderByDescending(x => x.fkperiodo.anio).ThenByDescending(x => x.mes).Select(x=> x.Relacionar(x.fkperiodo)).ToList();
            }

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }

            return registros;
        }

        private fraccionperiodo CargarRelaciones(fraccionperiodo unObjeto)
        {
            int ix;
            ix = listaMeses.FindIndex(x => x.Id == unObjeto.mes);
            if (ix > -1)
                unObjeto.ObjetoMes = listaMeses[ix];

            return unObjeto;
        }

        public int Grabar(short unAnio, short unMes, bool cerrado)
        {
            fraccionperiodo item = new fraccionperiodo(); //{ anio=unAnio, mes = unMes, cerrado = cerrado };
            return item.BorrarObjetoT();
        }

        public int Borrar(Periodo item)
        {
            return item.BorrarObjetoT();
        }

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
            }
            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<periodo>.ToBindingList(this.Registros());
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colMes"]).DataSource = listaMeses;
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn()
            {
                Name = "colAnio",
                HeaderText = "Año",
                DataPropertyName = "anio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colAnio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewComboBoxExColumn colMes = new DataGridViewComboBoxExColumn()
            {
                Name = "colMes",
                HeaderText = "Mes.",
                DataPropertyName = "Mes",
                ValueMember = "Objeto",
                DisplayMember = "Objeto",
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colCerrado = new DataGridViewCheckBoxColumn()
            {
                Name = "colCerrado",
                HeaderText = "Cerrado",
                DataPropertyName = "cerrado",
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
                colAnio,
                colMes,
                colCerrado,
                colModificado
             };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
