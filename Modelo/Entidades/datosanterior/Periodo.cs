using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace ModeloDB
{
    public class Periodo : Instrumental1
    {
        #region VARIABLES
        private short anio;
        private Mes mes;
        private bool cerrado;
        private const string nombreTabla = "periodos";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get; set; }
        public short Anio { get { return this.anio; } set { this.anio = value; } }
        public short IdMes { get; set; }
        public Mes Mes
        {
            get
            {
                if (this.mes == null)
                    return General.mesCero;
                else
                    return this.mes;
            }
            set
            {
                this.mes = value;
                if (value == null) this.IdMes = 0;
                else this.IdMes = value.Id;

            }
        }
        public bool Cerrado { get { return this.cerrado; } set { this.cerrado = value;  } }
        public Periodo Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Periodo() { }

        public Periodo(short Id) { this.anio = Id; this.Id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        //protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        //{
        //    lc.Clear();
        //    lc.Add(new CamposTabla("anio", true, System.Data.DbType.Int16, 0, this.Anio));
        //    lc.Add(new CamposTabla("mes", true, System.Data.DbType.Int16, 0, this.Mes.Id));
        //    lc.Add(new CamposTabla("cerrado", false, System.Data.DbType.Boolean, 0, this.cerrado));
        //    return lc;
        //}

        public override string ToString()
        {
            return this.anio.ToString() + "-" + string.Format("{0:00}", this.mes) + " (" + this.cerrado.ToString() + ")";
        }
        #endregion FUNCIONES LOCALES
    }
}
