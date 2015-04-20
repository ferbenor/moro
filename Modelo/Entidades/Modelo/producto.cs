using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="productos")]
	public partial class producto
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int      id                 { get; set; }            // integer
		[Column,        Nullable] public int?     idmarca            { get; set; }            // integer
		[Column,        NotNull ] public short    idunidaddemedida   { get; set; }            // smallint
		[Column,        Nullable] public string   codigo             { get; set; }            // character varying(15)
		[Column,        NotNull ] public string   descripcion        { get; set; }            // character varying(100)
		[Column,        NotNull ] public decimal  utilidadprecio1    { get; set; }            // numeric(4,2)
		[Column,        NotNull ] public decimal  precio1            { get; set; }            // numeric(8,2)
		[Column,        NotNull ] public decimal  utilidadprecio2    { get; set; }            // numeric(4,2)
		[Column,        NotNull ] public decimal  precio2            { get; set; }            // numeric(8,2)
		[Column,        NotNull ] public decimal  utilidadprecio3    { get; set; }            // numeric(4,2)
		[Column,        NotNull ] public decimal  precio3            { get; set; }            // numeric(8,2)
		[Column,        NotNull ] public decimal  utilidadprecio4    { get; set; }            // numeric(4,2)
		[Column,        NotNull ] public decimal  precio4            { get; set; }            // numeric(8,2)
		[Column,        NotNull ] public decimal  ultimocosto        { get; set; }            // numeric(8,2)
		[Column,        Nullable] public bool?    cheque             { get; set; }            // boolean
		[Column,        Nullable] public bool?    monedero           { get; set; }            // boolean
		[Column,        Nullable] public bool?    corriente          { get; set; }            // boolean
		[Column,        Nullable] public bool?    diferido           { get; set; }            // boolean
		[Column,        Nullable] public bool?    creditoempresarial { get; set; }            // boolean
		[Column,        Nullable] public bool?    creditopersonal    { get; set; }            // boolean
		                          public producto Objeto             { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_productos_marcas
		/// </summary>
		[Association(ThisKey="idmarca", OtherKey="id", CanBeNull=true)]
		public marca fkmarca { get; set; }

		/// <summary>
		/// fk_productos_unidadesdemedida
		/// </summary>
		[Association(ThisKey="idunidaddemedida", OtherKey="id", CanBeNull=false)]
		public unidaddemedida fkunidadesdemedida { get; set; }

		/// <summary>
		/// fk_detallesordenespedidos_productos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idproducto", CanBeNull=false)]
		public IEnumerable<detalleordenpedido> fkdetallesordenespedidos { get; set; }

		/// <summary>
		/// fk_detallesventas_productos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idproducto", CanBeNull=false)]
		public IEnumerable<detalleventa> fkdetallesventas { get; set; }

		/// <summary>
		/// fk_detallesinventarios_productos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idproducto", CanBeNull=false)]
		public IEnumerable<detallesinventario> fkdetallesinventarios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public producto Relacionar(marca fkmarca)
		{
			this.fkmarca = fkmarca;
			return this;
		}

		public producto Relacionar(unidaddemedida fkunidadesdemedida)
		{
			this.fkunidadesdemedida = fkunidadesdemedida;
			return this;
		}

		public producto Relacionar(IEnumerable<detalleordenpedido> fkdetallesordenespedidos)
		{
			this.fkdetallesordenespedidos = fkdetallesordenespedidos;
			return this;
		}

		public producto Relacionar(IEnumerable<detalleventa> fkdetallesventas)
		{
			this.fkdetallesventas = fkdetallesventas;
			return this;
		}

		public producto Relacionar(IEnumerable<detallesinventario> fkdetallesinventarios)
		{
			this.fkdetallesinventarios = fkdetallesinventarios;
			return this;
		}

		#endregion
	}
}