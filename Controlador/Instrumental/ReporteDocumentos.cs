using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practicas
{
    public partial class ReporteDocumento : Form
    {
        public ReporteDocumento()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            //webBrowser.Url = new Uri("C:\\Users\\Walter Loayza\\Desktop\\Contrato.htm");
            //webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //webBrowser.ShowPrintPreviewDialog();
        }
    }
}
