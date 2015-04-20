using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="provincias")]
	public partial class provincia
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short     id     { get; set; }            // smallint
		[Column,        NotNull] public string    nombre { get; set; }            // character varying(50)
		                         public provincia Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_cantones_provincias_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idprovincia", CanBeNull=false)]
		public IEnumerable<canton> fkcantones { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public provincia Relacionar(IEnumerable<canton> fkcantones)
		{
			this.fkcantones = fkcantones;
			return this;
		}

		#endregion
	}
}