namespace WindowsApp
{
    partial class ConveniosPagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrLista = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEliminar = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuscar = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrLista
            // 
            this.dgrLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEliminar,
            this.colId,
            this.colBuscar,
            this.colFormaPago,
            this.colValor});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgrLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrLista.Location = new System.Drawing.Point(1, 1);
            this.dgrLista.Margin = new System.Windows.Forms.Padding(15);
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.RowHeadersWidth = 25;
            this.dgrLista.Size = new System.Drawing.Size(350, 124);
            this.dgrLista.TabIndex = 5;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "-->";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEliminar.Text = null;
            this.colEliminar.ToolTipText = "Eliminar";
            this.colEliminar.Width = 30;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "idformapago";
            this.colId.HeaderText = "Id";
            this.colId.MinimumWidth = 30;
            this.colId.Name = "colId";
            this.colId.Width = 30;
            // 
            // colBuscar
            // 
            this.colBuscar.HeaderText = "-->";
            this.colBuscar.Name = "colBuscar";
            this.colBuscar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBuscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBuscar.Text = null;
            this.colBuscar.ToolTipText = "Buscar";
            this.colBuscar.Width = 30;
            // 
            // colFormaPago
            // 
            this.colFormaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFormaPago.DataPropertyName = "fkformaspago";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colFormaPago.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFormaPago.HeaderText = "Forma de pago";
            this.colFormaPago.MinimumWidth = 110;
            this.colFormaPago.Name = "colFormaPago";
            this.colFormaPago.ReadOnly = true;
            this.colFormaPago.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFormaPago.Width = 110;
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "valor";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.Format = "N2";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle7;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-302, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ConveniosPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dgrLista);
            this.Name = "ConveniosPagos";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(352, 126);
            this.Load += new System.EventHandler(this.FormasPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgrLista;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.CheckBox checkBox1;






    }
}
