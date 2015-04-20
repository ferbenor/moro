using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Parroquia : Instrumental
    {
        #region VARIABLES
        private short id;
        private string nombre;
        private Canton canton;
        private bool esUrbano = false;
        private const string nombreTabla = "parroquias";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value;  } }
        public string NombreUbicacion
        {
            get
            {
                if (this.canton == null)
                    return this.nombre;
                else
                    return this.nombre + ", " + this.Canton.NombreUbicacion;
            }
        }
        public short IdCanton { get; set; }
        public Canton Canton
        {
            get
            {
                if (this.canton == null)
                    return General.cantonCero;
                else
                    return this.canton;
            }
            set { this.canton = value; this.IdCanton = this.canton.Id;  }
        }
        public bool EsUrbano { get { return this.esUrbano; } set { this.esUrbano = value;  } }
        public Parroquia Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Parroquia() { }

        public Parroquia(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 100, this.nombre));
            lc.Add(new CamposTabla("idcanton", false, System.Data.DbType.Int16, 0, this.Canton.Id));
            lc.Add(new CamposTabla("esurbano", false, System.Data.DbType.Boolean, 0, this.esUrbano));
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
            return this.Nombre;
        }
        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is Parroquia)
            {
                Parroquia oVar = obj as Parroquia;
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
