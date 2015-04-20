using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="identificadorespagos")]
	public partial class identificadorpago
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int               id     { get; set; }            // integer
		                         public identificadorpago Objeto { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_conveniospagos_identificadorespagos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="identificadorpagos", CanBeNull=false)]
		public IEnumerable<conveniopago> fkconveniospago { get; set; }

		/// <summary>
		/// fk_ordenespedidos_identificadorespagos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="ididentificadorpago", CanBeNull=false)]
		public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

		/// <summary>
		/// fk_ventas_identificadorespagos_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="ididentificadorpago", CanBeNull=false)]
		public IEnumerable<venta> fkventas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public identificadorpago Relacionar(IEnumerable<conveniopago> fkconveniospago)
		{
			this.fkconveniospago = fkconveniospago;
			return this;
		}

		public identificadorpago Relacionar(IEnumerable<ordenpedido> fkordenespedidos)
		{
			this.fkordenespedidos = fkordenespedidos;
			return this;
		}

		public identificadorpago Relacionar(IEnumerable<venta> fkventas)
		{
			this.fkventas = fkventas;
			return this;
		}

		#endregion
	}
}