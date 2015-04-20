namespace Controladores
{
    partial class Reportes
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
            this.rpvInformes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInformes
            // 
            this.rpvInformes.AutoScroll = true;
            this.rpvInformes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInformes.Location = new System.Drawing.Point(0, 0);
            this.rpvInformes.Name = "rpvInformes";
            this.rpvInformes.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rpvInformes.Size = new System.Drawing.Size(810, 595);
            this.rpvInformes.TabIndex = 0;
            this.rpvInformes.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 595);
            this.Controls.Add(this.rpvInformes);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reportes_FormClosing);
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInformes;
    }
}