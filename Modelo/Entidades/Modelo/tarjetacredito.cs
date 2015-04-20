using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tarjetascreditos")]
	public partial class tarjetacredito
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short          id          { get; set; }            // smallint
		[Column,        Nullable] public string         descripcion { get; set; }            // character varying(25)
		[Column,        NotNull ] public bool           activo      { get; set; }            // boolean
		                          public tarjetacredito Objeto      { get { return this; } }

		#endregion
	}
}