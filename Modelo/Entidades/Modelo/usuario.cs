using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="usuarios")]
	public partial class usuario
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       id            { get; set; }            // integer
		[Column,        NotNull ] public int       idpersona     { get; set; }            // integer
		[Column,        NotNull ] public string    descripcion   { get; set; }            // character varying(40)
		[Column,        NotNull ] public bool      administrador { get; set; }            // boolean
		[Column,        NotNull ] public short     diasvigencia  { get; set; }            // smallint
		[Column,        NotNull ] public DateTime  fechacambio   { get; set; }            // date
		[Column,        NotNull ] public string    loginusuario  { get; set; }            // character varying(15)
		[Column,        NotNull ] public string    clave         { get; set; }            // character varying(32)
		[Column,        NotNull ] public bool      activo        { get; set; }            // boolean
		[Column,        Nullable] public DateTime? fechacreacion { get; set; }            // timestamp without time zone
		[Column,        NotNull ] public bool      multisesion   { get; set; }            // boolean
		                          public usuario   Objeto        { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_usuarios_personas
		/// </summary>
		[Association(ThisKey="idpersona", OtherKey="id", CanBeNull=false)]
		public persona fkpersona { get; set; }

		/// <summary>
		/// fk_detallesauditoriasmodulos_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuario", CanBeNull=false)]
		public IEnumerable<detallesauditoriasmodulo> fkdetallesauditoriasmodulos { get; set; }

		/// <summary>
		/// fk_ordenespedidos_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuarioregistra", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

		/// <summary>
		/// fk_ordenespedidos_usuarios1_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuarioanula", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidosusuarios1 { get; set; }

		/// <summary>
		/// fk_pagos_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuariocobranzas", CanBeNull=false)]
		public IEnumerable<pago> fkpagos { get; set; }

		/// <summary>
		/// fk_usuariossesionactiva_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuario", CanBeNull=false)]
		public usuariosesionactiva fkusuariossesionactiva { get; set; }

		/// <summary>
		/// fk_usuariosperfiles_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuario", CanBeNull=false)]
		public IEnumerable<usuarioperfil> fkusuariosperfile { get; set; }

		/// <summary>
		/// fk_bodegas_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuario", CanBeNull=false)]
		public IEnumerable<bodega> fkbodegas { get; set; }

		/// <summary>
		/// fk_ventas_usuarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuarioregistra", CanBeNull=false)]
		public IEnumerable<venta> fkventas { get; set; }

		/// <summary>
		/// fk_ventas_usuarios1_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idusuarioanula", CanBeNull=false)]
		public IEnumerable<venta> fkventasusuarios1 { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public usuario Relacionar(persona fkpersona)
		{
			this.fkpersona = fkpersona;
			return this;
		}

		public usuario Relacionar(IEnumerable<detallesauditoriasmodulo> fkdetallesauditoriasmodulos)
		{
			this.fkdetallesauditoriasmodulos = fkdetallesauditoriasmodulos;
			return this;
		}

		public usuario Relacionar(IEnumerable<ordenpedido> fkordenespedidos, IEnumerable<ordenpedido> fkordenespedidosusuarios1)
		{
			this.fkordenespedidos = fkordenespedidos;
			this.fkordenespedidosusuarios1 = fkordenespedidosusuarios1;
			return this;
		}

		public usuario Relacionar(IEnumerable<pago> fkpagos)
		{
			this.fkpagos = fkpagos;
			return this;
		}

		public usuario Relacionar(usuariosesionactiva fkusuariossesionactiva)
		{
			this.fkusuariossesionactiva = fkusuariossesionactiva;
			return this;
		}

		public usuario Relacionar(IEnumerable<usuarioperfil> fkusuariosperfile)
		{
			this.fkusuariosperfile = fkusuariosperfile;
			return this;
		}

		public usuario Relacionar(IEnumerable<bodega> fkbodegas)
		{
			this.fkbodegas = fkbodegas;
			return this;
		}

		public usuario Relacionar(IEnumerable<venta> fkventas, IEnumerable<venta> fkventasusuarios1)
		{
			this.fkventas = fkventas;
			this.fkventasusuarios1 = fkventasusuarios1;
			return this;
		}

		#endregion
	}
}