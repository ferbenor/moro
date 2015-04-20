using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class UnidadMedida : Instrumental
    {
        #region VARIABLES
        private short id;
        private string descripcion;
        private bool activo;
        private const string nombreTabla = "unidadesdemedida";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public bool Activo { get { return this.activo; } set { this.activo = value; } }
        public UnidadMedida Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public UnidadMedida() { }

        public UnidadMedida(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 50, this.descripcion) { NombreTabla = nombreTabla });
            lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.activo) { NombreTabla = nombreTabla });
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
            return this.Descripcion;
        }
        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is UnidadMedida)
            {
                UnidadMedida oVar = obj as UnidadMedida;
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
