using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Barrio : Instrumental
    {
        #region VARIABLES
        private int id;
        private string nombre;
        private Parroquia parroquia;
        private bool activo = false;
        private const string nombreTabla = "barrios";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value;  } }
        public string NombreUbicacion
        {
            get
            {
                if (this.parroquia == null)
                    return this.nombre;
                else
                    return this.nombre + ", " + this.Parroquia.NombreUbicacion;
            }
        }
        public int IdParroquia { get; set; }
        public Parroquia Parroquia
        {
            get
            {
                if (this.parroquia == null)
                    return General.parroquiaCero;
                else
                    return this.parroquia;
            }
            set { this.parroquia = value; this.IdParroquia = this.parroquia.Id;  }
        }
        public bool Activo { get { return this.activo; } set { this.activo = value;  } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Barrio() { }

        public Barrio(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 200, this.nombre));
            lc.Add(new CamposTabla("idparroquia", false, System.Data.DbType.Int32, 0, this.Parroquia.Id));
            lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.activo));
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
            return this.NombreUbicacion;
        }

        //public override int CompareTo(object obj)
        //{
        //    if (obj is Barrio)
        //    {
        //        Barrio oVar = obj as Barrio;
        //        return String.Compare(this.ToString(), oVar.ToString(), true);
        //    }
        //    else if (obj is string)
        //    {
        //        return String.Compare(this.ToString(), obj as string);
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}
        #endregion FUNCIONES LOCALES
    }
}
