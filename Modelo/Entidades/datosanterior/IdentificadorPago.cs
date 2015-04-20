using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class IdentificadorPago : Instrumental
    {
        #region VARIABLES
        private int id;
        private List<ConvenioPago> convenioPago;
        private const string nombreTabla = "identificadorpagos";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public List<ConvenioPago> ConvenioPago { get { if (convenioPago == null) { this.convenioPago = new List<ConvenioPago>(); return this.convenioPago; } else return this.convenioPago; } set { this.convenioPago = value; } }
        public IdentificadorPago Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region Constructores
        public IdentificadorPago() { }

        public IdentificadorPago(int Id)
        {
            this.id = Id;
        }
        #endregion Constructores

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.Id, true));

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
            return GeneraCadenaGuardar(nombreTabla, this.id);
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }

        public override int CompareTo(object obj)
        {
            if (obj is IdentificadorPago)
            {
                IdentificadorPago oVar = obj as IdentificadorPago;
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
        #endregion FUNCIONES LOCALES
    }
}
