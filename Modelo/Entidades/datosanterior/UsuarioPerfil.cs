using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class UsuarioPerfil : Instrumental
    {
        #region VARIABLES
        private short idUsuario;
        private short idPerfil;
        private const string nombreTabla = "usuariosperfiles";
        #endregion VARIABLES

        #region PROPIEDADES
        public short IdUsuario { get { return this.idUsuario; } set { this.idUsuario = value; } }
        public short IdPerfil { get { return this.idPerfil; } set { this.idPerfil = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public UsuarioPerfil() { }

        public UsuarioPerfil(short IdUsuario) { this.idUsuario = IdUsuario; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("idusuario", true, System.Data.DbType.Int16, 0, this.idUsuario));
            lc.Add(new CamposTabla("idperfil", false, System.Data.DbType.Int16, 0, this.idPerfil));
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
            return GeneraCadenaGuardar(nombreTabla, idUsuario);
        }

        #endregion FUNCIONES LOCALES
    }
}