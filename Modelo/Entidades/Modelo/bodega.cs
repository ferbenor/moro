using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="bodegas")]
	public partial class bodega
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int    id          { get; set; }            // integer
		[Column,        NotNull ] public int    idsucursal  { get; set; }            // integer
		[Column,        NotNull ] public string codigo      { get; set; }            // character varying(10)
		[Column,        Nullable] public string descripcion { get; set; }            // character varying(80)
		[Column,        NotNull ] public int    idusuario   { get; set; }            // integer
		[Column,        NotNull ] public int    idbarrio    { get; set; }            // integer
		[Column,        NotNull ] public bool   activo      { get; set; }            // boolean
		                          public bodega Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_bodegas_barrios
		/// </summary>
		[Association(ThisKey="idbarrio", OtherKey="id", CanBeNull=false)]
		public barrio fkbarrio { get; set; }

		/// <summary>
		/// fk_bodegas_sucursales
		/// </summary>
		[Association(ThisKey="idsucursal", OtherKey="id", CanBeNull=false)]
		public sucursal fksucursale { get; set; }

		/// <summary>
		/// fk_bodegas_usuarios
		/// </summary>
		[Association(ThisKey="idusuario", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		/// <summary>
		/// fk_inventarios_bodegas1_BackReference
		/// </summary>
		[Association(ThisKey="id, idsucursal", OtherKey="idbodega1, idsucursalbodega1", CanBeNull=false)]
		public IEnumerable<inventario> fkinventariosbodegas1 { get; set; }

		/// <summary>
		/// fk_inventarios_bodegas2_BackReference
		/// </summary>
		[Association(ThisKey="id, idsucursal", OtherKey="idbodega2, idsucursalbodega2", CanBeNull=false)]
		public IEnumerable<inventario> fkinventariosbodegas2 { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public bodega Relacionar(barrio fkbarrio)
		{
			this.fkbarrio = fkbarrio;
			return this;
		}

		public bodega Relacionar(sucursal fksucursale)
		{
			this.fksucursale = fksucursale;
			return this;
		}

		public bodega Relacionar(usuario fkusuario)
		{
			this.fkusuario = fkusuario;
			return this;
		}

		public bodega Relacionar(IEnumerable<inventario> fkinventariosbodegas1, IEnumerable<inventario> fkinventariosbodegas2)
		{
			this.fkinventariosbodegas1 = fkinventariosbodegas1;
			this.fkinventariosbodegas2 = fkinventariosbodegas2;
			return this;
		}

		#endregion
	}
}