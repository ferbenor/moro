using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="estadosfacturas")]
	public partial class estadosfactura
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short          id          { get; set; }            // smallint
		[Column,        NotNull] public string         descripcion { get; set; }            // character varying(50)
		[Column,        NotNull] public bool           activo      { get; set; }            // boolean
		                         public estadosfactura Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_ventas_estadosfacturas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idestadofactura", CanBeNull=false)]
		public IEnumerable<venta> fkventas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public estadosfactura Relacionar(IEnumerable<venta> fkventas)
		{
			this.fkventas = fkventas;
			return this;
		}

		#endregion
	}
}