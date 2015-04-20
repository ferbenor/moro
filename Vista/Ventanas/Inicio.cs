using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Validator;
using Controladores;
using System.Reflection;

namespace WindowsApp
{
    public partial class Inicio : Form
    {
        private bool validado = false;

        private short conteo = 0;

        public bool Validado { get { return validado; } }

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.lblVersion.Text = "Versión: " + VentanaPrincipalCr.Instancia.CargarVersionInfo(Assembly.GetExecutingAssembly());
            this.txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text.Length == 0)
                this.txtUsuario.Focus();
            else
                if (this.txtContrasena.Text.Length == 0)
                    this.txtContrasena.Focus();
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (VentanaPrincipalCr.Instancia.VerificaUsuario(this.txtUsuario.Text, txtContrasena.Text))
                    {
                        this.validado = true;
                        this.Close();
                    }
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conteo += 1;
                    if (conteo == 3)
                    {
                        MessageBox.Show("Ha excedido el número máximo de intentos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    if (this.ActiveControl.GetType().Name == "TextBoxX")
                        ((TextBox)this.ActiveControl).SelectAll();
                }
                
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            this.txtContrasena.SelectAll();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            this.txtUsuario.SelectAll();
        }

        
    }

}



