using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class CuentaContableAux : Instrumental
    {
        #region VARIABLES
        protected int id;
        protected string nombre;
        protected string codigo;
        private const string nombreTabla = "cuentascontables";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string IdNombre { get { if (this.id > 0) return this.codigo + "-" + this.nombre; else return ""; } }
        public CuentaContableAux Objeto { get { return this; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public CuentaContableAux() { }

        public CuentaContableAux(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 80, this.nombre));
            lc.Add(new CamposTabla("codigo", false, System.Data.DbType.String, 20, this.codigo));
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
            return GeneraCadenaGuardar(nombreTabla, this.id);
        }

        public override string ToString()
        {
            return this.IdNombre;
        }

        public override int CompareTo(object obj)
        {
            if (obj is CuentaContableAux)
            {
                CuentaContableAux oVar = obj as CuentaContableAux;
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
