using System.Collections;
using System.Collections.Generic;
using Entidades;
using System.Windows.Forms;

namespace Controladores
{
    public class ColeccionControl : CollectionBase
    {
        private List<Control> listaControles;

        public ColeccionControl()
        {
            listaControles = new List<Control>();

        }

        public Control this[int indice]
        {
            get { return ((Control)listaControles[indice]); }
            set { listaControles[indice] = value; }
        }

        public Control this[string key]
        {
            get
            {
                int i = listaControles.FindIndex(x => x.Name == key);
                if (i == -1)
                    throw new System.Exception("Control \'" + key + "\' no registrado");
                return ((Control)listaControles[i]);
            }
            set { listaControles[listaControles.FindIndex(x => x.Name == key)] = value; }
        }


        public bool AddRange(List<Control> value)
        {
            try
            {
                listaControles.AddRange(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        protected override void OnClear()
        {
            this.listaControles.Clear();
            base.OnClear();
        }

        // Añadir
        public bool Add(Control value)
        {
            try
            {
                listaControles.Add(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public int IndexOf(Control value)
        {
            return (listaControles.IndexOf(value));
        }

        public void Insert(int index, Control value)
        {
            listaControles.Insert(index, value);
        }

        public void Remove(Control value)
        {
            listaControles.Remove(value);
        }

        public bool Contains(Control value)
        {
            return (listaControles.Contains(value));
        }

        // Esto es lo que me faltaba en la clase y por eso me atasqué:
        // Un método que devuelva TODA la lista de objetos.
        public List<Control> ObtenerItems()
        {
            return listaControles;
        }
    }
}
