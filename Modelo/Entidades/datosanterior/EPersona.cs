using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public abstract class EPersona : Instrumental
    {
        #region VARIABLES
        protected int id;
        protected string apellido;
        protected string nombre;
        protected TipoPersona tipoPersona;
        protected TipoDocumento tipoDocumento;
        protected string identificacion;
        protected Genero genero;
        protected Parroquia parroquiaDocumento;
        protected EstadoPersona estadoPersona;
        protected DateTime fechaServidor;
        protected int version = 0;
        protected string referenciadireccion;
        protected string correo;

        public bool esNuevoPersona = true;
        protected string nombreTabla = "personas";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string NombreCompleto { get { if (this.id == -1) return General.itemCero; else return (this.apellido + " " + this.nombre).Trim(); } }
        public short IdTipoPersona { get; set; }
        public TipoPersona TipoPersona
        {
            get
            {
                if (this.tipoPersona == null)
                    this.tipoPersona = General.tipoPersonaCero;
                return this.tipoPersona;
            }
            set { this.tipoPersona = value; if (value == null) this.IdTipoPersona = 0; else this.IdTipoPersona = value.Id; }
        }

        public short IdTipoDocumento { get; set; }
        public TipoDocumento TipoDocumento
        {
            get
            {
                if (this.tipoDocumento == null)
                    this.tipoDocumento = General.tipoDocumentoCero;
                return this.tipoDocumento;
            }
            set { this.tipoDocumento = value; if (value == null) this.IdTipoDocumento = 0; else this.IdTipoDocumento = value.Id; }
        }

        public string Identificacion { get { return this.identificacion; } set { this.identificacion = value; } }
        public short IdGenero { get; set; }
        public Genero Genero
        {
            get
            {
                if (this.genero == null)
                    this.genero = General.generoCero;
                return this.genero;
            }
            set { this.genero = value; if (value == null) this.IdGenero = 0; else this.IdGenero = value.Id; }
        }

        public int IdParroquiaDocumento { get; set; }
        public Parroquia ParroquiaDocumento
        {
            get
            {
                if (this.parroquiaDocumento == null)
                    this.parroquiaDocumento = General.parroquiaCero;
                return this.parroquiaDocumento;
            }
            set { this.parroquiaDocumento = value; if (value == null) this.IdParroquiaDocumento = 0; else this.IdParroquiaDocumento = value.Id; }
        }

        public short IdEstadoPersona { get; set; }
        public EstadoPersona EstadoPersona
        {
            get
            {
                if (this.estadoPersona == null)
                    return General.estadoPersonaCero;
                else
                    return this.estadoPersona;
            }
            set { this.estadoPersona = value; if (value == null) this.IdEstadoPersona = 0; else this.IdEstadoPersona = value.Id; }
        }
        public DateTime FechaServidor { get { return this.fechaServidor; } }//set { this.fechaServidor = value;  } }
        public int Version { get { return version; } }
        public string ReferenciaDireccion { get { return this.referenciadireccion; } set { this.referenciadireccion = value; } }
        public string Correo { get { return this.correo; } set { this.correo = value; } }

        #endregion PROPIEDADES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            //lc.Clear();
            try
            {
                indiceCampo = 0;
                lc[indiceCampo++].Valor = this.id;
                lc[indiceCampo++].Valor = this.apellido;
                lc[indiceCampo++].Valor = this.nombre;
                lc[indiceCampo++].Valor = this.IdTipoPersona;
                lc[indiceCampo++].Valor = this.IdTipoDocumento;
                lc[indiceCampo++].Valor = this.identificacion;
                lc[indiceCampo++].Valor = this.IdGenero;
                lc[indiceCampo++].Valor = this.IdParroquiaDocumento;
                lc[indiceCampo++].Valor = this.IdEstadoPersona;
                lc[indiceCampo++].Valor = this.fechaServidor;
                lc[indiceCampo++].Valor = this.version;
                lc[indiceCampo++].Valor = this.referenciadireccion;
                lc[indiceCampo++].Valor = this.correo;
            }
            catch (Exception)
            {
                lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("apellido", false, System.Data.DbType.String, 50, this.Apellido) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 50, this.Nombre) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("idtipopersona", false, System.Data.DbType.Int16, 0, this.IdTipoPersona) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("idtipodocumento", false, System.Data.DbType.Int16, 0, this.IdTipoDocumento) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("identificacion", false, System.Data.DbType.String, 13, this.Identificacion) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("idgenero", false, System.Data.DbType.Int16, 0, this.IdGenero) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("idparroquiadocumento", false, System.Data.DbType.Int32, 0, this.IdParroquiaDocumento) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("idestadopersona", false, System.Data.DbType.Int16, 0, this.IdEstadoPersona) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("fechaservidor", false, System.Data.DbType.DateTime2, 0, this.FechaServidor, false, true) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("version", true, System.Data.DbType.Int32, 0, this.version) { EsVersion = true, NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("referenciadireccion", false, System.Data.DbType.String, 200, this.referenciadireccion) { NombreTabla = nombreTabla });
                lc.Add(new CamposTabla("correo", false, System.Data.DbType.String, 100, this.correo) { NombreTabla = nombreTabla});
                //throw;
            }
            /*            if (lc.Count == 0)
                        {
                            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("apellido", false, System.Data.DbType.String, 50, this.Apellido) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 50, this.Nombre) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("idtipopersona", false, System.Data.DbType.Int16, 0, this.IdTipoPersona) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("idtipodocumento", false, System.Data.DbType.Int16, 0, this.IdTipoDocumento) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("identificacion", false, System.Data.DbType.String, 13, this.Identificacion) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("idgenero", false, System.Data.DbType.Int16, 0, this.IdGenero) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("idparroquiadocumento", false, System.Data.DbType.Int16, 0, this.IdParroquiaDocumento) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("idestadopersona", false, System.Data.DbType.Int16, 0, this.IdEstadoPersona) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("fechaservidor", false, System.Data.DbType.DateTime2, 0, this.FechaServidor, false, true) { NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("version", true, System.Data.DbType.Int32, 0, this.version) { EsVersion = true, NombreTabla = nombreTabla });
                            lc.Add(new CamposTabla("referenciadireccion", false, System.Data.DbType.String, 200, this.referenciadireccion) { NombreTabla = nombreTabla });
                        }
                        else
                        {
                            indiceCampo = 0;
                            lc[indiceCampo++].Valor = this.id;
                            lc[indiceCampo++].Valor = this.apellido;
                            lc[indiceCampo++].Valor = this.nombre;
                            lc[indiceCampo++].Valor = this.IdTipoPersona;
                            lc[indiceCampo++].Valor = this.IdTipoDocumento;
                            lc[indiceCampo++].Valor = this.identificacion;
                            lc[indiceCampo++].Valor = this.IdGenero;
                            lc[indiceCampo++].Valor = this.IdParroquiaDocumento;
                            lc[indiceCampo++].Valor = this.IdEstadoPersona;
                            lc[indiceCampo++].Valor = this.fechaServidor;
                            lc[indiceCampo++].Valor = this.version;
                            lc[indiceCampo++].Valor = this.referenciadireccion;
                        }*/
            return lc;
        }

        public virtual string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public virtual string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public virtual string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public virtual string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, this.esNuevoPersona == true ? 0 : 1);
        }

        public void SetId(int unId)
        {
            this.id = unId;
        }

        public virtual void Limpiar()
        {
            this.id = 0;
            this.apellido = null;
            this.nombre = null;
            this.TipoPersona = null;
            this.TipoDocumento = null;
            this.identificacion = null;
            this.Genero = null;
            this.ParroquiaDocumento = null;
            this.referenciadireccion = null;
            this.correo = null;
            this.IdEstadoPersona = 1;
            this.EstadoPersona = null;
            this.version = 0;
            this.esNuevoPersona = true;
        }


        public override string ToString()
        {
            return this.NombreCompleto;
        }

        public override int CompareTo(object obj)
        {
            if (obj is EPersona)
            {
                EPersona oVar = obj as EPersona;
                return String.Compare(this.NombreCompleto, oVar.NombreCompleto, true);
            }
            else if (obj is string)
            {
                return String.Compare(this.NombreCompleto, obj as string);
            }
            else
            {
                return -1;
            }
        }
        #endregion FUNCIONES LOCALES
    }
}