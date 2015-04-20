using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="marcas")]
	public partial class marca
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int    id          { get; set; }            // integer
		[Column,        Nullable] public string descripcion { get; set; }            // character varying(25)
		[Column,        NotNull ] public bool   activo      { get; set; }            // boolean
		                          public marca  Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_productos_marcas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idmarca", CanBeNull=false)]
		public IEnumerable<producto> fkproductos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public marca Relacionar(IEnumerable<producto> fkproductos)
		{
			this.fkproductos = fkproductos;
			return this;
		}

		#endregion
	}
}