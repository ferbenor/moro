using System;
using System.Collections.Generic;
using Estructura;
using System.Linq;

namespace Entidades
{
    public class OrdenPedido : Instrumental
    {
        #region VARIABLES
        private int id;
        private Cliente cliente;
        private DateTime fecha;
        private string observacion;
        private EstadoOrdenPedido estadoOrdenPedido;
        private Usuario usuarioRegistra;
        private Usuario usuarioAnula;
        private List<DetalleOrdenPedido> detalleOrdenPedido;
        private decimal total;
        private decimal cancelado;
        private decimal saldo;
        private const string nombreTabla = "ordenespedido";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public int IdCliente { get; set; }
        public Cliente Cliente
        {
            get
            {
                if (this.cliente == null)
                { this.cliente = General.clienteVacio; this.IdCliente = General.personaCero.Id; }
                return this.cliente;
            }
            set { this.cliente = value; if (value == null) this.IdCliente = 0; else this.IdCliente = value.Id; }
        }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public string Observacion { get { return this.observacion; } set { this.observacion = value; } }
        public short IdEstadoOrdenPedido { get; set; }
        public EstadoOrdenPedido EstadoOrdenPedido
        {
            get
            {
                if (this.estadoOrdenPedido == null)
                { this.estadoOrdenPedido = General.estadoOrdenPedidoCero; this.IdEstadoOrdenPedido = General.estadoOrdenPedidoCero.Id; }
                return this.estadoOrdenPedido;
            }
            set { this.estadoOrdenPedido = value; if (value == null) this.IdEstadoOrdenPedido = 0; else this.IdEstadoOrdenPedido = value.Id; }
        }
        public short IdUsuarioRegistra { get; set; }
        public Usuario UsuarioRegistra
        {
            get
            {
                if (this.usuarioRegistra == null)
                    this.usuarioRegistra = General.usuarioCero;
                return this.usuarioRegistra;
            }
            set { this.usuarioRegistra = value; if (value == null) this.IdUsuarioRegistra = 0; else this.IdUsuarioRegistra = value.Id; }
        }
        public short IdUsuarioAnula { get; set; }
        public Usuario UsuarioAnula
        {
            get
            {
                if (this.usuarioAnula == null)
                    this.usuarioAnula = General.usuarioCero;
                return this.usuarioAnula;
            }
            set { this.usuarioAnula = value; if (value == null) this.IdUsuarioAnula = 0; else this.IdUsuarioAnula = value.Id; }
        }
        public List<DetalleOrdenPedido> DetalleOrdenPedido { get { if (detalleOrdenPedido == null) { this.detalleOrdenPedido = new List<DetalleOrdenPedido>(); return this.detalleOrdenPedido; } else return this.detalleOrdenPedido; } set { this.detalleOrdenPedido = value; this.total = value.Sum(x => x.Total); this.saldo = decimal.Round(total - cancelado, 2); } }
        public OrdenPedido Objeto { get { return this; } }

        public string Ubicacion { get { return this.Cliente.Barrio.ToString(); } }
        public string Ruc { get { return this.Cliente.Identificacion; } }
        public decimal Total { get { return this.total; } }

        public decimal Cancelado { get { return this.cancelado; } }

        public decimal Saldo { get { return this.saldo; } }

        #endregion PROPIEDADES

        #region Constructores
        public OrdenPedido() { }

        public OrdenPedido(int Id, decimal Cancelado)
        {
            this.id = Id;
            this.cancelado = Cancelado;
        }
        #endregion Constructores

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.Id, true));
            lc.Add(new CamposTabla("idcliente", false, System.Data.DbType.Int32, 0, this.IdCliente));
            lc.Add(new CamposTabla("fecha", false, System.Data.DbType.DateTime, 0, this.Fecha));
            lc.Add(new CamposTabla("observacion", false, System.Data.DbType.String, 100, this.Observacion));
            lc.Add(new CamposTabla("idestadoordenpedido", false, System.Data.DbType.Int16, 0, this.IdEstadoOrdenPedido));
            lc.Add(new CamposTabla("idusuarioregistra", false, System.Data.DbType.Int16, 0, this.IdUsuarioRegistra) { NoUpdate = true });
            lc.Add(new CamposTabla("idusuarioanula", false, System.Data.DbType.Int16, 0, this.IdUsuarioAnula) { SoloSelect = (this.IdUsuarioAnula == 0 ? true : false) });
            lc.Add(new CamposTabla("coalesce(sum(pa.valor), 0) as cancelado", false, System.Data.DbType.Decimal, 0, -1) { SoloSelect = true });
            lc.ForEach(x => { if (string.IsNullOrEmpty(x.NombreTabla) && !x.SoloSelect) x.NombreTabla = nombreTabla; });
            return lc;
        }

        public virtual string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public virtual string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, " inner join identificadorpagos ip on ip.id = ididentificadorpago " +
            "inner join conveniopagos cp on cp.identificadorpagos = ip.id left join pagos pa on pa.identificadorpagos=cp.identificadorpagos and pa.idformapago=cp.idformapago and pa.anulado = false" +
            (condicion.ToLower().IndexOf("order by") > -1 ? condicion.Replace("order by", " group by 1,2,3,4,5,6,7 order by") : condicion + " group by 1,2,3,4,5,6,7"));
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
            return base.ToString();
        }

        public void SetId(int unId)
        {
            this.id = unId;
        }

        public void Limpiar()
        {
            this.id = 0;
            this.cliente = null;
            this.fecha = new DateTime(1900, 1, 1);
            this.observacion = null;
            this.usuarioRegistra = null;
            this.usuarioAnula = null;
            this.detalleOrdenPedido = null;
        }

        public override int CompareTo(object obj)
        {
            if (obj is OrdenPedido)
            {
                OrdenPedido oVar = obj as OrdenPedido;
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
