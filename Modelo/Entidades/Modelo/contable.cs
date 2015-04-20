using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="contables")]
	public partial class contable
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       idperiodo         { get; set; }            // integer
		[Column,        NotNull ] public short     idtipocontable    { get; set; }            // smallint
		[Column,        NotNull ] public int       numero            { get; set; }            // integer
		[Column,        NotNull ] public DateTime  fecha             { get; set; }            // date
		[Column,        Nullable] public DateTime? fechacreacion     { get; set; }            // timestamp without time zone
		[Column,        Nullable] public DateTime? fechamodificacion { get; set; }            // timestamp without time zone
		[Column,        Nullable] public int?      idpersona         { get; set; }            // integer
		[Column,        Nullable] public string    beneficiario      { get; set; }            // character varying(255)
		[Column,        Nullable] public decimal?  valor             { get; set; }            // numeric(15,2)
		[Column,        Nullable] public string    observacion       { get; set; }            // character varying(255)
		[Column,        Nullable] public int?      idusuarioregistra { get; set; }            // integer
		[Column,        Nullable] public int?      idusuariomodifica { get; set; }            // integer
		[Column,        NotNull ] public bool      eseditable        { get; set; }            // boolean
		[Column,        NotNull ] public bool      esanulado         { get; set; }            // boolean
		                          public contable  Objeto            { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_contables_periodos
		/// </summary>
		[Association(ThisKey="idperiodo", OtherKey="id", CanBeNull=false)]
		public periodo fkperiodo { get; set; }

		/// <summary>
		/// fk_contables_personas
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="id", CanBeNull=true)]
		public persona fkpersona { get; set; }

		/// <summary>
		/// fk_contables_tiposcontable
		/// </summary>
		[Association(ThisKey="idtipocontable", OtherKey="id", CanBeNull=false)]
		public tipocontable fktiposcontable { get; set; }

		/// <summary>
		/// fk_detallescontables_contables_BackReference
		/// </summary>
		[Association(ThisKey="idperiodo, idtipocontable, numero", OtherKey="idperiodo, idtipocontable, numerocontable", CanBeNull=false)]
		public IEnumerable<detallecontable> fkdetallescontables { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public contable Relacionar(periodo fkperiodo)
		{
			this.fkperiodo = fkperiodo;
			return this;
		}

		public contable Relacionar(persona fkpersona)
		{
			this.fkpersona = fkpersona;
			return this;
		}

		public contable Relacionar(tipocontable fktiposcontable)
		{
			this.fktiposcontable = fktiposcontable;
			return this;
		}

		public contable Relacionar(IEnumerable<detallecontable> fkdetallescontables)
		{
			this.fkdetallescontables = fkdetallescontables;
			return this;
		}

		#endregion
	}
}