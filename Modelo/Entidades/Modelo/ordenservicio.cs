using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="ordenesservicios")]
	public partial class ordenservicio
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int           id              { get; set; }            // integer
		[Column,        Nullable] public int?          idcontrato      { get; set; }            // integer
		[Column,        Nullable] public short?        idtiposervicio  { get; set; }            // smallint
		[Column,        Nullable] public string        detalle         { get; set; }            // character varying(255)
		[Column,        NotNull ] public DateTime      fechaservicio   { get; set; }            // timestamp without time zone
		[Column,        Nullable] public char?         estado          { get; set; }            // character varying(1)
		[Column,        NotNull ] public DateTime      fechadefinicion { get; set; }            // date
		[Column,        Nullable] public DateTime?     fechaservidor   { get; set; }            // timestamp without time zone
		                          public ordenservicio Objeto          { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_ordenesservicios_contratos
		/// </summary>
		[Association(ThisKey="idcontrato", OtherKey="id", CanBeNull=true)]
		public contrato fkcontrato { get; set; }

		/// <summary>
		/// fk_ordenesservicios_tiposservicios
		/// </summary>
		[Association(ThisKey="idtiposervicio", OtherKey="id", CanBeNull=true)]
		public tiposervicio fktiposservicio { get; set; }

		/// <summary>
		/// fk_detallesordenesservicios_ordenesservicios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idordenservicio", CanBeNull=false)]
		public detalleordenservicio fkdetallesordenesservicio { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public ordenservicio Relacionar(contrato fkcontrato)
		{
			this.fkcontrato = fkcontrato;
			return this;
		}

		public ordenservicio Relacionar(tiposervicio fktiposservicio)
		{
			this.fktiposservicio = fktiposservicio;
			return this;
		}

		public ordenservicio Relacionar(detalleordenservicio fkdetallesordenesservicio)
		{
			this.fkdetallesordenesservicio = fkdetallesordenesservicio;
			return this;
		}

		#endregion
	}
}