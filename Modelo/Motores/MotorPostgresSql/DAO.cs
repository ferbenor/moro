using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using Datos;
using Estructura;
using System.Data;

namespace MotorPostgreSql
{
    class DAO : Datos.ProveedorDatos
    {
        #region PROPIEDADES
        //string mensaje;
        private NpgsqlConnection conexionLocal;
        bool exeAutoNum = false;
        NpgsqlCommand comandoPreparado;

        public NpgsqlConnection Conexion
        {
            get
            {
                if (conexionLocal == null)
                {
                    conexionLocal = new NpgsqlConnection(GlobalConnectionString);
                    if (conexionLocal == null)
                        throw new Exception("Falla de conexion a la base de datos");
                }
                return conexionLocal;
            }

        }
        #endregion PROPIEDADES

        #region FUNCIONES PARA EJECUTAR

        public void PreparaComando(string cadenaSQL, List<CamposTabla> lp, object unaConexion = null, object unaTransaccion = null)
        {
            //OBJETO PARA MANIPULACION DE CADENA SQL
            StringBuilder sqlNueva = new StringBuilder(cadenaSQL);

            //VERIFICACION DE CAMPOS DEFINIDOS COMO AUTONUMERICOS
            if (lp.Count(x => x.Autonumerico == true) == 1)
                exeAutoNum = true;
            else
                exeAutoNum = false;

            //DETERMINAMOS NOMBRE DE TABLA
            /*if (cadenaSQL.Contains("insert into"))
            {
                mensaje = "agregando";
            }
            if (cadenaSQL.Contains("update "))
            {
                mensaje = "actualizando"; exeAutoNum = false;
            }
            if (cadenaSQL.Contains("delete from"))
            {
                mensaje = "eliminando"; exeAutoNum = false;
            }*/

            //CREAMOS OBJETO COMANDO
            comandoPreparado = new NpgsqlCommand();
            comandoPreparado.Parameters.Clear();
            comandoPreparado.CommandType = System.Data.CommandType.Text;

            //SI ES EJECUCION DE AUTONUMERICO ESTABLECE LA DEVOLUCION DEL VALOR DE LA SECUENCIA
            if (exeAutoNum)
                sqlNueva.Replace("{%}", "coalesce");

            //CREACION DE PARAMETROS EN EL COMANDO Y DESCARTE DE CAMPOS AUTONUMERICOS
            foreach (CamposTabla item in lp)
            {
                if (item.Autonumerico == false)
                {
                    NpgsqlParameter parametro = new NpgsqlParameter();
                    parametro.ParameterName = "@" + item.Nombre;
                    if (item.TipoEstablecido)
                    {
                        parametro.DbType = item.Tipo;
                        parametro.Size = item.Tamaño;
                    }
                    parametro.Direction = item.Direccion;
                    comandoPreparado.Parameters.Add(parametro);
                }
            }

            //command.CommandText = sqlNueva.Replace("@", ":").ToString();
            comandoPreparado.CommandText = sqlNueva.ToString();
            //ASIGNACION DE CONEXION Y TRANSACCION
            if (unaConexion == null)
                comandoPreparado.Connection = this.Conexion;
            else
                comandoPreparado.Connection = (NpgsqlConnection)unaConexion;

            if (unaConexion != null && unaTransaccion != null)
                comandoPreparado.Transaction = (NpgsqlTransaction)unaTransaccion;
            comandoPreparado.Prepare();
        }

        public override int EjecutarCmdPreparado(List<CamposTabla> unRegistro)
        {
            int resultado = 0;
            try
            {
                foreach (CamposTabla item in unRegistro)
                {
                    if (this.comandoPreparado.Parameters.Count > 0)
                        if (this.comandoPreparado.Parameters.Contains("@" + item.Nombre))
                            this.comandoPreparado.Parameters[item.Nombre].Value = item.Valor;
                }
                //EJECUCION DE COMANDO 
                if (exeAutoNum)
                {
                    //CAPTURAMOS VALOR AUTONUMERICO DE TIPO SEQUENCE CUANDO EXEAUTONUM == TRUE
                    NpgsqlDataReader rd = (NpgsqlDataReader)ExecuteReader(this.comandoPreparado);
                    rd.Read();
                    resultado = Convert.ToInt32(rd["valorActual"]);
                    rd.Close();
                    rd.Dispose();
                    rd = null;
                }
                else
                {
                    //DEVOLVEMOS EL NUMERO DE REGISTROS AFECTADOS CUANDO EXEAUTONUM == FALSE
                    resultado = ExecuteNonQuery(this.comandoPreparado);
                }
            }
            catch (NpgsqlException)
            {
                //throw new Exception("Error " + mensaje + " Registro \nDetalle: ", ex);
                throw;
            }
            catch (Exception)
            {
                //throw new Exception("Error " + mensaje + " Registro \nDetalle: ", ex);
                throw;
            }
            //DEVOLUCION DE RESULTADO
            return resultado;
        }

