using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="sectoreseconomicos")]
	public partial class sectoreconomico
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull ] public short           id          { get; set; }            // smallint
		[Column,        NotNull ] public string          codigo      { get; set; }            // character varying(20)
		[Column,        Nullable] public string          descripcion { get; set; }            // character varying(500)
		[Column,        Nullable] public short?          idpadre     { get; set; }            // smallint
		[Column,        Nullable] public short?          nivel       { get; set; }            // smallint
		[Column,        Nullable] public bool?           activo      { get; set; }            // boolean
		                          public sectoreconomico Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_actividadeseconomicas_sectoresactividades_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idsector", CanBeNull=false)]
		public IEnumerable<actividadeconomica> fkactividadeseconomicassectoresactividades { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public sectoreconomico Relacionar(IEnumerable<actividadeconomica> fkactividadeseconomicassectoresactividades)
		{
			this.fkactividadeseconomicassectoresactividades = fkactividadeseconomicassectoresactividades;
			return this;
		}

		#endregion
	}

	// Vista
}