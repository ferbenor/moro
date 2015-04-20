namespace WindowsApp
{
    partial class Inventarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this.rfvValidador01 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this.stcEdiciones = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this._dgrFKDetallesInventario = new Proveedores.DgvPlus();
            this.pnlPie = new System.Windows.Forms.Panel();
            this._txtTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this._txtDescuento = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this._txtTipo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtPeriodo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblBodega2 = new System.Windows.Forms.Label();
            this.lblBodega1 = new System.Windows.Forms.Label();
            this._lblAnulado = new System.Windows.Forms.Label();
            this._txtObservacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.chkEditable = new System.Windows.Forms.CheckBox();
            this._txtBodega2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtBodega1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tabEdicion = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgrLista = new Proveedores.DgvPlus();
            this.colVer = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.pnlBusquedaAvanzada = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBuscarEstado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtpBuscarFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscarSector = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscarOrdenSN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblBuscarOrden = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.tabLista = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).BeginInit();
            this.stcEdiciones.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesInventario)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.gpbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
            this.pnlBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errValidacion;
            this.spvValidador.Highlighter = this.hhlResaltador;
            // 
            // errValidacion
            // 
            this.errValidacion.ContainerControl = this;
            this.errValidacion.Icon = ((System.Drawing.Icon)(resources.GetObject("errValidacion.Icon")));
            // 
            // hhlResaltador
            // 
            this.hhlResaltador.ContainerControl = this;
            // 
            // rfvValidador01
            // 
            this.rfvValidador01.ErrorMessage = "Este dato es requerido";
            this.rfvValidador01.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // stcEdiciones
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.stcEdiciones.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stcEdiciones.ControlBox.MenuBox.Name = "";
            this.stcEdiciones.ControlBox.MenuBox.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Random;
            this.stcEdiciones.ControlBox.Name = "";
            this.stcEdiciones.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stcEdiciones.ControlBox.MenuBox,
            this.stcEdiciones.ControlBox.CloseBox});
            this.stcEdiciones.Controls.Add(this.superTabControlPanel1);
            this.stcEdiciones.Controls.Add(this.superTabControlPanel2);
            this.stcEdiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcEdiciones.Location = new System.Drawing.Point(0, 0);
            this.stcEdiciones.Name = "stcEdiciones";
            this.stcEdiciones.ReorderTabsEnabled = true;
            this.stcEdiciones.SelectedTabIndex = 1;
            this.stcEdiciones.Size = new System.Drawing.Size(682, 375);
            this.stcEdiciones.TabIndex = 0;
            this.stcEdiciones.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabEdicion,
            this.tabLista});
            this.stcEdiciones.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this._dgrFKDetallesInventario);
            this.superTabControlPanel1.Controls.Add(this.pnlPie);
            this.superTabControlPanel1.Controls.Add(this.gpbCabecera);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(682, 350);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEdicion;
            // 
            // _dgrFKDetallesInventario
            // 
            this._dgrFKDetallesInventario.AllowUserToAddRows = false;
            this._dgrFKDetallesInventario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._dgrFKDetallesInventario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgrFKDetallesInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgrFKDetallesInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgrFKDetallesInventario.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgrFKDetallesInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgrFKDetallesInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._dgrFKDetallesInventario.Location = new System.Drawing.Point(0, 179);
            this._dgrFKDetallesInventario.Name = "_dgrFKDetallesInventario";
            this._dgrFKDetallesInventario.PermitirEventosInternos = false;
            this._dgrFKDetallesInventario.RowHeadersWidth = 25;
            this._dgrFKDetallesInventario.Size = new System.Drawing.Size(682, 138);
            this._dgrFKDetallesInventario.TabIndex = 1;
            this._dgrFKDetallesInventario.AntesBuscarCell += new Proveedores.AntesBuscarCellEventHandler(this._dgrFKDetallesVenta_AntesBuscarCell);
            this._dgrFKDetallesInventario.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgrFKDetallesVenta_CellEndEdit);
            this._dgrFKDetallesInventario.Leave += new System.EventHandler(this._dgrFKDetallesVenta_Leave);
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this._txtTotal);
            this.pnlPie.Controls.Add(this.lblDescuento);
            this.pnlPie.Controls.Add(this.lblTotal);
            this.pnlPie.Controls.Add(this._txtDescuento);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 317);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(682, 33);
            this.pnlPie.TabIndex = 3;
            // 
            // _txtTotal
            // 
            // 
            // 
            // 
            this._txtTotal.Border.Class = "TextBoxBorder";
            this._txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTotal.Location = new System.Drawing.Point(487, 6);
            this._txtTotal.MaxLength = 10;
            this._txtTotal.Name = "_txtTotal";
            this._txtTotal.ReadOnly = true;
            this._txtTotal.Size = new System.Drawing.Size(88, 22);
            this._txtTotal.TabIndex = 11;
            this._txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuento
            // 
            this.lblDescuento.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuento.Location = new System.Drawing.Point(237, 6);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(78, 22);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "Descuento:";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(405, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 22);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Valor total:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtDescuento
            // 
            // 
            // 
            // 
            this._txtDescuento.Border.Class = "TextBoxBorder";
            this._txtDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtDescuento.Location = new System.Drawing.Point(319, 6);
            this._txtDescuento.MaxLength = 10;
            this._txtDescuento.Name = "_txtDescuento";
            this._txtDescuento.Size = new System.Drawing.Size(88, 22);
            this._txtDescuento.TabIndex = 5;
            this._txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this._txtTipo);
            this.gpbCabecera.Controls.Add(this._txtPeriodo);
            this.gpbCabecera.Controls.Add(this._txtNumero);
            this.gpbCabecera.Controls.Add(this.lblPeriodo);
            this.gpbCabecera.Controls.Add(this.lblNumero);
            this.gpbCabecera.Controls.Add(this.lblBodega2);
            this.gpbCabecera.Controls.Add(this.lblBodega1);
            this.gpbCabecera.Controls.Add(this._lblAnulado);
            this.gpbCabecera.Controls.Add(this._txtObservacion);
            this.gpbCabecera.Controls.Add(this.lblTipo);
            this.gpbCabecera.Controls.Add(this.lblObservacion);
            this.gpbCabecera.Controls.Add(this.lblFecha);
            this.gpbCabecera.Controls.Add(this._dtpFecha);
            this.gpbCabecera.Controls.Add(this.chkEditable);
            this.gpbCabecera.Controls.Add(this._txtBodega2);
            this.gpbCabecera.Controls.Add(this._txtBodega1);
            this.gpbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCabecera.Location = new System.Drawing.Point(0, 0);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(682, 179);
            this.gpbCabecera.TabIndex = 2;
            this.gpbCabecera.TabStop = false;
            // 
            // _txtTipo
            // 
            this._txtTipo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtTipo.Border.Class = "TextBoxBorder";
            this._txtTipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTipo.FocusHighlightEnabled = true;
            this._txtTipo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTipo.Location = new System.Drawing.Point(462, 13);
            this._txtTipo.Name = "_txtTipo";
            this._txtTipo.ReadOnly = true;
            this._txtTipo.Size = new System.Drawing.Size(138, 22);
            this._txtTipo.TabIndex = 31;
            // 
            // _txtPeriodo
            // 
            this._txtPeriodo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtPeriodo.Border.Class = "TextBoxBorder";
            this._txtPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtPeriodo.FocusHighlightEnabled = true;
            this._txtPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPeriodo.Location = new System.Drawing.Point(102, 12);
            this._txtPeriodo.Name = "_txtPeriodo";
            this._txtPeriodo.ReadOnly = true;
            this._txtPeriodo.Size = new System.Drawing.Size(96, 22);
            this._txtPeriodo.TabIndex = 21;
            this._txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtNumero
            // 
            this._txtNumero.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtNumero.Border.Class = "TextBoxBorder";
            this._txtNumero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtNumero.FocusHighlightEnabled = true;
            this._txtNumero.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNumero.Location = new System.Drawing.Point(102, 40);
            this._txtNumero.Name = "_txtNumero";
            this._txtNumero.ReadOnly = true;
            this._txtNumero.Size = new System.Drawing.Size(96, 22);
            this._txtNumero.TabIndex = 21;
            this._txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Location = new System.Drawing.Point(7, 12);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(92, 22);
            this.lblPeriodo.TabIndex = 20;
            this.lblPeriodo.Text = "Periodo";
            this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(7, 40);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(92, 22);
            this.lblNumero.TabIndex = 20;
            this.lblNumero.Text = "Número";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBodega2
            // 
            this.lblBodega2.Location = new System.Drawing.Point(7, 97);
            this.lblBodega2.Name = "lblBodega2";
            this.lblBodega2.Size = new System.Drawing.Size(92, 22);
            this.lblBodega2.TabIndex = 24;
            this.lblBodega2.Text = "Bodega Destino";
            this.lblBodega2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBodega1
            // 
            this.lblBodega1.Location = new System.Drawing.Point(7, 68);
            this.lblBodega1.Name = "lblBodega1";
            this.lblBodega1.Size = new System.Drawing.Size(92, 22);
            this.lblBodega1.TabIndex = 24;
            this.lblBodega1.Text = "Bodega Origen";
            this.lblBodega1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblAnulado
            // 
            this._lblAnulado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAnulado.ForeColor = System.Drawing.Color.Red;
            this._lblAnulado.Location = new System.Drawing.Point(510, 39);
            this._lblAnulado.Name = "_lblAnulado";
            this._lblAnulado.Size = new System.Drawing.Size(90, 22);
            this._lblAnulado.TabIndex = 19;
            this._lblAnulado.Text = "[ ANULADO ]";
            this._lblAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblAnulado.Visible = false;
            // 
            // _txtObservacion
            // 
            // 
            // 
            // 
            this._txtObservacion.Border.Class = "TextBoxBorder";
            this._txtObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtObservacion.FocusHighlightEnabled = true;
            this._txtObservacion.Location = new System.Drawing.Point(102, 126);
            this._txtObservacion.MaxLength = 200;
            this._txtObservacion.Multiline = true;
            this._txtObservacion.Name = "_txtObservacion";
            this._txtObservacion.ReadOnly = true;
            this._txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtObservacion.Size = new System.Drawing.Size(498, 42);
            this._txtObservacion.TabIndex = 29;
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(413, 13);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(43, 22);
            this.lblTipo.TabIndex = 30;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObservacion
            // 
            this.lblObservacion.Location = new System.Drawing.Point(7, 136);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(92, 22);
            this.lblObservacion.TabIndex = 28;
            this.lblObservacion.Text = "Observación";
            this.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(204, 12);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 22);
            this.lblFecha.TabIndex = 22;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dtpFecha
            // 
            // 
            // 
            // 
            this._dtpFecha.BackgroundStyle.Class = "DateTimeInputBackground";
            this._dtpFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this._dtpFecha.ButtonDropDown.Visible = true;
            this._dtpFecha.CustomFormat = "dd MMM yyyy";
            this._dtpFecha.Enabled = false;
            this._dtpFecha.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this._dtpFecha.IsPopupCalendarOpen = false;
            this._dtpFecha.Location = new System.Drawing.Point(268, 12);
            // 
            // 
            // 
            this._dtpFecha.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._dtpFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFecha.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this._dtpFecha.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this._dtpFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFecha.MonthCalendar.DisplayMonth = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this._dtpFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this._dtpFecha.MonthCalendar.MarkedDates = new System.DateTime[0];
            this._dtpFecha.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this._dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this._dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this._dtpFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFecha.MonthCalendar.TodayButtonVisible = true;
            this._dtpFecha.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this._dtpFecha.Name = "_dtpFecha";
            this._dtpFecha.Size = new System.Drawing.Size(136, 22);
            this._dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._dtpFecha.TabIndex = 23;
            this._dtpFecha.Value = new System.DateTime(2015, 4, 14, 10, 13, 44, 0);
            // 
            // chkEditable
            // 
            this.chkEditable.AutoSize = true;
            this.chkEditable.Location = new System.Drawing.Point(608, 151);
            this.chkEditable.Name = "chkEditable";
            this.chkEditable.Size = new System.Drawing.Size(68, 17);
            this.chkEditable.TabIndex = 18;
            this.chkEditable.Text = "Editable";
            this.chkEditable.UseVisualStyleBackColor = true;
            // 
            // _txtBodega2
            // 
            this._txtBodega2.AutoSelectAll = true;
            // 
            // 
            // 
            this._txtBodega2.Border.Class = "TextBoxBorder";
            this._txtBodega2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtBodega2.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this._txtBodega2.ButtonCustom.Visible = true;
            this._txtBodega2.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this._txtBodega2.ButtonCustom2.Visible = true;
            this._txtBodega2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtBodega2.FocusHighlightEnabled = true;
            this._txtBodega2.Location = new System.Drawing.Point(102, 97);
            this._txtBodega2.Multiline = true;
            this._txtBodega2.Name = "_txtBodega2";
            this._txtBodega2.ReadOnly = true;
            this._txtBodega2.Size = new System.Drawing.Size(498, 23);
            this._txtBodega2.TabIndex = 17;
            this._txtBodega2.Tag = "2";
            this._txtBodega2.WatermarkText = "Selecciones bodega destino";
            this._txtBodega2.ButtonCustomClick += new System.EventHandler(this._txtBodega2_ButtonCustomClick);
            // 
            // _txtBodega1
            // 
            this._txtBodega1.AutoSelectAll = true;
            // 
            // 
            // 
            this._txtBodega1.Border.Class = "TextBoxBorder";
            this._txtBodega1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtBodega1.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this._txtBodega1.ButtonCustom.Visible = true;
            this._txtBodega1.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this._txtBodega1.ButtonCustom2.Visible = true;
            this._txtBodega1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtBodega1.FocusHighlightEnabled = true;
            this._txtBodega1.Location = new System.Drawing.Point(102, 68);
            this._txtBodega1.Multiline = true;
            this._txtBodega1.Name = "_txtBodega1";
            this._txtBodega1.ReadOnly = true;
            this._txtBodega1.Size = new System.Drawing.Size(498, 23);
            this._txtBodega1.TabIndex = 17;
            this._txtBodega1.Tag = "1";
            this._txtBodega1.WatermarkText = "Seleccione bodega origen";
            this._txtBodega1.ButtonCustomClick += new System.EventHandler(this._txtBodega1_ButtonCustomClick);
            // 
            // tabEdicion
            // 
            this.tabEdicion.AttachedControl = this.superTabControlPanel1;
            this.tabEdicion.GlobalItem = false;
            this.tabEdicion.Name = "tabEdicion";
            this.tabEdicion.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEdicion.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEdicion.Text = "Editando registro";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.dgrLista);
            this.superTabControlPanel2.Controls.Add(this.pnlBusquedaAvanzada);
            this.superTabControlPanel2.Controls.Add(this.pnlBusqueda);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(682, 375);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabLista;
            // 
            // dgrLista
            // 
            this.dgrLista.AllowUserToAddRows = false;
            this.dgrLista.AllowUserToDeleteRows = false;
            this.dgrLista.AllowUserToResizeColumns = false;
            this.dgrLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVer});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrLista.Location = new System.Drawing.Point(0, 130);
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.PermitirEventosInternos = false;
            this.dgrLista.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrLista.RowHeadersWidth = 22;
            this.dgrLista.Size = new System.Drawing.Size(682, 245);
            this.dgrLista.StandardTab = true;
            this.dgrLista.TabIndex = 2;
            this.dgrLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrLista_CellClick);
            this.dgrLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgrLista_KeyPress);
            // 
            // colVer
            // 
            this.colVer.HeaderText = "Ver";
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Text = null;
            this.colVer.Width = 30;
            // 
            // pnlBusquedaAvanzada
            // 
            this.pnlBusquedaAvanzada.BackColor = System.Drawing.Color.Transparent;
            this.pnlBusquedaAvanzada.Controls.Add(this.label4);
            this.pnlBusquedaAvanzada.Controls.Add(this.cboBuscarEstado);
            this.pnlBusquedaAvanzada.Controls.Add(this.label1);
            this.pnlBusquedaAvanzada.Controls.Add(this.lblTipoDocumento);
            this.pnlBusquedaAvanzada.Controls.Add(this.txtBuscarCliente);
            this.pnlBusquedaAvanzada.Controls.Add(this.dtpBuscarFecha);
            this.pnlBusquedaAvanzada.Controls.Add(this.label3);
            this.pnlBusquedaAvanzada.Controls.Add(this.txtBuscarSector);
            this.pnlBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusquedaAvanzada.Location = new System.Drawing.Point(0, 69);
            this.pnlBusquedaAvanzada.Name = "pnlBusquedaAvanzada";
            this.pnlBusquedaAvanzada.Size = new System.Drawing.Size(682, 61);
            this.pnlBusquedaAvanzada.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboBuscarEstado
            // 
            this.cboBuscarEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBuscarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarEstado.FormattingEnabled = true;
            this.cboBuscarEstado.ItemHeight = 16;
            this.cboBuscarEstado.Location = new System.Drawing.Point(84, 3);
            this.cboBuscarEstado.Name = "cboBuscarEstado";
            this.cboBuscarEstado.Size = new System.Drawing.Size(134, 22);
            this.cboBuscarEstado.TabIndex = 3;
            this.cboBuscarEstado.WatermarkText = "Estado";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(216, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Location = new System.Drawing.Point(24, 3);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(57, 21);
            this.lblTipoDocumento.TabIndex = 0;
            this.lblTipoDocumento.Text = "Estado";
            this.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.AutoSelectAll = true;
            // 
            // 
            // 
            this.txtBuscarCliente.Border.Class = "TextBoxBorder";
            this.txtBuscarCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscarCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarCliente.FocusHighlightEnabled = true;
            this.txtBuscarCliente.Location = new System.Drawing.Point(276, 2);
            this.txtBuscarCliente.MaxLength = 100;
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(287, 22);
            this.txtBuscarCliente.TabIndex = 2;
            this.txtBuscarCliente.WatermarkText = "Ingrese el apellido o nombre de cliente que desea buscar";
            // 
            // dtpBuscarFecha
            // 
            // 
            // 
            // 
            this.dtpBuscarFecha.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpBuscarFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBuscarFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpBuscarFecha.ButtonDropDown.Visible = true;
            this.dtpBuscarFecha.CustomFormat = "dd MMM yyyy";
            this.dtpBuscarFecha.IsPopupCalendarOpen = false;
            this.dtpBuscarFecha.Location = new System.Drawing.Point(84, 31);
            // 
            // 
            // 
            this.dtpBuscarFecha.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpBuscarFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBuscarFecha.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpBuscarFecha.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpBuscarFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBuscarFecha.MonthCalendar.DisplayMonth = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpBuscarFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpBuscarFecha.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpBuscarFecha.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpBuscarFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpBuscarFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpBuscarFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpBuscarFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBuscarFecha.MonthCalendar.TodayButtonVisible = true;
            this.dtpBuscarFecha.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpBuscarFecha.Name = "dtpBuscarFecha";
            this.dtpBuscarFecha.ShowCheckBox = true;
            this.dtpBuscarFecha.Size = new System.Drawing.Size(134, 22);
            this.dtpBuscarFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpBuscarFecha.TabIndex = 5;
            this.dtpBuscarFecha.Value = new System.DateTime(2014, 12, 3, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(216, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sector";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarSector
            // 
            this.txtBuscarSector.AutoSelectAll = true;
            // 
            // 
            // 
            this.txtBuscarSector.Border.Class = "TextBoxBorder";
            this.txtBuscarSector.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscarSector.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this.txtBuscarSector.ButtonCustom.Visible = true;
            this.txtBuscarSector.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this.txtBuscarSector.ButtonCustom2.Visible = true;
            this.txtBuscarSector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarSector.FocusHighlightEnabled = true;
            this.txtBuscarSector.Location = new System.Drawing.Point(276, 30);
            this.txtBuscarSector.Multiline = true;
            this.txtBuscarSector.Name = "txtBuscarSector";
            this.txtBuscarSector.ReadOnly = true;
            this.txtBuscarSector.Size = new System.Drawing.Size(425, 23);
            this.txtBuscarSector.TabIndex = 7;
            this.txtBuscarSector.WatermarkText = "Seleccione el sector";
            this.txtBuscarSector.ButtonCustomClick += new System.EventHandler(this.txtBuscarSector_ButtonCustomClick);
            this.txtBuscarSector.ButtonCustom2Click += new System.EventHandler(this.txtBuscarSector_ButtonCustom2Click);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.pnlBusqueda.Controls.Add(this.txtBuscarOrdenSN);
            this.pnlBusqueda.Controls.Add(this.lblBuscarOrden);
            this.pnlBusqueda.Controls.Add(this.lblBusqueda);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.lblMensaje);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(682, 69);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // txtBuscarOrdenSN
            // 
            this.txtBuscarOrdenSN.AutoSelectAll = true;
            // 
            // 
            // 
            this.txtBuscarOrdenSN.Border.Class = "TextBoxBorder";
            this.txtBuscarOrdenSN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscarOrdenSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarOrdenSN.FocusHighlightEnabled = true;
            this.txtBuscarOrdenSN.Location = new System.Drawing.Point(84, 42);
            this.txtBuscarOrdenSN.MaxLength = 5;
            this.txtBuscarOrdenSN.Name = "txtBuscarOrdenSN";
            this.txtBuscarOrdenSN.Size = new System.Drawing.Size(102, 22);
            this.txtBuscarOrdenSN.TabIndex = 2;
            this.txtBuscarOrdenSN.WatermarkText = "Orden";
            this.txtBuscarOrdenSN.TextChanged += new System.EventHandler(this.txtBuscarOrden_TextChanged);
            // 
            // lblBuscarOrden
            // 
            this.lblBuscarOrden.Location = new System.Drawing.Point(24, 43);
            this.lblBuscarOrden.Name = "lblBuscarOrden";
            this.lblBuscarOrden.Size = new System.Drawing.Size(57, 21);
            this.lblBuscarOrden.TabIndex = 1;
            this.lblBuscarOrden.Text = "Orden";
            this.lblBuscarOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.Blue;
            this.lblBusqueda.Location = new System.Drawing.Point(34, 10);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(136, 17);
            this.lblBusqueda.TabIndex = 0;
            this.lblBusqueda.Text = "Busqueda de ordenes";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(196, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(224, 43);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(183, 17);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "No se encontraron resultados";
            this.lblMensaje.Visible = false;
            // 
            // tabLista
            // 
            this.tabLista.AttachedControl = this.superTabControlPanel2;
            this.tabLista.GlobalItem = false;
            this.tabLista.Name = "tabLista";
            this.tabLista.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLista.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLista.Text = "Lista de registros";
            // 
            // Inventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(682, 375);
            this.Controls.Add(this.stcEdiciones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Inventarios";
            this.Text = "Inventarios";
            this.Activated += new System.EventHandler(this.Ventas_Activated);
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).EndInit();
            this.stcEdiciones.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesInventario)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.gpbCabecera.ResumeLayout(false);
            this.gpbCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.pnlBusquedaAvanzada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador01;
        private DevComponents.DotNetBar.SuperTabControl stcEdiciones;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private Proveedores.DgvPlus _dgrFKDetallesInventario;
        private DevComponents.DotNetBar.SuperTabItem tabEdicion;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private Proveedores.DgvPlus dgrLista;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblBusqueda;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscarCliente;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.SuperTabItem tabLista;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscarSector;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscarOrdenSN;
        private System.Windows.Forms.Label lblBuscarOrden;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpBuscarFecha;
        private System.Windows.Forms.Label lblTipoDocumento;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboBuscarEstado;
        private System.Windows.Forms.Panel pnlBusquedaAvanzada;
        private System.Windows.Forms.GroupBox gpbCabecera;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtBodega1;
        private System.Windows.Forms.CheckBox chkEditable;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colVer;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtNumero;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblBodega1;
        private System.Windows.Forms.Label _lblAnulado;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtObservacion;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label lblFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFecha;
        private System.Windows.Forms.Panel pnlPie;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblTotal;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDescuento;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtBodega2;
        private System.Windows.Forms.Label lblBodega2;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTipo;
    }
}