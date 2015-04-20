using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tiposcontables")]
	public partial class tipocontable
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short        id          { get; set; }            // smallint
		[Column,        NotNull] public string       descripcion { get; set; }            // character varying(100)
		                         public tipocontable Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_contables_tiposcontable_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idtipocontable", CanBeNull=false)]
		public IEnumerable<contable> fkcontablestiposcontables { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public tipocontable Relacionar(IEnumerable<contable> fkcontablestiposcontables)
		{
			this.fkcontablestiposcontables = fkcontablestiposcontables;
			return this;
		}

		#endregion
	}
}