using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ProveedorAcceso
    {
        public static ProveedorDatos DAO
        {
            get { return ProveedorDatos.Instancia; }
        }
    }
}
