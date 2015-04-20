using System.Collections;
using System.Collections.Generic;
using ModeloDB;
using System.Windows.Forms;

namespace Proveedores
{
    public class ColeccionParametros : CollectionBase
    {
        private List<parametrogeneral> listaParametros;

        public ColeccionParametros(List<parametrogeneral> unaListaParametrosGenerales)
        {
            listaParametros = unaListaParametrosGenerales;
        }

        public parametrogeneral this[int indice]
        {
            get { return ((parametrogeneral)listaParametros[indice]); }
            set { listaParametros[indice] = value; }
        }

        public parametrogeneral this[string Parametro]
        {
            get
            {
                int c = 0; int i = 0;
                int.TryParse(Parametro, out c);
                try
                {
                    if (c == 0)
                    {
                        i = listaParametros.FindIndex(x => x.nombre == Parametro);
                        if (i == -1)
                            throw new System.Exception("Parametro \'" + Parametro + "\' no definido");
                    }
                    else
                    {
                        i = listaParametros.FindIndex(x => x.id == c);
                        if (i == -1)
                            throw new System.Exception("Parametro con Id \'" + Parametro + "\' no definido");
                    }

                    return ((parametrogeneral)listaParametros[i]);
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
            set
            {
                int c = 0; int i = 0;
                int.TryParse(Parametro, out c);
                try
                {
                    if (c == 0)
                    {
                        i = listaParametros.FindIndex(x => x.nombre == Parametro);
                        if (i == -1)
                            throw new System.Exception("Parametro \'" + Parametro + "\' no definido");
                    }
                    else
                    {
                        i = listaParametros.FindIndex(x => x.id == c);
                        if (i == -1)
                            throw new System.Exception("Parametro con Id \'" + Parametro + "\' no definido");
                    }

                    listaParametros[i] = value;
                }
                catch (System.Exception)
                {
                    throw;
                }
                
            }
        }


        public bool AddRange(List<parametrogeneral> value)
        {
            try
            {
                listaParametros.AddRange(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        protected override void OnClear()
        {
            this.listaParametros.Clear();
            base.OnClear();
        }

        // Añadir
        public bool Add(parametrogeneral value)
        {
            try
            {
                listaParametros.Add(value);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public int IndexOf(parametrogeneral value)
        {
            return (listaParametros.IndexOf(value));
        }

        public void Insert(int index, parametrogeneral value)
        {
            listaParametros.Insert(index, value);
        }

        public void Remove(parametrogeneral value)
        {
            listaParametros.Remove(value);
        }

        public bool Contains(parametrogeneral value)
        {
            return (listaParametros.Contains(value));
        }

        // Esto es lo que me faltaba en la clase y por eso me atasqué:
        // Un método que devuelva TODA la lista de objetos.
        public List<parametrogeneral> ObtenerItems()
        {
            return listaParametros;
        }

    }
}
