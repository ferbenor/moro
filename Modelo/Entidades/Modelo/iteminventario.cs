using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="itemsinventarios")]
	public partial class iteminventario
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int            id          { get; set; }            // integer
		[Column,        NotNull ] public string         descripcion { get; set; }            // character varying(255)
		[Column,        NotNull ] public decimal        precio      { get; set; }            // numeric(5,2)
		[Column,        NotNull ] public char           tipo        { get; set; }            // character varying(1)
		[Column,        Nullable] public bool?          grabaiva    { get; set; }            // boolean
		                          public iteminventario Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesordenesservicios_itemsinventarios_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="iditeminventario", CanBeNull=false)]
		public IEnumerable<detalleordenservicio> fkdetallesordenesservicios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public iteminventario Relacionar(IEnumerable<detalleordenservicio> fkdetallesordenesservicios)
		{
			this.fkdetallesordenesservicios = fkdetallesordenesservicios;
			return this;
		}

		#endregion
	}
}