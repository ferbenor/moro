using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class CuentaBanco : Instrumental
    {
        #region VARIABLES
        private short id;
        private string descripcion;
        private string numeroCuenta;
        private Banco banco;
        private DateTime fechaApertura;
        private decimal saldoCuenta;
        private const string nombreTabla = "cuentasbanco";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public string NumeroCuenta { get { return this.numeroCuenta; } set { this.numeroCuenta = value; } }
        public short IdBanco { get; set; }
        public Banco Banco
        {
            get
            {
                if (this.banco == null)
                    return General.bancoCero;
                else
                    return this.banco;
            }
            set { this.banco = value; this.IdBanco = this.banco.Id; }
        }
        public DateTime FechaApertura { get { return this.fechaApertura; } set { this.fechaApertura = value; } }
        public decimal SaldoCuenta { get { return this.saldoCuenta; } set { this.saldoCuenta = value; } }
        public CuentaBanco Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public CuentaBanco() { }

        public CuentaBanco(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 25, this.descripcion));
            lc.Add(new CamposTabla("numerocuenta", false, System.Data.DbType.String, 25, this.numeroCuenta));
            lc.Add(new CamposTabla("idbanco", false, System.Data.DbType.Int16, 0, this.Banco.Id));
            lc.Add(new CamposTabla("fechaapertura", false, System.Data.DbType.DateTime, 0, this.fechaApertura));
            lc.Add(new CamposTabla("saldocuenta", false, System.Data.DbType.Decimal, 0, this.saldoCuenta));
            return lc;
        }

        public string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, id);
        }
        public override string ToString()
        {
            return this.descripcion;
        }
        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is CuentaBanco)
            {
                CuentaBanco oVar = obj as CuentaBanco;
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
    }
}