        public override void BorrarCmdPreparado()
        {
            exeAutoNum = false;
            if (comandoPreparado != null)
                comandoPreparado.Dispose();
            comandoPreparado = null;
        }

        private int EjecutarSQLAutonumerico(string cadenaSQL, List<CamposTabla> lp, object unaConexion = null, object unaTransaccion = null)
        {
            bool exeAutoNumerico = false;
            //OBJETO PARA MANIPULACION DE CADENA SQL
            StringBuilder sqlNueva = new StringBuilder(cadenaSQL);

            //VERIFICACION DE CAMPOS DEFINIDOS COMO AUTONUMERICOS
            if (lp.Count(x => x.Autonumerico == true) == 1)
            {
                exeAutoNumerico = true;
            }
            else
                exeAutoNumerico = false;

            //DETERMINAMOS NOMBRE DE TABLA
            /*if (cadenaSQL.Contains("insert into"))
            {
                mensaje = "agregando";
            }
            if (cadenaSQL.Contains("update "))
            {
                mensaje = "actualizando"; exeAutoNumerico = false;
            }
            if (cadenaSQL.Contains("delete from"))
            {
                mensaje = "eliminando"; exeAutoNumerico = false;
            }*/

            //CREAMOS OBJETO COMANDO
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;

            //SI ES EJECUCION DE AUTONUMERICO ESTABLECE LA DEVOLUCION DEL VALOR DE LA SECUENCIA
            if (exeAutoNumerico)
                sqlNueva.Replace("{%}", "coalesce");

            //CREACION DE PARAMETROS EN EL COMANDO Y DESCARTE DE CAMPOS AUTONUMERICOS
            foreach (CamposTabla item in lp)
            {
                if (!item.Nombre.Contains("#"))
                {
                    NpgsqlParameter parametro = new NpgsqlParameter();
                    parametro.ParameterName = "@" + item.Nombre;
                    if (item.TipoEstablecido)
                    {
                        parametro.DbType = item.Tipo;
                        parametro.Size = item.Tamaño;
                    }
                    parametro.Direction = item.Direccion;
                    parametro.Value = item.Valor;
                    command.Parameters.Add(parametro);
                }
            }

            //command.CommandText = sqlNueva.Replace("@", ":").ToString();
            command.CommandText = sqlNueva.ToString();
            //ASIGNACION DE CONEXION Y TRANSACCION
            if (unaConexion == null)
                command.Connection = this.Conexion;
            else
                command.Connection = (NpgsqlConnection)unaConexion;

            if (unaConexion != null && unaTransaccion != null)
                command.Transaction = (NpgsqlTransaction)unaTransaccion;

            //RESULTADO DEVUELTO
            int resultado = 0;

            try
            {
                if (unaConexion == null)
                    if (Conexion.State == System.Data.ConnectionState.Closed)
                        Conexion.Open();

                //EJECUCION DE COMANDO 
                if (exeAutoNumerico)
                {
                    //CAPTURAMOS VALOR AUTONUMERICO DE TIPO SEQUENCE CUANDO EXEAUTONUM == TRUE
                    NpgsqlDataReader rd = (NpgsqlDataReader)ExecuteReader(command);
                    rd.Read();
                    resultado = Convert.ToInt32(rd["valorActual"]);
                    rd.Close();
                    rd.Dispose();
                    rd = null;
                }
                else
                {
                    //DEVOLVEMOS EL NUMERO DE REGISTROS AFECTADOS CUANDO EXEAUTONUM == FALSE
                    resultado = ExecuteNonQuery(command);
                }
            }
            catch (NpgsqlException)
            {
                //throw new Exception("Error " + mensaje + " Registro \nDetalle: " + ex.ToString(), ex);
                throw;
            }
            /*catch (Exception)
            {
                //throw new Exception("Error " + mensaje + " Registro \nDetalle: " + ex.ToString(), ex);
                throw;
            }*/
            finally
            {
                //DESTRUCCION DE OBJETOS Y CIERRE DE CONEXION
                command.Dispose();
                if (unaConexion == null)
                {
                    if (conexionLocal != null)
                        if (Conexion.State == System.Data.ConnectionState.Open)
                        {
                            Conexion.Close();
                            conexionLocal = null;
                        }
                }
                //mensaje = null;
                sqlNueva = null;
            }
            //DEVOLUCION DE RESULTADO
            return resultado;

        }

