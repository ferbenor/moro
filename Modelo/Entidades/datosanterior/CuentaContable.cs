using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class CuentaContable : Instrumental
    {
        #region VARIABLES
        private int id;
        private CuentaContableAux padre;
        private string codigo;
        private string codigoPadre;
        private short periodo;
        private string nombre;
        private bool esGrupo;
        private decimal debitoInicial;
        private decimal creditoInicial;
        private DateTime fechaApertura = DateTime.Now;
        private bool vinculada = false;
        private const string nombreTabla = "cuentascontables";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public int IdPadre { get; set; }
        public CuentaContableAux Padre
        {
            get
            {
                if (this.padre == null)
                    return General.cuentaContableAuxCero;
                else
                    return this.padre;
            }
            set
            {
                this.padre = value;
                if (value == null) this.codigoPadre = "";
                else this.CodigoPadre = value.Codigo;

            }
        }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string CodigoPadre { get { if (this.codigoPadre == null) return ""; else return this.codigoPadre; } set { this.codigoPadre = value; } }
        public short Periodo { get { return this.periodo; } /*set { this.periodo = value;  }*/ }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string IdNombre { get { if (this.id == 0) return General.itemVacio; else return this.codigo.ToString() + "-" + this.nombre; } }
        public bool EsGrupo
        {
            get { return this.esGrupo; }
            set
            {
                if (vinculada)
                    this.esGrupo = true;
                else
                {
                    this.esGrupo = value;

                }
            }
        }
        public decimal DebitoInicial { get { return this.debitoInicial; } set { this.debitoInicial = value; } }
        public decimal CreditoInicial { get { return this.creditoInicial; } set { this.creditoInicial = value; } }
        public string FechaAperturaChr { get { if (this.fechaApertura == new DateTime(1900, 1, 1)) return ""; else return this.fechaApertura.ToString(); } }
        public DateTime FechaApertura { get { return fechaApertura; } }
        public bool Vinculada { get { return this.vinculada; } }
        public CuentaContable Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public CuentaContable() { this.periodo = General.periodoActual; }

        public CuentaContable(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.id, true));
            lc.Add(new CamposTabla("idpadre", false, System.Data.DbType.Int16, 0, this.Padre.Id));
            lc.Add(new CamposTabla("codigo", false, System.Data.DbType.String, 20, this.codigo));
            lc.Add(new CamposTabla("periodo", false, System.Data.DbType.Int16, 0, this.periodo));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 80, this.nombre));
            lc.Add(new CamposTabla("esgrupo", false, System.Data.DbType.Boolean, 0, this.esGrupo));
            lc.Add(new CamposTabla("debitoinicial", false, System.Data.DbType.Decimal, 0, this.debitoInicial));
            lc.Add(new CamposTabla("creditoinicial", false, System.Data.DbType.Decimal, 0, this.creditoInicial));
            lc.Add(new CamposTabla("fechaapertura", false, System.Data.DbType.Date, 0, null, false, true));
            lc.Add(new CamposTabla("case when (select count(c.codigo) from cuentascontables c where c.idpadre = " + nombreTabla + ".id and c.periodo = " + General.periodoActual + ") = 0 then false else true end vinculado", false, System.Data.DbType.Boolean, 0, -1, false, true));
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
            if (String.IsNullOrEmpty(this.IdNombre))
                return "";
            else
                return this.IdNombre;
        }

        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is CuentaContable)
            {
                CuentaContable oVar = obj as CuentaContable;
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
