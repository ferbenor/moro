using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="estadospersonas")]
	public partial class estadopersona
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short         id          { get; set; }            // smallint
		[Column,        Nullable] public string        descripcion { get; set; }            // character varying(13)
		[Column,        Nullable] public char?         abreviatura { get; set; }            // character(1)
		                          public estadopersona Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_personas_estadospersonas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idestadopersona", CanBeNull=false)]
		public IEnumerable<persona> fkpersonas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public estadopersona Relacionar(IEnumerable<persona> fkpersonas)
		{
			this.fkpersonas = fkpersonas;
			return this;
		}

		#endregion
	}
}