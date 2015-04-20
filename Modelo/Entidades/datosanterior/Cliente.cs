using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Cliente : EPersona
    {
        #region VARIABLES
        private string razonSocial;
        private DateTime fechaIngreso;
        private string telefono;
        private System.Drawing.Image foto;
        private byte[] imagenFoto;
        private Barrio barrio;
        private string celular;
        //private string correo;
        private EstadoCivil estadoCivil;
        private Persona conyugue;
        private Profesion profesion;
        private string informacionAdicional;
        public bool esNuevoCliente = true;
        //private bool llamadaSelect = false;
        private bool llamadaLocal = false;

        new public const string nombreTabla = "clientes";

        #endregion VARIABLES

        #region PROPIEDADES
        public string RazonSocial { get { return this.razonSocial; } set { this.razonSocial = value; } }
        public DateTime FechaIngreso { get { return this.fechaIngreso; } set { this.fechaIngreso = value; } }
        public string Telefono { get { return String.IsNullOrEmpty(this.telefono) ? string.Empty : " Fijo: " + this.telefono; } set { this.telefono = value; } }
        public System.Drawing.Image Foto { get { return this.foto; } set { this.foto = value; this.imagenFoto = General.Image2Bytes(this.foto); } }
        public byte[] ImagenFoto { get { return this.imagenFoto; } set { this.imagenFoto = value; this.foto = General.Bytes2Image(this.imagenFoto); } }
        public int IdBarrio { get; set; }
        public Barrio Barrio
        {
            get
            {
                if (this.barrio == null)
                    return General.barrioCero;
                else
                    return this.barrio;
            }
            set { this.barrio = value; if (value == null) { this.IdBarrio = 0; this.IdParroquiaDocumento = 0; } else { this.IdBarrio = value.Id; if (value.Parroquia != null) this.ParroquiaDocumento = value.Parroquia; } }
        }
        public string Celular { get { return String.IsNullOrEmpty(this.celular) ? string.Empty : " Movil: " + this.celular ;  } set { this.celular = value; } }
        //public string Correo { get { return this.correo; } set { this.correo = value; } }
        public short IdEstadoCivil { get; set; }
        public EstadoCivil EstadoCivil
        {
            get
            {
                if (this.estadoCivil == null)
                    return General.estadoCivilCero;
                else
                    return this.estadoCivil;
            }
            set { this.estadoCivil = value; if (value == null) this.IdEstadoCivil = 0; else this.IdEstadoCivil = value.Id; }
        }
        public int IdConyugue { get; set; }
        public Persona Conyugue
        {
            get
            {
                if (this.conyugue == null)
                    return General.personaVacio;
                else
                    return this.conyugue;
            }
            set { this.conyugue = value; if (value == null) this.IdConyugue = 0; else this.IdConyugue = value.Id; }
        }
        public short IdProfesion { get; set; }
        public Profesion Profesion
        {
            get
            {
                if (this.profesion == null)
                    return General.profesionCero;
                else
                    return this.profesion;
            }
            set { this.profesion = value; if (value == null) this.IdProfesion = 0; else this.IdProfesion = value.Id; }
        }
        public string InformacionAdicional { get { return this.informacionAdicional; } set { this.informacionAdicional = value; } }

        public Cliente Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Cliente() { }

        public Cliente(int Id, int Version, bool EsNuevoCliente) { this.id = Id; this.version = Version; this.esNuevoCliente = EsNuevoCliente; this.esNuevoPersona = false; }

        public Cliente(int Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            if (llamadaLocal)
            {
                //lc.Clear();
                try
                {
                    indiceCampo = lc.FindIndex(x => x.Nombre == "razonsocial");

                    lc[indiceCampo++].Valor = this.RazonSocial;
                    lc[indiceCampo++].Valor = this.Telefono;
                    lc[indiceCampo++].Valor = this.imagenFoto;
                    lc[indiceCampo++].Valor = this.IdBarrio;
                    lc[indiceCampo++].Valor = this.Celular;
                    //lc[indiceCampo++].Valor = this.Correo;
                    lc[indiceCampo++].Valor = this.IdEstadoCivil;
                    lc[indiceCampo++].Valor = this.IdConyugue;
                    lc[indiceCampo++].Valor = this.IdProfesion;
                    lc[indiceCampo++].Valor = this.InformacionAdicional;
                    lc[indiceCampo++].Valor = this.FechaIngreso;
                    lc[indiceCampo++].Valor = this.Id;
                }
                catch (Exception)
                {
                    base.GetCampos(lc);
                    lc.Add(new CamposTabla("razonsocial", false, System.Data.DbType.String, 100, this.RazonSocial));
                    lc.Add(new CamposTabla("telefono", false, System.Data.DbType.String, 13, this.Telefono));
                    lc.Add(new CamposTabla("imagenfoto", false, System.Data.DbType.Binary, 0, this.imagenFoto));
                    lc.Add(new CamposTabla("idbarrio", false, System.Data.DbType.Int32, 0, this.IdBarrio));
                    lc.Add(new CamposTabla("celular", false, System.Data.DbType.String, 13, this.Celular));
                    //lc.Add(new CamposTabla("correo", false, System.Data.DbType.String, 100, this.Correo));
                    lc.Add(new CamposTabla("idestadocivil", false, System.Data.DbType.Int16, 0, this.IdEstadoCivil));
                    lc.Add(new CamposTabla("idconyugue", false, System.Data.DbType.Int16, 0, this.IdConyugue));
                    lc.Add(new CamposTabla("idprofesion", false, System.Data.DbType.Int16, 0, this.IdProfesion));
                    lc.Add(new CamposTabla("informacionadicional", false, System.Data.DbType.String, 200, this.InformacionAdicional));
                    lc.Add(new CamposTabla("fechaingreso", false, System.Data.DbType.DateTime, 0, this.FechaIngreso));
                    lc.Add(new CamposTabla("idpersona", true, System.Data.DbType.Int32, 0, this.Id));
                    lc.Add(new CamposTabla("case when idpersona is null then true else false end as esNuevoCliente", true, System.Data.DbType.Int32, 0, this.esNuevoCliente) { SoloSelect = true });
                    lc.ForEach(x => { if (string.IsNullOrEmpty(x.NombreTabla) && !x.SoloSelect) x.NombreTabla = nombreTabla; });
                }
                return lc;
            }
            else
                return base.GetCampos(lc);
        }

        public override string CadenaSelect()
        {
            this.llamadaLocal = false;
            return GeneraCadenaSelect(nombreTabla);
        }

        public override string CadenaSelect(string condicion)
        {
            this.llamadaLocal = false;
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public override string CadenaBorrar()
        {
            this.llamadaLocal = false;
            return GeneraCadenaBorrar(nombreTabla);
        }

        public override string CadenaGuardar()
        {
            this.llamadaLocal = false;
            return base.CadenaGuardar();
        }

        //public string CadenaSelectCliente()
        //{
        //    this.llamadaLocal = true;
        //    return GeneraCadenaSelect(base.nombreTabla + " left join " + nombreTabla + " on " + base.nombreTabla + ".id = " + nombreTabla + ".idpersona", null, false);
        //}

        public string CadenaSelectCliente(string condicion = null)
        {
            this.llamadaLocal = true;
            return GeneraCadenaSelect(base.nombreTabla + " left join " + nombreTabla + " on " + base.nombreTabla + ".id = " + nombreTabla + ".idpersona ", condicion, false);
        }

        public string CadenaInactivarCliente()
        {
            this.llamadaLocal = true;
            this.ListaParametros.Clear();
            this.ListaParametros.Add(this.ListaCampos[this.ListaCampos.FindIndex(x => x.Nombre == "idpersona")]);
            this.ListaParametros.Add(this.ListaCampos[this.ListaCampos.FindIndex(x => x.Nombre == "idestadopersona")]);
            return "update " + base.nombreTabla + " set idestadopersona = @idestadopersona where id = @idpersona"; //GeneraCadenaBorrar(nombreTabla);
        }

        public string CadenaGuardarCliente()
        {
            this.llamadaLocal = true;
            return GeneraCadenaGuardar(nombreTabla, esNuevoCliente ? 0 : 1);
        }

        public override void Limpiar()
        {
            base.Limpiar();
            this.FechaIngreso = General.usuarioActivo.FechaSesion;
            this.razonSocial = null;
            this.telefono = null;
            this.foto = null;
            this.Barrio = null;
            this.celular = null;
            //this.correo = null;
            this.EstadoCivil = null;
            this.Conyugue = null;
            this.Profesion = null;
            this.informacionAdicional = null;
            this.esNuevoCliente = true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
