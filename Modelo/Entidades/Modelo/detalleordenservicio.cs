using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallesordenesservicios")]
	public partial class detalleordenservicio
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int                  idordenservicio  { get; set; }            // integer
		[Column,        NotNull ] public int                  iditeminventario { get; set; }            // integer
		[Column,        NotNull ] public short                numero           { get; set; }            // smallint
		[Column,        NotNull ] public decimal              cantidad         { get; set; }            // numeric(8,2)
		[Column,        NotNull ] public decimal              precio           { get; set; }            // numeric(10,2)
		[Column,        Nullable] public bool?                grabaiva         { get; set; }            // boolean
		[Column,        Nullable] public string               detalle          { get; set; }            // character varying(255)
		                          public detalleordenservicio Objeto           { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesordenesservicios_itemsinventarios
		/// </summary>
		[Association(ThisKey="iditeminventario", OtherKey="id", CanBeNull=false)]
		public iteminventario fkitemsinventario { get; set; }

		/// <summary>
		/// fk_detallesordenesservicios_ordenesservicios
		/// </summary>
		[Association(ThisKey="idordenservicio", OtherKey="id", CanBeNull=false)]
		public ordenservicio fkordenesservicio { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detalleordenservicio Relacionar(iteminventario fkitemsinventario)
		{
			this.fkitemsinventario = fkitemsinventario;
			return this;
		}

		public detalleordenservicio Relacionar(ordenservicio fkordenesservicio)
		{
			this.fkordenesservicio = fkordenesservicio;
			return this;
		}

		#endregion
	}
}