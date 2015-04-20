using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class MenuSistemaAux : Instrumental
    {
        #region VARIABLES
        private short id;
        private string nombre;
        private bool contenedor;
        private const string nombreTabla = "menus";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string IdNombre { get { if (this.id == 0) return General.itemCero; else return this.id.ToString() + "-" + this.nombre; } }
        public bool Contenedor { get { return this.contenedor; } set { this.contenedor = value; } }
        public MenuSistemaAux Objeto { get { return this; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public MenuSistemaAux() { }

        public MenuSistemaAux(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 50, this.nombre));
            lc.Add(new CamposTabla("contenedor", false, System.Data.DbType.Boolean, 0, this.contenedor));
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
            if (obj is MenuSistemaAux)
            {
                MenuSistemaAux oVar = obj as MenuSistemaAux;
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
