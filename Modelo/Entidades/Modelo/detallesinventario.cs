using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallesinventarios")]
	public partial class detallesinventario
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int                idperiodo  { get; set; }            // integer
		[Column,        NotNull] public char               tipo       { get; set; }            // character(1)
		[Column,        NotNull] public int                numero     { get; set; }            // integer
		[Column,        NotNull] public int                idproducto { get; set; }            // integer
		[Column,        NotNull] public int                registro   { get; set; }            // integer
		[Column,        NotNull] public decimal            cantidad   { get; set; }            // numeric(8,2)
		[Column,        NotNull] public decimal            precio     { get; set; }            // numeric(16,2)
		                         public detallesinventario Objeto     { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesinventarios_inventarios
		/// </summary>
		[Association(ThisKey="idperiodo, tipo, numero", OtherKey="idperiodo, tipo, numero", CanBeNull=false)]
		public inventario fkinventario { get; set; }

		/// <summary>
		/// fk_detallesinventarios_productos
		/// </summary>
		[Association(ThisKey="idproducto", OtherKey="id", CanBeNull=false)]
		public producto fkproducto { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detallesinventario Relacionar(inventario fkinventario)
		{
			this.fkinventario = fkinventario;
			return this;
		}

		public detallesinventario Relacionar(producto fkproducto)
		{
			this.fkproducto = fkproducto;
			return this;
		}

		#endregion
	}
}