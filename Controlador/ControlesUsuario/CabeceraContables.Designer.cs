namespace Controladores.ControlesUsuario
{
    partial class CabeceraContables
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExaminar = new DevComponents.DotNetBar.ButtonX();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTipoContable = new System.Windows.Forms.Label();
            this.cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dtpFecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExaminar
            // 
            this.btnExaminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExaminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExaminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExaminar.Location = new System.Drawing.Point(587, 31);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(85, 28);
            this.btnExaminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExaminar.TabIndex = 11;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.SystemColors.Control;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(29, 79);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(147, 17);
            this.lblMensaje.TabIndex = 13;
            this.lblMensaje.Text = "Registro no encontrado";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(496, 31);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 28);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNumero.Border.Class = "TextBoxBorder";
            this.txtNumero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumero.FocusHighlightEnabled = true;
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(251, 37);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(232, 22);
            this.txtNumero.TabIndex = 9;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTipoContable
            // 
            this.lblTipoContable.Location = new System.Drawing.Point(3, 37);
            this.lblTipoContable.Name = "lblTipoContable";
            this.lblTipoContable.Size = new System.Drawing.Size(58, 22);
            this.lblTipoContable.TabIndex = 14;
            this.lblTipoContable.Text = "Tipo";
            this.lblTipoContable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipo
            // 
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.ItemHeight = 16;
            this.cboTipo.Location = new System.Drawing.Point(64, 37);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(181, 22);
            this.cboTipo.TabIndex = 15;
            // 
            // dtpFecha
            // 
            // 
            // 
            // 
            this.dtpFecha.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpFecha.ButtonDropDown.Visible = true;
            this.dtpFecha.CustomFormat = "dd MMM yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpFecha.IsPopupCalendarOpen = false;
            this.dtpFecha.Location = new System.Drawing.Point(251, 11);
            // 
            // 
            // 
            this.dtpFecha.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecha.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpFecha.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecha.MonthCalendar.DisplayMonth = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpFecha.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecha.MonthCalendar.TodayButtonVisible = true;
            this.dtpFecha.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(113, 20);
            this.dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpFecha.TabIndex = 16;
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.CustomFormat = "dd MMM yyyy";
            this.dateTimeInput1.Enabled = false;
            this.dateTimeInput1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(370, 11);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(113, 20);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 16;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(64, 9);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(181, 22);
            this.comboBoxEx1.TabIndex = 15;
            // 
            // CabeceraContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimeInput1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblTipoContable);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNumero);
            this.Name = "CabeceraContables";
            this.Size = new System.Drawing.Size(672, 124);
            this.Load += new System.EventHandler(this.CabeceraContables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExaminar;
        private System.Windows.Forms.Label lblMensaje;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNumero;
        private System.Windows.Forms.Label lblTipoContable;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpFecha;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;

    }
}
