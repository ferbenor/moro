using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="cantones")]
	public partial class canton
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public short  id          { get; set; }            // smallint
		[Column,        NotNull] public string nombre      { get; set; }            // character varying(50)
		[Column,        NotNull] public short  idprovincia { get; set; }            // smallint
		                         public canton Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_cantones_provincias
		/// </summary>
		[Association(ThisKey="idprovincia", OtherKey="id", CanBeNull=false)]
		public provincia fkprovincia { get; set; }

		/// <summary>
		/// fk_parroquias_cantones_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idcanton", CanBeNull=false)]
		public IEnumerable<parroquia> fkparroquias { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public canton Relacionar(provincia fkprovincia)
		{
			this.fkprovincia = fkprovincia;
			return this;
		}

		public canton Relacionar(IEnumerable<parroquia> fkparroquias)
		{
			this.fkparroquias = fkparroquias;
			return this;
		}

		#endregion
	}
}