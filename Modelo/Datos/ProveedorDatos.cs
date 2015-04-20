using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Estructura;

namespace Datos
{
    public abstract class ProveedorDatos:AccesoDatos
    {
        private static ObjectHandle objeto;
        private static ProveedorDatos instancia = null;
        public static ProveedorDatos Instancia
        {
            get {
                if (instancia ==  null)
                {
                    objeto = Activator.CreateInstance(
                        ConfigurationManager.AppSettings["Libreria"],
                        ConfigurationManager.AppSettings["Clase"]
                        );
                }

                instancia = (ProveedorDatos)objeto.Unwrap();

                return ProveedorDatos.instancia;
            }
            set { instancia = value; }
        }
        #region Constructores
        public ProveedorDatos() { }
        #endregion

        #region Funciones Ejecutar, y creacion de objetos de transaccion
        public abstract int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp);
        public abstract int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion);
        public abstract int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion);

        //COMANDOS PREPARADOS
        public abstract void PreparaCMD(string cadenaSQL, List<CamposTabla> lp);
        public abstract void PreparaCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion);
        public abstract void PreparaCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion);
        public abstract int EjecutarCmdPreparado(List<CamposTabla> unRegistro);
        public abstract void BorrarCmdPreparado();

        public abstract IDataReader EjecutarReader(string cadenaSQL, List<CamposTabla> lp, object unaConexion);
        public abstract IDataReader EjecutarReader(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion);

        public abstract object CreaConexion();
        public abstract object CreaConexionClon();
        public abstract object CreaConexion(string unaCadenaConexion);
        public abstract object CreaTransaccion(object unaConexion);

        public abstract void Commit(object unaTransaccion);
        public abstract void RollBack(object unaTransaccion);
        public abstract void Close(object unaConexion);
        #endregion

        #region Generacion de cadenas SQL
        protected virtual string CadenaSelect(string camposSelect)
        {
            StringBuilder cadena = new StringBuilder();


            return cadena.ToString();
        }
        
        #endregion
        
        #region Listas de Objetos (GetObjetos)
        //public abstract object[] GetDatos();
        
        /*protected virtual MovieEntity GetMovieFromReader(IDataReader reader)
        {
            MovieEntity entity = null;
            try
            {
                entity = new MovieEntity();
                entity.IdMovie = (int)(reader["Id"]);
                entity.Name = reader["nombre"] == System.DBNull.Value ? null : (string)reader["nombre"];
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Movie data to object", ex);
            }
        }*/
        #endregion
        
    }
}
