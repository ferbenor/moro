namespace WindowsApp
{
    partial class Contables1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contables1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this._lblAnulado = new System.Windows.Forms.Label();
            this._txtDiferencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this._txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtValorHaber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnConsultar = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this._txtDetalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._txtBeneficiario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFecha = new System.Windows.Forms.Label();
            this._txtValorDebe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.lblTipoContable = new System.Windows.Forms.Label();
            this._cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este valor es requerido");
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this._dgrDetalle = new Proveedores.DgvPlus();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Este valor es requerido");
            this.gpbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgrDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this._lblAnulado);
            this.gpbCabecera.Controls.Add(this._txtDiferencia);
            this.gpbCabecera.Controls.Add(this._dtpFecha);
            this.gpbCabecera.Controls.Add(this.lblDiferencia);
            this.gpbCabecera.Controls.Add(this._txtNumero);
            this.gpbCabecera.Controls.Add(this._txtValorHaber);
            this.gpbCabecera.Controls.Add(this.btnConsultar);
            this.gpbCabecera.Controls.Add(this.label2);
            this.gpbCabecera.Controls.Add(this._txtDetalle);
            this.gpbCabecera.Controls.Add(this._txtBeneficiario);
            this.gpbCabecera.Controls.Add(this.lblFecha);
            this.gpbCabecera.Controls.Add(this._txtValorDebe);
            this.gpbCabecera.Controls.Add(this.label1);
            this.gpbCabecera.Controls.Add(this.lblNumero);
            this.gpbCabecera.Controls.Add(this.lblDetalle);
            this.gpbCabecera.Controls.Add(this.lblBeneficiario);
            this.gpbCabecera.Controls.Add(this.lblTipoContable);
            this.gpbCabecera.Controls.Add(this._cboTipo);
            this.gpbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCabecera.Location = new System.Drawing.Point(0, 0);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(607, 202);
            this.gpbCabecera.TabIndex = 0;
            this.gpbCabecera.TabStop = false;
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
            this._lblAnulado.Visible = false;
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
            this._txtDiferencia.Location = new System.Drawing.Point(469, 161);
            this._txtDiferencia.Name = "_txtDiferencia";
            this._txtDiferencia.ReadOnly = true;
            this._txtDiferencia.Size = new System.Drawing.Size(109, 22);
            this._txtDiferencia.TabIndex = 14;
            this._txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this._dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            this._dtpFecha.Enter += new System.EventHandler(this.dtpFecha_Enter);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Location = new System.Drawing.Point(400, 161);
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
            this._txtValorHaber.Location = new System.Drawing.Point(268, 161);
            this._txtValorHaber.Name = "_txtValorHaber";
            this._txtValorHaber.ReadOnly = true;
            this._txtValorHaber.Size = new System.Drawing.Size(109, 22);
            this._txtValorHaber.TabIndex = 12;
            this._txtValorHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConsultar
            // 
            this.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(554, 62);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(22, 22);
            this.btnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Visible = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Haber";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this._txtDetalle.Size = new System.Drawing.Size(490, 65);
            this._txtDetalle.TabIndex = 8;
            this.spvValidador.SetValidator1(this._txtDetalle, this.requiredFieldValidator2);
            this._txtDetalle.TextChanged += new System.EventHandler(this.txtDetalle_TextChanged);
            // 
            // _txtBeneficiario
            // 
            // 
            // 
            // 
            this._txtBeneficiario.Border.Class = "TextBoxBorder";
            this._txtBeneficiario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._txtBeneficiario.FocusHighlightEnabled = true;
            this._txtBeneficiario.Location = new System.Drawing.Point(88, 62);
            this._txtBeneficiario.Name = "_txtBeneficiario";
            this._txtBeneficiario.ReadOnly = true;
            this._txtBeneficiario.Size = new System.Drawing.Size(448, 22);
            this._txtBeneficiario.TabIndex = 5;
            this.spvValidador.SetValidator1(this._txtBeneficiario, this.requiredFieldValidator1);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(268, 34);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 22);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this._txtValorDebe.Location = new System.Drawing.Point(88, 161);
            this._txtValorDebe.Name = "_txtValorDebe";
            this._txtValorDebe.ReadOnly = true;
            this._txtValorDebe.Size = new System.Drawing.Size(109, 22);
            this._txtValorDebe.TabIndex = 10;
            this._txtValorDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Debe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(429, 34);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(51, 22);
            this.lblNumero.TabIndex = 4;
            this.lblNumero.Text = "Número";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Location = new System.Drawing.Point(7, 111);
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
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errValidacion;
            this.spvValidador.Highlighter = this.hhlResaltador;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Este valor es requerido";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // _dgrDetalle
            // 
            this._dgrDetalle.AllowUserToAddRows = false;
            this._dgrDetalle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._dgrDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgrDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgrDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgrDetalle.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgrDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgrDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._dgrDetalle.Location = new System.Drawing.Point(0, 202);
            this._dgrDetalle.Name = "_dgrDetalle";
            this._dgrDetalle.RowHeadersWidth = 25;
            this._dgrDetalle.Size = new System.Drawing.Size(607, 218);
            this._dgrDetalle.TabIndex = 1;
            this._dgrDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDetalle_CellEndEdit);
            this._dgrDetalle.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgrDetalle_UserDeletedRow);
            this._dgrDetalle.Leave += new System.EventHandler(this.dgrDetalle_Leave);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Este valor es requerido";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // Contables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 420);
            this.Controls.Add(this._dgrDetalle);
            this.Controls.Add(this.gpbCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Contables";
            this.Text = "Contables";
            this.Activated += new System.EventHandler(this.Contables_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Contables_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contables_FormClosed);
            this.Load += new System.EventHandler(this.Contables_Load);
            this.gpbCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dtpFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgrDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCabecera;
        private Proveedores.DgvPlus _dgrDetalle;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.Label lblTipoContable;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDetalle;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtBeneficiario;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput _dtpFecha;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtNumero;
        private DevComponents.DotNetBar.ButtonX btnConsultar;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtValorDebe;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtValorHaber;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX _txtDiferencia;
        private System.Windows.Forms.Label lblDiferencia;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private System.Windows.Forms.Label _lblAnulado;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
    }
}