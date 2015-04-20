using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="planes")]
	public partial class plan
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short    id         { get; set; }            // smallint
		[Column,        Nullable] public short?   idtipoplan { get; set; }            // smallint
		[Column,        Nullable] public decimal? precio     { get; set; }            // numeric(5,2)
		[Column,        Nullable] public string   anchobanda { get; set; }            // character varying(20)
		[Column,        Nullable] public bool?    activo     { get; set; }            // boolean
		                          public plan     Objeto     { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_planes_tiposplanes
		/// </summary>
		[Association(ThisKey="idtipoplan", OtherKey="id", CanBeNull=true)]
		public tipoplan fktiposplane { get; set; }

		/// <summary>
		/// fk_contratos_planes_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idplan", CanBeNull=false)]
		public IEnumerable<contrato> fkcontratos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public plan Relacionar(tipoplan fktiposplane)
		{
			this.fktiposplane = fktiposplane;
			return this;
		}

		public plan Relacionar(IEnumerable<contrato> fkcontratos)
		{
			this.fkcontratos = fkcontratos;
			return this;
		}

		#endregion
	}
}