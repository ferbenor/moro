using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="formaspagos")]
	public partial class formapago
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public string    id          { get; set; }            // character varying(5)
		[Column,        Nullable] public string    descripcion { get; set; }            // character varying(30)
		[Column,        Nullable] public string    modulo      { get; set; }            // character varying(25)
		[Column,        NotNull ] public bool      activo      { get; set; }            // boolean
		                          public formapago Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_conveniospagos_formaspagos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idformapago", CanBeNull=false)]
		public IEnumerable<conveniopago> fkconveniospagos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public formapago Relacionar(IEnumerable<conveniopago> fkconveniospagos)
		{
			this.fkconveniospagos = fkconveniospagos;
			return this;
		}

		#endregion
	}
}