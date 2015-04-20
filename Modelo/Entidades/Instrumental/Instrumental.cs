using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Estructura;
using System.ComponentModel;
using System.Reflection;

namespace ModeloDB
{
    public class PropertyCambiadoEventArgs : PropertyChangedEventArgs
    {
        public object Value { get; set; }

        public PropertyCambiadoEventArgs(string nombrePropiedad, object valor)
            : base(nombrePropiedad)
        {
            this.Value = valor;
        }
    }

    public delegate void PropertyCambiadoEventHandler(object sender, PropertyCambiadoEventArgs e);

    public abstract class Instrumental1 : IMaestras
    {
        public event PropertyCambiadoEventHandler PropertyCambiado;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name, object value)
        {
            PropertyCambiadoEventHandler handler = PropertyCambiado;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyCambiadoEventArgs(name, value));
            }
        }

        bool _modificado = false;
        //protected int indiceCampo = 0;
        //StringBuilder cadena = new StringBuilder();
        //List<CamposTabla> listaParametros = new List<CamposTabla>();
        //List<CamposTabla> lc = new List<CamposTabla>();

        public bool Modificado { get { return _modificado; } set { _modificado = value; } }

        public virtual void IntegrarAsociados()
        {

        }
    }
}

namespace Entidades
{
    public abstract class Instrumental : IComparable, IMaestras
    {
        bool _modificado = false;
        protected int indiceCampo = 0;
        StringBuilder cadena = new StringBuilder();
        List<CamposTabla> listaParametros = new List<CamposTabla>();
        List<CamposTabla> lc = new List<CamposTabla>();

        public bool Modificado { get { return _modificado; } set { _modificado = value; } }

        protected List<CamposTabla> ListaCampos
        {
            get
            {
                //if (lc.Count == 0)
                GetCampos(this.lc);
                return lc;
            }
        }

        public List<CamposTabla> ListaParametros
        {
            get { return listaParametros; }
            set { listaParametros = value; }
        }


        /// <summary>
        /// Constructor basico de Plantilla
        /// </summary>
        protected Instrumental() { }


        #region Metodos Abstractos
        protected abstract List<CamposTabla> GetCampos(List<CamposTabla> lc);
        #endregion

        #region Metodos Virtuales
        public List<CamposTabla> ObtenerParametrosGuardar(string nombreTabla = null)
        {
            if (nombreTabla == null)
                listaParametros = ListaCampos.Where(x => x.SoloSelect == false).ToList();
            else
                listaParametros = ListaCampos.Where(x => x.SoloSelect == false && x.NombreTabla == nombreTabla).ToList();
            return listaParametros;
        }

