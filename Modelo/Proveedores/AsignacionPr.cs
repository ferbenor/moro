using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using Entidades;
using Estructura;
using System.Reflection;
using CollectionLoaders;

namespace Proveedores
{
    public class AsignacionPr : InstrumentalPr
    {
        #region PROPIEDADES
        public string Modulo { get; set; }
        private Asignacion objetoAsignacion;
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public AsignacionPr()
        { objetoAsignacion = new Asignacion(); }
        #endregion CONSTRUCTORES

        #region FUNCIONES CARGA DE OBJETOS
        public List<Asignacion> ListaCombo(ref string unModulo)
        {
            return Registros(0, objetoAsignacion.SelectCombo(ref unModulo));
        }

        public List<Asignacion> ListaDetalle(short unCodigo, ref string unModulo)
        {
            return Registros(unCodigo, objetoAsignacion.SelectDetalle(ref unModulo));
        }



        public List<Asignacion> Registros(short unCodigo, string cadenaSQL)
        {
            List<Asignacion> listaObjeto = new List<Asignacion>();
            List<CamposTabla> lp = new List<CamposTabla>();
            if (unCodigo > 0)
                lp.Add(new CamposTabla("codigo", false, System.Data.DbType.Int16, 0, unCodigo));
            LectorDatos.Instancia.Conexion = this.MkConn();
            try
            {
                LectorDatos.Instancia.Abrir(cadenaSQL, lp);
                listaObjeto.LoadFromReader(LectorDatos.Instancia.Lector);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (!LectorDatos.Instancia.EstaCerrado)
                    LectorDatos.Instancia.Cerrar();
            }
            return listaObjeto;
        }
        #endregion FUNCIONES CARGA DE OBJETOS

        #region FUNCIONES GRABAR OBJETOS
        public int GrabarPerfiles(dynamic unaLista, short unId)
        {
            int i = 0;
            PerfilMenu entidad = new PerfilMenu(unId);
            List<Asignacion> lista = ((IEnumerable<Asignacion>)unaLista).Where(x => x.Asignado == true).ToList();

            object cnn = null; object trn = null;
            try
            {
                cnn = this.MkConn(); trn = this.MkTran(cnn);

                ProveedorAcceso.DAO.EjecutarCMD(entidad.CadenaBorrar(), entidad.ListaParametros, cnn, trn);
                entidad.IdPerfil = 0;
                ProveedorAcceso.DAO.PreparaCMD(entidad.CadenaGuardar(), entidad.ListaParametros, cnn, trn);
                foreach (Asignacion item in lista)
                {
                    entidad.IdPerfil = unId;
                    entidad.IdMenu = item.Id;
                    entidad.Editable = item.Editable;
                    i = ProveedorAcceso.DAO.EjecutarCmdPreparado(entidad.ObtenerParametrosGuardar());
                }
                ProveedorAcceso.DAO.Commit(trn);

            }
            catch (Exception)
            {
                ProveedorAcceso.DAO.RollBack(trn);
                throw;
            }
            finally
            {
                ProveedorAcceso.DAO.Close(cnn);
                ProveedorAcceso.DAO.BorrarCmdPreparado();
                cnn = null; trn = null;
            }
            entidad = null; lista = null;
            return i;
        }

        public int GrabarUsuarios(dynamic unaLista, short unId)
        {
            int i = 0;
            UsuarioPerfil entidad = new UsuarioPerfil(unId);
            List<Asignacion> lista = ((IEnumerable<Asignacion>)unaLista).Where(x => x.Asignado == true).ToList();

            object cnn = null; object trn = null;
            try
            {
                cnn = this.MkConn(); trn = this.MkTran(cnn);

                ProveedorAcceso.DAO.EjecutarCMD(entidad.CadenaBorrar(), entidad.ListaParametros, cnn, trn);
                entidad.IdUsuario = 0;
                ProveedorAcceso.DAO.PreparaCMD(entidad.CadenaGuardar(), entidad.ListaParametros, cnn, trn);
                foreach (Asignacion item in lista)
                {
                    entidad.IdUsuario = unId;
                    entidad.IdPerfil = item.Id;
                    i = ProveedorAcceso.DAO.EjecutarCmdPreparado(entidad.ObtenerParametrosGuardar());
                }
                ProveedorAcceso.DAO.Commit(trn);

            }
            catch (Exception)
            {
                ProveedorAcceso.DAO.RollBack(trn);
                throw;
            }
            finally
            {
                ProveedorAcceso.DAO.Close(cnn);
                cnn = null; trn = null;
            }
            entidad = null; lista = null;
            return i;
        }

        
        #endregion FUNCIONES GRABAR OBJETOS
    }
}
