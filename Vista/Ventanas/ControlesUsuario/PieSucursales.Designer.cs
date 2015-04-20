namespace WindowsApp
{
    partial class PieSucursales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrListaTelefonos = new Proveedores.DgvPlus();
            ((System.ComponentModel.ISupportInitialize)(this.dgrListaTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrListaTelefonos
            // 
            this.dgrListaTelefonos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrListaTelefonos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrListaTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrListaTelefonos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrListaTelefonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrListaTelefonos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrListaTelefonos.Location = new System.Drawing.Point(3, 3);
            this.dgrListaTelefonos.Name = "dgrListaTelefonos";
            this.dgrListaTelefonos.RowHeadersWidth = 25;
            this.dgrListaTelefonos.Size = new System.Drawing.Size(435, 200);
            this.dgrListaTelefonos.TabIndex = 2;
            // 
            // PieOficinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrListaTelefonos);
            this.Name = "PieOficinas";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(441, 206);
            this.Load += new System.EventHandler(this.PieOficinas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrListaTelefonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Proveedores.DgvPlus dgrListaTelefonos;
    }
}
