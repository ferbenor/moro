using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Empresa : Instrumental
    {
        #region VARIABLES
        private short id;
        private string descripcion;
        private System.Drawing.Image imagenLogo;
        private bool activo = true;
        private const string nombreTabla = "empresas";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public System.Drawing.Image ImagenLogo { get { return this.imagenLogo; } set { this.imagenLogo = value; } }
        public bool Activo { get { return this.activo; } set { this.activo = value; } }
        public Empresa Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Empresa()
        {
        }

        public Empresa(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 20, this.descripcion));
            lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.activo));
            return lc;
        }

        public string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, id);
        }

        public override string ToString()
        {
            return this.Descripcion;
        }

        #region FUNCIONES ASIGNACION
        public string SelectAsignacionCombo()
        {
            return "select id, descripcion, false as editable, false as asignado from " + nombreTabla + " where activo = true order by descripcion";
        }

        public string SelectAsignacionDetalle()
        {
            return "select distinct m.id, m.nombre, case when p.editable is null then false else p.editable end as editable, case when p.idperfil is null then false else true end asignado from menus m left join perfilesmenus p on m.id = p.idmenu and p.idperfil = @codigo where m.contenedor = false and m.visible = true order by m.nombre";
        }
        #endregion FUNCIONES ASIGNACION
        #endregion FUNCIONES LOCALES
    }
}
