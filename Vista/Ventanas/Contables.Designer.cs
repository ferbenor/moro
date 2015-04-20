namespace WindowsApp
{
    partial class Contables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contables));
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
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this.chkEditable = new System.Windows.Forms.CheckBox();
            this._txtBeneficiario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._lblAnulado = new System.Windows.Forms.Label();
            this._txtDiferencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this._txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtValorHaber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this._txtDetalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this._txtValorDebe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.lblTipoContable = new System.Windows.Forms.Label();
            this._cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tabEdicion = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
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
            this._dgrFKDetallesOrdenesPedido = new Proveedores.DgvPlus();
            this.dgrLista = new Proveedores.DgvPlus();
            this.colVer = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.compareValidator1 = new DevComponents.DotNetBar.Validator.CompareValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).BeginInit();
            this.stcEdiciones.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.gpbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            this.pnlBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesOrdenesPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
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
            this.superTabControlPanel1.Controls.Add(this.gpbCabecera);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(715, 406);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEdicion;
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this.chkEditable);
            this.gpbCabecera.Controls.Add(this._txtBeneficiario);
            this.gpbCabecera.Controls.Add(this._lblAnulado);
            this.gpbCabecera.Controls.Add(this._txtDiferencia);
            this.gpbCabecera.Controls.Add(this._dtpFecha);
            this.gpbCabecera.Controls.Add(this.lblDiferencia);
            this.gpbCabecera.Controls.Add(this._txtNumero);
            this.gpbCabecera.Controls.Add(this._txtValorHaber);
            this.gpbCabecera.Controls.Add(this.label5);
            this.gpbCabecera.Controls.Add(this._txtDetalle);
            this.gpbCabecera.Controls.Add(this.label6);
            this.gpbCabecera.Controls.Add(this._txtValorDebe);
            this.gpbCabecera.Controls.Add(this.label7);
            this.gpbCabecera.Controls.Add(this.label8);
            this.gpbCabecera.Controls.Add(this.lblDetalle);
            this.gpbCabecera.Controls.Add(this.lblBeneficiario);
            this.gpbCabecera.Controls.Add(this.lblTipoContable);
            this.gpbCabecera.Controls.Add(this._cboTipo);
            this.gpbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCabecera.Location = new System.Drawing.Point(0, 0);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(715, 183);
            this.gpbCabecera.TabIndex = 2;
            this.gpbCabecera.TabStop = false;
            // 
            // chkEditable
            // 
            this.chkEditable.AutoSize = true;
            this.chkEditable.Location = new System.Drawing.Point(602, 18);
            this.chkEditable.Name = "chkEditable";
            this.chkEditable.Size = new System.Drawing.Size(68, 17);
            this.chkEditable.TabIndex = 18;
            this.chkEditable.Text = "Editable";
            this.chkEditable.UseVisualStyleBackColor = true;
            // 
            // _txtBeneficiario
            // 
            this._txtBeneficiario.AutoSelectAll = true;
            // 
            // 
            // 
            this._txtBeneficiario.Border.Class = "TextBoxBorder";
            this._txtBeneficiario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtBeneficiario.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this._txtBeneficiario.ButtonCustom.Visible = true;
            this._txtBeneficiario.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this._txtBeneficiario.ButtonCustom2.Visible = true;
            this._txtBeneficiario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtBeneficiario.FocusHighlightEnabled = true;
            this._txtBeneficiario.Location = new System.Drawing.Point(87, 62);
            this._txtBeneficiario.Multiline = true;
            this._txtBeneficiario.Name = "_txtBeneficiario";
            this._txtBeneficiario.ReadOnly = true;
            this._txtBeneficiario.Size = new System.Drawing.Size(601, 23);
            this._txtBeneficiario.TabIndex = 17;
            this._txtBeneficiario.WatermarkText = "Seleccione el beneficiario";
            this._txtBeneficiario.ButtonCustomClick += new System.EventHandler(this._txtBeneficiario_ButtonCustomClick);
            // 
            // _lblAnulado
            // 
            this._lblAnulado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAnulado.ForeColor = System.Drawing.Color.Red;
            this._lblAnulado.Location = new System.Drawing.Point(483, 9);
            this._lblAnulado.Name = "_lblAnulado";
            this._lblAnulado.Size = new System.Drawing.Size(90, 22);
            this._lblAnulado.TabIndex = 16;
            this._lblAnulado.Text = "[ ANULADO ]";
            this._lblAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtDiferencia
            // 
            this._txtDiferencia.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtDiferencia.Border.Class = "TextBoxBorder";
            this._txtDiferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtDiferencia.FocusHighlightEnabled = true;
            this._txtDiferencia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDiferencia.Location = new System.Drawing.Point(469, 148);
            this._txtDiferencia.Name = "_txtDiferencia";
            this._txtDiferencia.ReadOnly = true;
            this._txtDiferencia.Size = new System.Drawing.Size(109, 22);
            this._txtDiferencia.TabIndex = 14;
            this._txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spvValidador.SetValidator1(this._txtDiferencia, this.compareValidator1);
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
            this._dtpFecha.Location = new System.Drawing.Point(312, 34);
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
            this._dtpFecha.Size = new System.Drawing.Size(113, 22);
            this._dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._dtpFecha.TabIndex = 3;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Location = new System.Drawing.Point(400, 148);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(63, 22);
            this.lblDiferencia.TabIndex = 13;
            this.lblDiferencia.Text = "Diferencia";
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this._txtNumero.Location = new System.Drawing.Point(483, 34);
            this._txtNumero.Name = "_txtNumero";
            this._txtNumero.ReadOnly = true;
            this._txtNumero.Size = new System.Drawing.Size(90, 22);
            this._txtNumero.TabIndex = 15;
            this._txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtValorHaber
            // 
            this._txtValorHaber.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtValorHaber.Border.Class = "TextBoxBorder";
            this._txtValorHaber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtValorHaber.FocusHighlightEnabled = true;
            this._txtValorHaber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtValorHaber.Location = new System.Drawing.Point(268, 148);
            this._txtValorHaber.Name = "_txtValorHaber";
            this._txtValorHaber.ReadOnly = true;
            this._txtValorHaber.Size = new System.Drawing.Size(109, 22);
            this._txtValorHaber.TabIndex = 12;
            this._txtValorHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(202, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Haber";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtDetalle
            // 
            // 
            // 
            // 
            this._txtDetalle.Border.Class = "TextBoxBorder";
            this._txtDetalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtDetalle.FocusHighlightEnabled = true;
            this._txtDetalle.Location = new System.Drawing.Point(88, 90);
            this._txtDetalle.Multiline = true;
            this._txtDetalle.Name = "_txtDetalle";
            this._txtDetalle.ReadOnly = true;
            this._txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDetalle.Size = new System.Drawing.Size(600, 52);
            this._txtDetalle.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(268, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtValorDebe
            // 
            this._txtValorDebe.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this._txtValorDebe.Border.Class = "TextBoxBorder";
            this._txtValorDebe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtValorDebe.FocusHighlightEnabled = true;
            this._txtValorDebe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtValorDebe.Location = new System.Drawing.Point(88, 148);
            this._txtValorDebe.Name = "_txtValorDebe";
            this._txtValorDebe.ReadOnly = true;
            this._txtValorDebe.Size = new System.Drawing.Size(109, 22);
            this._txtValorDebe.TabIndex = 10;
            this._txtValorDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(22, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Debe";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(429, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "Número";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Location = new System.Drawing.Point(7, 90);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(78, 22);
            this.lblDetalle.TabIndex = 7;
            this.lblDetalle.Text = "Detalle";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBeneficiario
            // 
            this.lblBeneficiario.Location = new System.Drawing.Point(7, 62);
            this.lblBeneficiario.Name = "lblBeneficiario";
            this.lblBeneficiario.Size = new System.Drawing.Size(78, 22);
            this.lblBeneficiario.TabIndex = 4;
            this.lblBeneficiario.Text = "Beneficiario";
            this.lblBeneficiario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoContable
            // 
            this.lblTipoContable.Location = new System.Drawing.Point(7, 34);
            this.lblTipoContable.Name = "lblTipoContable";
            this.lblTipoContable.Size = new System.Drawing.Size(78, 22);
            this.lblTipoContable.TabIndex = 0;
            this.lblTipoContable.Text = "Tipo";
            this.lblTipoContable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cboTipo
            // 
            this._cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTipo.Enabled = false;
            this._cboTipo.FormattingEnabled = true;
            this._cboTipo.ItemHeight = 16;
            this._cboTipo.Location = new System.Drawing.Point(88, 34);
            this._cboTipo.Name = "_cboTipo";
            this._cboTipo.Size = new System.Drawing.Size(181, 22);
            this._cboTipo.TabIndex = 1;
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
            this.superTabControlPanel2.Size = new System.Drawing.Size(715, 431);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabLista;
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
            // _dgrFKDetallesOrdenesPedido
            // 
            this._dgrFKDetallesOrdenesPedido.AllowUserToAddRows = false;
            this._dgrFKDetallesOrdenesPedido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._dgrFKDetallesOrdenesPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgrFKDetallesOrdenesPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgrFKDetallesOrdenesPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgrFKDetallesOrdenesPedido.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgrFKDetallesOrdenesPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgrFKDetallesOrdenesPedido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._dgrFKDetallesOrdenesPedido.Location = new System.Drawing.Point(0, 183);
            this._dgrFKDetallesOrdenesPedido.Name = "_dgrFKDetallesOrdenesPedido";
            this._dgrFKDetallesOrdenesPedido.PermitirEventosInternos = false;
            this._dgrFKDetallesOrdenesPedido.RowHeadersWidth = 25;
            this._dgrFKDetallesOrdenesPedido.Size = new System.Drawing.Size(715, 223);
            this._dgrFKDetallesOrdenesPedido.TabIndex = 1;
            this._dgrFKDetallesOrdenesPedido.AntesBuscarCell += new Proveedores.AntesBuscarCellEventHandler(this._dgrFKDetallesOrdenesPedido_AntesBuscarCell);
            this._dgrFKDetallesOrdenesPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgrFKDetallesOrdenesPedido_CellEndEdit);
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
            this.dgrLista.Size = new System.Drawing.Size(715, 301);
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
            // compareValidator1
            // 
            this.compareValidator1.ErrorMessage = "Your error message here.";
            this.compareValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.compareValidator1.ValueToCompare = "0";
            // 
            // Contables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(715, 431);
            this.Controls.Add(this.stcEdiciones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Contables";
            this.Text = "Orden de pedido";
            this.Activated += new System.EventHandler(this.OrdenesPedido_Activated);
            this.Load += new System.EventHandler(this.OrdenesPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).EndInit();
            this.stcEdiciones.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.gpbCabecera.ResumeLayout(false);
            this.gpbCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.pnlBusquedaAvanzada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpBuscarFecha)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesOrdenesPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
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
        private System.Windows.Forms.GroupBox gpbCabecera;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtBeneficiario;
        private System.Windows.Forms.Label _lblAnulado;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDiferencia;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFecha;
        private System.Windows.Forms.Label lblDiferencia;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtNumero;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtValorHaber;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDetalle;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtValorDebe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.Label lblTipoContable;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboTipo;
        private System.Windows.Forms.CheckBox chkEditable;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colVer;
        private DevComponents.DotNetBar.Validator.CompareValidator compareValidator1;
    }
}