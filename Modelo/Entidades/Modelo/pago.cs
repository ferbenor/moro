using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="pagos")]
	public partial class pago
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public int       identificadorpagos { get; set; }            // integer
		[Column,        NotNull ] public string    idformapago        { get; set; }            // character varying(5)
		[Column,        NotNull ] public short     numero             { get; set; }            // smallint
		[Column,        Nullable] public bool?     notificacion       { get; set; }            // boolean
		[Column,        Nullable] public DateTime? fecha              { get; set; }            // timestamp without time zone
		[Column,        NotNull ] public int       idusuariocobranzas { get; set; }            // integer
		[Column,        NotNull ] public decimal   valor              { get; set; }            // numeric(18,2)
		[Column,        Nullable] public string    detalle            { get; set; }            // character varying(255)
		[Column,        Nullable] public int?      idusuarioregistra  { get; set; }            // integer
		[Column,        Nullable] public int?      idusuarioanula     { get; set; }            // integer
		[Column,        Nullable] public bool?     anulado            { get; set; }            // boolean
		                          public pago      Objeto             { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_pagos_conveniospagos
		/// </summary>
		[Association(ThisKey="identificadorpagos, idformapago", OtherKey="identificadorpagos, idformapago", CanBeNull=false)]
		public conveniopago fkconveniospago { get; set; }

		/// <summary>
		/// fk_pagos_usuarios
		/// </summary>
		[Association(ThisKey="idusuariocobranzas", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public pago Relacionar(conveniopago fkconveniospago)
		{
			this.fkconveniospago = fkconveniospago;
			return this;
		}

		public pago Relacionar(usuario fkusuario)
		{
			this.fkusuario = fkusuario;
			return this;
		}

		#endregion
	}
}