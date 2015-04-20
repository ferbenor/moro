using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="perfiles")]
	public partial class perfil
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short  id          { get; set; }            // smallint
		[Column,        Nullable] public string descripcion { get; set; }            // character varying(20)
		[Column,        Nullable] public bool?  activo      { get; set; }            // boolean
		                          public perfil Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_perfilesmenus_perfiles_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperfil", CanBeNull=false)]
		public IEnumerable<perfilmenu> fkperfilesmenu { get; set; }

		/// <summary>
		/// fk_usuariosperfiles_perfiles_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idperfil", CanBeNull=false)]
		public IEnumerable<usuarioperfil> fkusuariosperfiles { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public perfil Relacionar(IEnumerable<perfilmenu> fkperfilesmenu)
		{
			this.fkperfilesmenu = fkperfilesmenu;
			return this;
		}

		public perfil Relacionar(IEnumerable<usuarioperfil> fkusuariosperfiles)
		{
			this.fkusuariosperfiles = fkusuariosperfiles;
			return this;
		}

		#endregion
	}
}