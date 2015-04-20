using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace Datos
{
    public abstract class AccesoDatos
    {
        #region Variables
        private static string globalConnectionString;
        private static string globalConnectionStringImagenes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Cadena de conexion para base de datos de imagenes
        /// </summary>
        public static string GlobalConnectionStringImagenes
        {
            get
            {
                if (globalConnectionString == null)
                    globalConnectionString = ConfigurationManager.ConnectionStrings["Imagenes"].ConnectionString;
                return globalConnectionStringImagenes;
            }
            set { globalConnectionStringImagenes = value; }
        }
        /// <summary>
        /// Cadena de conexion para base de datos principal
        /// </summary>
        public static string GlobalConnectionString
        {
            get
            {
                if (globalConnectionString == null)
                    globalConnectionString = ConfigurationManager.ConnectionStrings["Principal"].ConnectionString;
                return globalConnectionString;
            }
            set { globalConnectionString = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Ejecuta instruccion SQL de un objeto Command devolviendo el numero de registros afectados
        /// </summary>
        /// <param name="cmd">Objeto Command a ejecutar.</param>
        /// <returns>Retorna valor entero que determina el numero de registros afectados</returns>
        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Ejecuta instruccion SQL de un objeto Command devolviendo un DataReader
        /// </summary>
        /// <param name="cmd">Objeto Command a ejecutar.</param>
        /// <returns>Objeto IDataReader</returns>
        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return cmd.ExecuteReader(CommandBehavior.Default);
        }
        /// <summary>
        /// Ejecuta instruccion SQL de un objeto Command devolviendo un objeto
        /// </summary>
        /// <param name="cmd">Objeto Command a ejecutar.</param>
        /// <returns>Objeto</returns>
        protected Object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        #endregion

    }
}
