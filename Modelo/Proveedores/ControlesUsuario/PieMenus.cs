using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;
using ModeloDB;
using DevComponents.DotNetBar.Controls;

namespace WindowsApp
{
    public partial class PieMenus : UserControl, IControlesUsuario
    {
        #region VARIABLES

        private menu objetoLocal;

        #endregion VARIABLES

        #region PROPIEDADES

        public object Columnas { get; set; }

        public string Modulo { get; set; }

        public object Objeto { get; set; }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public PieMenus()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTORES

        #region METODOS MANIPULACION DEL CONTROL

        private void PieOficinas_Load(object sender, EventArgs e)
        {
            this.dgrListaColumnas.AutoGenerateColumns = false;
            this.ArmarGrid(this.dgrListaColumnas);

            this.dgrListaColumnas.PermitirEventosInternos = true;

            this.dgrListaColumnas.Leave += this.dgrLista_Leave;
            this.dgrListaColumnas.AntesBuscarCell += new AntesBuscarCellEventHandler(dgrListaColumnas_AntesBuscarCell);
            this.dgrListaColumnas.CellValueChanged += this.dgrLista_CellValueChanged;
            this.dgrListaColumnas.UserDeletedRow += new DataGridViewRowEventHandler(dgrListaColumnas_UserDeletedRow);

            MenuSistemaPr.Instancia.CargarTablas(this._cboTablas);

            if (this._cboTablas.Items.Count > 0) this._cboTablas.SelectedIndex = 0;

            ((DataGridViewComboBoxExColumn)this.dgrListaColumnas.Columns["colTipoColumna"]).DataSource = MenuSistemaPr.Instancia.TiposColumnas();
            ((DataGridViewComboBoxExColumn)this.dgrListaColumnas.Columns["colAlineacion"]).DataSource = MenuSistemaPr.Instancia.Alineaciones();
        }

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            if (unObjeto != null)
            {
                this.objetoLocal = (menu)unObjeto;
                this._cboTablas.Text = objetoLocal.tabla;
                if (this._cboTablas.SelectedIndex == -1) this._cboTablas.SelectedIndex = 0;
                this.objetoLocal.fkcolumnasgrid.CargarGrid(this.dgrListaColumnas);
                this.dgrListaColumnas.Visible = true;
            }
            else
            {
                this.dgrListaColumnas.DataSource = unObjeto;
                this.dgrListaColumnas.Visible = false;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            this.dgrListaColumnas.ReadOnly = !this.Enabled;
            this.dgrListaColumnas.AllowUserToAddRows = this.Enabled;
        }

        public Boolean Verificar()
        {
            return this.dgrListaColumnas.ControlEdicionGrid();
        }

        #endregion METODOS MANIPULACION DEL CONTROL

        #region METODOS PARA EVENTOS DE GRID

        void dgrListaColumnas_AntesBuscarCell(AntesBuscarCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.TipoConsulta = TipoConsulta.ColumnasPorTabla;
                e.SetValoresAdicionales(this._cboTablas.Text);
            }
            else
                e.Cancel = true;
        }

        private void dgrLista_Leave(object sender, EventArgs e)
        {
            this.dgrListaColumnas.ControlEdicionGrid();
        }

        void dgrLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.objetoLocal.Modificado = true;
        }

        void dgrListaColumnas_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.objetoLocal.Modificado = true;
        }

        #endregion METODOS PARA EVENTOS GRID

        #region ARMAR GRID COLUMNAS
        private void ArmarGrid(DgvPlus objetoGrid)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
            }
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colOrden = new DataGridViewTextBoxColumn()
            {
                Name = "colOrden",
                HeaderText = "Orden",
                DataPropertyName = "orden",
                MaxInputLength = 2,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colIdentificador = new DataGridViewTextBoxColumn()
            {
                Name = "colIdentificador",
                HeaderText = "Identificador",
                DataPropertyName = "identificador",
                Width = 80
            };

            DataGridViewTextBoxColumn colColumna = new DataGridViewTextBoxColumn()
            {
                Name = "colColumna",
                HeaderText = "Columna.",
                DataPropertyName = "nombre",
                Width = 200
            };

            DataGridViewButtonXColumn colColumnaBoton = new DataGridViewButtonXColumn()
            {
                Name = "colNombreBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colColumna",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };

            DataGridViewComboBoxExColumn colTipoColumna = new DataGridViewComboBoxExColumn()
            {
                Name = "colTipoColumna",
                HeaderText = "Tipo columna.",
                DataPropertyName = "fktiposcolumna",
                ValueMember = "Objeto",
                DisplayMember = "nombre",
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colCabecera = new DataGridViewTextBoxColumn()
            {
                Name = "colCabecera",
                HeaderText = "Texto Cabecera.",
                DataPropertyName = "cabecera",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colFormatoFecha = new DataGridViewTextBoxColumn()
            {
                Name = "colFormatoFecha",
                HeaderText = "Formato Fecha",
                DataPropertyName = "formatofecha",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewDateTimeInputColumn colFechaMinima = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaMinima",
                HeaderText = "Fecha minima",
                DataPropertyName = "fechaminima",
                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd",
                MinDate = new DateTime(1901, 02, 01),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colPropertyName = new DataGridViewTextBoxColumn()
            {
                Name = "colPropertyName",
                HeaderText = "PropertyName",
                DataPropertyName = "propertyname",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colValueMember = new DataGridViewTextBoxColumn()
            {
                Name = "colValueMember",
                HeaderText = "ValueMember",
                DataPropertyName = "valuemember",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colDisplayMember = new DataGridViewTextBoxColumn()
            {
                Name = "colDisplayMember",
                HeaderText = "DisplayMember",
                DataPropertyName = "displaymember",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colTag = new DataGridViewTextBoxColumn()
            {
                Name = "colTag",
                HeaderText = "Tag",
                DataPropertyName = "tag",
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewComboBoxExColumn colAlineacion = new DataGridViewComboBoxExColumn()
            {
                Name = "colAlineacion",
                HeaderText = "Alineacion.",
                DataPropertyName = "fkalineacion",
                ValueMember = "Objeto",
                DisplayMember = "nombre",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colWidth = new DataGridViewTextBoxColumn()
            {
                Name = "colWidth",
                HeaderText = "Width",
                DataPropertyName = "width",
                MaxInputLength = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colMaxLength = new DataGridViewTextBoxColumn()
            {
                Name = "colMaxLength",
                HeaderText = "MaxLength",
                DataPropertyName = "maxlength",
                MaxInputLength = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colReadOnly = new DataGridViewCheckBoxColumn()
            {
                Name = "colReadOnly",
                HeaderText = "ReadOnly",
                DataPropertyName = "sololectura",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colVisible = new DataGridViewCheckBoxColumn()
            {
                Name = "colVisible",
                HeaderText = "Visible",
                DataPropertyName = "visible",
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
                colIdentificador,
                colOrden,
                colColumna, 
                //colColumnaBoton, 
                colTipoColumna,
                colCabecera,
                colFormatoFecha, 
                colFechaMinima,
                colPropertyName, 
                colValueMember, 
                colDisplayMember,
                colTag,
                colAlineacion,
                colWidth,
                colMaxLength,
                colReadOnly,
                colVisible,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID COLUMNAS
    }
}
