namespace WindowsApp
{
    partial class Asignaciones
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrLista = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboCabecera = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnConsultar = new DevComponents.DotNetBar.ButtonX();
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this.lblXTitulo = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAsignado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
            this.gpbCabecera.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrLista
            // 
            this.dgrLista.AllowUserToAddRows = false;
            this.dgrLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colEditable,
            this.colAsignado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgrLista.Location = new System.Drawing.Point(0, 126);
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.RowHeadersWidth = 22;
            this.dgrLista.Size = new System.Drawing.Size(567, 256);
            this.dgrLista.TabIndex = 5;
            this.dgrLista.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgrLista_CellBeginEdit);
            this.dgrLista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrLista_CellEndEdit);
            this.dgrLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgrLista_KeyPress);
            // 
            // cboCabecera
            // 
            this.cboCabecera.DisplayMember = "Text";
            this.cboCabecera.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCabecera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabecera.FormattingEnabled = true;
            this.cboCabecera.ItemHeight = 16;
            this.cboCabecera.Location = new System.Drawing.Point(7, 24);
            this.cboCabecera.Name = "cboCabecera";
            this.cboCabecera.Size = new System.Drawing.Size(361, 22);
            this.cboCabecera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCabecera.TabIndex = 6;
            this.cboCabecera.SelectedIndexChanged += new System.EventHandler(this.cboCabecera_SelectedIndexChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConsultar.Location = new System.Drawing.Point(374, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(87, 28);
            this.btnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this.btnConsultar);
            this.gpbCabecera.Controls.Add(this.cboCabecera);
            this.gpbCabecera.Location = new System.Drawing.Point(15, 58);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(478, 58);
            this.gpbCabecera.TabIndex = 9;
            this.gpbCabecera.TabStop = false;
            this.gpbCabecera.Text = "Perfil";
            // 
            // lblXTitulo
            // 
            // 
            // 
            // 
            this.lblXTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblXTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblXTitulo.Name = "lblXTitulo";
            this.lblXTitulo.Size = new System.Drawing.Size(1000, 42);
            this.lblXTitulo.TabIndex = 10;
            this.lblXTitulo.Text = "<b><font size=\"+6\"><font color=\"#4B610B\">Titulo</font></font></b>";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.lblXTitulo);
            this.pnlCabecera.Controls.Add(this.gpbCabecera);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(567, 126);
            this.pnlCabecera.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Width = 250;
            // 
            // colEditable
            // 
            this.colEditable.DataPropertyName = "editable";
            this.colEditable.HeaderText = "Editable";
            this.colEditable.Name = "colEditable";
            this.colEditable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditable.Width = 60;
            // 
            // colAsignado
            // 
            this.colAsignado.DataPropertyName = "Asignado";
            this.colAsignado.HeaderText = "Asignado";
            this.colAsignado.Name = "colAsignado";
            this.colAsignado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAsignado.Width = 60;
            // 
            // Asignaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 382);
            this.Controls.Add(this.dgrLista);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Asignaciones";
            this.Activated += new System.EventHandler(this.Asignaciones_Activated);
            this.Load += new System.EventHandler(this.Asignaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            this.gpbCabecera.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgrLista;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCabecera;
        private DevComponents.DotNetBar.ButtonX btnConsultar;
        private System.Windows.Forms.GroupBox gpbCabecera;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lblXTitulo;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEditable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAsignado;
    }
}

