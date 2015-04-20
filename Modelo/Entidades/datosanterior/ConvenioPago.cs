using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class ConvenioPago : Instrumental
    {
        #region VARIABLES
        private IdentificadorPago identificadorPagos;
        private FormaPago formaPago;
        private List<Pago> pago;
        private const string nombreTabla = "conveniopagos";
        #endregion VARIABLES

        #region PROPIEDADES
        public int IdIdentificadorPagos { get; set; }
        public IdentificadorPago IdentificadorPagos
        {
            get
            {
                if (this.identificadorPagos == null)
                { this.identificadorPagos = General.identificadorPagosCero; this.IdIdentificadorPagos = this.identificadorPagos.Id; }
                return this.identificadorPagos;
            }
            set { this.identificadorPagos = value; if (value == null) this.IdIdentificadorPagos = 0; else this.IdIdentificadorPagos = value.Id; }
        }
        public short IdFormaPago { get; set; }
        public FormaPago FormaPago
        {
            get
            {
                if (this.formaPago == null)
                { this.formaPago = General.formaPagoCero; this.IdFormaPago = this.formaPago.Id; }
                return this.formaPago;
            }
            set { this.formaPago = value; if (value == null) this.IdFormaPago = 0; else this.IdFormaPago = value.Id; }
        }
        public List<Pago> Pago { get { if (pago == null) { this.pago = new List<Pago>(); return this.pago; } else return this.pago; } set { this.pago = value; } }
        public ConvenioPago Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region Constructores
        public ConvenioPago() { }

        public ConvenioPago(int unIdIdentificadorPagos)
        {
            this.IdIdentificadorPagos = unIdIdentificadorPagos;
        }

        public ConvenioPago(int unIdIdentificadorPagos, short unIdFormaPago)
        {
            this.IdIdentificadorPagos = unIdIdentificadorPagos;
            this.IdFormaPago = unIdFormaPago;
        }

        #endregion Constructores

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("identificadorpagos", true, System.Data.DbType.Int32, 0, this.IdIdentificadorPagos, true));
            lc.Add(new CamposTabla("formapago", false, System.Data.DbType.Int16, 0, this.IdFormaPago));

            return lc;
        }

        public virtual string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public virtual string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public virtual string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public virtual string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, 0);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void SetId(int unIdIdentificadorPagos)
        {
            this.IdIdentificadorPagos = unIdIdentificadorPagos;
        }

        public void SetValores(int unIdIdentificadorPagos, short unIdFormaPago)
        {
            this.IdIdentificadorPagos = unIdIdentificadorPagos;
            this.IdFormaPago = unIdFormaPago;
        }

        public void Limpiar()
        {
            this.identificadorPagos = null;
            this.formaPago = null;
        }

        public override int CompareTo(object obj)
        {
            if (obj is ConvenioPago)
            {
                ConvenioPago oVar = obj as ConvenioPago;
                return String.Compare(this.ToString(), oVar.ToString(), true);
            }
            else if (obj is string)
            {
                return String.Compare(this.ToString(), obj as string);
            }
            else
            {
                return -1;
            }
        }


        #endregion FUNCIONES LOCALES
    }
}
