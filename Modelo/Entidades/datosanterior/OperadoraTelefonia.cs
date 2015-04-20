﻿using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class OperadoraTelefonia : Instrumental
    {
        #region VARIABLES
        private short id;
        private string nombre;
        private const string nombreTabla = "operadorastelefonia";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value;  } }
        public OperadoraTelefonia Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public OperadoraTelefonia() { }

        public OperadoraTelefonia(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 20, this.nombre));
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
            return this.nombre;
        }

        public override int CompareTo(object obj)
        {
            if (obj is OperadoraTelefonia)
            {
                OperadoraTelefonia oVar = obj as OperadoraTelefonia;
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
