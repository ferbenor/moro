using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Proveedores;

namespace Controladores
{
    public partial class PieDetalles : UserControl, IControlesUsuario
    {
        object objetoContable;
        string modulo;

        public object Objeto { get { return this.objetoContable; } set { this.objetoContable = value; this.CargarDatos(); } }

        public string Modulo { get { return this.modulo; } set { this.modulo = value; } }

        public PieDetalles()
        {
            InitializeComponent();
        }

        private void PieDetalles_Load(object sender, EventArgs e)
        {
            this.dgrLista.AutoGenerateColumns = false;
            switch (this.Modulo)
            {
                case "ContablePr":
                    //ContableCr.Instancia.RaiseEstructuraGridDetalle(this.dgrLista);
                    break;
                default:
                    break;
            }
        }

        private void CargarDatos()
        {
            switch (this.Modulo)
            {
                case "ContablePr":
                    this.dgrLista.DataSource = null;
                    this.dgrLista.DataSource = ((Contable)this.Objeto).DetalleContable;
                    break;
                default:
                    break;
            }
            this.lblNumero.Text = "Registros detalle: " + this.dgrLista.RowCount;
        }

        public void OnDobleClick()
        {

        }
    }
}
