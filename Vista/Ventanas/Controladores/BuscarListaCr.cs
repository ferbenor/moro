using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApp
{

    public class BuscarListaCr
    {
        private static BuscarListaCr instancia;
        public static BuscarListaCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new BuscarListaCr();
                return instancia;
            }
        }

        private static Proveedores.BuscarListaPr proveedor;
        public static Proveedores.BuscarListaPr Proveedor
        {
            get
            {
                if (proveedor == null) proveedor = new Proveedores.BuscarListaPr();
                return proveedor;
            }
        }

        public object Buscar(string modulo, string tabla, string valorWhere, string campos, string ordenar = null, bool inicializado = false)
        {
            return Proveedores.BuscarListaPr.Buscar(modulo, tabla, valorWhere, campos, ordenar, inicializado);
        }
    }


}
