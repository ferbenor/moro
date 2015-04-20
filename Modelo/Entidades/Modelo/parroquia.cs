using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="parroquias")]
	public partial class parroquia
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int       id       { get; set; }            // integer
		[Column,        NotNull] public string    nombre   { get; set; }            // character varying(100)
		[Column,        NotNull] public short     idcanton { get; set; }            // smallint
		[Column,        NotNull] public bool      esurbano { get; set; }            // boolean
		                         public parroquia Objeto   { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_parroquias_cantones
		/// </summary>
		[Association(ThisKey="idcanton", OtherKey="id", CanBeNull=false)]
		public canton fkcantone { get; set; }

		/// <summary>
		/// fk_barrios_parroquias_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idparroquia", CanBeNull=false)]
		public IEnumerable<barrio> fkbarrios { get; set; }

		/// <summary>
		/// fk_personas_parroquias_BackReference
		/// </summary>
		[Association(ThisKey="id", OtherKey="idparroquiadocumento", CanBeNull=false)]
		public IEnumerable<persona> fkpersonas { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public parroquia Relacionar(canton fkcantone)
		{
			this.fkcantone = fkcantone;
			return this;
		}

		public parroquia Relacionar(IEnumerable<barrio> fkbarrios)
		{
			this.fkbarrios = fkbarrios;
			return this;
		}

		public parroquia Relacionar(IEnumerable<persona> fkpersonas)
		{
			this.fkpersonas = fkpersonas;
			return this;
		}

		#endregion
	}
}