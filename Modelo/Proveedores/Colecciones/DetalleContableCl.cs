using System.Collections;
using System.Collections.Generic;
using ModeloDB;

namespace Proveedores.Colecciones
{
    public class DetalleContableCl : CollectionBase
    {
        private List<detallecontable> listaContables;

        public DetalleContableCl()
        {
            listaContables = new List<detallecontable>();
            
        }

        public detallecontable this[int indice]
        {
            get { return ((detallecontable)listaContables[indice]); }
            set { listaContables[indice] = value; }
        }

        public bool AddRange(List<detallecontable> value)
        {
            try
            {
                listaContables.AddRange(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool AddRangeLista(List<contable> value)
        {
            try
            {
                foreach (contable item in value)
                {
                    listaContables.AddRange(item.fkdetallescontables);
                }
                
                return true;
            }
            catch
            {

                return false;
            }
        }

        // Añadir
        public bool Add(detallecontable value)
        {
            try
            {
                listaContables.Add(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public int IndexOf(detallecontable value)
        {
            return (listaContables.IndexOf(value));
        }

        public void Insert(int index, detallecontable value)
        {
            listaContables.Insert(index, value);
        }

        public void Remove(detallecontable value)
        {
            listaContables.Remove(value);
        }

        public bool Contains(detallecontable value)
        {
            return (listaContables.Contains(value));
        }

        // Esto es lo que me faltaba en la clase y por eso me atasqué:
        // Un método que devuelva TODA la lista de objetos.
        public List<detallecontable> ObtenerItems()
        {
            return listaContables;
        }
    }
}
