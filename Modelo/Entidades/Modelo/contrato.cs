using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="contratos")]
	public partial class contrato
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       id                        { get; set; }            // integer
		[Column,        Nullable] public short?    iddocumento               { get; set; }            // smallint
		[Column,        NotNull ] public int       idpersona                 { get; set; }            // integer
		[Column,        NotNull ] public short     idplan                    { get; set; }            // smallint
		[Column,        Nullable] public DateTime? fecha                     { get; set; }            // date
		[Column,        Nullable] public DateTime? fechaservidor             { get; set; }            // timestamp without time zone
		[Column,        Nullable] public DateTime? fechacancelacion          { get; set; }            // timestamp without time zone
		[Column,        Nullable] public bool?     vigente                   { get; set; }            // boolean
		[Column,        Nullable] public char?     mediotransmision          { get; set; }            // character(1)
		[Column,        Nullable] public short?    horariosoporte            { get; set; }            // smallint
		[Column,        Nullable] public short?    disponibilidad            { get; set; }            // smallint
		[Column,        Nullable] public bool?     accesoconmutado           { get; set; }            // boolean
		[Column,        Nullable] public bool?     accesocompartido          { get; set; }            // boolean
		[Column,        Nullable] public string    comparticion              { get; set; }            // character varying(4)
		[Column,        Nullable] public char?     tipoenlace                { get; set; }            // character varying(1)
		[Column,        Nullable] public short?    velocidadminimacliente    { get; set; }            // smallint
		[Column,        Nullable] public short?    velocidadminimaproveedor  { get; set; }            // smallint
		[Column,        Nullable] public short?    velocidadmaximaproveedor  { get; set; }            // smallint
		[Column,        Nullable] public short?    velocidadmaximacliente    { get; set; }            // smallint
		[Column,        Nullable] public string    direccionentregafactura   { get; set; }            // character varying(250)
		[Column,        Nullable] public decimal?  ivaactual                 { get; set; }            // numeric(3,2)
		[Column,        Nullable] public decimal?  precioinstalacion         { get; set; }            // numeric(5,2)
		[Column,        Nullable] public decimal?  preciomensual             { get; set; }            // numeric(5,2)
		[Column,        Nullable] public bool?     autorizamanejoinformacion { get; set; }            // boolean
		                          public contrato  Objeto                    { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_contratos_documentos
		/// </summary>
		[Association(ThisKey="iddocumento", OtherKey="id", CanBeNull=true)]
		public documento fkdocumento { get; set; }

		/// <summary>
		/// fk_contratos_personas
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="id", CanBeNull=false)]
		public persona fkpersona { get; set; }

		/// <summary>
		/// fk_contratos_planes
		/// </summary>
		[Association(ThisKey="idplan", OtherKey="id", CanBeNull=false)]
		public plan fkplane { get; set; }

		/// <summary>
		/// fk_ordenesservicios_contratos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idcontrato", CanBeNull=false)]
		public IEnumerable<ordenservicio> fkordenesservicios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public contrato Relacionar(documento fkdocumento)
		{
			this.fkdocumento = fkdocumento;
			return this;
		}

		public contrato Relacionar(persona fkpersona)
		{
			this.fkpersona = fkpersona;
			return this;
		}

		public contrato Relacionar(plan fkplane)
		{
			this.fkplane = fkplane;
			return this;
		}

		public contrato Relacionar(IEnumerable<ordenservicio> fkordenesservicios)
		{
			this.fkordenesservicios = fkordenesservicios;
			return this;
		}

		#endregion
	}
}