using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using ModeloDB;
using Proveedores;

namespace WindowsApp
{
    public partial class PieDetalles : UserControl, IControlesUsuario
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPIEDADES

        public object Columnas { get; set; }

        public string Modulo { get; set; }

        public object Objeto { get; set; }

        #endregion PROPIEDADES

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

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            throw new NotImplementedException();
        }

        public bool Verificar()
        {
            return false;
        }
    }
}
