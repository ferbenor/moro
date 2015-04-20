using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="personas")]
	public partial class persona
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int      id                   { get; set; }            // integer
		[Column,        NotNull ] public string   apellido             { get; set; }            // character varying(50)
		[Column,        NotNull ] public string   nombre               { get; set; }            // character varying(50)
		[Column,        NotNull ] public short    idtipopersona        { get; set; }            // smallint
		[Column,        Nullable] public short?   idtipodocumento      { get; set; }            // smallint
		[Column,        NotNull ] public string   identificacion       { get; set; }            // character varying(13)
		[Column,        NotNull ] public short    idgenero             { get; set; }            // smallint
		[Column,        NotNull ] public int      idparroquiadocumento { get; set; }            // integer
		[Column,        NotNull ] public short    idestadopersona      { get; set; }            // smallint
		[Column,        NotNull ] public DateTime fechaservidor        { get; set; }            // timestamp (3) without time zone
		[Column,        NotNull ] public int      version              { get; set; }            // integer
		[Column,        Nullable] public string   referenciadireccion  { get; set; }            // character varying(200)
		[Column,        Nullable] public string   correo               { get; set; }            // character varying(100)
		                          public persona  Objeto               { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_personas_estadospersonas
		/// </summary>
		[Association(ThisKey="idestadopersona", OtherKey="id", CanBeNull=false)]
		public estadopersona fkestadospersona { get; set; }

		/// <summary>
		/// fk_personas_generos
		/// </summary>
		[Association(ThisKey="idgenero", OtherKey="id", CanBeNull=false)]
		public genero fkgenero { get; set; }

		/// <summary>
		/// fk_personas_parroquias
		/// </summary>
		[Association(ThisKey="idparroquiadocumento", OtherKey="id", CanBeNull=false)]
		public parroquia fkparroquia { get; set; }

		/// <summary>
		/// fk_personas_tiposdocumentos
		/// </summary>
		[Association(ThisKey="idtipodocumento", OtherKey="id", CanBeNull=true)]
		public tipodocumento fktiposdocumento { get; set; }

		/// <summary>
		/// fk_personas_tipospersonas
		/// </summary>
		[Association(ThisKey="idtipopersona", OtherKey="id", CanBeNull=false)]
		public tipopersona fktipospersona { get; set; }

		/// <summary>
		/// fk_empresas_personas_contador_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersonacontador", CanBeNull=false)]
		public IEnumerable<empresa> fkempresascontadors { get; set; }

		/// <summary>
		/// fk_empresas_personas_gerente_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersonagerente", CanBeNull=false)]
		public IEnumerable<empresa> fkempresasgerentes { get; set; }

		/// <summary>
		/// fk_contables_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersona", CanBeNull=false)]
		public IEnumerable<contable> fkcontables { get; set; }

		/// <summary>
		/// fk_imagenespersonas_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersona", CanBeNull=false)]
		public IEnumerable<imagenespersona> fkimagenespersonas { get; set; }

		/// <summary>
		/// fk_sucursales_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersonaencargado", CanBeNull=false)]
		public IEnumerable<sucursal> fksucursales { get; set; }

		/// <summary>
		/// fk_usuarios_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersona", CanBeNull=false)]
		public IEnumerable<usuario> fkusuarios { get; set; }

		/// <summary>
		/// fk_clientes_conyuge_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idconyuge", CanBeNull=false)]
		public IEnumerable<cliente> fkclientesconyuges { get; set; }

		/// <summary>
		/// fk_clientes_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersona", CanBeNull=false)]
		public cliente fkcliente { get; set; }

		/// <summary>
		/// fk_contratos_personas_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idpersona", CanBeNull=false)]
		public IEnumerable<contrato> fkcontratos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public persona Relacionar(estadopersona fkestadospersona)
		{
			this.fkestadospersona = fkestadospersona;
			return this;
		}

		public persona Relacionar(genero fkgenero)
		{
			this.fkgenero = fkgenero;
			return this;
		}

		public persona Relacionar(parroquia fkparroquia)
		{
			this.fkparroquia = fkparroquia;
			return this;
		}

		public persona Relacionar(tipodocumento fktiposdocumento)
		{
			this.fktiposdocumento = fktiposdocumento;
			return this;
		}

		public persona Relacionar(tipopersona fktipospersona)
		{
			this.fktipospersona = fktipospersona;
			return this;
		}

		public persona Relacionar(IEnumerable<empresa> fkempresascontadors, IEnumerable<empresa> fkempresasgerentes)
		{
			this.fkempresascontadors = fkempresascontadors;
			this.fkempresasgerentes = fkempresasgerentes;
			return this;
		}

		public persona Relacionar(IEnumerable<contable> fkcontables)
		{
			this.fkcontables = fkcontables;
			return this;
		}

		public persona Relacionar(IEnumerable<imagenespersona> fkimagenespersonas)
		{
			this.fkimagenespersonas = fkimagenespersonas;
			return this;
		}

		public persona Relacionar(IEnumerable<sucursal> fksucursales)
		{
			this.fksucursales = fksucursales;
			return this;
		}

		public persona Relacionar(IEnumerable<usuario> fkusuarios)
		{
			this.fkusuarios = fkusuarios;
			return this;
		}

		public persona Relacionar(IEnumerable<cliente> fkclientesconyuges)
		{
			this.fkclientesconyuges = fkclientesconyuges;
			return this;
		}

		public persona Relacionar(cliente fkcliente)
		{
			this.fkcliente = fkcliente;
			return this;
		}

		public persona Relacionar(IEnumerable<contrato> fkcontratos)
		{
			this.fkcontratos = fkcontratos;
			return this;
		}

		#endregion
	}
}