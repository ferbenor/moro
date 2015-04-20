using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="parametrosgenerales")]
	public partial class parametrogeneral
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int              id     { get; set; }            // integer
		[Column,        Nullable] public string           nombre { get; set; }            // character varying(30)
		[Column,        Nullable] public string           valor  { get; set; }            // character varying(255)
		                          public parametrogeneral Objeto { get { return this; } }

		#endregion
	}
}