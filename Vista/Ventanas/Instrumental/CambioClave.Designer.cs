namespace WindowsApp
{
    partial class CambioClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioClave));
            this.lblContraseña = new DevComponents.DotNetBar.LabelX();
            this.lblUsuario = new DevComponents.DotNetBar.LabelX();
            this.txtConfirmacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNuevaClave = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnRegistrar = new DevComponents.DotNetBar.ButtonX();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.lblClaveAnterior = new DevComponents.DotNetBar.LabelX();
            this.txtClaveAnterior = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.compareValidator1 = new DevComponents.DotNetBar.Validator.CompareValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Campo requerido");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Campo requerido");
            this.errMensaje = new System.Windows.Forms.ErrorProvider(this.components);
            this.hglEfecto = new DevComponents.DotNetBar.Validator.Highlighter();
            this.lblXTitulo = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContraseña
            // 
            this.lblContraseña.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblContraseña.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblContraseña.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.ForeColor = System.Drawing.Color.Black;
            this.lblContraseña.Location = new System.Drawing.Point(3, 126);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(113, 23);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Confirmar clave";
            this.lblContraseña.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(3, 97);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(113, 23);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Nueva clave";
            this.lblUsuario.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtConfirmacion
            // 
            // 
            this.txtConfirmacion.Border.Class = "TextBoxBorder";
            this.txtConfirmacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfirmacion.FocusHighlightEnabled = true;
            this.txtConfirmacion.Location = new System.Drawing.Point(123, 126);
            this.txtConfirmacion.Name = "txtConfirmacion";
            this.txtConfirmacion.Size = new System.Drawing.Size(163, 22);
            this.txtConfirmacion.TabIndex = 5;
            this.txtConfirmacion.UseSystemPasswordChar = true;
            this.spvValidador.SetValidator1(this.txtConfirmacion, this.requiredFieldValidator3);
            this.spvValidador.SetValidator2(this.txtConfirmacion, this.compareValidator1);
            this.txtConfirmacion.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtConfirmacion.WatermarkText = "Confirmacion de clave";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Border.Class = "TextBoxBorder";
            this.txtNuevaClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNuevaClave.FocusHighlightEnabled = true;
            this.txtNuevaClave.Location = new System.Drawing.Point(123, 97);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Size = new System.Drawing.Size(163, 22);
            this.txtNuevaClave.TabIndex = 3;
            this.txtNuevaClave.UseSystemPasswordChar = true;
            this.spvValidador.SetValidator1(this.txtNuevaClave, this.requiredFieldValidator2);
            this.txtNuevaClave.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtNuevaClave.WatermarkText = "Nueva clave";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegistrar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnRegistrar.Location = new System.Drawing.Point(123, 164);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(77, 30);
            this.btnRegistrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.CausesValidation = false;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(209, 164);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 30);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblClaveAnterior
            // 
            this.lblClaveAnterior.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblClaveAnterior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblClaveAnterior.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveAnterior.ForeColor = System.Drawing.Color.Black;
            this.lblClaveAnterior.Location = new System.Drawing.Point(3, 68);
            this.lblClaveAnterior.Name = "lblClaveAnterior";
            this.lblClaveAnterior.Size = new System.Drawing.Size(113, 23);
            this.lblClaveAnterior.TabIndex = 0;
            this.lblClaveAnterior.Text = "Clave anterior";
            this.lblClaveAnterior.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtClaveAnterior
            // 
            // 
            // 
            // 
            this.txtClaveAnterior.Border.Class = "TextBoxBorder";
            this.txtClaveAnterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClaveAnterior.FocusHighlightEnabled = true;
            this.txtClaveAnterior.Location = new System.Drawing.Point(123, 68);
            this.txtClaveAnterior.Name = "txtClaveAnterior";
            this.txtClaveAnterior.Size = new System.Drawing.Size(163, 22);
            this.txtClaveAnterior.TabIndex = 1;
            this.txtClaveAnterior.UseSystemPasswordChar = true;
            this.spvValidador.SetValidator1(this.txtClaveAnterior, this.requiredFieldValidator1);
            this.txtClaveAnterior.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtClaveAnterior.WatermarkText = "Clave anterior";
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errMensaje;
            this.spvValidador.Highlighter = this.hglEfecto;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // compareValidator1
            // 
            this.compareValidator1.ControlToCompare = this.txtNuevaClave;
            this.compareValidator1.ErrorMessage = "Claves no coinciden";
            this.compareValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Campo requerido";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Campo requerido";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errMensaje
            // 
            this.errMensaje.ContainerControl = this;
            this.errMensaje.Icon = ((System.Drawing.Icon)(resources.GetObject("errMensaje.Icon")));
            // 
            // hglEfecto
            // 
            this.hglEfecto.ContainerControl = this;
            // 
            // lblXTitulo
            // 
            this.lblXTitulo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblXTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblXTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblXTitulo.Name = "lblXTitulo";
            this.lblXTitulo.Size = new System.Drawing.Size(337, 42);
            this.lblXTitulo.TabIndex = 11;
            this.lblXTitulo.Text = "<b><font size=\"+6\"><font color=\"#4B610B\">Cambio de clave del sistema</font></font" +
    "></b>";
            // 
            // CambioClave
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(302, 206);
            this.Controls.Add(this.lblXTitulo);
            this.Controls.Add(this.lblClaveAnterior);
            this.Controls.Add(this.txtClaveAnterior);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtConfirmacion);
            this.Controls.Add(this.txtNuevaClave);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambioClave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de clave";
             ((System.ComponentModel.ISupportInitialize)(this.errMensaje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblContraseña;
        private DevComponents.DotNetBar.LabelX lblUsuario;
        private DevComponents.DotNetBar.Controls.TextBoxX txtConfirmacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNuevaClave;
        private DevComponents.DotNetBar.ButtonX btnRegistrar;
        private DevComponents.DotNetBar.ButtonX btnSalir;
        private DevComponents.DotNetBar.LabelX lblClaveAnterior;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClaveAnterior;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private System.Windows.Forms.ErrorProvider errMensaje;
        private DevComponents.DotNetBar.Validator.Highlighter hglEfecto;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.CompareValidator compareValidator1;
        public DevComponents.DotNetBar.Controls.ReflectionLabel lblXTitulo;
    }
}