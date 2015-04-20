using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Mapping;
using LinqToDB;
using LinqToDB.Data;
using System.ComponentModel;
using LinqToDB.SchemaProvider;
using System.Globalization;

namespace ModeloDB
{
    public partial class cliente
    {
        public int id { get { return this.fkpersona.id; } }
        public string nombre { get { return this.fkpersona.nombre; } set { this.fkpersona.nombre = value; } }
        public string apellido { get { return this.fkpersona.apellido; } set { this.fkpersona.apellido = value; } }
        public string nombrecompleto { get { return this.apellido + " " + this.nombre + (string.IsNullOrEmpty(this.razonsocial) ? string.Empty : " (" + this.razonsocial + ")"); } }
        public string identificacion { get { return this.fkpersona.identificacion; } set { this.fkpersona.identificacion = value; } }
        public string referenciadireccion { get { return this.fkpersona.referenciadireccion; } set { this.fkpersona.referenciadireccion = value; } }
        public string correo { get { return this.fkpersona.correo; } set { this.fkpersona.correo = value; } }
        public genero genero { get { return this.fkpersona.fkgenero; } set { this.fkpersona.fkgenero = value; if (value != null) this.fkpersona.idgenero = value.id; } }
        public tipodocumento tipodocumento { get { return this.fkpersona.fktiposdocumento; } set { this.fkpersona.fktiposdocumento = value; if (value != null) this.fkpersona.idtipodocumento = value.id; } }
        public tipopersona tipopersona { get { return this.fkpersona.fktipospersona; } set { this.fkpersona.fktipospersona = value; if (value != null) this.fkpersona.idtipopersona = value.id; } }
        public estadopersona estadopersona { get { return this.fkpersona.fkestadospersona; } set { this.fkpersona.fkestadospersona = value; } }
        public string barrio { get { return this.fkbarrio.nombrecompleto; } }
        private System.Drawing.Image unaFoto;
        public System.Drawing.Image foto
        {
            get { if (unaFoto == null) this.unaFoto = Entidades.General.Bytes2Image(this.imagenfoto); return this.unaFoto; }
            set { this.unaFoto = value; this.imagenfoto = Entidades.General.Image2Bytes(value); }
        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombrecompleto;
        }

        #endregion
    }
}
