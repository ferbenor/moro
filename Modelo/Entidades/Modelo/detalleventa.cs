using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallesventas")]
	public partial class detalleventa
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int          idventa    { get; set; }            // integer
		[Column,        NotNull] public int          idproducto { get; set; }            // integer
		[Column,        NotNull] public short        cantidad   { get; set; }            // smallint
		[Column,        NotNull] public decimal      precio     { get; set; }            // numeric(8,2)
		                         public detalleventa Objeto     { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesventas_productos
		/// </summary>
		[Association(ThisKey="idproducto", OtherKey="id", CanBeNull=false)]
		public producto fkproducto { get; set; }

		/// <summary>
		/// fk_detallesventas_ventas
		/// </summary>
		[Association(ThisKey="idventa", OtherKey="id", CanBeNull=false)]
		public venta fkdetallesventas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detalleventa Relacionar(producto fkproducto)
		{
			this.fkproducto = fkproducto;
			return this;
		}

		public detalleventa Relacionar(venta fkdetallesventas)
		{
			this.fkdetallesventas = fkdetallesventas;
			return this;
		}

		#endregion
	}
}