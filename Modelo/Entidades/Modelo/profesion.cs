using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="profesiones")]
	public partial class profesion
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short     id          { get; set; }            // smallint
		[Column,        Nullable] public string    nombre      { get; set; }            // character varying(100)
		[Column,        Nullable] public string    abreviatura { get; set; }            // character varying(5)
		                          public profesion Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_clientes_profesiones_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idprofesion", CanBeNull=false)]
		public IEnumerable<cliente> fkclientes { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public profesion Relacionar(IEnumerable<cliente> fkclientes)
		{
			this.fkclientes = fkclientes;
			return this;
		}

		#endregion
	}
}