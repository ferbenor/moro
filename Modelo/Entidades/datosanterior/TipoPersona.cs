﻿using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class TipoPersona : Instrumental
    {
        #region VARIABLES
        private short id;
        private string descripcion;
        private string abreviatura;
        private const string nombreTabla = "tipospersonas";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value;  } }
        public string Abreviatura { get { return this.abreviatura; } set { this.abreviatura = value;  } }
        public TipoPersona Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public TipoPersona() { }

        public TipoPersona(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 13, this.descripcion));
            lc.Add(new CamposTabla("abreviatura", false, System.Data.DbType.String, 1, this.abreviatura));
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

        public override int CompareTo(object obj)
        {
            if (obj is TipoPersona)
            {
                TipoPersona oVar = obj as TipoPersona;
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
