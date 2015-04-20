using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="detallesauditoriasmodulos")]
	public partial class detallesauditoriasmodulo
	{
		#region PROPIEDADES

		[PrimaryKey,    NotNull] public int                      idauditoria { get; set; }            // integer
		[Column,        NotNull] public DateTime                 fechahora   { get; set; }            // timestamp (3) without time zone
		[Column,        NotNull] public int                      idusuario   { get; set; }            // integer
		[Column,        NotNull] public char                     tipo        { get; set; }            // character(1)
		[Column,        NotNull] public string                   detalle     { get; set; }            // character varying(255)
		                         public detallesauditoriasmodulo Objeto      { get { return this; } }

		#endregion

		#region RELACIONES (PROPIEDADES)

		/// <summary>
		/// fk_detallesauditoriasmodulos_auditoriasmodulos
		/// </summary>
		[Association(ThisKey="idauditoria", OtherKey="id", CanBeNull=false)]
		public auditoriasmodulo fkauditoriasmodulo { get; set; }

		/// <summary>
		/// fk_detallesauditoriasmodulos_usuarios
		/// </summary>
		[Association(ThisKey="idusuario", OtherKey="id", CanBeNull=false)]
		public usuario fkusuario { get; set; }

		#endregion

		#region RELACIONES (FUNCIONES)

		public detallesauditoriasmodulo Relacionar(auditoriasmodulo fkauditoriasmodulo)
		{
			this.fkauditoriasmodulo = fkauditoriasmodulo;
			return this;
		}

		public detallesauditoriasmodulo Relacionar(usuario fkusuario)
		{
			this.fkusuario = fkusuario;
			return this;
		}

		#endregion
	}
}