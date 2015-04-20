using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class ActividadEconomicaAux : Instrumental
    {
        #region VARIABLES
        protected short id;
        protected string codigo;
        protected string nombre;
        protected string descripcion;
        
        private const string nombreTabla = "actividadeseconomicas";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public string IdNombre { get { if (this.id > 0) return this.codigo + "-" + this.descripcion; else return ""; } }
        public ActividadEconomicaAux Objeto { get { return this; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ActividadEconomicaAux() { }

        public ActividadEconomicaAux(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.id, true));
            lc.Add(new CamposTabla("codigo", false, System.Data.DbType.String, 500, this.codigo));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 500, this.codigo));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 500, this.descripcion));
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
            if (obj is ActividadEconomicaAux)
            {
                ActividadEconomicaAux oVar = obj as ActividadEconomicaAux;
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
