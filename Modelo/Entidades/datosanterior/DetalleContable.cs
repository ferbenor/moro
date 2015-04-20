using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class DetalleContable : Instrumental
    {
        #region VARIABLES
        //private int numero;
        //private short periodo = General.periodoActual;
        //private TipoContable tipoContable;
        private Contable cabContable;
        private short registro;
        private string codigoCuenta;
        private CuentaContable cuentaContable;
        private string detalleCuenta;
        private decimal valorDebe;
        private decimal valorHaber;
        private short tipoMovimiento;

        private const string nombreTabla = "detallescontable";
        #endregion VARIABLES

        #region PROPIEDADES
        //public int Numero { get { return this.numero; } set { this.numero = value; } }
        //public short Periodo { get { return this.periodo; } set { this.periodo = value; } }
        //public short IdTipoContable { get; set; }
        //public TipoContable TipoContable
        //{
        //    get
        //    {
        //        if (this.tipoContable == null)
        //            return General.tipoContableCero;
        //        else
        //            return this.tipoContable;
        //    }
        //    set { this.tipoContable = value; }
        //}
        public Contable CabContable
        {
            get { return cabContable; }
            set
            {
                cabContable = value;
            }
        }
        public short Registro { get { return this.registro; } set { this.registro = value; } }
        public string CodigoCuenta { get { if (this.codigoCuenta == null) return ""; else return this.codigoCuenta; } set { this.codigoCuenta = value; } }
        public int IdCuentaContable { get; set; }
        public CuentaContable CuentaContable
        {
            get
            {
                if (this.cuentaContable == null)
                    return General.cuentaContableCero;
                else
                    return this.cuentaContable;
            }
            set
            {
                this.cuentaContable = value;
                if (value == null) { this.codigoCuenta = null; this.IdCuentaContable = 0; }
                else { this.codigoCuenta = value.Codigo; this.IdCuentaContable = value.Id; }
            }
        }
        public string DetalleCuenta { get { return this.detalleCuenta; } set { if (!string.IsNullOrWhiteSpace(this.codigoCuenta)) this.detalleCuenta = value; } }
        public decimal ValorDebe { get { return this.valorDebe; } set { if (!string.IsNullOrWhiteSpace(this.codigoCuenta)) { this.valorDebe = value; this.valorHaber = 0; if (this.valorDebe > 0) this.tipoMovimiento = 1; else this.tipoMovimiento = 0; } } }
        public decimal ValorHaber { get { return this.valorHaber; } set { if (!string.IsNullOrWhiteSpace(this.codigoCuenta)) { this.valorHaber = value; this.valorDebe = 0; if (this.valorHaber > 0) this.tipoMovimiento = 2; else this.tipoMovimiento = 0; } } }
        public short TipoMovimiento { get { return this.tipoMovimiento; } set { this.tipoMovimiento = value; } }
        public DetalleContable Objeto { get { return this; } }
        //public string DescripcionDetalleContable { get { return this.periodo + " - " + this.TipoContable.Descripcion + " - " + String.Format("{0:00000000}", this.numero) + " - " + String.Format("{0:00}", this.registro) + " - Cuenta: " + this.CuentaContable.ToString() + " - D: " + this.valorDebe + " - H: " + this.valorHaber; } }
        public string DescripcionDetalleContable { get { return (this.CabContable == null ? 0 : this.CabContable.Periodo) + " - " + (this.CabContable == null ? "" : this.CabContable.TipoContable.Descripcion) + " - " + String.Format("{0:00000000}", (this.CabContable == null ? 0 : this.CabContable.Numero)) + " - " + String.Format("{0:00}", this.registro) + " - Cuenta: " + this.CuentaContable.ToString() + " - D: " + this.valorDebe + " - H: " + this.valorHaber; } }

        public string NombreCuenta { get { return this.CuentaContable.Nombre; } }
        public int NumeroContable { get { return this.CabContable.Numero; } }
        public string TipoContable { get { return this.CabContable.TipoContable.ToString(); } }
        public short Periodo { get { return this.CabContable.Periodo; } }
        public DateTime Fecha { get { return this.CabContable.Fecha; } }
        public string Beneficiario { get { return this.CabContable.Beneficiario.ToString(); } }
        public string Observacion { get { return this.cabContable.Observacion; } }
        public decimal Valor { get { return CabContable.Valor; } }
        public string RegistradoPor { get { return CabContable.UsuarioRegistra.ToString(); } }
        public string FechaCreacion { get { return CabContable.FechaCreacionChr; } }
        public string FechaModificacion { get { return CabContable.FechaModificacionChr; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public DetalleContable() { }

        public DetalleContable(Contable unContable) { this.cabContable = unContable; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("numerocontable", true, System.Data.DbType.Int32, 0, this.CabContable.Numero));
            lc.Add(new CamposTabla("periodo", true, System.Data.DbType.Int16, 0, this.CabContable.Periodo));
            lc.Add(new CamposTabla("idtipocontable", true, System.Data.DbType.Int16, 0, this.CabContable.IdTipoContable));
            lc.Add(new CamposTabla("registro", false, System.Data.DbType.Int16, 0, this.registro));
            lc.Add(new CamposTabla("idcuentacontable", false, System.Data.DbType.Int32, 0, this.CuentaContable.Id));
            lc.Add(new CamposTabla("detallecuenta", false, System.Data.DbType.String, 0, this.detalleCuenta));
            lc.Add(new CamposTabla("valordebe", false, System.Data.DbType.Decimal, 0, this.valorDebe));
            lc.Add(new CamposTabla("valorhaber", false, System.Data.DbType.Decimal, 0, this.valorHaber));
            lc.Add(new CamposTabla("tipomovimiento", false, System.Data.DbType.Int16, 0, this.tipoMovimiento));
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
            return this.DescripcionDetalleContable;
        }
        #endregion FUNCIONES LOCALES
    }
}
