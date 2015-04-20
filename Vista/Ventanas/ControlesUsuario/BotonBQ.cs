using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class ButtonBQ : UserControl//DevComponents.DotNetBar.Controls.TextBoxX
    {
        public delegate void BotonPulsadoEventHandler(object sender, BotonPulsadoEventArgs e);

        public event BotonPulsadoEventHandler BotonPulsado;

        protected virtual void OnBotonPulsado(BotonPulsadoEventArgs e)
        {
            BotonPulsadoEventHandler handler = BotonPulsado;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        string nombreObjeto = "Apoderado";
        public string NombreObjeto
        {
            get { return this.nombreObjeto; }
            set
            {
                this.nombreObjeto = value;
                this.btnConsultar.Text = "Consultar " + this.nombreObjeto;
                this.btnQuitar.Text = "Quitar " + this.nombreObjeto;
            }
        }



        public ButtonBQ()
        {
            InitializeComponent();

        }

        private void btnPulsado_Click(object sender, EventArgs e)
        {
            switch (((DevComponents.DotNetBar.ButtonX)sender).Name)
            {
                case "btnConsultar":
                    this.OnBotonPulsado(new BotonPulsadoEventArgs() { Boton = 1 });
                    break;
                case "btnQuitar":
                    this.OnBotonPulsado(new BotonPulsadoEventArgs() { Boton = 2 });
                    break;
            }
        }


    }

    public class BotonPulsadoEventArgs : EventArgs
    {
        public int Boton { get; set; }

    }
}
