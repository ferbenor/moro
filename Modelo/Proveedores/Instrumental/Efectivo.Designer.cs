namespace Proveedores
{
    partial class Efectivo
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
            this.txtRecibido = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.txtEfectivo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDevuelto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDevuelto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRecibido.Border.Class = "TextBoxBorder";
            this.txtRecibido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRecibido.FocusHighlightEnabled = true;
            this.txtRecibido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibido.Location = new System.Drawing.Point(80, 49);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(98, 22);
            this.txtRecibido.TabIndex = 1;
            this.txtRecibido.Text = "0.00";
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecibido.TextChanged += new System.EventHandler(this.txtRecibido_TextChanged);
            // 
            // lblRecibido
            // 
            this.lblRecibido.Location = new System.Drawing.Point(12, 49);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(65, 22);
            this.lblRecibido.TabIndex = 0;
            this.lblRecibido.Text = "Recibido";
            this.lblRecibido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.Location = new System.Drawing.Point(12, 21);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(65, 22);
            this.lblEfectivo.TabIndex = 4;
            this.lblEfectivo.Text = "Efectivo";
            this.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(80, 115);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 28);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(171, 115);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEfectivo.Border.Class = "TextBoxBorder";
            this.txtEfectivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEfectivo.FocusHighlightEnabled = true;
            this.txtEfectivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(80, 21);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(98, 22);
            this.txtEfectivo.TabIndex = 6;
            this.txtEfectivo.Text = "0.00";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDevuelto
            // 
            this.txtDevuelto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDevuelto.Border.Class = "TextBoxBorder";
            this.txtDevuelto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDevuelto.FocusHighlightEnabled = true;
            this.txtDevuelto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevuelto.Location = new System.Drawing.Point(80, 77);
            this.txtDevuelto.Name = "txtDevuelto";
            this.txtDevuelto.ReadOnly = true;
            this.txtDevuelto.Size = new System.Drawing.Size(98, 22);
            this.txtDevuelto.TabIndex = 7;
            this.txtDevuelto.Text = "0.00";
            this.txtDevuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDevuelto
            // 
            this.lblDevuelto.Location = new System.Drawing.Point(12, 77);
            this.lblDevuelto.Name = "lblDevuelto";
            this.lblDevuelto.Size = new System.Drawing.Size(65, 22);
            this.lblDevuelto.TabIndex = 5;
            this.lblDevuelto.Text = "Devuelto";
            this.lblDevuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Efectivo
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(269, 151);
            this.Controls.Add(this.txtDevuelto);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.lblDevuelto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtRecibido);
            this.Controls.Add(this.lblRecibido);
            this.Controls.Add(this.lblEfectivo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Efectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Efectivo";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtRecibido;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Label lblEfectivo;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDevuelto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEfectivo;
        private System.Windows.Forms.Label lblDevuelto;
    }
}