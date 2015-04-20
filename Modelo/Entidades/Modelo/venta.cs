using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="ventas")]
	public partial class venta
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       id                  { get; set; }            // integer
		[Column,        NotNull ] public int       idcliente           { get; set; }            // integer
		[Column,        NotNull ] public DateTime  fecha               { get; set; }            // date
		[Column,        Nullable] public string    observacion         { get; set; }            // character varying(255)
		[Column,        NotNull ] public short     idestadofactura     { get; set; }            // smallint
		[Column,        NotNull ] public int       idusuarioregistra   { get; set; }            // integer
		[Column,        Nullable] public int?      idusuarioanula      { get; set; }            // integer
		[Column,        Nullable] public int?      ididentificadorpago { get; set; }            // integer
		[Column,        NotNull ] public bool      esanulado           { get; set; }            // boolean
		[Column,        NotNull ] public DateTime  fechaservidor       { get; set; }            // timestamp (3) without time zone
		[Column,        NotNull ] public int       idbarrio            { get; set; }            // integer
		[Column,        Nullable] public DateTime? fechaanulacion      { get; set; }            // timestamp (3) without time zone
		                          public venta     Objeto              { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_ventas_barrios
		/// </summary>
		[Association(ThisKey="idbarrio", OtherKey="id", CanBeNull=false)]
		public barrio fkbarrio { get; set; }

		/// <summary>
		/// fk_ventas_clientes
		/// </summary>
		[Association(ThisKey="idcliente", OtherKey="idpersona", CanBeNull=false)]
		public cliente fkcliente { get; set; }

		/// <summary>
		/// fk_ventas_estadosfacturas
		/// </summary>
		[Association(ThisKey="idestadofactura", OtherKey="id", CanBeNull=false)]
		public estadosfactura fkestadosfactura { get; set; }

		/// <summary>
		/// fk_ventas_identificadorespagos
		/// </summary>
		[Association(ThisKey="ididentificadorpago", OtherKey="id", CanBeNull=true)]
		public identificadorpago fkidentificadorespago { get; set; }

		/// <summary>
		/// fk_ventas_usuarios
		/// </summary>
		[Association(ThisKey="idusuarioregistra", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		/// <summary>
		/// fk_ventas_usuarios1
		/// </summary>
		[Association(ThisKey="idusuarioanula", OtherKey="id", CanBeNull=true)]
		public usuario fkusuarios1 { get; set; }

		/// <summary>
		/// fk_detallesventas_ventas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idventa", CanBeNull=false)]
		public IEnumerable<detalleventa> fkdetallesventa { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public venta Relacionar(barrio fkbarrio)
		{
			this.fkbarrio = fkbarrio;
			return this;
		}

		public venta Relacionar(cliente fkcliente)
		{
			this.fkcliente = fkcliente;
			return this;
		}

		public venta Relacionar(estadosfactura fkestadosfactura)
		{
			this.fkestadosfactura = fkestadosfactura;
			return this;
		}

		public venta Relacionar(identificadorpago fkidentificadorespago)
		{
			this.fkidentificadorespago = fkidentificadorespago;
			return this;
		}

		public venta Relacionar(usuario fkusuario, usuario fkusuarios1)
		{
			this.fkusuario = fkusuario;
			this.fkusuarios1 = fkusuarios1;
			return this;
		}

		public venta Relacionar(IEnumerable<detalleventa> fkdetallesventa)
		{
			this.fkdetallesventa = fkdetallesventa;
			return this;
		}

		#endregion
	}
}