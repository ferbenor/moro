using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="bancos")]
	public partial class banco
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short  id     { get; set; }            // smallint
		[Column,        Nullable] public string nombre { get; set; }            // character varying(25)
		[Column,        NotNull ] public bool   activo { get; set; }            // boolean
		                          public banco  Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_cuentasbancos_bancos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idbanco", CanBeNull=false)]
		public IEnumerable<cuentabanco> fkcuentasbancos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public banco Relacionar(IEnumerable<cuentabanco> fkcuentasbancos)
		{
			this.fkcuentasbancos = fkcuentasbancos;
			return this;
		}

		#endregion
	}
}