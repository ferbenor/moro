using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="alineacion")]
	public partial class alineacion
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short      id     { get; set; }            // smallint
		[Column,        Nullable] public string     nombre { get; set; }            // character varying(255)
		                          public alineacion Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_columnasgrids_alineacion_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idalineacion", CanBeNull=false)]
		public IEnumerable<columnasgrid> fkcolumnasgrids { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public alineacion Relacionar(IEnumerable<columnasgrid> fkcolumnasgrids)
		{
			this.fkcolumnasgrids = fkcolumnasgrids;
			return this;
		}

		#endregion
	}
}