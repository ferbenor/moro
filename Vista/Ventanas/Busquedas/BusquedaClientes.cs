using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;
using Entidades;

namespace WindowsApp
{
    public partial class BusquedaClientes : Form
    {
        public ClientePr proveedor;
        public Cliente objeto;

        public BusquedaClientes()
        {
            InitializeComponent();
        }

        private void BusquedaContables_Load(object sender, EventArgs e)
        {
            General.Interfaz(this);
            
            this.Icon = General.ObtenerIcono("Listar.ico");

            this.cboTipo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            int numero = 0;
            int.TryParse(this.txtNumero.Text, out numero);
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.lblBuscando.Visible = true;
                //objeto = proveedor.RegistroPorId(int.Parse(this.txtNumero.Text));
                if (objeto == null)
                {
                    this.lblMensaje.Visible = true;
                    this.txtNumero.Focus();
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

        private void BusquedaClientes_FormClosed(object sender, FormClosedEventArgs e)
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

        private void BusquedaClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
                e.Cancel = true;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNumero.Size = new Size(98, 22);

            switch (this.cboTipo.SelectedIndex)
            {
                case 0:
                    this.txtNumero.TextAlign = HorizontalAlignment.Left;
                    General.SoloNumeros(this.txtNumero);
                    break;
                case 1:
                    this.txtNumero.TextAlign = HorizontalAlignment.Right;
                    General.SoloNumeros(this.txtNumero);
                    break;
                case 2:
                    this.txtNumero.TextAlign = HorizontalAlignment.Left;
                    General.QuitarSoloNumeros(this.txtNumero);
                    this.txtNumero.Size = new Size(130, 22);
                    break;
            }
        }
    }
}
