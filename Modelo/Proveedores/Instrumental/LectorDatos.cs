using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Datos;
using Estructura;

namespace Proveedores
{
    public class LectorDatos : CollectionBase, IDisposable
    {
        #region VARIABLES
        private static LectorDatos instancia = null;
        private bool esConexionInterna = false;
        private object cnn;
        private IDataReader lector;
        #endregion VARIABLES

        #region PROPIEDADES
        public static LectorDatos Instancia { get { if (instancia == null) instancia = new LectorDatos(); return instancia; } set { instancia = value; } }

        public IDataReader Lector
        {
            get { return lector; }
            set { lector = value; }
        }

        public object Conexion
        {
            get { return cnn; }
            set { this.cnn = value; this.esConexionInterna = value == null ? false : true; }
        }

        public bool EstaCerrado { get { if (lector == null) return true; else return this.lector.IsClosed; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public LectorDatos()
        { }
        #endregion CONSTRUCTORES

        #region METODOS DE INSTANCIA
        public void Abrir(string cadenaSelect, List<CamposTabla> lp)
        {
            try
            {
                if (Entidades.General.miConexion != null)
                {
                    cnn = Entidades.General.miConexion;
                    if (this.lector != null)
                        if (!this.lector.IsClosed)
                            this.lector.Close();
                    this.esConexionInterna = false;
                }
                if (this.cnn == null)
                {
                    cnn = ProveedorAcceso.DAO.CreaConexion();
                    this.esConexionInterna = true;
                }
                lector = ProveedorAcceso.DAO.EjecutarReader(cadenaSelect, lp, cnn);
            }
            catch (Exception)
            {
                if (cnn != null && this.esConexionInterna == true)
                    ProveedorAcceso.DAO.Close(cnn);
                esConexionInterna = false;
                throw;
                //General.Mensaje(ex.Message);
            }
        }
        public void Abrir(string cadenaSelect, List<CamposTabla> lp, object unaConexion)
        {
            lector = ProveedorAcceso.DAO.EjecutarReader(cadenaSelect, lp, unaConexion);
        }
        public void Abrir(string cadenaSelect, List<CamposTabla> lp, object unaConexion, object unaTransaccion)
        {
            lector = ProveedorAcceso.DAO.EjecutarReader(cadenaSelect, lp, unaConexion, unaTransaccion);
        }

        public void Cerrar()
        {
            lector.Close();
            ProveedorAcceso.DAO.Close(cnn);
            Entidades.General.miConexion = null;
        }
        public bool Read()
        {
            return lector.Read();
        }
        public bool esNulo(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return true;
            else
                return false;
        }

        public object this[int numeroColumna]
        {
            get { return (this.lector[numeroColumna]); }
        }

        public object this[string nombreColumna]
        {
            get { return (this.lector[nombreColumna]); }
        }

        public string GetName(int numeroColumna)
        {
            return this.lector.GetName(numeroColumna);
        }

        public int FieldCount()
        {
            return this.lector.FieldCount;
        }

        public dynamic GetValorDinamico(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return null;
            else
                return this.lector.GetValue(numeroColumna);
        }

        public object GetValor(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return null;
            else
                return this.lector.GetValue(numeroColumna);
        }
        #region GETDECIMAL
        /// <summary>
        /// Obtiene el valor numérico de posicion fija del campo especificado.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor decimal.</returns>
        public decimal GetDecimal(int numeroColumna)
        {
            return this.lector.GetDecimal(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor numérico de posicion fija del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor decimal.</returns>
        public decimal GetDecimalIsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return 0.0M;
            else
                return this.lector.GetDecimal(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor numérico de posicion fija del campo especificado.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor decimal.</returns>
        public decimal GetDecimal(string nombreColumna)
        {
            return this.lector.GetDecimal(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor numérico de posicion fija del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor decimal.</returns>
        public decimal GetDecimalIsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return 0.0M;
            else
                return this.lector.GetDecimal(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETDECIMAL

        #region GETSTRING
        /// <summary>
        /// Obtiene el valor de cadena del campos especificado,
        /// en caso de ser DBNull devuelve el valor 'null'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns> Valor string.</returns>
        public string GetString(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return null;
            else
                return this.lector.GetString(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de cadena del campos especificado, 
        /// en caso de ser DBNull devuelve el valor 'Empty'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns> Valor string.</returns>
        public string GetStringIsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return "";
            else
                return this.lector.GetString(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de cadena del campos especificado, 
        /// en caso de ser DBNull devuelve el valor 'null'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns> Valor string.</returns>
        public string GetString(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return null;
            else
                return this.lector.GetString(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor de cadena del campos especificado, 
        /// en caso de ser DBNull devuelve el valor 'Empty'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns> Valor string.</returns>
        public string GetStringIsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return "";
            else
                return this.lector.GetString(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETSTRING

        #region GETCHAR
        /// <summary>
        /// Obtiene un valor char de la posicion [0] del campo especificado.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor char.</returns>
        public char GetChar(int numeroColumna)
        {
            return this.lector.GetString(numeroColumna)[0];
        }
        /// <summary>
        /// Obtiene un valor char de la posicion [0] del campo especificado.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor char.</returns>
        public char GetChar(string nombreColumna)
        {
            return this.lector.GetString(this.lector.GetOrdinal(nombreColumna))[0];
        }
        #endregion GETCHAR

        #region GETDATETIME
        /// <summary>
        /// Obtiene el valor de los datos de fecha y hora del campo especificado, 
        /// en caso de ser DBNull devuelve el dato de fecha '1900-01-01'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor DateTime.</returns>
        public DateTime GetDateTimeIsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return new DateTime(1900, 1, 1);
            else
                return this.lector.GetDateTime(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de los datos de fecha y hora del campo especificado, 
        /// en caso de ser DBNull devuelve el dato de fecha '1900-01-01'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor DateTime.</returns>
        public DateTime GetDateTime(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return new DateTime(1900, 1, 1);
            else
                return this.lector.GetDateTime(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de los datos de fecha y hora del campo especificado, 
        /// en caso de ser DBNull devuelve el dato de fecha '1900-01-01'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor DateTime.</returns>
        public DateTime GetDateTimeIsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return new DateTime(1900, 1, 1);
            else
                return this.lector.GetDateTime(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor de los datos de fecha y hora del campo especificado, 
        /// en caso de ser DBNull devuelve el dato de fecha '1900-01-01'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor DateTime.</returns>
        public DateTime GetDateTime(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return new DateTime(1900, 1, 1);
            else
                return this.lector.GetDateTime(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETDATETIME

        #region GETINT16
        /// <summary>
        /// Obtiene el valor entero de 16 bits con signo del campo especificado.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor short (Int16).</returns>
        public short GetInt16(int numeroColumna)
        {
            return this.lector.GetInt16(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor entero de 16 bits con signo del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor short (Int16).</returns>
        public short GetInt16IsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return 0;
            else
                return this.lector.GetInt16(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor entero de 16 bits con signo del campo especificado.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor short (Int16).</returns>
        public short GetInt16(string nombreColumna)
        {
            return this.lector.GetInt16(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor entero de 16 bits con signo del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor short (Int16).</returns>
        public short GetInt16IsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return 0;
            else
                return this.lector.GetInt16(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETINT16

        #region GETINT32
        /// <summary>
        /// Obtiene el valor entero de 32 bits con signo del campo especificado.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor int (Int32).</returns>
        public int GetInt32(int numeroColumna)
        {
            return this.lector.GetInt32(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor entero de 32 bits con signo del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor int (Int32).</returns>
        public int GetInt32IsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return 0;
            else
                return this.lector.GetInt32(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor entero de 32 bits con signo del campo especificado.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor int (Int32).</returns>
        public int GetInt32(string nombreColumna)
        {
            return this.lector.GetInt32(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor entero de 32 bits con signo del campo especificado, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor int (Int32).</returns>
        public int GetInt32IsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return 0;
            else
                return this.lector.GetInt32(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETINT32

        #region GETBYTE
        /// <summary>
        /// Obtiene el valor entero de 8 bits sin signo de la columna especificada, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor byte.</returns>
        public byte GetByte(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return 0;
            else
                return this.lector.GetByte(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor entero de 8 bits sin signo de la columna especificada, 
        /// en caso de ser DBNull devuelve el valor '0'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor byte.</returns>
        public byte GetByte(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return 0;
            else
                return this.lector.GetByte(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETBYTE

        #region GETBOOLEAN
        /// <summary>
        /// Obtiene el valor de la columna especificada como tipo Boolean.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor bool.</returns>
        public bool GetBoolean(int numeroColumna)
        {
            return this.lector.GetBoolean(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de la columna especificada como tipo Boolean, 
        /// en caso de ser DBNull devuelve el valor 'false'.
        /// </summary>
        /// <param name="numeroColumna">Indice de base cero del campo a obtener.</param>
        /// <returns>Valor bool.</returns>
        public bool GetBooleanIsNull(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return false;
            else
                return this.lector.GetBoolean(numeroColumna);
        }
        /// <summary>
        /// Obtiene el valor de la columna especificada como tipo Boolean.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor bool.</returns>
        public bool GetBoolean(string nombreColumna)
        {
            return this.lector.GetBoolean(this.lector.GetOrdinal(nombreColumna));
        }
        /// <summary>
        /// Obtiene el valor de la columna especificada como tipo Boolean, 
        /// en caso de ser DBNull devuelve el valor 'false'.
        /// </summary>
        /// <param name="nombreColumna">Nombre del campo a obtener.</param>
        /// <returns>Valor bool.</returns>
        public bool GetBooleanIsNull(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return false;
            else
                return this.lector.GetBoolean(this.lector.GetOrdinal(nombreColumna));
        }
        #endregion GETBOOLEAN

        #region GETCAMPOOBJECT
        public object GetCampoObject(int numeroColumna)
        {
            return this.lector[numeroColumna];
        }
        public object GetCampoObject(string nombreColumna)
        {
            return this.lector[this.lector.GetOrdinal(nombreColumna)];
        }
        #endregion GETCAMPOOBJECT

        #region GETIMAGEN
        public Image GetImagen(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return null;
            byte[] MyData = new byte[0];
            MyData = (byte[])(this.lector.GetValue(numeroColumna));
            MemoryStream stream = new MemoryStream(MyData);
            return Image.FromStream(stream);
        }
        public Image GetImagen(string nombreColumna)
        {
            if (this.lector.IsDBNull(this.lector.GetOrdinal(nombreColumna)))
                return null;
            byte[] MyData = new byte[0];
            MyData = (byte[])(this.lector.GetValue(this.lector.GetOrdinal(nombreColumna)));
            MemoryStream stream = new MemoryStream(MyData);
            return Image.FromStream(stream);
        }
        #endregion GETIMAGEN

        #region GETBYTEARRAY
        public Byte[] GetByteArray(int numeroColumna)
        {
            if (this.lector.IsDBNull(numeroColumna))
                return null;
            byte[] MyData = new byte[0];
            MyData = (byte[])(this.lector.GetValue(numeroColumna));
            return MyData;
        }
        #endregion GETBYTEARRAY
        #endregion METODOS DE INSTANCIA

        public void Dispose()
        {
            if (cnn != null)
                ProveedorAcceso.DAO.Close(cnn);
            if (this.lector != null)
                this.lector.Dispose();

            this.cnn = null; this.lector = null;
        }
    }
}
