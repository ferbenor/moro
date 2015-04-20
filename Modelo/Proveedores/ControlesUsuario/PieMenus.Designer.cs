namespace WindowsApp
{
    partial class PieMenus
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
            this.tabBotones = new System.Windows.Forms.TabControl();
            this.tabColumnas = new System.Windows.Forms.TabPage();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this._cboTablas = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblTabla = new System.Windows.Forms.Label();
            this.tabBarra = new System.Windows.Forms.TabPage();
            this.dgrListaColumnas = new Proveedores.DgvPlus();
            this.tabBotones.SuspendLayout();
            this.tabColumnas.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrListaColumnas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBotones
            // 
            this.tabBotones.Controls.Add(this.tabColumnas);
            this.tabBotones.Controls.Add(this.tabBarra);
            this.tabBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBotones.Location = new System.Drawing.Point(3, 3);
            this.tabBotones.Name = "tabBotones";
            this.tabBotones.SelectedIndex = 0;
            this.tabBotones.Size = new System.Drawing.Size(557, 232);
            this.tabBotones.TabIndex = 3;
            // 
            // tabColumnas
            // 
            this.tabColumnas.Controls.Add(this.dgrListaColumnas);
            this.tabColumnas.Controls.Add(this.pnlSuperior);
            this.tabColumnas.Location = new System.Drawing.Point(4, 22);
            this.tabColumnas.Name = "tabColumnas";
            this.tabColumnas.Padding = new System.Windows.Forms.Padding(3);
            this.tabColumnas.Size = new System.Drawing.Size(549, 206);
            this.tabColumnas.TabIndex = 1;
            this.tabColumnas.Text = "Columnas";
            this.tabColumnas.UseVisualStyleBackColor = true;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this._cboTablas);
            this.pnlSuperior.Controls.Add(this.lblTabla);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(543, 35);
            this.pnlSuperior.TabIndex = 3;
            // 
            // _cboTablas
            // 
            this._cboTablas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTablas.FormattingEnabled = true;
            this._cboTablas.ItemHeight = 16;
            this._cboTablas.Location = new System.Drawing.Point(81, 5);
            this._cboTablas.Name = "_cboTablas";
            this._cboTablas.Size = new System.Drawing.Size(362, 22);
            this._cboTablas.TabIndex = 6;
            // 
            // lblTabla
            // 
            this.lblTabla.Location = new System.Drawing.Point(16, 5);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(59, 22);
            this.lblTabla.TabIndex = 2;
            this.lblTabla.Text = "Tabla:";
            this.lblTabla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabBarra
            // 
            this.tabBarra.Location = new System.Drawing.Point(4, 22);
            this.tabBarra.Name = "tabBarra";
            this.tabBarra.Padding = new System.Windows.Forms.Padding(3);
            this.tabBarra.Size = new System.Drawing.Size(549, 206);
            this.tabBarra.TabIndex = 0;
            this.tabBarra.Text = "Opciones de barra de herramientas";
            this.tabBarra.UseVisualStyleBackColor = true;
            // 
            // dgrListaColumnas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrListaColumnas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrListaColumnas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrListaColumnas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrListaColumnas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrListaColumnas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrListaColumnas.Location = new System.Drawing.Point(3, 38);
            this.dgrListaColumnas.Name = "dgrListaColumnas";
            this.dgrListaColumnas.PermitirEventosInternos = false;
            this.dgrListaColumnas.RowHeadersWidth = 25;
            this.dgrListaColumnas.Size = new System.Drawing.Size(543, 165);
            this.dgrListaColumnas.TabIndex = 2;
            // 
            // PieMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabBotones);
            this.Name = "PieMenus";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(563, 238);
            this.Load += new System.EventHandler(this.PieOficinas_Load);
            this.tabBotones.ResumeLayout(false);
            this.tabColumnas.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrListaColumnas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Proveedores.DgvPlus dgrListaColumnas;
        private System.Windows.Forms.TabControl tabBotones;
        private System.Windows.Forms.TabPage tabBarra;
        private System.Windows.Forms.TabPage tabColumnas;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTabla;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _cboTablas;
    }
}
