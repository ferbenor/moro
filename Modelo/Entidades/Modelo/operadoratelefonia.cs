using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="operadorastelefonias")]
	public partial class operadoratelefonia
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short              id     { get; set; }            // smallint
		[Column,        Nullable] public string             nombre { get; set; }            // character varying(30)
		                          public operadoratelefonia Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_telefonossucursales_operadorastelefonias_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idoperadoratelefonia", CanBeNull=false)]
		public IEnumerable<telefonosucursal> fktelefonossucursales { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public operadoratelefonia Relacionar(IEnumerable<telefonosucursal> fktelefonossucursales)
		{
			this.fktelefonossucursales = fktelefonossucursales;
			return this;
		}

		#endregion
	}
}