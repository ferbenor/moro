using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;

namespace WindowsApp.ControlesUsuario
{
    public partial class CabeceraContables : UserControl, IControlesUsuario
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPIEDADES

        public object Columnas { get; set; }

        public string Modulo { get; set; }

        public object Objeto { get; set; }

        #endregion PROPIEDADES

        public CabeceraContables()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            //object objeto;

            //Form form = ((IAccesoMetodos)this.ParentForm).Examinar(31, out objeto);

            //ESTABLECEMOS INSTANCIA DE PROVEEDOR DENTRO DEL CONTROLADOR OBTENIDA DESDE LISTA
            //ContableCr.Instancia.proveedor = null;
            //ContableCr.Instancia.proveedor = (Proveedores.ContablePr)((IAccesoMetodos)this.ParentForm).ProveedorInstancia;
            //((IAccesoMetodos)form).EstablecerObjetoLocal(objeto);

            //Entidades.TipoContable a = ContableCr.Instancia.proveedor.ListaTipoContable[0];
            //Entidades.TipoContable b = ((Entidades.Contable)((IAccesoMetodos)form).ObtenerObjetoLocal()).TipoContable;


            //((IAccesoMetodos)form).RaiseEvent = true;
            //ContableCr.Instancia.RaiseCargaVista(((IAccesoMetodos)form).ObtenerObjetoLocal());

            //((IAccesoMetodos)form).RaiseEvent = false;
        }

        private void CabeceraContables_Load(object sender, EventArgs e)
        {
            if (this.cboTipo.DataSource == null)
                this.cboTipo.DataSource = ContableCr.Instancia.proveedor.ListaTipoContable;
        }

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            this.btnExaminar.PerformClick();
        }

        public bool Verificar()
        {
            return false;
        }
    }
}
