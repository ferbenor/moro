using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB11
{
[Table(Schema="public", Name="barrios")]
	public partial class barrio
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int    id          { get; set; }            // integer
		[Column,        NotNull] public string nombre      { get; set; }            // character varying(200)
		[Column,        NotNull] public int    idparroquia { get; set; }            // integer
		[Column,        NotNull] public bool   activo      { get; set; }            // boolean
		                         public barrio Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_barrios_parroquias
		/// </summary>
		[Association(ThisKey="idparroquia", OtherKey="id", CanBeNull=false)]
		public parroquia fkparroquia { get; set; }

		/// <summary>
		/// fk_ordenespedidos_barrios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbarrio", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

		/// <summary>
		/// fk_sucursales_barrios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbarrio", CanBeNull=false)]
		public IEnumerable<sucursal> fksucursales { get; set; }

		/// <summary>
		/// fk_clientes_barrios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbarrio", CanBeNull=false)]
		public IEnumerable<cliente> fkclientes { get; set; }

		/// <summary>
		/// fk_bodegas_barrios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbarrio", CanBeNull=false)]
		public IEnumerable<bodega> fkbodegas { get; set; }

		/// <summary>
		/// fk_ventas_barrios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbarrio", CanBeNull=false)]
		public IEnumerable<venta> fkventas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public barrio Relacionar(parroquia fkparroquia)
		{
			this.fkparroquia = fkparroquia;
			return this;
		}

		public barrio Relacionar(IEnumerable<ordenpedido> fkordenespedidos)
		{
			this.fkordenespedidos = fkordenespedidos;
			return this;
		}

		public barrio Relacionar(IEnumerable<sucursal> fksucursales)
		{
			this.fksucursales = fksucursales;
			return this;
		}

		public barrio Relacionar(IEnumerable<cliente> fkclientes)
		{
			this.fkclientes = fkclientes;
			return this;
		}

		public barrio Relacionar(IEnumerable<bodega> fkbodegas)
		{
			this.fkbodegas = fkbodegas;
			return this;
		}

		public barrio Relacionar(IEnumerable<venta> fkventas)
		{
			this.fkventas = fkventas;
			return this;
		}

		#endregion
	}
}