using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proveedores
{
    public class Valores
    {
        public decimal Valor { get; set; }
        public bool Efectivo { get; set; }
        public bool CreditoPersonal { get; set; }
        public bool CreditoEmpresarial { get; set; }
        public bool TCCorriente { get; set; }
        public bool TCDiferido { get; set; }
        public bool MonederoElectronico { get; set; }
        public bool Cheque { get; set; }
        public bool TransferenciaLocal { get; set; }
        public bool Giro { get; set; }
    }
}
