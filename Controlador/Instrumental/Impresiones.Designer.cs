namespace Controladores
{
    partial class Impresiones
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
            this.optLista = new System.Windows.Forms.RadioButton();
            this.optLote = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.gpbImpresion = new System.Windows.Forms.GroupBox();
            this.gpbImpresion.SuspendLayout();
            this.SuspendLayout();
            // 
            // optLista
            // 
            this.optLista.AutoSize = true;
            this.optLista.Checked = true;
            this.optLista.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLista.ForeColor = System.Drawing.Color.Black;
            this.optLista.Location = new System.Drawing.Point(11, 33);
            this.optLista.Name = "optLista";
            this.optLista.Size = new System.Drawing.Size(62, 17);
            this.optLista.TabIndex = 0;
            this.optLista.TabStop = true;
            this.optLista.Text = "En lista";
            this.optLista.UseVisualStyleBackColor = true;
            // 
            // optLote
            // 
            this.optLote.AutoSize = true;
            this.optLote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLote.ForeColor = System.Drawing.Color.Black;
            this.optLote.Location = new System.Drawing.Point(93, 33);
            this.optLote.Name = "optLote";
            this.optLote.Size = new System.Drawing.Size(65, 17);
            this.optLote.TabIndex = 0;
            this.optLote.Text = "Por lote";
            this.optLote.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(103, 80);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(12, 80);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 28);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gpbImpresion
            // 
            this.gpbImpresion.Controls.Add(this.optLote);
            this.gpbImpresion.Controls.Add(this.optLista);
            this.gpbImpresion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbImpresion.ForeColor = System.Drawing.Color.Blue;
            this.gpbImpresion.Location = new System.Drawing.Point(12, 12);
            this.gpbImpresion.Name = "gpbImpresion";
            this.gpbImpresion.Size = new System.Drawing.Size(176, 62);
            this.gpbImpresion.TabIndex = 6;
            this.gpbImpresion.TabStop = false;
            this.gpbImpresion.Text = "Impresión";
            // 
            // Impresiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 118);
            this.Controls.Add(this.gpbImpresion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Impresiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresiones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Impresiones_FormClosed);
            this.Load += new System.EventHandler(this.Impresiones_Load);
            this.gpbImpresion.ResumeLayout(false);
            this.gpbImpresion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton optLista;
        private System.Windows.Forms.RadioButton optLote;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.GroupBox gpbImpresion;
    }
}