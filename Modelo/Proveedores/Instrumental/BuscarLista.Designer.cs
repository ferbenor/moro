namespace Proveedores
{
    partial class frmBuscarL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarL));
            this.dgrLista = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSeleccionar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.spvValidador = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.hhlResaltador = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Valor requerido");
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.gpbCabecera = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.gpbBotones = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).BeginInit();
            this.gpbCabecera.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.gpbBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrLista
            // 
            this.dgrLista.AllowUserToAddRows = false;
            this.dgrLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgrLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dgrLista.Location = new System.Drawing.Point(0, 58);
            this.dgrLista.MultiSelect = false;
            this.dgrLista.Name = "dgrLista";
            this.dgrLista.ReadOnly = true;
            this.dgrLista.RowHeadersVisible = false;
            this.dgrLista.RowHeadersWidth = 22;
            this.dgrLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrLista.Size = new System.Drawing.Size(644, 255);
            this.dgrLista.TabIndex = 1;
            this.dgrLista.DoubleClick += new System.EventHandler(this.dgrLista_DoubleClick);
            this.dgrLista.Enter += new System.EventHandler(this.dgrLista_Enter);
            this.dgrLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgrLista_KeyDown);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeleccionar.Enabled = false;
            this.btnSeleccionar.Location = new System.Drawing.Point(6, 15);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 28);
            this.btnSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(106, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 28);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            // 
            // spvValidador
            // 
            this.spvValidador.ContainerControl = this;
            this.spvValidador.ErrorProvider = this.errValidacion;
            this.spvValidador.Highlighter = this.hhlResaltador;
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
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusHighlightEnabled = true;
            this.txtBuscar.Location = new System.Drawing.Point(6, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(362, 22);
            this.txtBuscar.TabIndex = 0;
            this.spvValidador.SetValidator1(this.txtBuscar, this.requiredFieldValidator1);
            this.txtBuscar.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtBuscar.WatermarkText = "Por favor ingrese los parametros de busqueda";
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Valor requerido";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.Location = new System.Drawing.Point(388, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 22);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gpbCabecera
            // 
            this.gpbCabecera.Controls.Add(this.txtBuscar);
            this.gpbCabecera.Controls.Add(this.btnBuscar);
            this.gpbCabecera.Location = new System.Drawing.Point(5, 2);
            this.gpbCabecera.Name = "gpbCabecera";
            this.gpbCabecera.Size = new System.Drawing.Size(416, 50);
            this.gpbCabecera.TabIndex = 0;
            this.gpbCabecera.TabStop = false;
            this.gpbCabecera.Text = "Buscar";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.gpbBotones);
            this.pnlControles.Controls.Add(this.gpbCabecera);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Padding = new System.Windows.Forms.Padding(3);
            this.pnlControles.Size = new System.Drawing.Size(644, 58);
            this.pnlControles.TabIndex = 0;
            // 
            // gpbBotones
            // 
            this.gpbBotones.Controls.Add(this.btnCancelar);
            this.gpbBotones.Controls.Add(this.btnSeleccionar);
            this.gpbBotones.Location = new System.Drawing.Point(432, 2);
            this.gpbBotones.Name = "gpbBotones";
            this.gpbBotones.Size = new System.Drawing.Size(200, 50);
            this.gpbBotones.TabIndex = 1;
            this.gpbBotones.TabStop = false;
            // 
            // frmBuscarL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(644, 313);
            this.ControlBox = false;
            this.Controls.Add(this.dgrLista);
            this.Controls.Add(this.pnlControles);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBuscarL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frmBuscarL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errValidacion)).EndInit();
            this.gpbCabecera.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.gpbBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgrLista;
        private DevComponents.DotNetBar.ButtonX btnSeleccionar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.Validator.SuperValidator spvValidador;
        private System.Windows.Forms.ErrorProvider errValidacion;
        private DevComponents.DotNetBar.Validator.Highlighter hhlResaltador;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscar;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private System.Windows.Forms.Panel pnlControles;
        public System.Windows.Forms.GroupBox gpbCabecera;
        public System.Windows.Forms.GroupBox gpbBotones;
    }
}