using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using LinqToDB;
using ModeloDB;

namespace Proveedores
{
    public class CuentaBancoPr
    {
        #region VARIABLES
        private static CuentaBancoPr instancia = null;

        private List<banco> listaBanco;
        #endregion VARIABLES

        #region PROPIEDADES
        public static CuentaBancoPr Instancia { get { if (instancia == null) instancia = new CuentaBancoPr(); return instancia; } set { instancia = value; } }

        public List<banco> ListaBanco
        {
            get { if (this.listaBanco == null) this.listaBanco = BancoPr.Instancia.Registros(); return listaBanco; }
            set { listaBanco = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public CuentaBancoPr()
        { }

        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS

        public cuentabanco Registro(short unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<cuentabanco> Registros(string expresion = null, params object[] parametros)
        {
            List<cuentabanco> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaBanco = db.bancos.Where(x => x.activo == true).ToList();

                registros = db.cuentasbancos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).Select(x =>
                    x.Relacionar(x.fkcuentascontable
                    )).ToList();
            }

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }

            return registros;
        }

        private cuentabanco CargarRelaciones(cuentabanco unObjeto)
        {
            int ix;
            ix = ListaBanco.FindIndex(x => x.id == unObjeto.idbanco);
            if (ix > -1)
                unObjeto.fkbanco = ListaBanco[ix];

            return unObjeto;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(cuentabanco item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<cuentabanco> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(cuentabanco item)
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
            //objetoGrid.DataSource = SoporteList<cuentabanco>.ToBindingList(this.Registros());
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            ListaBanco = null;
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colIdBanco"]).DataSource = ListaBanco;
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
                HeaderText = "Descripción.",
                DataPropertyName = "descripcion",
                MaxInputLength = 25,
                Width = 250,
                //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colNumeroCuenta = new DataGridViewTextBoxColumn()
            {
                Name = "colNumeroCuenta",
                HeaderText = "Cuenta.",
                DataPropertyName = "numerocuenta",
                MaxInputLength = 25,
                Width = 100,
                //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewComboBoxExColumn colIdBanco = new DataGridViewComboBoxExColumn()
            {
                Name = "colIdBanco",
                HeaderText = "Banco.",
                DataPropertyName = "fkbanco",
                ValueMember = "Objeto",
                DisplayMember = "Objeto",
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewDateTimeInputColumn colFechaApertura = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaApertura",
                HeaderText = "Aperturada",
                DataPropertyName = "fechaapertura",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colFechaApertura.ButtonDropDown.Visible = true;
            colFechaApertura.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            colFechaApertura.AutoAdvance = true;
            colFechaApertura.MonthCalendar.TodayButtonVisible = true;

            DataGridViewDoubleInputColumn colSaldoCuenta = new DataGridViewDoubleInputColumn()
            {
                Name = "colSaldoCuenta",
                HeaderText = "Saldo",
                DataPropertyName = "saldocuenta",
                Width = 100
            };
            colSaldoCuenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSaldoCuenta.DefaultCellStyle.Format = "C5";

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "activo",
                Visible = false
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
                colNumeroCuenta,
                colIdBanco,
                colFechaApertura,
                colSaldoCuenta,
                colActivo,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}

