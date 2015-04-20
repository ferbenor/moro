using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Ediciones : Form
    {
        public Ediciones()
        {
            InitializeComponent();
        }

        private void Ediciones_Load(object sender, EventArgs e)
        {
            this.dgrLista.Dock = DockStyle.Fill;
            this.pnlControles.Dock = DockStyle.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.gpbBusqueda.Visible = true;
            this.dgrLista.Visible = true;
        }

        private void dgrLista_Click(object sender, EventArgs e)
        {
            this.gpbBusqueda.Visible = false;
            this.dgrLista.Visible = false;
            this.pnlControles.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.pnlControles.Visible = false;
            this.dgrLista.Visible = true;
        }
    }
}
