using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="clientes")]
	public partial class cliente
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       idpersona            { get; set; }            // integer
		[Column,        Nullable] public string    razonsocial          { get; set; }            // character varying(250)
		[Column,        NotNull ] public DateTime  fechaingreso         { get; set; }            // date
		[Column,        Nullable] public string    telefono             { get; set; }            // character varying(13)
		[Column,        Nullable] public byte[]    imagenfoto           { get; set; }            // bytea
		[Column,        NotNull ] public int       idbarrio             { get; set; }            // integer
		[Column,        Nullable] public string    celular              { get; set; }            // character varying(13)
		[Column,        Nullable] public string    certificadovotacion  { get; set; }            // character varying(15)
		[Column,        NotNull ] public short     idestadocivil        { get; set; }            // smallint
		[Column,        Nullable] public int?      idconyuge            { get; set; }            // integer
		[Column,        NotNull ] public short     idprofesion          { get; set; }            // smallint
		[Column,        Nullable] public string    informacionadicional { get; set; }            // character varying(200)
		[Column,        Nullable] public DateTime? fechaservidor        { get; set; }            // timestamp (3) without time zone
		                          public cliente   Objeto               { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_clientes_barrios
		/// </summary>
		[Association(ThisKey="idbarrio", OtherKey="id", CanBeNull=false)]
		public barrio fkbarrio { get; set; }

		/// <summary>
		/// fk_clientes_conyuge
		/// </summary>
		[Association(ThisKey="idconyuge", OtherKey="id", CanBeNull=true)]
		public persona fkconyuge { get; set; }

		/// <summary>
		/// fk_clientes_personas
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="id", CanBeNull=false)]
		public persona fkpersona { get; set; }

		/// <summary>
		/// fk_clientes_profesiones
		/// </summary>
		[Association(ThisKey="idprofesion", OtherKey="id", CanBeNull=false)]
		public profesion fkprofesione { get; set; }

		/// <summary>
		/// fk_clientes_estadosciviles
		/// </summary>
		[Association(ThisKey="idestadocivil", OtherKey="id", CanBeNull=false)]
		public estadocivil fkestadoscivile { get; set; }

		/// <summary>
		/// fk_ordenespedidos_clientes_BackReference
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="idcliente", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

		/// <summary>
		/// fk_ventas_clientes_BackReference
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="idcliente", CanBeNull=false)]
		public IEnumerable<venta> fkventas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public cliente Relacionar(barrio fkbarrio)
		{
			this.fkbarrio = fkbarrio;
			return this;
		}

		public cliente Relacionar(persona fkconyuge, persona fkpersona)
		{
			this.fkconyuge = fkconyuge;
			this.fkpersona = fkpersona;
			return this;
		}

		public cliente Relacionar(profesion fkprofesione)
		{
			this.fkprofesione = fkprofesione;
			return this;
		}

		public cliente Relacionar(estadocivil fkestadoscivile)
		{
			this.fkestadoscivile = fkestadoscivile;
			return this;
		}

		public cliente Relacionar(IEnumerable<ordenpedido> fkordenespedidos)
		{
			this.fkordenespedidos = fkordenespedidos;
			return this;
		}

		public cliente Relacionar(IEnumerable<venta> fkventas)
		{
			this.fkventas = fkventas;
			return this;
		}

		#endregion
	}
}