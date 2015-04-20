using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="empresas")]
	public partial class empresa
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short   id                    { get; set; }            // smallint
		[Column,        Nullable] public string  nombre                { get; set; }            // character varying(50)
		[Column,        Nullable] public string  identificacion        { get; set; }            // character(13)
		[Column,        Nullable] public string  razonsocial           { get; set; }            // character varying(100)
		[Column,        Nullable] public string  nombrecomercial       { get; set; }            // character varying(250)
		[Column,        NotNull ] public int     idpersonagerente      { get; set; }            // integer
		[Column,        NotNull ] public int     idpersonacontador     { get; set; }            // integer
		[Column,        NotNull ] public bool    obligadocontabilidad  { get; set; }            // boolean
		[Column,        Nullable] public string  contribuyenteespecial { get; set; }            // character varying(5)
		[Column,        NotNull ] public bool    activo                { get; set; }            // boolean
		[Column,        Nullable] public byte[]  logo                  { get; set; }            // bytea
		                          public empresa Objeto                { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_empresas_personas_contador
		/// </summary>
		[Association(ThisKey="idpersonacontador", OtherKey="id", CanBeNull=false)]
		public persona fkpersonascontador { get; set; }

		/// <summary>
		/// fk_empresas_personas_gerente
		/// </summary>
		[Association(ThisKey="idpersonagerente", OtherKey="id", CanBeNull=false)]
		public persona fkpersonasgerente { get; set; }

		/// <summary>
		/// fk_sucursales_empresas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idempresa", CanBeNull=false)]
		public IEnumerable<sucursal> fksucursales { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public empresa Relacionar(persona fkpersonascontador, persona fkpersonasgerente)
		{
			this.fkpersonascontador = fkpersonascontador;
			this.fkpersonasgerente = fkpersonasgerente;
			return this;
		}

		public empresa Relacionar(IEnumerable<sucursal> fksucursales)
		{
			this.fksucursales = fksucursales;
			return this;
		}

		#endregion
	}
}