using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tiposimagenes")]
	public partial class tiposimagene
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short        id          { get; set; }            // smallint
		[Column,        NotNull] public string       descripcion { get; set; }            // character varying(30)
		[Column,        NotNull] public bool         activo      { get; set; }            // boolean
		                         public tiposimagene Objeto      { get { return this; } }

		#endregion
	}
}