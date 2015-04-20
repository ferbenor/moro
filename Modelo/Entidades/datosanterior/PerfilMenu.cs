using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class PerfilMenu : Instrumental
    {
        #region VARIABLES
        private short idPerfil;
        private short idMenu;
        private bool editable;
        private const string nombreTabla = "perfilesmenus";
        #endregion VARIABLES

        #region PROPIEDADES
        public short IdPerfil { get { return this.idPerfil; } set { this.idPerfil = value; } }
        public short IdMenu { get { return this.idMenu; } set { this.idMenu = value; } }
        public bool Editable { get { return this.editable; } set { this.editable = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public PerfilMenu() { }

        public PerfilMenu(short IdPerfil) { this.idPerfil = IdPerfil; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("idperfil", true, System.Data.DbType.Int16, 0, this.idPerfil));
            lc.Add(new CamposTabla("idmenu", false, System.Data.DbType.Int16, 0, this.idMenu));
            lc.Add(new CamposTabla("editable", false, System.Data.DbType.Boolean, 0, this.editable));
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
            return GeneraCadenaGuardar(nombreTabla, idPerfil);
        }

        #endregion FUNCIONES LOCALES
    }
}