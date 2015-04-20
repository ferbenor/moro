using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace WindowsApp
{
    public partial class Impresiones : Form
    {
        public Impresiones()
        {
            InitializeComponent();
        }

        private void Impresiones_Load(object sender, EventArgs e)
        {
            this.Icon = General.ObtenerIcono("Listar.ico");
            General.Interfaz(this);
        }

        private void Impresiones_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.optLista.Checked)
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.No;

            this.Close();
        }


    }
}
