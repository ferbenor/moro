using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Inicio frmInicio = new Inicio();
            frmInicio.ShowDialog();
            if (frmInicio.Validado != false)
            {
                frmInicio.Dispose();
                Application.Run(new Principal());
            }
            else
                Application.Exit();
            //Application.Run(new Inicio());
            
            //Application.Run(new Form2W());
        }
    }
}
