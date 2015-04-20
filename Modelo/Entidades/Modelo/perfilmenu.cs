using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="perfilesmenus")]
	public partial class perfilmenu
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short      idperfil { get; set; }            // smallint
		[Column,        NotNull] public short      idmenu   { get; set; }            // smallint
		[Column,        NotNull] public bool       editable { get; set; }            // boolean
		                         public perfilmenu Objeto   { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_perfilesmenus_menus
		/// </summary>
		[Association(ThisKey="idmenu", OtherKey="id", CanBeNull=false)]
		public menu fkmenu { get; set; }

		/// <summary>
		/// fk_perfilesmenus_perfiles
		/// </summary>
		[Association(ThisKey="idperfil", OtherKey="id", CanBeNull=false)]
		public perfil fkperfiles { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public perfilmenu Relacionar(menu fkmenu)
		{
			this.fkmenu = fkmenu;
			return this;
		}

		public perfilmenu Relacionar(perfil fkperfiles)
		{
			this.fkperfiles = fkperfiles;
			return this;
		}

		#endregion
	}
}