using System.Collections.Generic;

namespace ModeloDB
{
    public class Mes 
    {
        #region VARIABLES
        private short id;
        private string nombre;
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public Mes Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Mes() { }

        public Mes(short Id, string Nombre)
        {
            this.id = Id;
            this.nombre = Nombre;
        }

        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        //protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        //{
        //    return null;
        //}

        public List<Mes> ListaMeses()
        {
            List<Mes> lista = new List<Mes>() { 
                new Mes(1, "ENERO"), new Mes(2, "FEBRERO"), new Mes(3, "MARZO"),
                new Mes(4, "ABRIL"), new Mes(5, "MAYO"), new Mes(6, "JUNIO"),
                new Mes(7, "JULIO"), new Mes(8, "AGOSTO"), new Mes(9, "SEPTIEMBRE"),
                new Mes(10, "OCTUBRE"), new Mes(11, "NOVIEMBRE"), new Mes(12, "DICIEMBRE")
            };
            return lista;
        }

        public override string ToString()
        {
            return this.nombre;
        }
        #endregion FUNCIONES LOCALES
    }
}
