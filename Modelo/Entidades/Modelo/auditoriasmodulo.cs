using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="auditoriasmodulos")]
	public partial class auditoriasmodulo
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int              id     { get; set; }            // integer
		[Column,        Nullable] public string           modulo { get; set; }            // character varying(100)
		                          public auditoriasmodulo Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesauditoriasmodulos_auditoriasmodulos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idauditoria", CanBeNull=false)]
		public detallesauditoriasmodulo fkdetallesauditoriasmodulo { get; set; }

		/// <summary>
		/// fk_inventarios_auditoriasmodulos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idauditoria", CanBeNull=false)]
		public IEnumerable<inventario> fkinventarios { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public auditoriasmodulo Relacionar(detallesauditoriasmodulo fkdetallesauditoriasmodulo)
		{
			this.fkdetallesauditoriasmodulo = fkdetallesauditoriasmodulo;
			return this;
		}

		public auditoriasmodulo Relacionar(IEnumerable<inventario> fkinventarios)
		{
			this.fkinventarios = fkinventarios;
			return this;
		}

		#endregion
	}
}