namespace WindowsApp
{
    partial class BusquedaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusquedaClientes));
            this.txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblTipoContable = new System.Windows.Forms.Label();
            this.cboTipo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Valor requerido");
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this.lblBuscando = new System.Windows.Forms.Label();
            this.valIdentificacion = new DevComponents.Editors.ComboItem();
            this.valCodigo = new DevComponents.Editors.ComboItem();
            this.valNombre = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            this.SuspendLayout();
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
            this.txtNumero.Location = new System.Drawing.Point(73, 46);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(98, 22);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spvValidador.SetValidator1(this.txtNumero, this.requiredFieldValidator1);
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(12, 46);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(58, 22);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoContable
            // 
            this.lblTipoContable.Location = new System.Drawing.Point(12, 18);
            this.lblTipoContable.Name = "lblTipoContable";
            this.lblTipoContable.Size = new System.Drawing.Size(58, 22);
            this.lblTipoContable.TabIndex = 4;
            this.lblTipoContable.Text = "Tipo";
            this.lblTipoContable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipo
            // 
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.ItemHeight = 16;
            this.cboTipo.Items.AddRange(new object[] {
            this.valIdentificacion,
            this.valCodigo,
            this.valNombre});
            this.cboTipo.Location = new System.Drawing.Point(73, 18);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(245, 22);
            this.cboTipo.TabIndex = 5;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(142, 92);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 28);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.SystemColors.Control;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(171, 70);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(147, 17);
            this.lblMensaje.TabIndex = 8;
            this.lblMensaje.Text = "Registro no encontrado";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(233, 92);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errValidacion;
            this.spvValidador.Highlighter = this.hhlResaltador;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Valor requerido";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // lblBuscando
            // 
            this.lblBuscando.AutoSize = true;
            this.lblBuscando.BackColor = System.Drawing.SystemColors.Control;
            this.lblBuscando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscando.ForeColor = System.Drawing.Color.Blue;
            this.lblBuscando.Location = new System.Drawing.Point(35, 97);
            this.lblBuscando.Name = "lblBuscando";
            this.lblBuscando.Size = new System.Drawing.Size(73, 17);
            this.lblBuscando.TabIndex = 9;
            this.lblBuscando.Text = "Buscando...";
            this.lblBuscando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBuscando.Visible = false;
            // 
            // valIdentificacion
            // 
            this.valIdentificacion.Text = "Identificacion";
            // 
            // valCodigo
            // 
            this.valCodigo.Text = "Codigo";
            // 
            // valNombre
            // 
            this.valNombre.Text = "Nombre";
            // 
            // BusquedaClientes
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(335, 133);
            this.Controls.Add(this.lblBuscando);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblTipoContable);
            this.Controls.Add(this.cboTipo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusquedaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros de busqueda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusquedaClientes_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusquedaClientes_FormClosed);
            this.Load += new System.EventHandler(this.BusquedaContables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNumero;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblTipoContable;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTipo;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.Label lblMensaje;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.Label lblBuscando;
        private DevComponents.Editors.ComboItem valIdentificacion;
        private DevComponents.Editors.ComboItem valCodigo;
        private DevComponents.Editors.ComboItem valNombre;
    }
}