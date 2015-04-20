using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallesordenespedidos")]
	public partial class detalleordenpedido
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int                idordenpedido { get; set; }            // integer
		[Column,        NotNull] public int                idproducto    { get; set; }            // integer
		[Column,        NotNull] public short              cantidad      { get; set; }            // smallint
		[Column,        NotNull] public decimal            precio        { get; set; }            // numeric(8,2)
		                         public detalleordenpedido Objeto        { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesordenespedidos_ordenespedidos
		/// </summary>
		[Association(ThisKey="idordenpedido", OtherKey="id", CanBeNull=false)]
		public ordenpedido fkordenespedido { get; set; }

		/// <summary>
		/// fk_detallesordenespedidos_productos
		/// </summary>
		[Association(ThisKey="idproducto", OtherKey="id", CanBeNull=false)]
		public producto fkproducto { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detalleordenpedido Relacionar(ordenpedido fkordenespedido)
		{
			this.fkordenespedido = fkordenespedido;
			return this;
		}

		public detalleordenpedido Relacionar(producto fkproducto)
		{
			this.fkproducto = fkproducto;
			return this;
		}

		#endregion
	}
}