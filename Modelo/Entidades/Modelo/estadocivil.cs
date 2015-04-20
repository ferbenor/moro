using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="estadosciviles")]
	public partial class estadocivil
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short       id     { get; set; }            // smallint
		[Column,        NotNull] public string      nombre { get; set; }            // character varying(20)
		                         public estadocivil Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_clientes_estadosciviles_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idestadocivil", CanBeNull=false)]
		public IEnumerable<cliente> fkclientes { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public estadocivil Relacionar(IEnumerable<cliente> fkclientes)
		{
			this.fkclientes = fkclientes;
			return this;
		}

		#endregion
	}
}