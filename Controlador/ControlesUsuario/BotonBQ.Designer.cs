namespace Controladores
{
    partial class ButtonBQ
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
            this.btnQuitar = new DevComponents.DotNetBar.ButtonX();
            this.btnConsultar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnQuitar
            // 
            this.btnQuitar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuitar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnQuitar.ImageTextSpacing = 1;
            this.btnQuitar.Location = new System.Drawing.Point(28, 3);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(22, 22);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Tag = "0";
            this.btnQuitar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnQuitar.Click += new System.EventHandler(this.btnPulsado_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnConsultar.ImageTextSpacing = 1;
            this.btnConsultar.Location = new System.Drawing.Point(3, 3);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(22, 22);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Tag = "0";
            this.btnConsultar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnConsultar.Click += new System.EventHandler(this.btnPulsado_Click);
            // 
            // ButtonBQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnConsultar);
            this.Name = "ButtonBQ";
            this.Size = new System.Drawing.Size(53, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnQuitar;
        private DevComponents.DotNetBar.ButtonX btnConsultar;
    }
}
