using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Producto : Instrumental
    {
        #region VARIABLES
        private int id;
        private UnidadMedida unidaddemedida;
        private string descripcion;
        private decimal precio1;
        private decimal precio2;
        private decimal precio3;
        private decimal stock;
        public const string nombreTabla = "productos";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public short IdUnidadDeMedida { get; set; }
        public UnidadMedida UnidadMedida
        {
            get
            {
                if (this.unidaddemedida == null)
                    return General.unidadCero;
                else
                    return this.unidaddemedida;
            }
            set { this.unidaddemedida = value; this.IdUnidadDeMedida = this.unidaddemedida.Id; }
        }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public decimal Precio1 { get { return this.precio1; } set { this.precio1 = value; } }
        public decimal Precio2 { get { return this.precio2; } set { this.precio2 = value; } }
        public decimal Precio3 { get { return this.precio3; } set { this.precio3 = value; }}
        public decimal Stock { get { return this.stock; } set { this.stock = value; } }
        public Producto Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Producto() { }

        public Producto(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.Id, true));
            lc.Add(new CamposTabla("idunidaddemedida", false, System.Data.DbType.Int16, 0, this.UnidadMedida.Id));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 100, this.descripcion));
            lc.Add(new CamposTabla("precio1", false, System.Data.DbType.Decimal, 0, this.precio1));
            lc.Add(new CamposTabla("precio2", false, System.Data.DbType.Decimal, 0, this.precio2));
            lc.Add(new CamposTabla("precio3", false, System.Data.DbType.Decimal, 0, this.precio3));
            lc.Add(new CamposTabla("stock", false, System.Data.DbType.Decimal, 0, this.stock));
            lc.ForEach(x => { if (string.IsNullOrEmpty(x.NombreTabla) && !x.SoloSelect) x.NombreTabla = nombreTabla; });

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
            return this.descripcion;
        }
        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is Producto)
            {
                Producto oVar = obj as Producto;
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