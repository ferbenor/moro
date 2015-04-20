using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="inventarios")]
	public partial class inventario
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int        idperiodo         { get; set; }            // integer
		[Column,        NotNull ] public char       tipo              { get; set; }            // character(1)
		[Column,        NotNull ] public int        numero            { get; set; }            // integer
		[Column,        NotNull ] public int        idbodega1         { get; set; }            // integer
		[Column,        NotNull ] public int        idsucursalbodega1 { get; set; }            // integer
		[Column,        Nullable] public int?       idbodega2         { get; set; }            // integer
		[Column,        Nullable] public int?       idsucursalbodega2 { get; set; }            // integer
		[Column,        NotNull ] public DateTime   fecha             { get; set; }            // date
		[Column,        Nullable] public DateTime?  fecharegistro     { get; set; }            // timestamp without time zone
		[Column,        NotNull ] public int        idauditoria       { get; set; }            // integer
		[Column,        Nullable] public string     observacion       { get; set; }            // character varying(255)
		[Column,        NotNull ] public bool       esanulado         { get; set; }            // boolean
		                          public inventario Objeto            { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_inventarios_auditoriasmodulos
		/// </summary>
		[Association(ThisKey="idauditoria", OtherKey="id", CanBeNull=false)]
		public auditoriasmodulo fkauditoriasmodulo { get; set; }

		/// <summary>
		/// fk_inventarios_bodegas1
		/// </summary>
		[Association(ThisKey="idbodega1, idsucursalbodega1", OtherKey="id, idsucursal", CanBeNull=false)]
		public bodega fkbodegas1 { get; set; }

		/// <summary>
		/// fk_inventarios_bodegas2
		/// </summary>
		[Association(ThisKey="idbodega2, idsucursalbodega2", OtherKey="id, idsucursal", CanBeNull=true)]
		public bodega fkbodegas2 { get; set; }

		/// <summary>
		/// fk_inventarios_periodos
		/// </summary>
		[Association(ThisKey="idperiodo", OtherKey="id", CanBeNull=false)]
		public periodo fkperiodo { get; set; }

		/// <summary>
		/// fk_detallesinventarios_inventarios_BackReference
		/// </summary>
		[Association(ThisKey="idperiodo, tipo, numero", OtherKey="idperiodo, tipo, numero", CanBeNull=false)]
		public IEnumerable<detallesinventario> fkdetallesinventarios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public inventario Relacionar(auditoriasmodulo fkauditoriasmodulo)
		{
			this.fkauditoriasmodulo = fkauditoriasmodulo;
			return this;
		}

		public inventario Relacionar(bodega fkbodegas1, bodega fkbodegas2)
		{
			this.fkbodegas1 = fkbodegas1;
			this.fkbodegas2 = fkbodegas2;
			return this;
		}

		public inventario Relacionar(periodo fkperiodo)
		{
			this.fkperiodo = fkperiodo;
			return this;
		}

		public inventario Relacionar(IEnumerable<detallesinventario> fkdetallesinventarios)
		{
			this.fkdetallesinventarios = fkdetallesinventarios;
			return this;
		}

		#endregion
	}
}