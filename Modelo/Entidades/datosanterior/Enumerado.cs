using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace ModeloDB
{
    public class Enumerado : IComparable
    {
        #region VARIABLES
        private object id;
        private string texto;
        #endregion VARIABLES

        #region PROPIEDADES
        public object Id { get { return this.id; } }
        public short IdInt16 { get { return (short)this.id; } }
        public int IdInt32 { get { return (int)this.id; } }
        public string IdChr { get { return this.id.ToString(); } }
        public string Texto { get { return this.texto; } set { this.texto = value; } }
        public Enumerado Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Enumerado() { }

        public Enumerado(short unId) { this.id = unId; }

        public Enumerado(object unId, string unTexto)
        {
            this.id = unId;
            this.texto = unTexto;
        }

        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
 
        public override string ToString()
        {
            return this.texto;
        }

        public int CompareTo(object obj)
        {
            if (obj is Enumerado)
            {
                Enumerado oVar = obj as Enumerado;
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
