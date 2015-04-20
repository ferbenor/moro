using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class ItemInventario : Instrumental
    {
        #region VARIABLES
        private int id;
        private string descripcion;
        private decimal precio;
        private string tipo;
        private bool grabaIva;
        private bool editable = false;
        private const string textoNoEditable = "Item referenciado en transacciones, campo no puede ser modificado";
        private const string nombreTabla = "itemsinventario";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Descripcion { get { return this.descripcion; } set { if (this.editable) this.descripcion = value; else General.Mensaje(textoNoEditable); } }
        public decimal Precio { get { return this.precio; } set { this.precio = value; } }
        public string Tipo { get { return this.tipo; } set { if (this.editable) this.tipo = value; else General.Mensaje(textoNoEditable); } }
        public bool GrabaIva { get { return this.grabaIva; } set { this.grabaIva = value; } }
        public bool Editable { get { return this.editable; } }
        public ItemInventario Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ItemInventario() { }

        public ItemInventario(int Id)
        {
            this.id = Id;
        }

        public ItemInventario(string unaDescripcion)
        {
            this.descripcion = unaDescripcion;
        }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.Id, true));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 255, this.Descripcion));
            lc.Add(new CamposTabla("precio", false, System.Data.DbType.Decimal, 0, this.Precio));
            lc.Add(new CamposTabla("tipo", false, System.Data.DbType.String, 1, this.Tipo));
            lc.Add(new CamposTabla("grabaiva", false, System.Data.DbType.Boolean, 0, this.grabaIva));
            lc.Add(new CamposTabla("(select case when sum(iditeminventario) > 0 then false else true end from " +
                "(select count(iditeminventario) iditeminventario from detalleordenesservicio where iditeminventario=id) a)::boolean",
                false, System.Data.DbType.Boolean, 0, -1) { SoloSelect = true });

            return lc;
        }

        public virtual string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public virtual string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public virtual string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public virtual string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, this.id);
        }

        public override string ToString()
        {
            return this.Descripcion;
        }

        //*#SETID

        //*#SETVALORES

        //*#LIMPIAR

        public override int CompareTo(object obj)
        {
            if (obj is ItemInventario)
            {
                ItemInventario oVar = obj as ItemInventario;
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
