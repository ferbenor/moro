using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="periodos")]
	public partial class periodo
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short   id         { get; set; }            // smallint
		[Column,        Nullable] public int?    idsucursal { get; set; }            // integer
		[Column,        Nullable] public short?  anio       { get; set; }            // smallint
		                          public periodo Objeto     { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_periodos_sucursales
		/// </summary>
		[Association(ThisKey="idsucursal", OtherKey="id", CanBeNull=true)]
		public sucursal fksucursale { get; set; }

		/// <summary>
		/// fk_cuentascontables_periodos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperiodo", CanBeNull=false)]
		public IEnumerable<cuentacontable> fkcuentascontables { get; set; }

		/// <summary>
		/// fk_contables_periodos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperiodo", CanBeNull=false)]
		public contable fkcontable { get; set; }

		/// <summary>
		/// fk_fraccionesperiodos_periodos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperiodo", CanBeNull=false)]
		public IEnumerable<fraccionperiodo> fkfraccionesperiodos { get; set; }

		/// <summary>
		/// fk_inventarios_periodos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperiodo", CanBeNull=false)]
		public inventario fkinventario { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public periodo Relacionar(sucursal fksucursale)
		{
			this.fksucursale = fksucursale;
			return this;
		}

		public periodo Relacionar(IEnumerable<cuentacontable> fkcuentascontables)
		{
			this.fkcuentascontables = fkcuentascontables;
			return this;
		}

		public periodo Relacionar(contable fkcontable)
		{
			this.fkcontable = fkcontable;
			return this;
		}

		public periodo Relacionar(IEnumerable<fraccionperiodo> fkfraccionesperiodos)
		{
			this.fkfraccionesperiodos = fkfraccionesperiodos;
			return this;
		}

		public periodo Relacionar(inventario fkinventario)
		{
			this.fkinventario = fkinventario;
			return this;
		}

		#endregion
	}
}