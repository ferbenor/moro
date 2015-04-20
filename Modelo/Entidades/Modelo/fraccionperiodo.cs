using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="fraccionesperiodos")]
	public partial class fraccionperiodo
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int             id        { get; set; }            // integer
		[Column,        NotNull] public short           idperiodo { get; set; }            // smallint
		[Column,        NotNull] public short           mes       { get; set; }            // smallint
		[Column,        NotNull] public bool            cerrado   { get; set; }            // boolean
		                         public fraccionperiodo Objeto    { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_fraccionesperiodos_periodos
		/// </summary>
		[Association(ThisKey="idperiodo", OtherKey="id", CanBeNull=false)]
		public periodo fkperiodo { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public fraccionperiodo Relacionar(periodo fkperiodo)
		{
			this.fkperiodo = fkperiodo;
			return this;
		}

		#endregion
	}
}