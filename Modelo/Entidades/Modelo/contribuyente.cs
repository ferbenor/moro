using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="contribuyentes")]
	public partial class contribuyente
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short         id     { get; set; }            // smallint
		[Column,        NotNull] public string        nombre { get; set; }            // character varying(100)
		                         public contribuyente Objeto { get { return this; } }

		#endregion
	}
}