using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class Pago : Instrumental
    {
        #region VARIABLES
        private ConvenioPago cabecera;
        private int identificadorPagos;
        private FormaPago formaPago;
        private short numero;
        private bool notificacion;
        private DateTime fecha;
        private Usuario usuarioCobranzas;
        private decimal valor;
        private string detalle;
        private Usuario usuarioRegistra;
        private Usuario usuarioAnula;
        private bool anulado;
        private const string nombreTabla = "pagos";
        #endregion VARIABLES

        #region PROPIEDADES
        public ConvenioPago Cabecera { get { return this.cabecera; } set { this.cabecera = value; } }
        public int IdentificadorPagos { get { return this.identificadorPagos; } }
        public short IdFormaPago { get; set; }
        public FormaPago FormaPago
        {
            
            get
            {
                if (this.formaPago == null)
                { this.formaPago = General.formaPagoCero; this.IdFormaPago = this.formaPago.Id; }
                return this.formaPago;
            }
            set { this.formaPago = value; if (value == null) this.IdFormaPago = 0; else this.IdFormaPago = value.Id; }
        }
        public short Numero { get { return this.numero; } }
        public bool Notificacion { get { return this.notificacion; } set { this.notificacion = value; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public short IdUsuarioCobranzas { get; set; }
        public Usuario UsuarioCobranzas
        {
            get
            {
                if (this.usuarioCobranzas == null)
                { this.usuarioCobranzas = General.usuarioCero; this.IdUsuarioCobranzas = this.usuarioCobranzas.Id; }
                return this.usuarioCobranzas;
            }
            set { this.usuarioCobranzas = value; if (value == null) this.IdUsuarioCobranzas = 0; else this.IdUsuarioCobranzas = value.Id; }
        }
        public decimal Valor { get { return this.valor; } set { this.valor = value; } }
        public string Detalle { get { return this.detalle; } set { this.detalle = value; } }
        public short IdUsuarioRegistra { get; set; }
        public Usuario UsuarioRegistra
        {
            get
            {
                if (this.usuarioRegistra == null)
                { this.usuarioRegistra = General.usuarioCero; this.IdUsuarioRegistra = this.usuarioRegistra.Id; }
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
                { this.usuarioAnula = General.usuarioCero; this.IdUsuarioAnula = this.usuarioAnula.Id; }
                return this.usuarioAnula;
            }
            set { this.usuarioAnula = value; if (value == null) this.IdUsuarioAnula = 0; else this.IdUsuarioAnula = value.Id; }
        }
        public bool Anulado { get { return this.anulado; } set { this.anulado = value; } }
        public Pago Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region Constructores
        public Pago() { }

        public Pago(int unIdentificadorPagos)
        {
            this.identificadorPagos = unIdentificadorPagos;
        }

        public Pago(ConvenioPago unaCabecera, int unIdentificadorPagos, short unIdFormaPago, short unNumero, bool unNotificacion, DateTime unFecha, short unIdUsuarioCobranzas, decimal unValor, string unDetalle, short unIdUsuarioRegistra, short unIdUsuarioAnula, bool unAnulado)
        {
            this.cabecera = unaCabecera;
            this.identificadorPagos = unIdentificadorPagos;
            this.IdFormaPago = unIdFormaPago;
            this.numero = unNumero;
            this.notificacion = unNotificacion;
            this.fecha = unFecha;
            this.IdUsuarioCobranzas = unIdUsuarioCobranzas;
            this.valor = unValor;
            this.detalle = unDetalle;
            this.IdUsuarioRegistra = unIdUsuarioRegistra;
            this.IdUsuarioAnula = unIdUsuarioAnula;
            this.anulado = unAnulado;
        }

        #endregion Constructores

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("identificadorpagos", true, System.Data.DbType.Int32, 0, this.IdentificadorPagos, true));
            lc.Add(new CamposTabla("formapago", true, System.Data.DbType.Int16, 0, this.IdFormaPago, true));
            lc.Add(new CamposTabla("numero", true, System.Data.DbType.Int16, 0, this.Numero, true));
            lc.Add(new CamposTabla("notificacion", false, System.Data.DbType.Boolean, 0, this.Notificacion));
            lc.Add(new CamposTabla("fecha", false, System.Data.DbType.DateTime, 0, this.Fecha));
            lc.Add(new CamposTabla("usuariocobranzas", false, System.Data.DbType.Int16, 0, this.IdUsuarioCobranzas));
            lc.Add(new CamposTabla("valor", false, System.Data.DbType.Decimal, 0, this.Valor));
            lc.Add(new CamposTabla("detalle", false, System.Data.DbType.String, 255, this.Detalle));
            lc.Add(new CamposTabla("usuarioregistra", false, System.Data.DbType.Int16, 0, this.IdUsuarioRegistra));
            lc.Add(new CamposTabla("usuarioanula", false, System.Data.DbType.Int16, 0, this.IdUsuarioAnula));
            lc.Add(new CamposTabla("anulado", false, System.Data.DbType.Boolean, 0, this.Anulado));

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
            //return GeneraCadenaBorrar(nombreTabla);

            return "select * from fn_reg_pagos(@pidentificadorpagos, @pidformapago, @pnotificacion, @pfecha, @pidusuariocobranza, @pvalor, " +
            "@pdetalle, @pidusuarioregistra, @pidusuarioanula, @ttran)";
        }

        public virtual string CadenaGuardar()
        {
            //return GeneraCadenaGuardar(nombreTabla, this.identificadorPagos,  this.formaPago,  this.numero, "where identificadorpagos = " + this.IdentificadorPagos + " and formapago = " + this.FormaPago + " and numero = " + this.Numero);

            return "select * from fn_reg_pagos(@pidentificadorpagos, @pidformapago, @pnotificacion, @pfecha, @pidusuariocobranza, @pvalor, " +
            "@pdetalle, @pidusuarioregistra, @pidusuarioanula, @ttran)";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //*#SETID

        //*#SETVALORES

        //*#LIMPIAR

        public override int CompareTo(object obj)
        {
            if (obj is Pago)
            {
                Pago oVar = obj as Pago;
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
