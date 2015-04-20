using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModeloDB;
using System.Collections.Generic;
using System.Linq;

namespace Proveedores
{
    public partial class Efectivo : Form, IControlesUsuario
    {
        private decimal importeTotal;
        public decimal ImporteTotal { get { return importeTotal; } set { importeTotal = value; } }
        public bool Verificado { get; set; }

        conveniopago objetoLocal;
        public object Objeto
        {
            get
            {
                return this.objetoLocal;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object Columnas { get; set; }

        public Efectivo()
        {
            InitializeComponent();
        }

        private void calcularCambio()
        {
            this.txtDevuelto.Text = (decimal.Parse(this.txtRecibido.Text) - this.importeTotal).ToString("N2");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Verificado = this.Verificar();
            if (!this.Verificado)
                General.Mensaje("Verifique el cuadre de valores");
            else
            {
                this.objetoLocal.valor = decimal.Parse(this.txtRecibido.Text);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Verificado = false;
            this.Close();
        }

        public string Modulo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            this.objetoLocal = unObjeto as conveniopago;
            this.importeTotal = ((IEnumerable<Valores>)listaValores).Where(x => x.Efectivo).Sum(x => x.Valor);
            if (objetoLocal != null)
            {
                if (this.objetoLocal.fkpagos != null)
                    if (this.objetoLocal.fkpagos.Count > 0)
                        this.txtRecibido.Text = this.objetoLocal.fkpagos[0].valor.ToString("N2");
            }
            this.txtEfectivo.Text = this.importeTotal.ToString("N2");
            
        }

        public bool Verificar()
        {
            if (decimal.Parse(this.txtEfectivo.Text) + decimal.Parse(this.txtDevuelto.Text) == decimal.Parse(this.txtRecibido.Text))
            {
                pago unPago = new pago()
                    {
                        anulado = false,
                        detalle = "Pago total efectivo",
                        fecha = LinqToDB.Sql.DateTime,
                        //idformapago = objetoLocal.idformapago,
                        idusuarioregistra = General.usuarioActivo.idusuario,
                        idusuariocobranzas = General.usuarioActivo.idusuario,
                        notificacion = false,
                        numero = 1,
                        valor = decimal.Parse(this.txtRecibido.Text)
                    };

                if (this.objetoLocal == null)
                    this.objetoLocal = new conveniopago();

                if (this.objetoLocal.fkpagos == null)
                    this.objetoLocal.fkpagos = new List<pago>();

                if (this.objetoLocal.fkpagos.Count == 0)
                    this.objetoLocal.fkpagos.Add(unPago);
                else
                    this.objetoLocal.fkpagos[0] = unPago;

                return true;
            }
            else
                return false;
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            calcularCambio();
        }



    }
}