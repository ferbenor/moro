using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="usuariosperfiles")]
	public partial class usuarioperfil
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int           idusuario { get; set; }            // integer
		[Column,        NotNull] public short         idperfil  { get; set; }            // smallint
		                         public usuarioperfil Objeto    { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_usuariosperfiles_perfiles
		/// </summary>
		[Association(ThisKey="idperfil", OtherKey="id", CanBeNull=false)]
		public perfil fkperfile { get; set; }

		/// <summary>
		/// fk_usuariosperfiles_usuarios
		/// </summary>
		[Association(ThisKey="idusuario", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public usuarioperfil Relacionar(perfil fkperfile)
		{
			this.fkperfile = fkperfile;
			return this;
		}

		public usuarioperfil Relacionar(usuario fkusuario)
		{
			this.fkusuario = fkusuario;
			return this;
		}

		#endregion
	}
}