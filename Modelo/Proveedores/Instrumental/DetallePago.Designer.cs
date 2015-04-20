namespace WindowsApp
{
    partial class DetallePago
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.txtTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDevuelto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDevuelto = new System.Windows.Forms.Label();
            this.stcFormasPagos = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtMeses = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMeses = new System.Windows.Forms.Label();
            this.cboTarjeta = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBuscarBanco = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tabTarjeta = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabCredito = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabEfectivo = new DevComponents.DotNetBar.SuperTabItem();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.stcFormasPagos)).BeginInit();
            this.stcFormasPagos.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.pnlBotones.SuspendLayout();
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
            this.txtRecibido.Location = new System.Drawing.Point(72, 5);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(98, 22);
            this.txtRecibido.TabIndex = 1;
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRecibido
            // 
            this.lblRecibido.BackColor = System.Drawing.Color.Transparent;
            this.lblRecibido.Location = new System.Drawing.Point(4, 5);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(65, 22);
            this.lblRecibido.TabIndex = 0;
            this.lblRecibido.Text = "Recibido";
            this.lblRecibido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(4, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 27);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Location = new System.Drawing.Point(72, 8);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 28);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(163, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTotal.Border.Class = "TextBoxBorder";
            this.txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.FocusHighlightEnabled = true;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(72, 12);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(98, 29);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtDevuelto.Location = new System.Drawing.Point(72, 33);
            this.txtDevuelto.Name = "txtDevuelto";
            this.txtDevuelto.Size = new System.Drawing.Size(98, 22);
            this.txtDevuelto.TabIndex = 7;
            this.txtDevuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDevuelto
            // 
            this.lblDevuelto.BackColor = System.Drawing.Color.Transparent;
            this.lblDevuelto.Location = new System.Drawing.Point(4, 33);
            this.lblDevuelto.Name = "lblDevuelto";
            this.lblDevuelto.Size = new System.Drawing.Size(65, 22);
            this.lblDevuelto.TabIndex = 5;
            this.lblDevuelto.Text = "Devuelto";
            this.lblDevuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stcFormasPagos
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.stcFormasPagos.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stcFormasPagos.ControlBox.MenuBox.Name = "";
            this.stcFormasPagos.ControlBox.MenuBox.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Random;
            this.stcFormasPagos.ControlBox.Name = "";
            this.stcFormasPagos.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stcFormasPagos.ControlBox.MenuBox,
            this.stcFormasPagos.ControlBox.CloseBox});
            this.stcFormasPagos.Controls.Add(this.superTabControlPanel3);
            this.stcFormasPagos.Controls.Add(this.superTabControlPanel2);
            this.stcFormasPagos.Controls.Add(this.superTabControlPanel1);
            this.stcFormasPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.stcFormasPagos.Location = new System.Drawing.Point(0, 49);
            this.stcFormasPagos.Name = "stcFormasPagos";
            this.stcFormasPagos.ReorderTabsEnabled = true;
            this.stcFormasPagos.SelectedTabIndex = 1;
            this.stcFormasPagos.Size = new System.Drawing.Size(434, 123);
            this.stcFormasPagos.TabIndex = 8;
            this.stcFormasPagos.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabEfectivo,
            this.tabCredito,
            this.tabTarjeta});
            this.stcFormasPagos.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.txtMeses);
            this.superTabControlPanel3.Controls.Add(this.lblMeses);
            this.superTabControlPanel3.Controls.Add(this.cboTarjeta);
            this.superTabControlPanel3.Controls.Add(this.lblTarjeta);
            this.superTabControlPanel3.Controls.Add(this.lblBanco);
            this.superTabControlPanel3.Controls.Add(this.txtBuscarBanco);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(434, 98);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tabTarjeta;
            // 
            // txtMeses
            // 
            this.txtMeses.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMeses.Border.Class = "TextBoxBorder";
            this.txtMeses.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMeses.FocusHighlightEnabled = true;
            this.txtMeses.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeses.Location = new System.Drawing.Point(73, 70);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(98, 22);
            this.txtMeses.TabIndex = 15;
            this.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMeses
            // 
            this.lblMeses.BackColor = System.Drawing.Color.Transparent;
            this.lblMeses.Location = new System.Drawing.Point(5, 70);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(65, 22);
            this.lblMeses.TabIndex = 14;
            this.lblMeses.Text = "Meses";
            this.lblMeses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTarjeta
            // 
            this.cboTarjeta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjeta.FormattingEnabled = true;
            this.cboTarjeta.ItemHeight = 16;
            this.cboTarjeta.Location = new System.Drawing.Point(73, 42);
            this.cboTarjeta.Name = "cboTarjeta";
            this.cboTarjeta.Size = new System.Drawing.Size(182, 22);
            this.cboTarjeta.TabIndex = 11;
            this.cboTarjeta.WatermarkText = "Tarjeta";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.lblTarjeta.Location = new System.Drawing.Point(13, 42);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(57, 21);
            this.lblTarjeta.TabIndex = 10;
            this.lblTarjeta.Text = "Tarjeta";
            this.lblTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBanco
            // 
            this.lblBanco.BackColor = System.Drawing.Color.Transparent;
            this.lblBanco.Location = new System.Drawing.Point(13, 15);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(57, 21);
            this.lblBanco.TabIndex = 12;
            this.lblBanco.Text = "Banco";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarBanco
            // 
            this.txtBuscarBanco.AutoSelectAll = true;
            // 
            // 
            // 
            this.txtBuscarBanco.Border.Class = "TextBoxBorder";
            this.txtBuscarBanco.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscarBanco.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F4;
            this.txtBuscarBanco.ButtonCustom.Visible = true;
            this.txtBuscarBanco.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.Del;
            this.txtBuscarBanco.ButtonCustom2.Visible = true;
            this.txtBuscarBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarBanco.FocusHighlightEnabled = true;
            this.txtBuscarBanco.Location = new System.Drawing.Point(73, 13);
            this.txtBuscarBanco.Multiline = true;
            this.txtBuscarBanco.Name = "txtBuscarBanco";
            this.txtBuscarBanco.ReadOnly = true;
            this.txtBuscarBanco.Size = new System.Drawing.Size(349, 23);
            this.txtBuscarBanco.TabIndex = 13;
            this.txtBuscarBanco.WatermarkText = "Seleccione el banco";
            // 
            // tabTarjeta
            // 
            this.tabTarjeta.AttachedControl = this.superTabControlPanel3;
            this.tabTarjeta.GlobalItem = false;
            this.tabTarjeta.Name = "tabTarjeta";
            this.tabTarjeta.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabTarjeta.TabFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabTarjeta.Text = "Tarjeta de crédito";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(434, 98);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabCredito;
            // 
            // tabCredito
            // 
            this.tabCredito.AttachedControl = this.superTabControlPanel2;
            this.tabCredito.GlobalItem = false;
            this.tabCredito.Name = "tabCredito";
            this.tabCredito.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCredito.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCredito.Text = "Crédito directo";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.txtRecibido);
            this.superTabControlPanel1.Controls.Add(this.txtDevuelto);
            this.superTabControlPanel1.Controls.Add(this.lblRecibido);
            this.superTabControlPanel1.Controls.Add(this.lblDevuelto);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(434, 98);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabEfectivo;
            // 
            // tabEfectivo
            // 
            this.tabEfectivo.AttachedControl = this.superTabControlPanel1;
            this.tabEfectivo.GlobalItem = false;
            this.tabEfectivo.Name = "tabEfectivo";
            this.tabEfectivo.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEfectivo.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEfectivo.Text = "Efectivo";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.Transparent;
            this.pnlCabecera.Controls.Add(this.txtTotal);
            this.pnlCabecera.Controls.Add(this.lblTotal);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(434, 49);
            this.pnlCabecera.TabIndex = 9;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 172);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(434, 42);
            this.pnlBotones.TabIndex = 10;
            // 
            // DetallePago
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(434, 214);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.stcFormasPagos);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetallePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de pago";
            ((System.ComponentModel.ISupportInitialize)(this.stcFormasPagos)).EndInit();
            this.stcFormasPagos.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtRecibido;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Label lblTotal;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDevuelto;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTotal;
        private System.Windows.Forms.Label lblDevuelto;
        private DevComponents.DotNetBar.SuperTabControl stcFormasPagos;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabEfectivo;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabCredito;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tabTarjeta;
        private System.Windows.Forms.DataGridViewImageColumn colVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioRegistra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioAnula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAnula;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlBotones;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMeses;
        private System.Windows.Forms.Label lblMeses;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTarjeta;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label lblBanco;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscarBanco;
    }
}