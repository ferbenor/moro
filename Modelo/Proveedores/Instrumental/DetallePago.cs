using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class DetallePago : Form
    {
        #region PROPIEDADES
        
        
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public DetallePago()
        {
            InitializeComponent();
        }
        #endregion CONSTRUCTORES

        #region METODOS
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion METODOS
    }
}