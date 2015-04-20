using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="telefonossucursales")]
	public partial class telefonosucursal
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int              idsucursal           { get; set; }            // integer
		[Column,        NotNull ] public short            idoperadoratelefonia { get; set; }            // smallint
		[Column,        NotNull ] public string           telefono             { get; set; }            // character varying(13)
		[Column,        Nullable] public bool?            activo               { get; set; }            // boolean
		                          public telefonosucursal Objeto               { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_telefonossucursales_operadorastelefonias
		/// </summary>
		[Association(ThisKey="idoperadoratelefonia", OtherKey="id", CanBeNull=false)]
		public operadoratelefonia fkoperadorastelefonia { get; set; }

		/// <summary>
		/// fk_telefonossucursales_sucursales
		/// </summary>
		[Association(ThisKey="idsucursal", OtherKey="id", CanBeNull=false)]
		public sucursal fktelefonossucursal { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public telefonosucursal Relacionar(operadoratelefonia fkoperadorastelefonia)
		{
			this.fkoperadorastelefonia = fkoperadorastelefonia;
			return this;
		}

		public telefonosucursal Relacionar(sucursal fktelefonossucursal)
		{
			this.fktelefonossucursal = fktelefonossucursal;
			return this;
		}

		#endregion
	}
}