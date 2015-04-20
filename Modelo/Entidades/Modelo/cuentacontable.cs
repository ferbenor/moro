using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="cuentascontables")]
	public partial class cuentacontable
	{
		#region PROPIEDADES

		[Column,        NotNull] public int            idperiodo      { get; set; }            // integer
		[PrimaryKey,    NotNull] public int            id             { get; set; }            // integer
		[Column,        NotNull] public int            idpadre        { get; set; }            // integer
		[Column,        NotNull] public string         codigo         { get; set; }            // character varying(20)
		[Column,        NotNull] public string         nombre         { get; set; }            // character varying(80)
		[Column,        NotNull] public bool           esgrupo        { get; set; }            // boolean
		[Column,        NotNull] public decimal        debitoinicial  { get; set; }            // numeric(15,2)
		[Column,        NotNull] public decimal        creditoinicial { get; set; }            // numeric(15,2)
		[Column,        NotNull] public DateTime       fechaapertura  { get; set; }            // timestamp without time zone
		                         public cuentacontable Objeto         { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_cuentascontables_periodos
		/// </summary>
		[Association(ThisKey="idperiodo", OtherKey="id", CanBeNull=false)]
		public periodo fkperiodo { get; set; }

		/// <summary>
		/// fk_detallescontables_cuentascontables_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idcuentacontable", CanBeNull=false)]
		public IEnumerable<detallecontable> fkdetallescontables { get; set; }

		/// <summary>
		/// fk_cuentasbancos_cuentascontables_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idcuentacontable", CanBeNull=false)]
		public IEnumerable<cuentabanco> fkcuentasbancos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public cuentacontable Relacionar(periodo fkperiodo)
		{
			this.fkperiodo = fkperiodo;
			return this;
		}

		public cuentacontable Relacionar(IEnumerable<detallecontable> fkdetallescontables)
		{
			this.fkdetallescontables = fkdetallescontables;
			return this;
		}

		public cuentacontable Relacionar(IEnumerable<cuentabanco> fkcuentasbancos)
		{
			this.fkcuentasbancos = fkcuentasbancos;
			return this;
		}

		#endregion
	}
}