using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tiposcolumnas")]
	public partial class tipocolumna
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short       id     { get; set; }            // smallint
		[Column,        Nullable] public string      nombre { get; set; }            // character varying(255)
		                          public tipocolumna Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_columnasgrids_tiposcolumnas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idtipocolumna", CanBeNull=false)]
		public IEnumerable<columnasgrid> fkcolumnasgrids { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public tipocolumna Relacionar(IEnumerable<columnasgrid> fkcolumnasgrids)
		{
			this.fkcolumnasgrids = fkcolumnasgrids;
			return this;
		}

		#endregion
	}
}