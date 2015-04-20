namespace WindowsApp
{
    partial class OrdenesPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenesPedido));
            ModeloDB.identificadorpago identificadorpago1 = new ModeloDB.identificadorpago();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTelefono = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTelefono = new System.Windows.Forms.Label();
            this._txtIdentificacionSN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRuc = new System.Windows.Forms.Label();
            this.txtDireccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbldireccion = new System.Windows.Forms.Label();
            this._lblMensaje = new System.Windows.Forms.Label();
            this._dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this._btnConsultarClientes = new DevComponents.DotNetBar.ButtonX();
            this.txtCliente = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFecha = new System.Windows.Forms.Label();
            this._txtIdRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.rfvValidador01 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this._txtCanceladoRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtSaldoRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtTotalRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNumero = new System.Windows.Forms.Label();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this._txtObservacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblObservacion = new System.Windows.Forms.Label();
            this._txtFKBarrioRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblCancelado = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this._conveniosPagos1 = new WindowsApp.ConveniosPagos();
            this.stcEdiciones = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this._dgrFKDetallesOrdenesPedido = new Proveedores.DgvPlus();
            this.tabEdicion = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgrLista = new Proveedores.DgvPlus();
            this.colVer = new System.Windows.Forms.DataGridViewImageColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioRegistra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioAnula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaAnula = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).BeginInit();
            this.stcEdiciones.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesOrdenesPedido)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
            this.pnlBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTelefono
            // 
            // 
            // 
            // 
            this.txtTelefono.Border.Class = "TextBoxBorder";
            this.txtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTelefono.Location = new System.Drawing.Point(486, 68);
            this.txtTelefono.MaxLength = 13;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(218, 22);
            this.txtTelefono.TabIndex = 12;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(420, 68);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 22);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfonos:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtIdentificacionSN
            // 
            // 
            // 
            // 
            this._txtIdentificacionSN.Border.Class = "TextBoxBorder";
            this._txtIdentificacionSN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtIdentificacionSN.FocusHighlightEnabled = true;
            this._txtIdentificacionSN.Location = new System.Drawing.Point(90, 40);
            this._txtIdentificacionSN.MaxLength = 13;
            this._txtIdentificacionSN.Name = "_txtIdentificacionSN";
            this._txtIdentificacionSN.ReadOnly = true;
            this._txtIdentificacionSN.Size = new System.Drawing.Size(96, 22);
            this._txtIdentificacionSN.TabIndex = 6;
            // 
            // lblRuc
            // 
            this.lblRuc.Location = new System.Drawing.Point(9, 38);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(78, 22);
            this.lblRuc.TabIndex = 5;
            this.lblRuc.Text = "Cliente:";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDireccion
            // 
            // 
            // 
            // 
            this.txtDireccion.Border.Class = "TextBoxBorder";
            this.txtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.FocusHighlightEnabled = true;
            this.txtDireccion.Location = new System.Drawing.Point(90, 68);
            this.txtDireccion.MaxLength = 200;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(327, 22);
            this.txtDireccion.TabIndex = 10;
            // 
            // lbldireccion
            // 
            this.lbldireccion.Location = new System.Drawing.Point(9, 68);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(78, 22);
            this.lbldireccion.TabIndex = 9;
            this.lbldireccion.Text = "Dirección:";
            this.lbldireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblMensaje
            // 
            this._lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblMensaje.ForeColor = System.Drawing.Color.Red;
            this._lblMensaje.Location = new System.Drawing.Point(446, 11);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(90, 22);
            this._lblMensaje.TabIndex = 0;
            this._lblMensaje.Text = "[ ANULADO ]";
            this._lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this._dtpFecha.Location = new System.Drawing.Point(256, 12);
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
            this._dtpFecha.Size = new System.Drawing.Size(125, 22);
            this._dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._dtpFecha.TabIndex = 4;
            // 
            // _btnConsultarClientes
            // 
            this._btnConsultarClientes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this._btnConsultarClientes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this._btnConsultarClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnConsultarClientes.Location = new System.Drawing.Point(553, 40);
            this._btnConsultarClientes.Name = "_btnConsultarClientes";
            this._btnConsultarClientes.Size = new System.Drawing.Size(22, 22);
            this._btnConsultarClientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._btnConsultarClientes.TabIndex = 8;
            this._btnConsultarClientes.Visible = false;
            this._btnConsultarClientes.Click += new System.EventHandler(this._btnConsultarClientes_Click);
            // 
            // txtCliente
            // 
            // 
            // 
            // 
            this.txtCliente.Border.Class = "TextBoxBorder";
            this.txtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCliente.FocusHighlightEnabled = true;
            this.txtCliente.Location = new System.Drawing.Point(193, 40);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(344, 22);
            this.txtCliente.TabIndex = 7;
            this.spvValidador.SetValidator1(this.txtCliente, this.rfvValidador01);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(192, 12);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 22);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtIdRO
            // 
            this._txtIdRO.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtIdRO.Border.Class = "TextBoxBorder";
            this._txtIdRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtIdRO.FocusHighlightEnabled = true;
            this._txtIdRO.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtIdRO.Location = new System.Drawing.Point(90, 12);
            this._txtIdRO.Name = "_txtIdRO";
            this._txtIdRO.ReadOnly = true;
            this._txtIdRO.Size = new System.Drawing.Size(96, 22);
            this._txtIdRO.TabIndex = 2;
            this._txtIdRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errValidacion;
            this.spvValidador.Highlighter = this.hhlResaltador;
            // 
            // rfvValidador01
            // 
            this.rfvValidador01.ErrorMessage = "Este dato es requerido";
            this.rfvValidador01.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // _txtCanceladoRO
            // 
            // 
            // 
            // 
            this._txtCanceladoRO.Border.Class = "TextBoxBorder";
            this._txtCanceladoRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtCanceladoRO.Location = new System.Drawing.Point(90, 40);
            this._txtCanceladoRO.MaxLength = 10;
            this._txtCanceladoRO.Name = "_txtCanceladoRO";
            this._txtCanceladoRO.ReadOnly = true;
            this._txtCanceladoRO.Size = new System.Drawing.Size(88, 22);
            this._txtCanceladoRO.TabIndex = 4;
            this._txtCanceladoRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtSaldoRO
            // 
            // 
            // 
            // 
            this._txtSaldoRO.Border.Class = "TextBoxBorder";
            this._txtSaldoRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtSaldoRO.Location = new System.Drawing.Point(90, 68);
            this._txtSaldoRO.MaxLength = 10;
            this._txtSaldoRO.Name = "_txtSaldoRO";
            this._txtSaldoRO.ReadOnly = true;
            this._txtSaldoRO.Size = new System.Drawing.Size(88, 22);
            this._txtSaldoRO.TabIndex = 5;
            this._txtSaldoRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtTotalRO
            // 
            // 
            // 
            // 
            this._txtTotalRO.Border.Class = "TextBoxBorder";
            this._txtTotalRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTotalRO.Location = new System.Drawing.Point(90, 12);
            this._txtTotalRO.MaxLength = 10;
            this._txtTotalRO.Name = "_txtTotalRO";
            this._txtTotalRO.ReadOnly = true;
            this._txtTotalRO.Size = new System.Drawing.Size(88, 22);
            this._txtTotalRO.TabIndex = 3;
            this._txtTotalRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(9, 12);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(78, 22);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Número:";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this._txtObservacion);
            this.pnlCabecera.Controls.Add(this.lblObservacion);
            this.pnlCabecera.Controls.Add(this._txtFKBarrioRO);
            this.pnlCabecera.Controls.Add(this.label2);
            this.pnlCabecera.Controls.Add(this._txtIdRO);
            this.pnlCabecera.Controls.Add(this.txtCliente);
            this.pnlCabecera.Controls.Add(this.lblNumero);
            this.pnlCabecera.Controls.Add(this._btnConsultarClientes);
            this.pnlCabecera.Controls.Add(this.txtTelefono);
            this.pnlCabecera.Controls.Add(this.lblRuc);
            this.pnlCabecera.Controls.Add(this._lblMensaje);
            this.pnlCabecera.Controls.Add(this.lblTelefono);
            this.pnlCabecera.Controls.Add(this._txtIdentificacionSN);
            this.pnlCabecera.Controls.Add(this.txtDireccion);
            this.pnlCabecera.Controls.Add(this.lbldireccion);
            this.pnlCabecera.Controls.Add(this.lblFecha);
            this.pnlCabecera.Controls.Add(this._dtpFecha);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(715, 175);
            this.pnlCabecera.TabIndex = 0;
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
            this._txtObservacion.Location = new System.Drawing.Point(89, 125);
            this._txtObservacion.MaxLength = 255;
            this._txtObservacion.Multiline = true;
            this._txtObservacion.Name = "_txtObservacion";
            this._txtObservacion.ReadOnly = true;
            this._txtObservacion.Size = new System.Drawing.Size(615, 40);
            this._txtObservacion.TabIndex = 16;
            // 
            // lblObservacion
            // 
            this.lblObservacion.Location = new System.Drawing.Point(8, 131);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(78, 22);
            this.lblObservacion.TabIndex = 15;
            this.lblObservacion.Text = "Observación:";
            this.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtFKBarrioRO
            // 
            this._txtFKBarrioRO.AutoSelectAll = true;
            // 
            // 
            // 
            this._txtFKBarrioRO.Border.Class = "TextBoxBorder";
            this._txtFKBarrioRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtFKBarrioRO.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this._txtFKBarrioRO.ButtonCustom.Visible = true;
            this._txtFKBarrioRO.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this._txtFKBarrioRO.ButtonCustom2.Visible = true;
            this._txtFKBarrioRO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtFKBarrioRO.FocusHighlightEnabled = true;
            this._txtFKBarrioRO.Location = new System.Drawing.Point(90, 96);
            this._txtFKBarrioRO.Multiline = true;
            this._txtFKBarrioRO.Name = "_txtFKBarrioRO";
            this._txtFKBarrioRO.ReadOnly = true;
            this._txtFKBarrioRO.Size = new System.Drawing.Size(614, 23);
            this._txtFKBarrioRO.TabIndex = 14;
            this._txtFKBarrioRO.WatermarkText = "Seleccione el sector";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Entregar en:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.pnlTotales);
            this.pnlPie.Controls.Add(this._conveniosPagos1);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 299);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(715, 107);
            this.pnlPie.TabIndex = 2;
            // 
            // pnlTotales
            // 
            this.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTotales.Controls.Add(this.lblSubtotal);
            this.pnlTotales.Controls.Add(this._txtTotalRO);
            this.pnlTotales.Controls.Add(this._txtCanceladoRO);
            this.pnlTotales.Controls.Add(this.lblCancelado);
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Controls.Add(this._txtSaldoRO);
            this.pnlTotales.Location = new System.Drawing.Point(471, 3);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(206, 101);
            this.pnlTotales.TabIndex = 3;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal.Location = new System.Drawing.Point(8, 67);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(78, 22);
            this.lblSubtotal.TabIndex = 2;
            this.lblSubtotal.Text = "Saldo:";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancelado
            // 
            this.lblCancelado.BackColor = System.Drawing.Color.Transparent;
            this.lblCancelado.Location = new System.Drawing.Point(9, 39);
            this.lblCancelado.Name = "lblCancelado";
            this.lblCancelado.Size = new System.Drawing.Size(78, 22);
            this.lblCancelado.TabIndex = 1;
            this.lblCancelado.Text = "Abonado:";
            this.lblCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(9, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 22);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Valor total:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _conveniosPagos1
            // 
            this._conveniosPagos1.Columnas = null;
            this._conveniosPagos1.DataSource = null;
            identificadorpago1.fkconveniospago = null;
            identificadorpago1.fkordenespedidos = null;
            identificadorpago1.fkventas = null;
            identificadorpago1.id = 0;
            this._conveniosPagos1.IdentificadorPago = identificadorpago1;
            this._conveniosPagos1.Location = new System.Drawing.Point(3, 3);
            this._conveniosPagos1.Modulo = null;
            this._conveniosPagos1.Name = "_conveniosPagos1";
            this._conveniosPagos1.Objeto = identificadorpago1;
            this._conveniosPagos1.Padding = new System.Windows.Forms.Padding(1);
            this._conveniosPagos1.Size = new System.Drawing.Size(462, 102);
            this._conveniosPagos1.TabIndex = 3;
            this._conveniosPagos1.TotalPagado = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.stcEdiciones.Controls.Add(this.superTabControlPanel2);
            this.stcEdiciones.Controls.Add(this.superTabControlPanel1);
            this.stcEdiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcEdiciones.Location = new System.Drawing.Point(0, 0);
            this.stcEdiciones.Name = "stcEdiciones";
            this.stcEdiciones.ReorderTabsEnabled = true;
            this.stcEdiciones.SelectedTabIndex = 1;
            this.stcEdiciones.Size = new System.Drawing.Size(715, 431);
            this.stcEdiciones.TabIndex = 0;
            this.stcEdiciones.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabEdicion,
            this.tabLista});
            this.stcEdiciones.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this._dgrFKDetallesOrdenesPedido);
            this.superTabControlPanel1.Controls.Add(this.pnlCabecera);
            this.superTabControlPanel1.Controls.Add(this.pnlPie);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(715, 406);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEdicion;
            // 
            // _dgrFKDetallesOrdenesPedido
            // 
            this._dgrFKDetallesOrdenesPedido.AllowUserToAddRows = false;
            this._dgrFKDetallesOrdenesPedido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._dgrFKDetallesOrdenesPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this._dgrFKDetallesOrdenesPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgrFKDetallesOrdenesPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgrFKDetallesOrdenesPedido.DefaultCellStyle = dataGridViewCellStyle8;
            this._dgrFKDetallesOrdenesPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgrFKDetallesOrdenesPedido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._dgrFKDetallesOrdenesPedido.Location = new System.Drawing.Point(0, 175);
            this._dgrFKDetallesOrdenesPedido.Name = "_dgrFKDetallesOrdenesPedido";
            this._dgrFKDetallesOrdenesPedido.PermitirEventosInternos = false;
            this._dgrFKDetallesOrdenesPedido.RowHeadersWidth = 25;
            this._dgrFKDetallesOrdenesPedido.Size = new System.Drawing.Size(715, 124);
            this._dgrFKDetallesOrdenesPedido.TabIndex = 1;
            this._dgrFKDetallesOrdenesPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgrDetalleOrdenPedido_CellEndEdit);
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
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(715, 406);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabLista;
            // 
            // dgrLista
            // 
            this.dgrLista.AllowUserToAddRows = false;
            this.dgrLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVer,
            this.id,
            this.colFecha,
            this.colRuc,
            this.colCliente,
            this.colTotal,
            this.colCancelado,
            this.colSaldo,
            this.colUbicacion,
            this.colObservacion,
            this.colUsuarioRegistra,
            this.colEstado,
            this.colUsuarioAnula,
            this.colFechaAnula});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrLista.Location = new System.Drawing.Point(0, 130);
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.PermitirEventosInternos = false;
            this.dgrLista.ReadOnly = true;
            this.dgrLista.RowHeadersWidth = 25;
            this.dgrLista.Size = new System.Drawing.Size(715, 276);
            this.dgrLista.StandardTab = true;
            this.dgrLista.TabIndex = 2;
            this.dgrLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrLista_CellClick);
            this.dgrLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgrLista_KeyPress);
            // 
            // colVer
            // 
            this.colVer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVer.Frozen = true;
            this.colVer.HeaderText = "Ver";
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVer.Width = 30;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 42;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFecha.DataPropertyName = "fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 62;
            // 
            // colRuc
            // 
            this.colRuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRuc.DataPropertyName = "identificacion";
            this.colRuc.HeaderText = "Identificación";
            this.colRuc.Name = "colRuc";
            this.colRuc.ReadOnly = true;
            this.colRuc.Width = 102;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCliente.DataPropertyName = "fkcliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 68;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotal.DataPropertyName = "total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 57;
            // 
            // colCancelado
            // 
            this.colCancelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCancelado.DataPropertyName = "cancelado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colCancelado.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCancelado.HeaderText = "Cancelado";
            this.colCancelado.Name = "colCancelado";
            this.colCancelado.ReadOnly = true;
            this.colCancelado.Width = 86;
            // 
            // colSaldo
            // 
            this.colSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSaldo.DataPropertyName = "saldo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle5.Format = "N2";
            this.colSaldo.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            this.colSaldo.Width = 61;
            // 
            // colUbicacion
            // 
            this.colUbicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUbicacion.DataPropertyName = "fkbarrio";
            this.colUbicacion.HeaderText = "Ubicación";
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.ReadOnly = true;
            this.colUbicacion.Width = 83;
            // 
            // colObservacion
            // 
            this.colObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colObservacion.DataPropertyName = "observacion";
            this.colObservacion.HeaderText = "Observación";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.ReadOnly = true;
            this.colObservacion.Width = 96;
            // 
            // colUsuarioRegistra
            // 
            this.colUsuarioRegistra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUsuarioRegistra.DataPropertyName = "fkusuario";
            this.colUsuarioRegistra.HeaderText = "Registra";
            this.colUsuarioRegistra.Name = "colUsuarioRegistra";
            this.colUsuarioRegistra.ReadOnly = true;
            this.colUsuarioRegistra.Width = 74;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEstado.DataPropertyName = "fkestadosordenespedido";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 67;
            // 
            // colUsuarioAnula
            // 
            this.colUsuarioAnula.DataPropertyName = "fkusuarios1";
            this.colUsuarioAnula.HeaderText = "Anula";
            this.colUsuarioAnula.Name = "colUsuarioAnula";
            this.colUsuarioAnula.ReadOnly = true;
            this.colUsuarioAnula.Width = 62;
            // 
            // colFechaAnula
            // 
            this.colFechaAnula.DataPropertyName = "fechaanulacion";
            this.colFechaAnula.HeaderText = "Anulado";
            this.colFechaAnula.Name = "colFechaAnula";
            this.colFechaAnula.ReadOnly = true;
            this.colFechaAnula.Width = 76;
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
            this.pnlBusquedaAvanzada.Size = new System.Drawing.Size(715, 61);
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
            this.pnlBusqueda.Size = new System.Drawing.Size(715, 69);
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
            // OrdenesPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(715, 431);
            this.Controls.Add(this.stcEdiciones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrdenesPedido";
            this.Text = "Orden de pedido";
            this.Activated += new System.EventHandler(this.OrdenesPedido_Activated);
            this.Load += new System.EventHandler(this.OrdenesPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.pnlTotales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).EndInit();
            this.stcEdiciones.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesOrdenesPedido)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.pnlBusquedaAvanzada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCliente;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFecha;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtIdRO;
        private DevComponents.DotNetBar.ButtonX _btnConsultarClientes;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private System.Windows.Forms.Label _lblMensaje;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDireccion;
        private System.Windows.Forms.Label lbldireccion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtIdentificacionSN;
        private System.Windows.Forms.Label lblRuc;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtSaldoRO;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtCanceladoRO;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTotalRO;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblCancelado;
        private System.Windows.Forms.Label lblTotal;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador01;
        private DevComponents.DotNetBar.SuperTabControl stcEdiciones;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private Proveedores.DgvPlus _dgrFKDetallesOrdenesPedido;
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
        private DevComponents.DotNetBar.Controls.TextBoxX _txtObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtFKBarrioRO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn colVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioRegistra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioAnula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAnula;
        private ConveniosPagos _conveniosPagos1;
        private System.Windows.Forms.Panel pnlTotales;
    }
}