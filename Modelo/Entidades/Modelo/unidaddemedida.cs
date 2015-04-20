using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="unidadesdemedida")]
	public partial class unidaddemedida
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short          id          { get; set; }            // smallint
		[Column,        NotNull] public string         descripcion { get; set; }            // character varying(50)
		[Column,        NotNull] public bool           activo      { get; set; }            // boolean
		                         public unidaddemedida Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_productos_unidadesdemedida_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idunidaddemedida", CanBeNull=false)]
		public IEnumerable<producto> fkproductos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public unidaddemedida Relacionar(IEnumerable<producto> fkproductos)
		{
			this.fkproductos = fkproductos;
			return this;
		}

		#endregion
	}

	// Vista
}