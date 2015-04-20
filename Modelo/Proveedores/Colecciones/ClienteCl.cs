using System.Collections;
using System.Collections.Generic;
using ModeloDB;

namespace Proveedores.Colecciones
{
    public class ClienteCl : CollectionBase
    {
        private List<cliente> listaClientes;

        public ClienteCl()
        {
            listaClientes = new List<cliente>();
            
        }

        public cliente this[int indice]
        {
            get { return ((cliente)listaClientes[indice]); }
            set { listaClientes[indice] = value; }
        }

        public bool AddRange(List<cliente> value)
        {
            try
            {
                listaClientes.AddRange(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        // Añadir
        public bool Add(cliente value)
        {
            try
            {
                listaClientes.Add(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public int IndexOf(cliente value)
        {
            return (listaClientes.IndexOf(value));
        }

        public void Insert(int index, cliente value)
        {
            listaClientes.Insert(index, value);
        }

        public void Remove(cliente value)
        {
            listaClientes.Remove(value);
        }

        public bool Contains(cliente value)
        {
            return (listaClientes.Contains(value));
        }

        // Esto es lo que me faltaba en la clase y por eso me atasqué:
        // Un método que devuelva TODA la lista de objetos.
        public List<cliente> ObtenerItems()
        {
            return listaClientes;
        }
    }
}
