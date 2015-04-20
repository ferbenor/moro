using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallescontables")]
	public partial class detallecontable
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short           idperiodo        { get; set; }            // smallint
		[Column,        NotNull ] public short           idtipocontable   { get; set; }            // smallint
		[Column,        NotNull ] public int             numerocontable   { get; set; }            // integer
		[Column,        NotNull ] public short           registro         { get; set; }            // smallint
		[Column,        NotNull ] public int             idcuentacontable { get; set; }            // integer
		[Column,        Nullable] public string          detallecuenta    { get; set; }            // character varying(255)
		[Column,        NotNull ] public decimal         valordebe        { get; set; }            // numeric(15,2)
		[Column,        NotNull ] public decimal         valorhaber       { get; set; }            // numeric(15,2)
		[Column,        NotNull ] public short           tipomovimiento   { get; set; }            // smallint
		                          public detallecontable Objeto           { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallescontables_contables
		/// </summary>
		[Association(ThisKey="idperiodo, idtipocontable, numerocontable", OtherKey="idperiodo, idtipocontable, numero", CanBeNull=false)]
		public contable fkcontable { get; set; }

		/// <summary>
		/// fk_detallescontables_cuentascontables
		/// </summary>
		[Association(ThisKey="idcuentacontable", OtherKey="id", CanBeNull=false)]
		public cuentacontable fkcuentascontable { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detallecontable Relacionar(contable fkcontable)
		{
			this.fkcontable = fkcontable;
			return this;
		}

		public detallecontable Relacionar(cuentacontable fkcuentascontable)
		{
			this.fkcuentascontable = fkcuentascontable;
			return this;
		}

		#endregion
	}
}