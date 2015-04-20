using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tiposservicios")]
	public partial class tiposervicio
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short        id          { get; set; }            // smallint
		[Column,        Nullable] public string       descripcion { get; set; }            // character varying(20)
		[Column,        Nullable] public bool?        activo      { get; set; }            // boolean
		                          public tiposervicio Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_ordenesservicios_tiposservicios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idtiposervicio", CanBeNull=false)]
		public IEnumerable<ordenservicio> fkordenesservicios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public tiposervicio Relacionar(IEnumerable<ordenservicio> fkordenesservicios)
		{
			this.fkordenesservicios = fkordenesservicios;
			return this;
		}

		#endregion
	}
}