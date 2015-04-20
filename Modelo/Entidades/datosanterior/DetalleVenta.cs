using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class DetalleVenta : Instrumental
    {
        #region VARIABLES
        private Venta cabeceraVenta;
        private Producto producto;
        private short cantidad;
        private decimal precio;
        private decimal total;
        public const string nombreTabla = "detallesventas";
        #endregion VARIABLES

        #region PROPIEDADES
        public Venta CabeceraOrdenPedido { get { return this.cabeceraVenta; } set { this.cabeceraVenta = value; } }
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public Producto Producto
        {
            get
            {
                if (this.producto == null)
                { this.producto = General.productoCero; this.IdProducto = this.producto.Id; }
                return this.producto;
            }
            set
            {
                this.producto = value; if (value == null) { this.IdProducto = 0; this.CodigoProducto = null; this.Precio = 0; } else { this.IdProducto = value.Id; this.Precio = value.Precio1; }
            }
        }
        public short Cantidad { get { return this.cantidad; } set { this.cantidad = value; this.total = this.cantidad * this.precio; } }
        public decimal Precio { get { return this.precio; } set { this.precio = value; this.total = this.cantidad * this.precio; } }
        public decimal Total { get { return this.total; } }
        public DetalleVenta Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region Constructores
        public DetalleVenta() { }

        #endregion Constructores

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("idordenpedido", true, System.Data.DbType.Int32, 0, this.CabeceraOrdenPedido.Id));
            lc.Add(new CamposTabla("idproducto", false, System.Data.DbType.Int32, 0, this.IdProducto));
            lc.Add(new CamposTabla("cantidad", false, System.Data.DbType.Int16, 0, this.Cantidad));
            lc.Add(new CamposTabla("precio", false, System.Data.DbType.Decimal, 0, this.Precio));
            lc.ForEach(x => { if (string.IsNullOrEmpty(x.NombreTabla) && !x.SoloSelect) x.NombreTabla = nombreTabla; });
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
            return GeneraCadenaGuardar(nombreTabla, 0);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int CompareTo(object obj)
        {
            if (obj is DetalleVenta)
            {
                DetalleVenta oVar = obj as DetalleVenta;
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
