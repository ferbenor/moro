using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="actividadeseconomicas")]
	public partial class actividadeconomica
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short              id             { get; set; }            // smallint
		[Column,        NotNull ] public string             codigo         { get; set; }            // character varying(20)
		[Column,        NotNull ] public string             nombre         { get; set; }            // character varying(500)
		[Column,        Nullable] public string             descripcion    { get; set; }            // character varying(500)
		[Column,        Nullable] public short?             idpadre        { get; set; }            // smallint
		[Column,        Nullable] public short?             orden          { get; set; }            // smallint
		[Column,        Nullable] public short?             niveleconomico { get; set; }            // smallint
		[Column,        Nullable] public bool?              activo         { get; set; }            // boolean
		[Column,        Nullable] public short?             idsector       { get; set; }            // smallint
		                          public actividadeconomica Objeto         { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_actividadeseconomicas_sectoresactividades
		/// </summary>
		[Association(ThisKey="idsector", OtherKey="id", CanBeNull=true)]
		public sectoreconomico fksectoresactividade { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public actividadeconomica Relacionar(sectoreconomico fksectoresactividade)
		{
			this.fksectoresactividade = fksectoresactividade;
			return this;
		}

		#endregion
	}
}