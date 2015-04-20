using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class UsuarioSesionActiva : Instrumental
    {
        #region VARIABLES
        private short idUsuario;
        private Usuario usuario;
        private string ipSesion;
        private DateTime fechaSesion;
        private const string nombreTabla = "usuariossesionactiva";
        #endregion VARIABLES

        #region PROPIEDADES
        public short IdUsuario { get { return this.idUsuario; } set { this.idUsuario = value; } }
        public Usuario Usuario
        {
            get
            {
                if (this.usuario == null)
                    this.usuario = General.usuarioCero;
                return this.usuario;
            }
            set { this.usuario = value; if (value == null) this.IdUsuario = 0; else this.IdUsuario = value.Id; }
        }
        public string IpSesion
        {
            get
            {
                if (String.IsNullOrEmpty(this.ipSesion)) return General.ipLocal; else return ipSesion;
            }
            set { this.ipSesion = value; }
        }
        public DateTime FechaSesion { get { return fechaSesion; } }
        public UsuarioSesionActiva Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public UsuarioSesionActiva() { }

        public UsuarioSesionActiva(DateTime FechaSesion)
        {
            this.fechaSesion = FechaSesion;
        }

        public UsuarioSesionActiva(Usuario unUsuario) { this.usuario = unUsuario; this.idUsuario = this.Usuario.Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            try
            {
                indiceCampo = 0;
                lc[indiceCampo++].Valor = this.Usuario.Id;
                lc[indiceCampo++].Valor = this.ipSesion;
                //lc[indiceCampo++].Valor = General.BDFechaActual;
            }
            catch (Exception)
            {
                lc.Add(new CamposTabla("idusuario", true, System.Data.DbType.Int16, 0, this.Usuario.Id));
                lc.Add(new CamposTabla("ipsesion", false, System.Data.DbType.String, 15, this.ipSesion) { NoUpdate = true });
                //lc.Add(new CamposTabla("#fechasesion", false, System.Data.DbType.DateTime, 0, General.BDFechaHoraActual));
                lc.ForEach(x => x.NombreTabla = nombreTabla);
            }
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
            return GeneraCadenaGuardar(nombreTabla, this.idUsuario);
        }

        public override string ToString()
        {
            return this.Usuario.Descripcion + " (" + this.ipSesion + ")";
        }


        #endregion FUNCIONES LOCALES
    }
}
