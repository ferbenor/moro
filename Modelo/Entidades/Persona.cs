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

    public partial class persona:IDisposable
    {
        public string NombreCompleto { get { return this.apellido + " " + this.nombre; } }
        public estadopersona estadopersona { get { return this.fkestadospersona; } }

        public persona()
        {
            this.PropertyCambiado += persona_PropertyCambiado;
            this.fkparroquia = General.parroquiaCero;
            this.fktiposdocumento = General.tipoDocumentoCero;
            this.fktipospersona = General.tipoPersonaCero;
            this.fkgenero = General.generoCero;
        }

        ~persona()
        {
            this.Dispose();
        }

        void persona_PropertyCambiado(object sender, PropertyCambiadoEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "fktipospersona":
                    if (e.Value == null) this.idtipopersona = 0; else this.idtipopersona = ((tipopersona)e.Value).id;
                    break;
                case "fktiposdocumento":
                    if (e.Value == null) this.idtipodocumento = 0; else this.idtipodocumento = ((tipodocumento)e.Value).id;
                    break;
                case "fkparroquia":
                    if (e.Value == null) this.idparroquiadocumento = 0; else this.idparroquiadocumento = ((parroquia)e.Value).id;
                    break;
                case "fkgenero":
                    if (e.Value == null) this.idgenero = 0; else this.idgenero = ((genero)e.Value).id;
                    break;
                default:
                    break;
            }
        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.NombreCompleto.Trim();
        }

        public void Dispose()
        {
            this.PropertyCambiado -= persona_PropertyCambiado;
        }

        #endregion
    }

}