        private IDataReader EjecutarQuery(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion = null)
        {
            //NpgsqlCommand command = new NpgsqlCommand(cadenaSQL.Replace("@", ":"));
            //IDataReader rd = null;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = (NpgsqlConnection)unaConexion;
            
            if (unaTransaccion != null)
                command.Transaction = (NpgsqlTransaction)unaTransaccion;

            command.CommandType = System.Data.CommandType.Text;

            foreach (CamposTabla item in lp)
            {
                NpgsqlParameter parametro = new NpgsqlParameter();
                parametro.ParameterName = "@" + item.Nombre;
                if (item.TipoEstablecido)
                {
                    parametro.DbType = item.Tipo;
                    parametro.Size = item.Tamaño;
                }
                parametro.Direction = item.Direccion;
                parametro.Value = item.Valor;
                command.Parameters.Add(parametro);

            }

            command.CommandText = cadenaSQL;

            try
            {
                if (unaConexion == null)
                    if (Conexion.State == System.Data.ConnectionState.Closed)
                        Conexion.Open();

                //rd = ExecuteReader(command.Clone());
                return ExecuteReader(command);
            }
            catch (Exception)
            {
                //throw new Exception("Error obteniendo registros \nDetalle: " + ex.ToString(), ex);
                throw;
            }
            finally
            {
                if(command != null)
                    command.Dispose();
                command = null;
            }
            //return rd;
        }
        #endregion FUNCIONES PARA EJECUTAR

        #region EJECUTAR CMD
        public override int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp);
        }
        public override int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp, unaConexion);
        }
        public override int EjecutarCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp, unaConexion, unaTransaccion);
        }
        #endregion EJECUTAR CMD

        #region EJECUTAR AUTONUMERICO
        /*public override int EjecutarAutonumerico(string cadenaSQL, List<CamposTabla> lp)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp);
        }
        public override int EjecutarAutonumerico(string cadenaSQL, List<CamposTabla> lp, object unaConexion)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp, unaConexion);
        }
        public override int EjecutarAutonumerico(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion)
        {
            return EjecutarSQLAutonumerico(cadenaSQL, lp, unaConexion, unaTransaccion);
        }*/
        #endregion EJECUTAR AUTONUMERICO

        #region EJECUTAR READER
        public override IDataReader EjecutarReader(string cadenaSQL, List<CamposTabla> lp, object unaConexion)
        {
            return EjecutarQuery(cadenaSQL, lp, unaConexion);
        }

        public override IDataReader EjecutarReader(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion)
        {
            return EjecutarQuery(cadenaSQL, lp, unaConexion, unaTransaccion);
        }
        #endregion EJECUTAR READER

        #region Objetos para Transaccion
        /// <summary>
        /// Crea un objeto Conexion con estado Open.
        /// </summary>
        /// <returns>Conexion tipo 'objeto'</returns>
        public override object CreaConexion()
        {
            //NpgsqlConnection conn = this.Conexion;
            if (this.Conexion.State == ConnectionState.Closed)
                this.Conexion.Open();

            return this.Conexion;
        }
        public override object CreaConexionClon()
        {
            NpgsqlConnection conn = new NpgsqlConnection(this.Conexion.ConnectionString);
            
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }
        public override object CreaConexion(string unaCadenaConexion)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(unaCadenaConexion);
            if (conexion == null)
                throw new Exception("Falla de conexion a la base de datos");
            if (conexion.State == ConnectionState.Open)
                conexion.Open();
            return conexion;
        }
        /// <summary>
        /// Crea un objeto Transaccion de la base de datos y la retorna como 'object'
        /// </summary>
        /// <param name="unaConexion">Una conexion con estado Open</param>
        /// <returns>Transaccion como 'object'</returns>
        public override object CreaTransaccion(object unaConexion)
        {
            NpgsqlConnection conn = ((NpgsqlConnection)unaConexion);
            NpgsqlTransaction transaccion = conn.BeginTransaction();
            return transaccion;
        }

        public override void Commit(object unaTransaccion)
        {
            if (unaTransaccion != null)
                ((NpgsqlTransaction)unaTransaccion).Commit();
        }

        public override void RollBack(object unaTransaccion)
        {
            if (unaTransaccion != null)
                ((NpgsqlTransaction)unaTransaccion).Rollback();
        }

        public override void Close(object unaConexion)
        {
            if (unaConexion != null)
            {
                ((NpgsqlConnection)unaConexion).Close();
            }
        }
        #endregion Objetos para transaccion

        #region COMANDOS PREPARADOS
        public override void PreparaCMD(string cadenaSQL, List<CamposTabla> lp)
        {
            this.PreparaComando(cadenaSQL, lp);
        }

        public override void PreparaCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion)
        {
            this.PreparaComando(cadenaSQL, lp, unaConexion);
        }

        public override void PreparaCMD(string cadenaSQL, List<CamposTabla> lp, object unaConexion, object unaTransaccion)
        {
            this.PreparaComando(cadenaSQL, lp, unaConexion, unaTransaccion);
        }

        #endregion COMANDOS PREPARADOS
    }
}
