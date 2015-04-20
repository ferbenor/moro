using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="menus")]
	public partial class menu
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short  id         { get; set; }            // smallint
		[Column,        NotNull ] public short  idpadre    { get; set; }            // smallint
		[Column,        Nullable] public string nombre     { get; set; }            // character varying(50)
		[Column,        Nullable] public string titulo     { get; set; }            // character varying(50)
		[Column,        NotNull ] public bool   visible    { get; set; }            // boolean
		[Column,        NotNull ] public bool   contenedor { get; set; }            // boolean
		[Column,        Nullable] public string formulario { get; set; }            // character varying(50)
		[Column,        Nullable] public string modulo     { get; set; }            // character varying(50)
		[Column,        Nullable] public string busqueda   { get; set; }            // character varying(50)
		[Column,        Nullable] public string piedetalle { get; set; }            // character varying(50)
		[Column,        NotNull ] public short  icono      { get; set; }            // smallint
		[Column,        NotNull ] public bool   editable   { get; set; }            // boolean
		[Column,        Nullable] public string tabla      { get; set; }            // character varying(255)
		                          public menu   Objeto     { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_columnasgrids_menus_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idmenu", CanBeNull=false)]
		public IEnumerable<columnasgrid> fkcolumnasgrid { get; set; }

		/// <summary>
		/// fk_perfilesmenus_menus_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idmenu", CanBeNull=false)]
		public IEnumerable<perfilmenu> fkperfilesmenus { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public menu Relacionar(IEnumerable<columnasgrid> fkcolumnasgrid)
		{
			this.fkcolumnasgrid = fkcolumnasgrid;
			return this;
		}

		public menu Relacionar(IEnumerable<perfilmenu> fkperfilesmenus)
		{
			this.fkperfilesmenus = fkperfilesmenus;
			return this;
		}

		#endregion
	}
}