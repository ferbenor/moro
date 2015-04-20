using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="usuariossesionactiva")]
	public partial class usuariosesionactiva
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int                 idusuario   { get; set; }            // integer
		[Column,        NotNull] public string              ipsesion    { get; set; }            // character varying(120)
		[Column,        NotNull] public DateTime            fechasesion { get; set; }            // timestamp (6) without time zone
		                         public usuariosesionactiva Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_usuariossesionactiva_usuarios
		/// </summary>
		[Association(ThisKey="idusuario", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public usuariosesionactiva Relacionar(usuario fkusuario)
		{
			this.fkusuario = fkusuario;
			return this;
		}

		#endregion
	}
}