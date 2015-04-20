using System;
using System.Collections.Generic;
using System.Text;
using Estructura;
using System.Reflection;

namespace Entidades
{
    public class Asignacion
    {
        #region VARIABLES
        private short id = 0;
        private string nombre = null;
        private bool editable;
        private bool asignado;
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } }
        public bool Editable { get { return this.editable; } set { this.editable = value; } }
        public bool Asignado { get { return this.asignado; } set { this.asignado = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Asignacion() { }
        #endregion CONSTRUCTORES

        #region CADENAS PARA CARGA DE OBJETOS
        public string SelectCombo(ref string unModulo)
        {
            string cadena;
            Type unTipo = Type.GetType("Entidades." + unModulo + ", Entidades"); object unObjeto = Activator.CreateInstance(unTipo);
            MethodInfo method = unTipo.GetMethod("SelectAsignacionCombo", BindingFlags.Instance | BindingFlags.Public);
            cadena = (string)method.Invoke(unObjeto, null);
            unTipo = null;
            unObjeto = null;
            method = null;
            return cadena;
        }

        public string SelectDetalle(ref string unModulo)
        {
            string cadena;
            Type unTipo = Type.GetType("Entidades." + unModulo + ", Entidades"); object unObjeto = Activator.CreateInstance(unTipo);
            MethodInfo method = unTipo.GetMethod("SelectAsignacionDetalle", BindingFlags.Instance | BindingFlags.Public);
            cadena = (string)method.Invoke(unObjeto, null);
            unTipo = null;
            unObjeto = null;
            method = null;
            return cadena;
        }
        #endregion CADENAS PARA CARGA DE OBJETOS
    }
}
