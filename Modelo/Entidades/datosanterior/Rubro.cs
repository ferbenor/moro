using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Rubro : Instrumental
    {
        #region VARIABLES
        protected int id;
        protected string codigo;//apellido
        protected string nombre;
        protected string definicion;
        protected double valor;
        protected CuentaContable cuentaContable;
        protected bool seFactura;
        protected bool automatico;
        protected bool activo;
        
        protected string nombreTabla = "rubros";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Definicion { get { return this.definicion; } set { this.definicion= value; } }
        public double Valor { get { return this.valor; } set { this.valor = value; } }
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
            set { this.cuentaContable = value; if (value == null) this.IdCuentaContable = 0; else this.IdCuentaContable= value.Id; }
        }
        public bool SeFactura { get { return this.seFactura; } set { this.seFactura= value; } }
        public bool Automatico { get { return this.automatico; } set { this.automatico = value; } }
        public bool Activo { get { return this.activo; } set { this.activo = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Rubro() { }
        
        public Rubro(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("codigo", false, System.Data.DbType.String, 15, this.codigo) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 100, this.nombre) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("definicion", false, System.Data.DbType.String, 200, this.definicion) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("valor", false, System.Data.DbType.Decimal, 0, this.valor) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("idcuentacontable", false, System.Data.DbType.Int16, 0, this.IdCuentaContable) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("sefactura", false, System.Data.DbType.Boolean, 0, this.seFactura) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("automatico", false, System.Data.DbType.Boolean, 0, this.automatico) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.activo) { NombreTabla = nombreTabla });
            

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
            return GeneraCadenaGuardar(nombreTabla, id);
        }

        public void SetId(int unId)
        {
            this.id = unId;
        }

        public virtual void Limpiar()
        {
            this.id = 0;
            this.codigo = null;
            this.nombre = null;
            this.definicion = null;
            this.cuentaContable = null;
            this.valor = 0;
            this.seFactura = false;
            this.automatico = false;
            this.activo = false;
        }


        public override string ToString()
        {
            return this.nombre;
        }

        
        #endregion FUNCIONES LOCALES


    }
}
