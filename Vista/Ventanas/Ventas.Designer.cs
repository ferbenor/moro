namespace WindowsApp
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
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
            this._dgrFKDetallesVenta = new Proveedores.DgvPlus();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblIva12 = new System.Windows.Forms.Label();
            this.lblSubtotal12 = new System.Windows.Forms.Label();
            this._txtTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDescuento = new System.Windows.Forms.Label();
            this._txtIva = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSubtotal0 = new System.Windows.Forms.Label();
            this._txtSubtotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTotal = new System.Windows.Forms.Label();
            this._txtDescuento = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtSubtotalGrabado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtSubtotalNoGrabado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this._txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._cboLugar = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblNumero = new System.Windows.Forms.Label();
            this._txtTelefono = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRuc = new System.Windows.Forms.Label();
            this._lblAnulado = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this._txtDireccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLugar = new System.Windows.Forms.Label();
            this.lbldireccion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.chkEditable = new System.Windows.Forms.CheckBox();
            this._txtCliente = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesVenta)).BeginInit();
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
            this.stcEdiciones.Size = new System.Drawing.Size(715, 375);
            this.stcEdiciones.TabIndex = 0;
            this.stcEdiciones.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabEdicion,
            this.tabLista});
            this.stcEdiciones.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this._dgrFKDetallesVenta);
            this.superTabControlPanel1.Controls.Add(this.pnlPie);
            this.superTabControlPanel1.Controls.Add(this.gpbCabecera);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(715, 350);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEdicion;
            // 
            // _dgrFKDetallesVenta
            // 
            this._dgrFKDetallesVenta.AllowUserToAddRows = false;
            this._dgrFKDetallesVenta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._dgrFKDetallesVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgrFKDetallesVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgrFKDetallesVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgrFKDetallesVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgrFKDetallesVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgrFKDetallesVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._dgrFKDetallesVenta.Location = new System.Drawing.Point(0, 133);
            this._dgrFKDetallesVenta.Name = "_dgrFKDetallesVenta";
            this._dgrFKDetallesVenta.PermitirEventosInternos = false;
            this._dgrFKDetallesVenta.RowHeadersWidth = 25;
            this._dgrFKDetallesVenta.Size = new System.Drawing.Size(715, 142);
            this._dgrFKDetallesVenta.TabIndex = 1;
            this._dgrFKDetallesVenta.AntesBuscarCell += new Proveedores.AntesBuscarCellEventHandler(this._dgrFKDetallesVenta_AntesBuscarCell);
            this._dgrFKDetallesVenta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgrFKDetallesVenta_CellEndEdit);
            this._dgrFKDetallesVenta.Leave += new System.EventHandler(this._dgrFKDetallesVenta_Leave);
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblSubtotal);
            this.pnlPie.Controls.Add(this.lblIva12);
            this.pnlPie.Controls.Add(this.lblSubtotal12);
            this.pnlPie.Controls.Add(this._txtTotal);
            this.pnlPie.Controls.Add(this.lblDescuento);
            this.pnlPie.Controls.Add(this._txtIva);
            this.pnlPie.Controls.Add(this.lblSubtotal0);
            this.pnlPie.Controls.Add(this._txtSubtotal);
            this.pnlPie.Controls.Add(this.lblTotal);
            this.pnlPie.Controls.Add(this._txtDescuento);
            this.pnlPie.Controls.Add(this._txtSubtotalGrabado);
            this.pnlPie.Controls.Add(this._txtSubtotalNoGrabado);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 275);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(715, 75);
            this.pnlPie.TabIndex = 3;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal.Location = new System.Drawing.Point(194, 13);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(78, 22);
            this.lblSubtotal.TabIndex = 2;
            this.lblSubtotal.Text = "Subtotal:";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIva12
            // 
            this.lblIva12.BackColor = System.Drawing.Color.Transparent;
            this.lblIva12.Location = new System.Drawing.Point(194, 41);
            this.lblIva12.Name = "lblIva12";
            this.lblIva12.Size = new System.Drawing.Size(78, 22);
            this.lblIva12.TabIndex = 8;
            this.lblIva12.Text = "Iva 12%:";
            this.lblIva12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal12
            // 
            this.lblSubtotal12.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal12.Location = new System.Drawing.Point(8, 13);
            this.lblSubtotal12.Name = "lblSubtotal12";
            this.lblSubtotal12.Size = new System.Drawing.Size(78, 22);
            this.lblSubtotal12.TabIndex = 0;
            this.lblSubtotal12.Text = "Subtotal 12%:";
            this.lblSubtotal12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtTotal
            // 
            // 
            // 
            // 
            this._txtTotal.Border.Class = "TextBoxBorder";
            this._txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTotal.Location = new System.Drawing.Point(487, 41);
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
            this.lblDescuento.Location = new System.Drawing.Point(405, 13);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(78, 22);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "Descuento:";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtIva
            // 
            // 
            // 
            // 
            this._txtIva.Border.Class = "TextBoxBorder";
            this._txtIva.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtIva.Location = new System.Drawing.Point(278, 41);
            this._txtIva.MaxLength = 10;
            this._txtIva.Name = "_txtIva";
            this._txtIva.ReadOnly = true;
            this._txtIva.Size = new System.Drawing.Size(88, 22);
            this._txtIva.TabIndex = 9;
            this._txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal0
            // 
            this.lblSubtotal0.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal0.Location = new System.Drawing.Point(8, 41);
            this.lblSubtotal0.Name = "lblSubtotal0";
            this.lblSubtotal0.Size = new System.Drawing.Size(78, 22);
            this.lblSubtotal0.TabIndex = 6;
            this.lblSubtotal0.Text = "Subtotal 0%:";
            this.lblSubtotal0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtSubtotal
            // 
            // 
            // 
            // 
            this._txtSubtotal.Border.Class = "TextBoxBorder";
            this._txtSubtotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtSubtotal.Location = new System.Drawing.Point(278, 13);
            this._txtSubtotal.MaxLength = 10;
            this._txtSubtotal.Name = "_txtSubtotal";
            this._txtSubtotal.ReadOnly = true;
            this._txtSubtotal.Size = new System.Drawing.Size(88, 22);
            this._txtSubtotal.TabIndex = 3;
            this._txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(405, 41);
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
            this._txtDescuento.Location = new System.Drawing.Point(487, 13);
            this._txtDescuento.MaxLength = 10;
            this._txtDescuento.Name = "_txtDescuento";
            this._txtDescuento.Size = new System.Drawing.Size(88, 22);
            this._txtDescuento.TabIndex = 5;
            this._txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtSubtotalGrabado
            // 
            // 
            // 
            // 
            this._txtSubtotalGrabado.Border.Class = "TextBoxBorder";
            this._txtSubtotalGrabado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtSubtotalGrabado.Location = new System.Drawing.Point(90, 13);
            this._txtSubtotalGrabado.MaxLength = 10;
            this._txtSubtotalGrabado.Name = "_txtSubtotalGrabado";
            this._txtSubtotalGrabado.ReadOnly = true;
            this._txtSubtotalGrabado.Size = new System.Drawing.Size(88, 22);
            this._txtSubtotalGrabado.TabIndex = 1;
            this._txtSubtotalGrabado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtSubtotalNoGrabado
            // 
            // 
            // 
            // 
            this._txtSubtotalNoGrabado.Border.Class = "TextBoxBorder";
            this._txtSubtotalNoGrabado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtSubtotalNoGrabado.Location = new System.Drawing.Point(90, 41);
            this._txtSubtotalNoGrabado.MaxLength = 10;
            this._txtSubtotalNoGrabado.Name = "_txtSubtotalNoGrabado";
            this._txtSubtotalNoGrabado.ReadOnly = true;
            this._txtSubtotalNoGrabado.Size = new System.Drawing.Size(88, 22);
            this._txtSubtotalNoGrabado.TabIndex = 7;
            this._txtSubtotalNoGrabado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this._txtNumero);
            this.gpbCabecera.Controls.Add(this._cboLugar);
            this.gpbCabecera.Controls.Add(this.lblNumero);
            this.gpbCabecera.Controls.Add(this._txtTelefono);
            this.gpbCabecera.Controls.Add(this.lblRuc);
            this.gpbCabecera.Controls.Add(this._lblAnulado);
            this.gpbCabecera.Controls.Add(this.lblTelefono);
            this.gpbCabecera.Controls.Add(this._txtDireccion);
            this.gpbCabecera.Controls.Add(this.lblLugar);
            this.gpbCabecera.Controls.Add(this.lbldireccion);
            this.gpbCabecera.Controls.Add(this.lblFecha);
            this.gpbCabecera.Controls.Add(this._dtpFecha);
            this.gpbCabecera.Controls.Add(this.chkEditable);
            this.gpbCabecera.Controls.Add(this._txtCliente);
            this.gpbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCabecera.Location = new System.Drawing.Point(0, 0);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(715, 133);
            this.gpbCabecera.TabIndex = 2;
            this.gpbCabecera.TabStop = false;
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
            this._txtNumero.Location = new System.Drawing.Point(87, 13);
            this._txtNumero.Name = "_txtNumero";
            this._txtNumero.ReadOnly = true;
            this._txtNumero.Size = new System.Drawing.Size(96, 22);
            this._txtNumero.TabIndex = 21;
            this._txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cboLugar
            // 
            this._cboLugar.DisplayMember = "Text";
            this._cboLugar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboLugar.FormattingEnabled = true;
            this._cboLugar.ItemHeight = 16;
            this._cboLugar.Location = new System.Drawing.Point(87, 97);
            this._cboLugar.Name = "_cboLugar";
            this._cboLugar.Size = new System.Drawing.Size(291, 22);
            this._cboLugar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._cboLugar.TabIndex = 31;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(6, 13);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(78, 22);
            this.lblNumero.TabIndex = 20;
            this.lblNumero.Text = "Número:";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtTelefono
            // 
            // 
            // 
            // 
            this._txtTelefono.Border.Class = "TextBoxBorder";
            this._txtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTelefono.Location = new System.Drawing.Point(469, 97);
            this._txtTelefono.MaxLength = 13;
            this._txtTelefono.Name = "_txtTelefono";
            this._txtTelefono.ReadOnly = true;
            this._txtTelefono.Size = new System.Drawing.Size(102, 22);
            this._txtTelefono.TabIndex = 33;
            // 
            // lblRuc
            // 
            this.lblRuc.Location = new System.Drawing.Point(6, 41);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(78, 22);
            this.lblRuc.TabIndex = 24;
            this.lblRuc.Text = "Cliente:";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblAnulado
            // 
            this._lblAnulado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAnulado.ForeColor = System.Drawing.Color.Red;
            this._lblAnulado.Location = new System.Drawing.Point(481, 12);
            this._lblAnulado.Name = "_lblAnulado";
            this._lblAnulado.Size = new System.Drawing.Size(90, 22);
            this._lblAnulado.TabIndex = 19;
            this._lblAnulado.Text = "[ ANULADO ]";
            this._lblAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblAnulado.Visible = false;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(403, 97);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 22);
            this.lblTelefono.TabIndex = 32;
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtDireccion
            // 
            // 
            // 
            // 
            this._txtDireccion.Border.Class = "TextBoxBorder";
            this._txtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtDireccion.FocusHighlightEnabled = true;
            this._txtDireccion.Location = new System.Drawing.Point(87, 69);
            this._txtDireccion.MaxLength = 200;
            this._txtDireccion.Name = "_txtDireccion";
            this._txtDireccion.ReadOnly = true;
            this._txtDireccion.Size = new System.Drawing.Size(484, 22);
            this._txtDireccion.TabIndex = 29;
            // 
            // lblLugar
            // 
            this.lblLugar.Location = new System.Drawing.Point(6, 97);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(78, 22);
            this.lblLugar.TabIndex = 30;
            this.lblLugar.Text = "Lugar:";
            this.lblLugar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldireccion
            // 
            this.lbldireccion.Location = new System.Drawing.Point(6, 69);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(78, 22);
            this.lbldireccion.TabIndex = 28;
            this.lbldireccion.Text = "Dirección:";
            this.lbldireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(189, 13);
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
            this._dtpFecha.Location = new System.Drawing.Point(253, 13);
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
            this._dtpFecha.TabIndex = 23;
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
            // _txtCliente
            // 
            this._txtCliente.AutoSelectAll = true;
            // 
            // 
            // 
            this._txtCliente.Border.Class = "TextBoxBorder";
            this._txtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtCliente.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this._txtCliente.ButtonCustom.Visible = true;
            this._txtCliente.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this._txtCliente.ButtonCustom2.Visible = true;
            this._txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtCliente.FocusHighlightEnabled = true;
            this._txtCliente.Location = new System.Drawing.Point(87, 41);
            this._txtCliente.Multiline = true;
            this._txtCliente.Name = "_txtCliente";
            this._txtCliente.ReadOnly = true;
            this._txtCliente.Size = new System.Drawing.Size(484, 23);
            this._txtCliente.TabIndex = 17;
            this._txtCliente.WatermarkText = "Seleccione un cliente";
            this._txtCliente.ButtonCustomClick += new System.EventHandler(this._txtCliente_ButtonCustomClick);
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
            this.superTabControlPanel2.Size = new System.Drawing.Size(715, 375);
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
            this.dgrLista.Size = new System.Drawing.Size(715, 245);
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
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(715, 375);
            this.Controls.Add(this.stcEdiciones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.Activated += new System.EventHandler(this.Ventas_Activated);
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).EndInit();
            this.stcEdiciones.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgrFKDetallesVenta)).EndInit();
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
        private Proveedores.DgvPlus _dgrFKDetallesVenta;
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
        private DevComponents.DotNetBar.Controls.TextBoxX _txtCliente;
        private System.Windows.Forms.CheckBox chkEditable;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colVer;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtNumero;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboLugar;
        private System.Windows.Forms.Label lblNumero;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTelefono;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label _lblAnulado;
        private System.Windows.Forms.Label lblTelefono;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDireccion;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.Label lbldireccion;
        private System.Windows.Forms.Label lblFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFecha;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblIva12;
        private System.Windows.Forms.Label lblSubtotal12;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTotal;
        private System.Windows.Forms.Label lblDescuento;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtIva;
        private System.Windows.Forms.Label lblSubtotal0;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDescuento;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtSubtotalGrabado;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtSubtotalNoGrabado;
    }
}