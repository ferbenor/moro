using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;
using ModeloDB;

namespace Controladores
{
    public partial class BusquedaContables : Form
    {
        public contable objeto;

        public List<tipocontable> listaTipos;

        public BusquedaContables()
        {
            InitializeComponent();
        }

        private void BusquedaContables_Load(object sender, EventArgs e)
        {
            General.Interfaz(this);
            //General.SoloNumeros(this.txtNumero);

            this.Icon = General.ObtenerIcono("Listar.ico");

            List<fraccionperiodo> listaPeriodos = PeriodoPr.Instancia.RegistrosDePeriodos();
            this.cboTipo.DisplayMember = "Descripcion";
            this.cboTipo.ValueMember = "Objeto";
            this.cboTipo.DataSource = listaTipos;
            this.cboTipo.SelectedIndex = 0;
            this.cboPeriodo.DisplayMember = "Anio";
            this.cboPeriodo.ValueMember = "Anio";
            this.cboPeriodo.DataSource = listaPeriodos;
            this.cboPeriodo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ContablePr proveedor = new ContablePr();
            int numero = 0;
            int.TryParse(this.txtNumeroSN.Text, out numero);
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.lblBuscando.Visible = true;
                objeto = proveedor.RegistroPorId((short)this.cboPeriodo.SelectedValue, (tipocontable)this.cboTipo.SelectedValue, int.Parse(this.txtNumeroSN.Text));
                if (objeto == null)
                {
                    this.lblMensaje.Visible = true;
                    this.txtNumeroSN.Focus();
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }
                this.lblBuscando.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void BusquedaContables_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            this.lblMensaje.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BusquedaContables_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
                e.Cancel = true;
        }
    }
}
