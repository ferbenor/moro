using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="imagenespersonas")]
	public partial class imagenespersona
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short           idtipoimagen { get; set; }            // smallint
		[Column,        NotNull ] public int             idpersona    { get; set; }            // integer
		[Column,        NotNull ] public bool            activo       { get; set; }            // boolean
		[Column,        Nullable] public byte[]          imagen       { get; set; }            // bytea
		                          public imagenespersona Objeto       { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_imagenespersonas_personas
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="id", CanBeNull=false)]
		public persona fkpersona { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public imagenespersona Relacionar(persona fkpersona)
		{
			this.fkpersona = fkpersona;
			return this;
		}

		#endregion
	}
}