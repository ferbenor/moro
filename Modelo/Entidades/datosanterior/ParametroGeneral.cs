using System;
using System.Collections.Generic;
using Estructura;
namespace Entidades
{
    public class ParametroGeneral : Instrumental
    {
        #region VARIABLES
        private int id;
        private string nombre;
        private string valor;
        private const string nombreTabla = "parametrosgenerales";
        #endregion VARIABLES

        #region PROPIEDADES
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string ValorString { get { return this.valor; } set { this.valor = value; } }
        public bool ValorBoolean
        {
            get { 
                bool res = false; bool.TryParse(this.valor, out res);
                return res; 
            }
        }
        public short ValorInt16
        {
            get
            {
                short res = 0; short.TryParse(this.valor, out res);
                return res;
            }
        }
        public int ValorInt32
        {
            get
            {
                int res = 0; int.TryParse(this.valor, out res);
                return res;
            }
        }
        public decimal ValorDecimal
        {
            get
            {
                decimal res = 0; decimal.TryParse(this.valor, out res);
                return res;
            }
        }
        public ParametroGeneral Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ParametroGeneral() { }

        public ParametroGeneral(int Id)
        {
            this.id = Id;
        }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int32, 0, this.Id, true));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 30, this.Nombre));
            lc.Add(new CamposTabla("valor", false, System.Data.DbType.String, 50, this.ValorString));

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
            return base.ToString();
        }

        public void SetValor(object unValor)
        {
            switch (unValor.GetType().Name)
            {
                case "Boolean":
                    this.valor = unValor.ToString();
                    break;
                default:
                    this.valor = unValor.ToString();
                    break;
            }
            
        }

        //*#SETVALORES

        //*#LIMPIAR

        public override int CompareTo(object obj)
        {
            if (obj is ParametroGeneral)
            {
                ParametroGeneral oVar = obj as ParametroGeneral;
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
