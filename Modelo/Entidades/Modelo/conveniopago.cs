using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="conveniospagos")]
	public partial class conveniopago
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int          identificadorpagos { get; set; }            // integer
		[Column,        NotNull] public string       idformapago        { get; set; }            // character varying(5)
		[Column,        NotNull] public decimal      valor              { get; set; }            // numeric(18,2)
		[Column,        NotNull] public short        pagos              { get; set; }            // smallint
		                         public conveniopago Objeto             { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_conveniospagos_formaspagos
		/// </summary>
		[Association(ThisKey="idformapago", OtherKey="id", CanBeNull=false)]
		public formapago fkformaspago { get; set; }

		/// <summary>
		/// fk_conveniospagos_identificadorespagos
		/// </summary>
		[Association(ThisKey="identificadorpagos", OtherKey="id", CanBeNull=false)]
		public identificadorpago fkidentificadorespagos { get; set; }

		/// <summary>
		/// fk_pagos_conveniospagos_BackReference
		/// </summary>
		[Association(ThisKey="identificadorpagos, idformapago", OtherKey="identificadorpagos, idformapago", CanBeNull=false)]
		public IEnumerable<pago> fkpagos { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public conveniopago Relacionar(formapago fkformaspago)
		{
			this.fkformaspago = fkformaspago;
			return this;
		}

		public conveniopago Relacionar(identificadorpago fkidentificadorespagos)
		{
			this.fkidentificadorespagos = fkidentificadorespagos;
			return this;
		}

		public conveniopago Relacionar(IEnumerable<pago> fkpagos)
		{
			this.fkpagos = fkpagos;
			return this;
		}

		#endregion
	}
}