using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="cuentasbancos")]
	public partial class cuentabanco
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short       id               { get; set; }            // smallint
		[Column,        Nullable] public string      descripcion      { get; set; }            // character varying(25)
		[Column,        NotNull ] public short       idbanco          { get; set; }            // smallint
		[Column,        Nullable] public int?        idcuentacontable { get; set; }            // integer
		[Column,        Nullable] public DateTime?   fechaapertura    { get; set; }            // date
		[Column,        Nullable] public decimal?    saldocuenta      { get; set; }            // numeric(15,5)
		[Column,        NotNull ] public string      numerocuenta     { get; set; }            // character varying(25)
		[Column,        NotNull ] public bool        activo           { get; set; }            // boolean
		                          public cuentabanco Objeto           { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_cuentasbancos_bancos
		/// </summary>
		[Association(ThisKey="idbanco", OtherKey="id", CanBeNull=false)]
		public banco fkbanco { get; set; }

		/// <summary>
		/// fk_cuentasbancos_cuentascontables
		/// </summary>
		[Association(ThisKey="idcuentacontable", OtherKey="id", CanBeNull=true)]
		public cuentacontable fkcuentascontable { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public cuentabanco Relacionar(banco fkbanco)
		{
			this.fkbanco = fkbanco;
			return this;
		}

		public cuentabanco Relacionar(cuentacontable fkcuentascontable)
		{
			this.fkcuentascontable = fkcuentascontable;
			return this;
		}

		#endregion
	}
}