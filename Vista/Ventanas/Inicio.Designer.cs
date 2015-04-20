namespace WindowsApp
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.txtContrasena = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUsuario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblUsuario = new DevComponents.DotNetBar.LabelX();
            this.lblContraseña = new DevComponents.DotNetBar.LabelX();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Clave es requerida");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Nombre de usuario es requerido");
            this.errMensaje = new System.Windows.Forms.ErrorProvider(this.components);
            this.hghEfecto = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Usuario y contraseña son requeridos");
            this.btnEntrar = new DevComponents.DotNetBar.ButtonX();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.lnkWeb = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.gpbSesion = new System.Windows.Forms.GroupBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlBotones = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.errMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContrasena
            // 
            // 
            // 
            // 
            this.txtContrasena.Border.Class = "TextBoxBorder";
            this.txtContrasena.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContrasena.FocusHighlightEnabled = true;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(74, 258);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(191, 25);
            this.txtContrasena.TabIndex = 3;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.spvValidador.SetValidator1(this.txtContrasena, this.requiredFieldValidator3);
            this.txtContrasena.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtContrasena.WatermarkText = "Clave";
            this.txtContrasena.Enter += new System.EventHandler(this.txtContrasena_Enter);
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.Border.Class = "TextBoxBorder";
            this.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsuario.FocusHighlightEnabled = true;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(74, 226);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(191, 25);
            this.txtUsuario.TabIndex = 1;
            this.spvValidador.SetValidator1(this.txtUsuario, this.requiredFieldValidator2);
            this.txtUsuario.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtUsuario.WatermarkText = "Nombre de usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(8, 227);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 23);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblContraseña
            // 
            this.lblContraseña.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblContraseña.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblContraseña.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.ForeColor = System.Drawing.Color.Black;
            this.lblContraseña.Location = new System.Drawing.Point(8, 259);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(61, 23);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Clave";
            this.lblContraseña.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errMensaje;
            this.spvValidador.Highlighter = this.hghEfecto;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Clave es requerida";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Nombre de usuario es requerido";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errMensaje
            // 
            this.errMensaje.ContainerControl = this;
            this.errMensaje.Icon = ((System.Drawing.Icon)(resources.GetObject("errMensaje.Icon")));
            // 
            // hghEfecto
            // 
            this.hghEfecto.ContainerControl = this;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Usuario y contraseña son requeridos";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // btnEntrar
            // 
            this.btnEntrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEntrar.Image = global::WindowsApp.Properties.Resources.Conectar;
            this.btnEntrar.Location = new System.Drawing.Point(44, 27);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(93, 31);
            this.btnEntrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnEntrar.TabIndex = 1;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.CausesValidation = false;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::WindowsApp.Properties.Resources.no;
            this.btnSalir.Location = new System.Drawing.Point(147, 27);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 31);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lnkWeb
            // 
            this.lnkWeb.AutoSize = true;
            this.lnkWeb.BackColor = System.Drawing.Color.Transparent;
            this.lnkWeb.LinkColor = System.Drawing.Color.Black;
            this.lnkWeb.Location = new System.Drawing.Point(171, 64);
            this.lnkWeb.Name = "lnkWeb";
            this.lnkWeb.Size = new System.Drawing.Size(111, 15);
            this.lnkWeb.TabIndex = 7;
            this.lnkWeb.TabStop = true;
            this.lnkWeb.Text = "www.moro.com";
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(172, 1);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(109, 16);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "Versión";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpbSesion
            // 
            this.gpbSesion.BackColor = System.Drawing.Color.Transparent;
            this.gpbSesion.CausesValidation = false;
            this.gpbSesion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbSesion.ForeColor = System.Drawing.Color.Blue;
            this.gpbSesion.Location = new System.Drawing.Point(2, 195);
            this.gpbSesion.Name = "gpbSesion";
            this.gpbSesion.Size = new System.Drawing.Size(280, 105);
            this.gpbSesion.TabIndex = 6;
            this.gpbSesion.TabStop = false;
            this.gpbSesion.Text = "Iniciar sesion";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::WindowsApp.Properties.Resources.Llave;
            this.picLogo.Location = new System.Drawing.Point(29, 21);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(228, 170);
            this.picLogo.TabIndex = 9;
            this.picLogo.TabStop = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.lnkWeb);
            this.pnlBotones.Controls.Add(this.btnEntrar);
            this.pnlBotones.Controls.Add(this.btnSalir);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 296);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(284, 83);
            this.pnlBotones.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBotones.Style.BackColor1.Color = System.Drawing.Color.GhostWhite;
            this.pnlBotones.Style.BackColor2.Color = System.Drawing.SystemColors.HotTrack;
            this.pnlBotones.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBotones.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBotones.Style.GradientAngle = 90;
            this.pnlBotones.TabIndex = 10;
            // 
            // Inicio
            // 
            this.AcceptButton = this.btnEntrar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.MintCream;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(284, 379);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.gpbSesion);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::WindowsApp.Properties.Resources.Icono;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso al sistema";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtUsuario;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContrasena;
        private DevComponents.DotNetBar.ButtonX btnEntrar;
        private DevComponents.DotNetBar.ButtonX btnSalir;

        private DevComponents.DotNetBar.LabelX lblContraseña;
        private DevComponents.DotNetBar.LabelX lblUsuario;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private System.Windows.Forms.ErrorProvider errMensaje;
        private DevComponents.DotNetBar.Validator.Highlighter hghEfecto;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.GroupBox gpbSesion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel lnkWeb;
        private System.Windows.Forms.PictureBox picLogo;
        private DevComponents.DotNetBar.PanelEx pnlBotones;
    }
}