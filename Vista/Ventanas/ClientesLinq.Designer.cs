namespace WindowsApp
{
    partial class ClientesLinq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesLinq));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this._txtReferenciaDireccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador01 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this._txtBarrioRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador07 = new DevComponents.DotNetBar.Validator.CompareValidator();
            this._txtRazonSocial = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador04 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this._txtApellido = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador05 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this._txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador06 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this._txtIdentificacionSN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rfvValidador03 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this._cboTipoDocumento = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.rfvValidador02 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este dato es requerido");
            this.txtBusqueda = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFiltro = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._cboIdEstadoCivil = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this._cboGenero = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this._txtFKProfesioneRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtInformacionAdicional = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtFKConyugeRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblConyuge = new System.Windows.Forms.Label();
            this.lblProfesion = new System.Windows.Forms.Label();
            this.lblInfAdicional = new System.Windows.Forms.Label();
            this._txtCorreo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this._txtCelularSN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCelular = new System.Windows.Forms.Label();
            this._txtTelefonoSN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.ofdDialogo = new System.Windows.Forms.OpenFileDialog();
            this.stcInformacion = new DevComponents.DotNetBar.SuperTabControl();
            this.pnlDatosPersonales = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this._bbqBarrio = new WindowsApp.ButtonBQ();
            this.pnlDatosNatural = new System.Windows.Forms.Panel();
            this._bbqConyugue = new WindowsApp.ButtonBQ();
            this._bbqProfesion = new WindowsApp.ButtonBQ();
            this.tabDatosPersonales = new DevComponents.DotNetBar.SuperTabItem();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.stcEdiciones = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this._btnQuitarFoto = new DevComponents.DotNetBar.ButtonX();
            this.lblTipoPersona = new System.Windows.Forms.Label();
            this._lblEstado = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this._cboTipoPersona = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblApellido = new System.Windows.Forms.Label();
            this._btnCargarFoto = new DevComponents.DotNetBar.ButtonX();
            this._picFoto = new System.Windows.Forms.PictureBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this._dtpFechaIngreso = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this._txtIdRO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblIdenfificacion = new System.Windows.Forms.Label();
            this.tabEdicion = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgrLista = new Proveedores.DgvPlus();
            this.colVer = new System.Windows.Forms.DataGridViewImageColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLista = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcInformacion)).BeginInit();
            this.stcInformacion.SuspendLayout();
            this.pnlDatosPersonales.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlDatosNatural.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).BeginInit();
            this.stcEdiciones.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFechaIngreso)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
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
            // _txtReferenciaDireccion
            // 
            // 
            // 
            // 
            this._txtReferenciaDireccion.Border.Class = "TextBoxBorder";
            this._txtReferenciaDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtReferenciaDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtReferenciaDireccion.FocusHighlightEnabled = true;
            this._txtReferenciaDireccion.Location = new System.Drawing.Point(105, 60);
            this._txtReferenciaDireccion.Name = "_txtReferenciaDireccion";
            this._txtReferenciaDireccion.Size = new System.Drawing.Size(588, 22);
            this._txtReferenciaDireccion.TabIndex = 8;
            this.spvValidador.SetValidator1(this._txtReferenciaDireccion, this.rfvValidador01);
            // 
            // rfvValidador01
            // 
            this.rfvValidador01.ErrorMessage = "Este dato es requerido";
            this.rfvValidador01.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // _txtBarrioRO
            // 
            // 
            // 
            // 
            this._txtBarrioRO.Border.Class = "TextBoxBorder";
            this._txtBarrioRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtBarrioRO.FocusHighlightEnabled = true;
            this._txtBarrioRO.Location = new System.Drawing.Point(105, 32);
            this._txtBarrioRO.Name = "_txtBarrioRO";
            this._txtBarrioRO.ReadOnly = true;
            this._txtBarrioRO.Size = new System.Drawing.Size(524, 22);
            this._txtBarrioRO.TabIndex = 5;
            this.spvValidador.SetValidator1(this._txtBarrioRO, this.rfvValidador07);
            // 
            // rfvValidador07
            // 
            this.rfvValidador07.ErrorMessage = "Este dato es requerido";
            this.rfvValidador07.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.rfvValidador07.Operator = DevComponents.DotNetBar.Validator.eValidationCompareOperator.NotEqual;
            this.rfvValidador07.ValueToCompare = "Seleccione";
            // 
            // _txtRazonSocial
            // 
            // 
            // 
            // 
            this._txtRazonSocial.Border.Class = "TextBoxBorder";
            this._txtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtRazonSocial.FocusHighlightEnabled = true;
            this._txtRazonSocial.Location = new System.Drawing.Point(104, 95);
            this._txtRazonSocial.Name = "_txtRazonSocial";
            this._txtRazonSocial.Size = new System.Drawing.Size(365, 22);
            this._txtRazonSocial.TabIndex = 12;
            this.spvValidador.SetValidator1(this._txtRazonSocial, this.rfvValidador04);
            // 
            // rfvValidador04
            // 
            this.rfvValidador04.ErrorMessage = "Este dato es requerido";
            this.rfvValidador04.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // _txtApellido
            // 
            // 
            // 
            // 
            this._txtApellido.Border.Class = "TextBoxBorder";
            this._txtApellido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtApellido.FocusHighlightEnabled = true;
            this._txtApellido.Location = new System.Drawing.Point(104, 123);
            this._txtApellido.Name = "_txtApellido";
            this._txtApellido.Size = new System.Drawing.Size(226, 22);
            this._txtApellido.TabIndex = 15;
            this.spvValidador.SetValidator1(this._txtApellido, this.rfvValidador05);
            // 
            // rfvValidador05
            // 
            this.rfvValidador05.ErrorMessage = "Este dato es requerido";
            this.rfvValidador05.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // _txtNombre
            // 
            // 
            // 
            // 
            this._txtNombre.Border.Class = "TextBoxBorder";
            this._txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtNombre.FocusHighlightEnabled = true;
            this._txtNombre.Location = new System.Drawing.Point(104, 151);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(226, 22);
            this._txtNombre.TabIndex = 17;
            this.spvValidador.SetValidator1(this._txtNombre, this.rfvValidador06);
            // 
            // rfvValidador06
            // 
            this.rfvValidador06.ErrorMessage = "Este dato es requerido";
            this.rfvValidador06.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // _txtIdentificacionSN
            // 
            // 
            // 
            // 
            this._txtIdentificacionSN.Border.Class = "TextBoxBorder";
            this._txtIdentificacionSN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtIdentificacionSN.FocusHighlightEnabled = true;
            this._txtIdentificacionSN.Location = new System.Drawing.Point(104, 67);
            this._txtIdentificacionSN.MaxLength = 13;
            this._txtIdentificacionSN.Name = "_txtIdentificacionSN";
            this._txtIdentificacionSN.Size = new System.Drawing.Size(113, 22);
            this._txtIdentificacionSN.TabIndex = 10;
            this.spvValidador.SetValidator1(this._txtIdentificacionSN, this.rfvValidador03);
            this._txtIdentificacionSN.Leave += new System.EventHandler(this._txtIdentificacionSN_Leave);
            // 
            // rfvValidador03
            // 
            this.rfvValidador03.ErrorMessage = "Este dato es requerido";
            this.rfvValidador03.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // _cboTipoDocumento
            // 
            this._cboTipoDocumento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTipoDocumento.FormattingEnabled = true;
            this._cboTipoDocumento.ItemHeight = 16;
            this._cboTipoDocumento.Location = new System.Drawing.Point(356, 39);
            this._cboTipoDocumento.Name = "_cboTipoDocumento";
            this._cboTipoDocumento.Size = new System.Drawing.Size(113, 22);
            this._cboTipoDocumento.TabIndex = 7;
            this.spvValidador.SetValidator1(this._cboTipoDocumento, this.rfvValidador02);
            // 
            // rfvValidador02
            // 
            this.rfvValidador02.ErrorMessage = "Este dato es requerido";
            this.rfvValidador02.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // txtBusqueda
            // 
            // 
            // 
            // 
            this.txtBusqueda.Border.Class = "TextBoxBorder";
            this.txtBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.FocusHighlightEnabled = true;
            this.txtBusqueda.Location = new System.Drawing.Point(65, 41);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(313, 22);
            this.txtBusqueda.TabIndex = 2;
            this.spvValidador.SetValidator1(this.txtBusqueda, this.rfvValidador04);
            this.txtBusqueda.WatermarkText = "Ingrese el apellido o nombre de cliente que desea buscar";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // txtFiltro
            // 
            // 
            // 
            // 
            this.txtFiltro.Border.Class = "TextBoxBorder";
            this.txtFiltro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltro.FocusHighlightEnabled = true;
            this.txtFiltro.Location = new System.Drawing.Point(390, 5);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(313, 22);
            this.txtFiltro.TabIndex = 5;
            this.spvValidador.SetValidator1(this.txtFiltro, this.rfvValidador04);
            this.txtFiltro.WatermarkText = "Ingrese el apellido o nombre de cliente que desea buscar";
            this.txtFiltro.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            // 
            // _cboIdEstadoCivil
            // 
            this._cboIdEstadoCivil.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboIdEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboIdEstadoCivil.FormattingEnabled = true;
            this._cboIdEstadoCivil.ItemHeight = 16;
            this._cboIdEstadoCivil.Location = new System.Drawing.Point(105, 38);
            this._cboIdEstadoCivil.Name = "_cboIdEstadoCivil";
            this._cboIdEstadoCivil.Size = new System.Drawing.Size(147, 22);
            this._cboIdEstadoCivil.TabIndex = 3;
            this._cboIdEstadoCivil.SelectedIndexChanged += new System.EventHandler(this._cboEstadoCivil_SelectedIndexChanged);
            // 
            // _cboGenero
            // 
            this._cboGenero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboGenero.FormattingEnabled = true;
            this._cboGenero.ItemHeight = 16;
            this._cboGenero.Location = new System.Drawing.Point(105, 10);
            this._cboGenero.Name = "_cboGenero";
            this._cboGenero.Size = new System.Drawing.Size(129, 22);
            this._cboGenero.TabIndex = 1;
            // 
            // _txtFKProfesioneRO
            // 
            // 
            // 
            // 
            this._txtFKProfesioneRO.Border.Class = "TextBoxBorder";
            this._txtFKProfesioneRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtFKProfesioneRO.FocusHighlightEnabled = true;
            this._txtFKProfesioneRO.Location = new System.Drawing.Point(105, 94);
            this._txtFKProfesioneRO.Name = "_txtFKProfesioneRO";
            this._txtFKProfesioneRO.ReadOnly = true;
            this._txtFKProfesioneRO.Size = new System.Drawing.Size(292, 22);
            this._txtFKProfesioneRO.TabIndex = 8;
            // 
            // _txtInformacionAdicional
            // 
            // 
            // 
            // 
            this._txtInformacionAdicional.Border.Class = "TextBoxBorder";
            this._txtInformacionAdicional.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtInformacionAdicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtInformacionAdicional.FocusHighlightEnabled = true;
            this._txtInformacionAdicional.Location = new System.Drawing.Point(104, 88);
            this._txtInformacionAdicional.Multiline = true;
            this._txtInformacionAdicional.Name = "_txtInformacionAdicional";
            this._txtInformacionAdicional.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtInformacionAdicional.Size = new System.Drawing.Size(588, 32);
            this._txtInformacionAdicional.TabIndex = 10;
            // 
            // _txtFKConyugeRO
            // 
            // 
            // 
            // 
            this._txtFKConyugeRO.Border.Class = "TextBoxBorder";
            this._txtFKConyugeRO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtFKConyugeRO.FocusHighlightEnabled = true;
            this._txtFKConyugeRO.Location = new System.Drawing.Point(105, 66);
            this._txtFKConyugeRO.Name = "_txtFKConyugeRO";
            this._txtFKConyugeRO.ReadOnly = true;
            this._txtFKConyugeRO.Size = new System.Drawing.Size(292, 22);
            this._txtFKConyugeRO.TabIndex = 5;
            // 
            // lblConyuge
            // 
            this.lblConyuge.BackColor = System.Drawing.Color.Transparent;
            this.lblConyuge.Location = new System.Drawing.Point(5, 66);
            this.lblConyuge.Name = "lblConyuge";
            this.lblConyuge.Size = new System.Drawing.Size(96, 22);
            this.lblConyuge.TabIndex = 4;
            this.lblConyuge.Text = "Conyugue";
            this.lblConyuge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProfesion
            // 
            this.lblProfesion.BackColor = System.Drawing.Color.Transparent;
            this.lblProfesion.Location = new System.Drawing.Point(5, 94);
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Size = new System.Drawing.Size(96, 22);
            this.lblProfesion.TabIndex = 7;
            this.lblProfesion.Text = "Profesión";
            this.lblProfesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfAdicional
            // 
            this.lblInfAdicional.BackColor = System.Drawing.Color.Transparent;
            this.lblInfAdicional.Location = new System.Drawing.Point(13, 88);
            this.lblInfAdicional.Name = "lblInfAdicional";
            this.lblInfAdicional.Size = new System.Drawing.Size(87, 32);
            this.lblInfAdicional.TabIndex = 9;
            this.lblInfAdicional.Text = "Información adicional";
            this.lblInfAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtCorreo
            // 
            // 
            // 
            // 
            this._txtCorreo.Border.Class = "TextBoxBorder";
            this._txtCorreo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this._txtCorreo.FocusHighlightEnabled = true;
            this._txtCorreo.Location = new System.Drawing.Point(104, 122);
            this._txtCorreo.Name = "_txtCorreo";
            this._txtCorreo.Size = new System.Drawing.Size(293, 22);
            this._txtCorreo.TabIndex = 11;
            // 
            // lblCorreo
            // 
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.Location = new System.Drawing.Point(4, 122);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(96, 22);
            this.lblCorreo.TabIndex = 10;
            this.lblCorreo.Text = "e-mail";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.Location = new System.Drawing.Point(5, 60);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(96, 22);
            this.lblDireccion.TabIndex = 7;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtCelularSN
            // 
            // 
            // 
            // 
            this._txtCelularSN.Border.Class = "TextBoxBorder";
            this._txtCelularSN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtCelularSN.FocusHighlightEnabled = true;
            this._txtCelularSN.Location = new System.Drawing.Point(291, 4);
            this._txtCelularSN.MaxLength = 10;
            this._txtCelularSN.Name = "_txtCelularSN";
            this._txtCelularSN.Size = new System.Drawing.Size(115, 22);
            this._txtCelularSN.TabIndex = 3;
            // 
            // lblCelular
            // 
            this.lblCelular.BackColor = System.Drawing.Color.Transparent;
            this.lblCelular.Location = new System.Drawing.Point(226, 4);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(61, 22);
            this.lblCelular.TabIndex = 2;
            this.lblCelular.Text = "Celular";
            this.lblCelular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtTelefonoSN
            // 
            // 
            // 
            // 
            this._txtTelefonoSN.Border.Class = "TextBoxBorder";
            this._txtTelefonoSN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtTelefonoSN.FocusHighlightEnabled = true;
            this._txtTelefonoSN.Location = new System.Drawing.Point(105, 4);
            this._txtTelefonoSN.MaxLength = 10;
            this._txtTelefonoSN.Name = "_txtTelefonoSN";
            this._txtTelefonoSN.Size = new System.Drawing.Size(115, 22);
            this._txtTelefonoSN.TabIndex = 1;
            // 
            // lblTelefono
            // 
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Location = new System.Drawing.Point(5, 4);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(96, 22);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Telefono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoCivil.Location = new System.Drawing.Point(5, 38);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(96, 22);
            this.lblEstadoCivil.TabIndex = 2;
            this.lblEstadoCivil.Text = "Estado civil";
            this.lblEstadoCivil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBarrio
            // 
            this.lblBarrio.BackColor = System.Drawing.Color.Transparent;
            this.lblBarrio.Location = new System.Drawing.Point(5, 32);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(96, 22);
            this.lblBarrio.TabIndex = 4;
            this.lblBarrio.Text = "Barrio";
            this.lblBarrio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGenero
            // 
            this.lblGenero.BackColor = System.Drawing.Color.Transparent;
            this.lblGenero.Location = new System.Drawing.Point(5, 10);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(96, 22);
            this.lblGenero.TabIndex = 0;
            this.lblGenero.Text = "Género";
            this.lblGenero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ofdDialogo
            // 
            this.ofdDialogo.DefaultExt = "Jpg";
            this.ofdDialogo.FileName = "Foto";
            this.ofdDialogo.Filter = "Archivos de imagen (*.Jpg, *.Bmp, *.Gif)|*.Jpg;*.Bmp;*.Gif";
            this.ofdDialogo.Title = "Seleccione Foto del cliente";
            // 
            // stcInformacion
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.stcInformacion.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stcInformacion.ControlBox.MenuBox.Name = "";
            this.stcInformacion.ControlBox.Name = "";
            this.stcInformacion.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stcInformacion.ControlBox.MenuBox,
            this.stcInformacion.ControlBox.CloseBox});
            this.stcInformacion.Controls.Add(this.pnlDatosPersonales);
            this.stcInformacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcInformacion.Location = new System.Drawing.Point(0, 179);
            this.stcInformacion.Name = "stcInformacion";
            this.stcInformacion.ReorderTabsEnabled = true;
            this.stcInformacion.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.stcInformacion.SelectedTabIndex = 0;
            this.stcInformacion.Size = new System.Drawing.Size(706, 297);
            this.stcInformacion.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stcInformacion.TabIndex = 1;
            this.stcInformacion.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabDatosPersonales});
            this.stcInformacion.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.stcInformacion.Text = "Información";
            // 
            // pnlDatosPersonales
            // 
            this.pnlDatosPersonales.Controls.Add(this.pnlDatos);
            this.pnlDatosPersonales.Controls.Add(this.pnlDatosNatural);
            this.pnlDatosPersonales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatosPersonales.Location = new System.Drawing.Point(0, 25);
            this.pnlDatosPersonales.Name = "pnlDatosPersonales";
            this.pnlDatosPersonales.Size = new System.Drawing.Size(706, 272);
            this.pnlDatosPersonales.TabIndex = 0;
            this.pnlDatosPersonales.TabItem = this.tabDatosPersonales;
            // 
            // pnlDatos
            // 
            this.pnlDatos.AutoScroll = true;
            this.pnlDatos.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatos.CausesValidation = false;
            this.pnlDatos.Controls.Add(this._txtCelularSN);
            this.pnlDatos.Controls.Add(this._bbqBarrio);
            this.pnlDatos.Controls.Add(this.lblDireccion);
            this.pnlDatos.Controls.Add(this.lblCelular);
            this.pnlDatos.Controls.Add(this._txtReferenciaDireccion);
            this.pnlDatos.Controls.Add(this._txtTelefonoSN);
            this.pnlDatos.Controls.Add(this._txtInformacionAdicional);
            this.pnlDatos.Controls.Add(this.lblTelefono);
            this.pnlDatos.Controls.Add(this.lblBarrio);
            this.pnlDatos.Controls.Add(this.lblInfAdicional);
            this.pnlDatos.Controls.Add(this._txtBarrioRO);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatos.Location = new System.Drawing.Point(0, 146);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(706, 126);
            this.pnlDatos.TabIndex = 1;
            // 
            // _bbqBarrio
            // 
            this._bbqBarrio.AutoSize = true;
            this._bbqBarrio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bbqBarrio.BackColor = System.Drawing.Color.Transparent;
            this._bbqBarrio.Location = new System.Drawing.Point(641, 29);
            this._bbqBarrio.Name = "_bbqBarrio";
            this._bbqBarrio.NombreObjeto = "Barrios";
            this._bbqBarrio.Size = new System.Drawing.Size(53, 28);
            this._bbqBarrio.TabIndex = 6;
            this._bbqBarrio.BotonPulsado += new WindowsApp.ButtonBQ.BotonPulsadoEventHandler(this.bbqBuscarQuitar_BotonPulsado);
            // 
            // pnlDatosNatural
            // 
            this.pnlDatosNatural.AutoScroll = true;
            this.pnlDatosNatural.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatosNatural.CausesValidation = false;
            this.pnlDatosNatural.Controls.Add(this._txtCorreo);
            this.pnlDatosNatural.Controls.Add(this._cboGenero);
            this.pnlDatosNatural.Controls.Add(this.lblGenero);
            this.pnlDatosNatural.Controls.Add(this._bbqConyugue);
            this.pnlDatosNatural.Controls.Add(this._cboIdEstadoCivil);
            this.pnlDatosNatural.Controls.Add(this._bbqProfesion);
            this.pnlDatosNatural.Controls.Add(this._txtFKConyugeRO);
            this.pnlDatosNatural.Controls.Add(this.lblConyuge);
            this.pnlDatosNatural.Controls.Add(this._txtFKProfesioneRO);
            this.pnlDatosNatural.Controls.Add(this.lblEstadoCivil);
            this.pnlDatosNatural.Controls.Add(this.lblCorreo);
            this.pnlDatosNatural.Controls.Add(this.lblProfesion);
            this.pnlDatosNatural.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatosNatural.Location = new System.Drawing.Point(0, 0);
            this.pnlDatosNatural.Name = "pnlDatosNatural";
            this.pnlDatosNatural.Size = new System.Drawing.Size(706, 146);
            this.pnlDatosNatural.TabIndex = 0;
            // 
            // _bbqConyugue
            // 
            this._bbqConyugue.AutoSize = true;
            this._bbqConyugue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bbqConyugue.BackColor = System.Drawing.Color.Transparent;
            this._bbqConyugue.Location = new System.Drawing.Point(409, 63);
            this._bbqConyugue.Name = "_bbqConyugue";
            this._bbqConyugue.NombreObjeto = "Conyugues";
            this._bbqConyugue.Size = new System.Drawing.Size(53, 28);
            this._bbqConyugue.TabIndex = 6;
            this._bbqConyugue.BotonPulsado += new WindowsApp.ButtonBQ.BotonPulsadoEventHandler(this.bbqBuscarQuitar_BotonPulsado);
            // 
            // _bbqProfesion
            // 
            this._bbqProfesion.AutoSize = true;
            this._bbqProfesion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bbqProfesion.BackColor = System.Drawing.Color.Transparent;
            this._bbqProfesion.Location = new System.Drawing.Point(409, 91);
            this._bbqProfesion.Name = "_bbqProfesion";
            this._bbqProfesion.NombreObjeto = "Profesiones";
            this._bbqProfesion.Size = new System.Drawing.Size(53, 28);
            this._bbqProfesion.TabIndex = 9;
            this._bbqProfesion.BotonPulsado += new WindowsApp.ButtonBQ.BotonPulsadoEventHandler(this.bbqBuscarQuitar_BotonPulsado);
            // 
            // tabDatosPersonales
            // 
            this.tabDatosPersonales.AttachedControl = this.pnlDatosPersonales;
            this.tabDatosPersonales.GlobalItem = false;
            this.tabDatosPersonales.Name = "tabDatosPersonales";
            this.tabDatosPersonales.Text = "Datos personales";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(384, 41);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(22, 22);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptarB_Click);
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
            this.stcEdiciones.Size = new System.Drawing.Size(706, 501);
            this.stcEdiciones.TabIndex = 0;
            this.stcEdiciones.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabEdicion,
            this.tabLista});
            this.stcEdiciones.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.stcInformacion);
            this.superTabControlPanel1.Controls.Add(this.pnlCabecera);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(706, 476);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEdicion;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.AutoScroll = true;
            this.pnlCabecera.BackColor = System.Drawing.Color.Transparent;
            this.pnlCabecera.Controls.Add(this._txtRazonSocial);
            this.pnlCabecera.Controls.Add(this.lblRazonSocial);
            this.pnlCabecera.Controls.Add(this._btnQuitarFoto);
            this.pnlCabecera.Controls.Add(this._txtApellido);
            this.pnlCabecera.Controls.Add(this.lblTipoPersona);
            this.pnlCabecera.Controls.Add(this._lblEstado);
            this.pnlCabecera.Controls.Add(this.lblFechaIngreso);
            this.pnlCabecera.Controls.Add(this._cboTipoPersona);
            this.pnlCabecera.Controls.Add(this.lblApellido);
            this.pnlCabecera.Controls.Add(this._btnCargarFoto);
            this.pnlCabecera.Controls.Add(this._txtNombre);
            this.pnlCabecera.Controls.Add(this._picFoto);
            this.pnlCabecera.Controls.Add(this.lblCodigo);
            this.pnlCabecera.Controls.Add(this._dtpFechaIngreso);
            this.pnlCabecera.Controls.Add(this._txtIdRO);
            this.pnlCabecera.Controls.Add(this.lblTipoDocumento);
            this.pnlCabecera.Controls.Add(this.lblNombre);
            this.pnlCabecera.Controls.Add(this._txtIdentificacionSN);
            this.pnlCabecera.Controls.Add(this.lblIdenfificacion);
            this.pnlCabecera.Controls.Add(this._cboTipoDocumento);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(706, 179);
            this.pnlCabecera.TabIndex = 0;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Location = new System.Drawing.Point(5, 95);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(96, 22);
            this.lblRazonSocial.TabIndex = 11;
            this.lblRazonSocial.Text = "Razon social";
            this.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _btnQuitarFoto
            // 
            this._btnQuitarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this._btnQuitarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this._btnQuitarFoto.Location = new System.Drawing.Point(593, 92);
            this._btnQuitarFoto.Name = "_btnQuitarFoto";
            this._btnQuitarFoto.Size = new System.Drawing.Size(65, 25);
            this._btnQuitarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._btnQuitarFoto.TabIndex = 13;
            this._btnQuitarFoto.Text = "Quitar";
            this._btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoPersona.Location = new System.Drawing.Point(5, 39);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(96, 22);
            this.lblTipoPersona.TabIndex = 4;
            this.lblTipoPersona.Text = "Persona";
            this.lblTipoPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblEstado
            // 
            this._lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEstado.Location = new System.Drawing.Point(349, 151);
            this._lblEstado.Name = "_lblEstado";
            this._lblEstado.Size = new System.Drawing.Size(120, 22);
            this._lblEstado.TabIndex = 18;
            this._lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.Location = new System.Drawing.Point(5, 11);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(96, 22);
            this.lblFechaIngreso.TabIndex = 0;
            this.lblFechaIngreso.Text = "Ingresa";
            this.lblFechaIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cboTipoPersona
            // 
            this._cboTipoPersona.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTipoPersona.FormattingEnabled = true;
            this._cboTipoPersona.ItemHeight = 16;
            this._cboTipoPersona.Location = new System.Drawing.Point(104, 39);
            this._cboTipoPersona.Name = "_cboTipoPersona";
            this._cboTipoPersona.Size = new System.Drawing.Size(147, 22);
            this._cboTipoPersona.TabIndex = 5;
            this._cboTipoPersona.SelectedIndexChanged += new System.EventHandler(this._cboTipoPersona_SelectedIndexChanged);
            // 
            // lblApellido
            // 
            this.lblApellido.Location = new System.Drawing.Point(5, 123);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(96, 22);
            this.lblApellido.TabIndex = 14;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _btnCargarFoto
            // 
            this._btnCargarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this._btnCargarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this._btnCargarFoto.Location = new System.Drawing.Point(593, 61);
            this._btnCargarFoto.Name = "_btnCargarFoto";
            this._btnCargarFoto.Size = new System.Drawing.Size(65, 25);
            this._btnCargarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._btnCargarFoto.TabIndex = 8;
            this._btnCargarFoto.Text = "Cargar";
            this._btnCargarFoto.Click += new System.EventHandler(this.btnCargarFoto_Click);
            // 
            // _picFoto
            // 
            this._picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._picFoto.Location = new System.Drawing.Point(490, 11);
            this._picFoto.Name = "_picFoto";
            this._picFoto.Size = new System.Drawing.Size(97, 106);
            this._picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picFoto.TabIndex = 22;
            this._picFoto.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(256, 11);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(96, 22);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Codigo";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dtpFechaIngreso
            // 
            // 
            // 
            // 
            this._dtpFechaIngreso.BackgroundStyle.Class = "DateTimeInputBackground";
            this._dtpFechaIngreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFechaIngreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this._dtpFechaIngreso.ButtonDropDown.Visible = true;
            this._dtpFechaIngreso.CustomFormat = "dd MMM yyyy";
            this._dtpFechaIngreso.Enabled = false;
            this._dtpFechaIngreso.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this._dtpFechaIngreso.IsPopupCalendarOpen = false;
            this._dtpFechaIngreso.Location = new System.Drawing.Point(104, 11);
            // 
            // 
            // 
            this._dtpFechaIngreso.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._dtpFechaIngreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFechaIngreso.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this._dtpFechaIngreso.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this._dtpFechaIngreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFechaIngreso.MonthCalendar.DisplayMonth = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this._dtpFechaIngreso.MonthCalendar.MarkedDates = new System.DateTime[0];
            this._dtpFechaIngreso.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._dtpFechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this._dtpFechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this._dtpFechaIngreso.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this._dtpFechaIngreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._dtpFechaIngreso.MonthCalendar.TodayButtonVisible = true;
            this._dtpFechaIngreso.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this._dtpFechaIngreso.Name = "_dtpFechaIngreso";
            this._dtpFechaIngreso.Size = new System.Drawing.Size(113, 22);
            this._dtpFechaIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this._dtpFechaIngreso.TabIndex = 1;
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
            this._txtIdRO.Location = new System.Drawing.Point(356, 11);
            this._txtIdRO.Name = "_txtIdRO";
            this._txtIdRO.ReadOnly = true;
            this._txtIdRO.Size = new System.Drawing.Size(113, 22);
            this._txtIdRO.TabIndex = 3;
            this._txtIdRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Location = new System.Drawing.Point(256, 39);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(96, 22);
            this.lblTipoDocumento.TabIndex = 6;
            this.lblTipoDocumento.Text = "Documento";
            this.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(5, 151);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(96, 22);
            this.lblNombre.TabIndex = 16;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIdenfificacion
            // 
            this.lblIdenfificacion.Location = new System.Drawing.Point(5, 67);
            this.lblIdenfificacion.Name = "lblIdenfificacion";
            this.lblIdenfificacion.Size = new System.Drawing.Size(96, 22);
            this.lblIdenfificacion.TabIndex = 9;
            this.lblIdenfificacion.Text = "Identificacion";
            this.lblIdenfificacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.superTabControlPanel2.Controls.Add(this.pnlBusqueda);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(706, 476);
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
            this.colId,
            this.colIentificacion,
            this.colApellido,
            this.colDireccion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrLista.Location = new System.Drawing.Point(0, 88);
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.ReadOnly = true;
            this.dgrLista.RowHeadersWidth = 25;
            this.dgrLista.Size = new System.Drawing.Size(706, 388);
            this.dgrLista.StandardTab = true;
            this.dgrLista.TabIndex = 1;
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
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "idpersona";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 42;
            // 
            // colIentificacion
            // 
            this.colIentificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIentificacion.DataPropertyName = "Identificacion";
            this.colIentificacion.HeaderText = "Identificacion";
            this.colIentificacion.Name = "colIentificacion";
            this.colIentificacion.ReadOnly = true;
            this.colIentificacion.Width = 102;
            // 
            // colApellido
            // 
            this.colApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colApellido.DataPropertyName = "nombrecompleto";
            this.colApellido.HeaderText = "Cliente";
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            this.colApellido.Width = 68;
            // 
            // colDireccion
            // 
            this.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDireccion.DataPropertyName = "referenciadireccion";
            this.colDireccion.HeaderText = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            this.colDireccion.Width = 80;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.txtFiltro);
            this.pnlBusqueda.Controls.Add(this.lblMensaje);
            this.pnlBusqueda.Controls.Add(this.lblBusqueda);
            this.pnlBusqueda.Controls.Add(this.txtBusqueda);
            this.pnlBusqueda.Controls.Add(this.label1);
            this.pnlBusqueda.Controls.Add(this.btnAceptar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(706, 88);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(66, 66);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(154, 17);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "No se encontro el cliente";
            this.lblMensaje.Visible = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.Blue;
            this.lblBusqueda.Location = new System.Drawing.Point(15, 10);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(131, 17);
            this.lblBusqueda.TabIndex = 0;
            this.lblBusqueda.Text = "Busqueda de clientes";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // ClientesLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(706, 501);
            this.Controls.Add(this.stcEdiciones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClientesLinq";
            this.Text = "Clientes";
            this.Activated += new System.EventHandler(this.Clientes_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Clientes_FormClosing);
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcInformacion)).EndInit();
            this.stcInformacion.ResumeLayout(false);
            this.pnlDatosPersonales.ResumeLayout(false);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlDatosNatural.ResumeLayout(false);
            this.pnlDatosNatural.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stcEdiciones)).EndInit();
            this.stcEdiciones.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFechaIngreso)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private System.Windows.Forms.OpenFileDialog ofdDialogo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboIdEstadoCivil;
        private System.Windows.Forms.Label lblEstadoCivil;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtBarrioRO;
        private System.Windows.Forms.Label lblBarrio;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboGenero;
        private System.Windows.Forms.Label lblGenero;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtTelefonoSN;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtCelularSN;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblTelefono;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtInformacionAdicional;
        private System.Windows.Forms.Label lblInfAdicional;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtReferenciaDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private ButtonBQ _bbqBarrio;
        private ButtonBQ _bbqConyugue;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtFKConyugeRO;
        private System.Windows.Forms.Label lblConyuge;
        private ButtonBQ _bbqProfesion;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtFKProfesioneRO;
        private System.Windows.Forms.Label lblProfesion;
        private DevComponents.DotNetBar.SuperTabControl stcInformacion;
        private DevComponents.DotNetBar.SuperTabControlPanel pnlDatosPersonales;
        private DevComponents.DotNetBar.SuperTabItem tabDatosPersonales;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Panel pnlDatosNatural;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador01;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador04;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador05;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador06;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador03;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator rfvValidador02;
        private DevComponents.DotNetBar.Validator.CompareValidator rfvValidador07;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private Proveedores.DgvPlus dgrLista;
        private DevComponents.DotNetBar.SuperTabControl stcEdiciones;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabEdicion;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private System.Windows.Forms.Panel pnlBusqueda;
        private DevComponents.DotNetBar.SuperTabItem tabLista;
        private System.Windows.Forms.Panel pnlCabecera;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtRazonSocial;
        private System.Windows.Forms.Label lblRazonSocial;
        private DevComponents.DotNetBar.ButtonX _btnQuitarFoto;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtApellido;
        private System.Windows.Forms.Label lblTipoPersona;
        private System.Windows.Forms.Label _lblEstado;
        private System.Windows.Forms.Label lblFechaIngreso;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboTipoPersona;
        private System.Windows.Forms.Label lblApellido;
        private DevComponents.DotNetBar.ButtonX _btnCargarFoto;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtNombre;
        private System.Windows.Forms.PictureBox _picFoto;
        private System.Windows.Forms.Label lblCodigo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFechaIngreso;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtIdRO;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblNombre;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtIdentificacionSN;
        private System.Windows.Forms.Label lblIdenfificacion;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboTipoDocumento;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label lblMensaje;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFiltro;
        private System.Windows.Forms.DataGridViewImageColumn colVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
    }
}