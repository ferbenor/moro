using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Usuario : Instrumental
    {
        #region VARIABLES
        private short id;
        private string identificacion;
        private Persona persona;
        private string descripcion;
        private bool administrador;
        private short diasVigencia = 30;
        private DateTime fechaCambio = DateTime.Now;
        private string loginUsuario;
        private string clave;
        private bool activo = true;
        private DateTime fechaCreacion = DateTime.Now;
        private DateTime fechaServidor;
        private bool menusAsignados = false;
        private bool reseteaClave = false;
        private bool multiSesion = false;
        private const string nombreTabla = "usuarios";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Identificacion { get { return this.identificacion; } set { this.identificacion = value; } }
        public int IdPersona { get; set; }
        public Persona Persona
        {
            get
            {
                if (this.persona == null)
                    return General.personaCero;
                else
                    return this.persona;
            }
            set { this.persona = value; if (value == null) { this.IdPersona = 0; this.Identificacion = ""; } else { this.IdPersona = value.Id; this.Identificacion = value.Identificacion; } }
            //set
            //{
            //    this.persona = value;
            //    if (value == null) this.Identificacion = "";
            //    else this.Identificacion = value.Identificacion;

            //}
        }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public bool Administrador { get { return this.administrador; } set { this.administrador = value; } }
        public short DiasVigencia { get { return this.diasVigencia; } set { this.diasVigencia = value; } }
        public DateTime FechaCambio { get { return this.fechaCambio; } }
        public string FechaCambioChr { get { if (this.fechaCambio == new DateTime(1900, 1, 1)) return ""; else return this.fechaCambio.ToString(); } }
        public string LoginUsuario { get { return this.loginUsuario; } set { this.loginUsuario = value; } }
        public string Clave
        {
            get
            {
                if (String.IsNullOrEmpty(this.clave) || this.reseteaClave) return General.CifrarClave(this.loginUsuario + " " + this.loginUsuario); else return this.clave;
            }
            set { this.clave = General.CifrarClave(this.loginUsuario + " " + value); }
        }
        public bool Activo { get { return this.activo; } set { this.activo = value; } }
        public DateTime FechaCreacion { get { return this.fechaCreacion; } }
        public string FechaCreacionChr { get { if (this.fechaCreacion == new DateTime(1900, 1, 1)) return ""; else return this.fechaCreacion.ToString(); } }
        public DateTime FechaServidor { get { return fechaServidor; } set { fechaServidor = value; } }
        public bool MenusAsignados { get { return menusAsignados; } }
        public bool ReseteaClave { get { return this.reseteaClave; } set { this.reseteaClave = value; } }
        public bool MultiSesion { get { return this.multiSesion; } set { this.multiSesion = value; } }

        public bool CambioClave
        {
            get
            {
                if (General.CifrarClave(this.loginUsuario + " " + this.loginUsuario) == this.clave)
                    return true;
                else
                {
                    TimeSpan dias = new TimeSpan(this.FechaServidor.Ticks - fechaCambio.Ticks);
                    if (dias.Days > diasVigencia || this.clave == "")
                        return true;
                    else
                        return false;
                }
            }
        }
        public Usuario Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Usuario() { }

        public Usuario(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            if (lc.Count == 0)
            {
                lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
                lc.Add(new CamposTabla("idpersona", false, System.Data.DbType.Int32, 0, this.Persona.Id));
                lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 40, this.Descripcion));
                lc.Add(new CamposTabla("administrador", false, System.Data.DbType.Boolean, 0, this.Administrador));
                lc.Add(new CamposTabla("diasvigencia", false, System.Data.DbType.Int16, 0, this.DiasVigencia));
                lc.Add(new CamposTabla("#fechacambio", false, System.Data.DbType.Date, 0, General.BDFechaActual));
                lc.Add(new CamposTabla("loginusuario", false, System.Data.DbType.String, 15, this.LoginUsuario));
                lc.Add(new CamposTabla("clave", false, System.Data.DbType.String, 128, this.Clave));
                lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.Activo));
                lc.Add(new CamposTabla("fechacreacion", false, System.Data.DbType.DateTime, 0, this.FechaCreacion, false, true));
                lc.Add(new CamposTabla(General.BDFechaActual, false, System.Data.DbType.DateTime, 0, -1, false, true));
                lc.Add(new CamposTabla("case when (select count(p.idperfil) from perfilesmenus p, usuariosperfiles u where p.idperfil = u.idperfil and idusuario = id) = 0 then false else true end menusasignados", false, System.Data.DbType.Boolean, 0, -1, false, true));
                lc.Add(new CamposTabla("multisesion", false, System.Data.DbType.Boolean, 0, this.MultiSesion, false, true));
                lc.ForEach(x => x.NombreTabla = nombreTabla);
            }
            else
            {
                indiceCampo = 0;
                lc[indiceCampo++].Valor = this.Id;
                lc[indiceCampo++].Valor = this.IdPersona;
                lc[indiceCampo++].Valor = this.Descripcion;
                lc[indiceCampo++].Valor = this.Administrador;
                lc[indiceCampo++].Valor = this.DiasVigencia;
                lc[indiceCampo++].Valor = General.BDFechaActual;
                lc[indiceCampo++].Valor = this.LoginUsuario;
                lc[indiceCampo++].Valor = this.Clave;
                lc[indiceCampo++].Valor = this.Activo;
                lc[indiceCampo++].Valor = this.FechaCreacion;
                lc[indiceCampo++].Valor = -1;
                lc[indiceCampo++].Valor = -1;
                lc[indiceCampo++].Valor = this.MultiSesion;
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
            return GeneraCadenaGuardar(nombreTabla, id);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.descripcion))
                return "";
            else
                return this.Descripcion + " (" + this.loginUsuario + ")";
        }

        #region FUNCIONES ASIGNACION
        public string SelectAsignacionCombo()
        {
            return "select t.id, t.descripcion || ' (' || t.loginusuario || ')' descripcion, false as editable, false asignado from " + nombreTabla + " t where t.activo = true order by descripcion";
        }

        public string SelectAsignacionDetalle()
        {
            return "select distinct p.id, p.descripcion, true as editable, case when u.idusuario is null then false else true end asignado from perfiles p left join usuariosperfiles u on p.id = u.idperfil and u.idusuario = @codigo where p.activo = true order by p.descripcion";
        }
        #endregion FUNCIONES ASIGNACION
        #endregion FUNCIONES LOCALES

        public override int CompareTo(object obj)
        {
            if (obj is Usuario)
            {
                Usuario oVar = obj as Usuario;
                return String.Compare(this.ToString(), oVar.ToString(), true);
            }
            else if (obj is string)
            {
                return String.Compare(this.ToString(), obj as string);
            }
            else
            {
                return -1;
            }
        }
    }
}
