using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="estadosordenespedidos")]
	public partial class estadoordenpedido
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short             id          { get; set; }            // smallint
		[Column,        NotNull] public string            descripcion { get; set; }            // character varying(50)
		[Column,        NotNull] public bool              activo      { get; set; }            // boolean
		                         public estadoordenpedido Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_ordenespedidos_estadosordenespedidos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idestadoordenpedido", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public estadoordenpedido Relacionar(IEnumerable<ordenpedido> fkordenespedidos)
		{
			this.fkordenespedidos = fkordenespedidos;
			return this;
		}

		#endregion
	}
}