        protected string GeneraCadenaSelect(string unaTabla, string condicion = null, bool nombreTabla = true)
        {
            int conteo = this.ListaCampos.Count;
            try
            {
                cadena.Clear();
                cadena.Append("select ");

                for (int i = 0; i < conteo; i++)
                {
                    if (nombreTabla)
                        cadena.Append((Object.Equals(lc[i].Valor, -1) || lc[i].Nombre.Contains("#") ? "" : unaTabla + ".") + lc[i].Nombre);
                    else
                        cadena.Append((lc[i].NombreTabla != null ? lc[i].NombreTabla + "." : "") + lc[i].Nombre);
                    cadena.Append(", ");

                }
                cadena.Remove(cadena.Length - 2, 2);
                cadena.Append(" from " + unaTabla);
                if (condicion != null)
                    cadena.Append(" " + condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return cadena.Replace("#", "").ToString();
        }

        protected string GeneraCadenaBorrar(string unaTabla)
        {
            try
            {
                listaParametros.Clear();
                cadena.Clear();
                List<CamposTabla> claves = ListaCampos.Where(x => x.Clave == true).ToList();
                listaParametros = claves;
                cadena.Append("delete from " + unaTabla.Trim() + " where ");
                for (int i = 0; i < claves.Count; i++)
                {
                    cadena.Append(/*unaTabla + "." + */claves[i].Nombre + " = @" + claves[i].Nombre);
                    cadena.Append(" and ");
                }
                cadena.Remove(cadena.Length - 5, 5);
            }
            catch (Exception)
            {

                throw;
            }
            return cadena.ToString();
        }

        protected string GeneraCadenaGuardar(string unaTabla, int unId, string condicionMax = null)
        {
            cadena.Clear();
            StringBuilder cadenaValues = new StringBuilder();
            //listaParametros = ListaCampos.Where(x => x.SoloSelect == false).ToList();
            ObtenerParametrosGuardar(unaTabla);
            int conteo = listaParametros.Count;
            try
            {
                if (unId == 0)
                {
                    string finCadena = null;
                    cadena.Append("insert into " + unaTabla.Trim() + " (");
                    cadenaValues.Append(") values (");

                    for (int i = 0; i < conteo; i++)
                    {
                        cadena.Append(listaParametros[i].Nombre);
                        if (listaParametros[i].Autonumerico)
                        {
                            cadenaValues.Append("(select ({%}(max(" + listaParametros[i].Nombre + "), 0)) + 1 from " + unaTabla);
                            if (condicionMax == null)
                            {
                                cadenaValues.Append(" )");
                                finCadena = "; select {%}(max(" + listaParametros[i].Nombre + "), 0) as valorActual from " + unaTabla + ";";
                            }
                            else
                            {
                                cadenaValues.Append(" " + condicionMax + ")");
                                finCadena = "; select {%}(max(" + listaParametros[i].Nombre + "), 0) as valorActual from " + unaTabla + " " + condicionMax + ";";
                            }
                        }
                        else
                        {
                            if (listaParametros[i].Nombre.Contains("#"))
                                cadenaValues.Append(listaParametros[i].Valor);
                            else
                                cadenaValues.Append("@" + listaParametros[i].Nombre);
                        }
                        if (i < conteo - 1)
                        {
                            cadena.Append(", ");
                            cadenaValues.Append(", ");
                        }
                        else
                            cadenaValues.Append(finCadena != null ? ")" + finCadena : ");");
                    }

                }
                else
                {
                    List<CamposTabla> claves = listaParametros.Where(x => x.Clave == true).ToList();
                    cadena.Append("update " + unaTabla.Trim() + " set ");
                    cadenaValues.Append(" where ");
                    //CAMPOS
                    for (int i = 0; i < conteo; i++)
                    {
                        if ((listaParametros[i].Clave == false || listaParametros[i].EsVersion == true) && listaParametros[i].NoUpdate == false)
                        {
                            if (listaParametros[i].Nombre.Contains("#"))
                                cadena.Append(listaParametros[i].Nombre + "=" + listaParametros[i].Valor);
                            else
                                cadena.Append(listaParametros[i].Nombre + (listaParametros[i].EsVersion ? " = " + listaParametros[i].Nombre + " + 1" : " = @" + listaParametros[i].Nombre));
                            cadena.Append(", ");
                        }
                    }
                    cadena.Remove(cadena.Length - 2, 2);
                    //CLAVES
                    for (int i = 0; i < claves.Count; i++)
                    {
                        cadenaValues.Append(/*unaTabla + "." + */claves[i].Nombre + " = @" + claves[i].Nombre);
                        cadenaValues.Append(" and ");
                    }
                    cadenaValues.Remove(cadenaValues.Length - 5, 5);

                    //REMOVER PARAMETROS FUERA DE UPDATE
                    List<CamposTabla> listaNoUpdate = listaParametros.Where(x => x.NoUpdate == true).ToList();
                    foreach (CamposTabla item in listaNoUpdate)
                    {
                        listaParametros.Remove(item);
                    }
                    listaNoUpdate = null;

                }

            }
            catch (Exception)
            {

                throw;
            }
            return cadena.Replace("#", "").ToString() + cadenaValues.ToString();
            //cadena.Clear();
            //cadenaValues.Clear();
        }
        #endregion Metodos Virtuales

        public virtual int CompareTo(object obj)
        {
            return -1;
        }
    }
}
