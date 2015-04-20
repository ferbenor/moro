using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="documentos")]
	public partial class documento
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short     id          { get; set; }            // smallint
		[Column,        Nullable] public string    descripcion { get; set; }            // character varying(100)
		[Column,        Nullable] public string    contenido   { get; set; }            // character(10)
		                          public documento Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_contratos_documentos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="iddocumento", CanBeNull=false)]
		public IEnumerable<contrato> fkcontratos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public documento Relacionar(IEnumerable<contrato> fkcontratos)
		{
			this.fkcontratos = fkcontratos;
			return this;
		}

		#endregion
	}
}