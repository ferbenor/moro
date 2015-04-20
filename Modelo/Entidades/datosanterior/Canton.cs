using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Canton : Instrumental
    {
        #region VARIABLES
        private short id;
        private string nombre;
        private Provincia provincia;
        private const string nombreTabla = "cantones";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value;  } }
        public string NombreUbicacion
        {
            get { 
                if (this.provincia == null)
                    return this.nombre;
                else
                    return this.nombre + ", " + this.Provincia.Nombre ; 
            }
        }
        public short IdProvincia { get; set; }
        public Provincia Provincia
        {
            get
            {
                if (this.provincia == null)
                    return General.provinciaCero;
                else
                    return this.provincia;
            }
            set { this.provincia = value;  }
        }
        //public bool Modificado { get { return modificado; } }
        public Canton Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Canton() { }

        public Canton(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 50, this.nombre));
            lc.Add(new CamposTabla("idprovincia", false, System.Data.DbType.Int16, 0, this.Provincia.Id));
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

        public override int CompareTo(object obj)
        {
            if (obj is Canton)
            {
                Canton oVar = obj as Canton;
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
