using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloDB;

namespace WindowsApp
{
    public partial class CambioClave : Form
    {
        private string claveAnterior;
        private string nuevaClave;
        private usuario usuarioVerificado;
        private bool registrar = false;

        public usuario UsuarioVerificado { get { return usuarioVerificado; } set { usuarioVerificado = value; } }
        public string ClaveAnterior { get { return claveAnterior; } }
        public string NuevaClave { get { return nuevaClave; } }
        public bool Registrar { get { return registrar; } set { registrar = value; } }
        
        public CambioClave()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtClaveAnterior.Text.Length == 0)
                this.txtClaveAnterior.Focus();
            else
                if (this.txtNuevaClave.Text.Length == 0)
                    this.txtNuevaClave.Focus();
                else
                    if (this.txtConfirmacion.Text.Length == 0)
                        this.txtConfirmacion.Focus();
            if (!String.Equals(usuarioVerificado.clave, General.CifrarClave(usuarioVerificado.loginusuario + " " + this.txtClaveAnterior.Text)))
                General.Mensaje("Clave anterior incorrecta. \nPor favor verifique.", MessageBoxIcon.Information);
            else
            {
                this.spvValidador.Validate();
                if (this.spvValidador.LastFailedValidationResults.Count == 0)
                {
                    this.claveAnterior = this.txtClaveAnterior.Text;
                    this.nuevaClave = this.txtConfirmacion.Text;
                    this.registrar = true;
                    this.Close();
                }
            }
        }

     }
}
