using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="sucursales")]
	public partial class sucursal
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int      id                    { get; set; }            // integer
		[Column,        Nullable] public short?   idempresa             { get; set; }            // smallint
		[Column,        Nullable] public string   nombre                { get; set; }            // character varying(100)
		[Column,        Nullable] public short?   codigoestablecimiento { get; set; }            // smallint
		[Column,        Nullable] public int?     idbarrio              { get; set; }            // integer
		[Column,        Nullable] public string   direccion             { get; set; }            // character varying(255)
		[Column,        Nullable] public int?     idpersonaencargado    { get; set; }            // integer
		[Column,        Nullable] public string   correo                { get; set; }            // character varying(250)
		[Column,        Nullable] public string   telefono              { get; set; }            // character varying(13)
		                          public sucursal Objeto                { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_sucursales_barrios
		/// </summary>
		[Association(ThisKey="idbarrio", OtherKey="id", CanBeNull=true)]
		public barrio fkbarrio { get; set; }

		/// <summary>
		/// fk_sucursales_empresas
		/// </summary>
		[Association(ThisKey="idempresa", OtherKey="id", CanBeNull=true)]
		public empresa fkempresa { get; set; }

		/// <summary>
		/// fk_sucursales_personas
		/// </summary>
		[Association(ThisKey="idpersonaencargado", OtherKey="id", CanBeNull=true)]
		public persona fkpersona { get; set; }

		/// <summary>
		/// fk_periodos_sucursales_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idsucursal", CanBeNull=false)]
		public IEnumerable<periodo> fkperiodos { get; set; }

		/// <summary>
		/// fk_telefonossucursales_sucursales_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idsucursal", CanBeNull=false)]
		public IEnumerable<telefonosucursal> fktelefonossucursale { get; set; }

		/// <summary>
		/// fk_bodegas_sucursales_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idsucursal", CanBeNull=false)]
		public IEnumerable<bodega> fkbodegas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public sucursal Relacionar(barrio fkbarrio)
		{
			this.fkbarrio = fkbarrio;
			return this;
		}

		public sucursal Relacionar(empresa fkempresa)
		{
			this.fkempresa = fkempresa;
			return this;
		}

		public sucursal Relacionar(persona fkpersona)
		{
			this.fkpersona = fkpersona;
			return this;
		}

		public sucursal Relacionar(IEnumerable<periodo> fkperiodos)
		{
			this.fkperiodos = fkperiodos;
			return this;
		}

		public sucursal Relacionar(IEnumerable<telefonosucursal> fktelefonossucursale)
		{
			this.fktelefonossucursale = fktelefonossucursale;
			return this;
		}

		public sucursal Relacionar(IEnumerable<bodega> fkbodegas)
		{
			this.fkbodegas = fkbodegas;
			return this;
		}

		#endregion
	}
}