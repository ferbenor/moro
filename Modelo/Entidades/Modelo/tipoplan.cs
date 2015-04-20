using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="tiposplanes")]
	public partial class tipoplan
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short    id          { get; set; }            // smallint
		[Column,        Nullable] public string   descripcion { get; set; }            // character varying(20)
		[Column,        Nullable] public bool?    activo      { get; set; }            // boolean
		                          public tipoplan Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_planes_tiposplanes_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idtipoplan", CanBeNull=false)]
		public IEnumerable<plan> fkplanes { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public tipoplan Relacionar(IEnumerable<plan> fkplanes)
		{
			this.fkplanes = fkplanes;
			return this;
		}

		#endregion
	}
}