using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsApp
{
    public partial class Reportes : Form
    {
        public string Reporte { get; set; }
        public object Lista { get; set; }
        public ReportParameterCollection ListaParametros { get; set; }
        public string FuenteDatos { get; set; }

        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            this.rpvInformes.Reset();
            this.rpvInformes.ProcessingMode = ProcessingMode.Local;
            //this.rpvInformes.LocalReport.ReportPath = this.Reporte;
            this.rpvInformes.LocalReport.ReportEmbeddedResource = "WindowsApp.Reportes." + this.Reporte + ".rdlc";
            if (ListaParametros == null)
            {
                ReportDataSource datos = new ReportDataSource();
                datos.Name = this.FuenteDatos;
                datos.Value = this.Lista;
                this.rpvInformes.RefreshReport();
                this.rpvInformes.LocalReport.DataSources.Clear();
                this.rpvInformes.LocalReport.DataSources.Add(datos);
                //this.rpvInformes.RefreshReport();
            }
            else
            {
                this.rpvInformes.LocalReport.SetParameters(ListaParametros);
            }
            this.rpvInformes.RefreshReport();
            this.rpvInformes.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void Reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rpvInformes.Reset();
        }


    }
}
