using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="columnasgrids")]
	public partial class columnasgrid
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int          idmenu        { get; set; }            // integer
		[Column,        NotNull ] public short        identificador { get; set; }            // smallint
		[Column,        NotNull ] public string       nombre        { get; set; }            // character varying(255)
		[Column,        Nullable] public short?       orden         { get; set; }            // smallint
		[Column,        Nullable] public short?       idtipocolumna { get; set; }            // smallint
		[Column,        Nullable] public string       cabecera      { get; set; }            // character varying(255)
		[Column,        Nullable] public string       formatofecha  { get; set; }            // character varying(255)
		[Column,        Nullable] public DateTime?    fechaminima   { get; set; }            // date
		[Column,        Nullable] public string       propertyname  { get; set; }            // character varying(255)
		[Column,        Nullable] public string       valuemember   { get; set; }            // character varying(255)
		[Column,        Nullable] public string       displaymember { get; set; }            // character varying(255)
		[Column,        Nullable] public string       tag           { get; set; }            // character varying(255)
		[Column,        Nullable] public string       busqueda      { get; set; }            // character varying(120)
		[Column,        Nullable] public short?       idalineacion  { get; set; }            // smallint
		[Column,        Nullable] public short?       width         { get; set; }            // smallint
		[Column,        Nullable] public short?       maxlength     { get; set; }            // smallint
		[Column,        Nullable] public bool?        sololectura   { get; set; }            // boolean
		[Column,        Nullable] public bool?        visible       { get; set; }            // boolean
		                          public columnasgrid Objeto        { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_columnasgrids_alineacion
		/// </summary>
		[Association(ThisKey="idalineacion", OtherKey="id", CanBeNull=true)]
		public alineacion fkalineacion { get; set; }

		/// <summary>
		/// fk_columnasgrids_menus
		/// </summary>
		[Association(ThisKey="idmenu", OtherKey="id", CanBeNull=false)]
		public menu fkcolumnasgrid { get; set; }

		/// <summary>
		/// fk_columnasgrids_tiposcolumnas
		/// </summary>
		[Association(ThisKey="idtipocolumna", OtherKey="id", CanBeNull=true)]
		public tipocolumna fktiposcolumna { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public columnasgrid Relacionar(alineacion fkalineacion)
		{
			this.fkalineacion = fkalineacion;
			return this;
		}

		public columnasgrid Relacionar(menu fkcolumnasgrid)
		{
			this.fkcolumnasgrid = fkcolumnasgrid;
			return this;
		}

		public columnasgrid Relacionar(tipocolumna fktiposcolumna)
		{
			this.fktiposcolumna = fktiposcolumna;
			return this;
		}

		#endregion
	}
}