using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Proveedores;
using ModeloDB;
using System.Diagnostics;
using System.Reflection;

namespace Controladores
{
    public class VentanaPrincipalCr
    {
        private static VentanaPrincipalCr instancia;
        public static VentanaPrincipalCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new VentanaPrincipalCr();
                return instancia;
            }
        }
        // Para la ventana de Asignaciones
        public void Apariencia(Control unControl)
        {
            General.Interfaz(unControl);
        }

        public void ValidarSoloNumeros(Control unControl)
        {
            General.SoloNumeros(unControl);
        }

        MenuSistemaPr objetoMenu = new MenuSistemaPr();
        public MenuSistemaPr ObjetoMenu { get { return objetoMenu; } }

        #region DEFINICION DE EVENTOS
        public delegate void OnCargaInicialDelegado(object sender, CargaInicialEventArgs e);
        public event OnCargaInicialDelegado OnCargaInicialEvent;
        #endregion DEFINICION DE EVENTOS

        #region REGISTRO DE EVENTOS
        public void RegisterView(IViewPrincipal ventana)
        {
            this.OnCargaInicialEvent += new OnCargaInicialDelegado(ventana.OnCargaDatos);
        }

        public void UnregisterView(IViewPrincipal ventana)
        {
            this.OnCargaInicialEvent -= new OnCargaInicialDelegado(ventana.OnCargaDatos);
        }
        #endregion REGISTRO DE EVENTOS

        #region USUARIOS MENUS Y PARAMETROS
        public void ObtenerDatosMenu(short unIdMenu, out System.Drawing.Bitmap unaImagen,
            out string unFormulario, out string unModulo, out string unTitulo, out bool esEditable,
            out string unaBusqueda, out string esPieDetalle)
        {
            menu menu = null;
            int i = objetoMenu.listaMenus.FindIndex(x => x.id == unIdMenu);
            if (i > -1)
                menu = objetoMenu.listaMenus.ElementAt(i);

            unaImagen = new System.Drawing.Bitmap(General.Imagenes.Images[menu.icono]);
            unFormulario = menu.formulario;
            unModulo = menu.modulo;
            unTitulo = menu.titulo;
            esEditable = menu.editable;
            unaBusqueda = menu.busqueda;
            esPieDetalle = menu.piedetalle;
        }

        public string CargarVersionInfo(Assembly unEnsamblado)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(unEnsamblado.Location);
            General.appProducto = fileVersionInfo.ProductName;
            General.appVersion = fileVersionInfo.ProductVersion;
            General.appDerechoCopia = fileVersionInfo.LegalCopyright;
            General.appCompania = fileVersionInfo.CompanyName;
            General.appComentario = fileVersionInfo.Comments;
            fileVersionInfo = null;
            return General.appVersion;
        }

        public void EstablecerValores()
        {
            if (this.OnCargaInicialEvent != null)
            {
                General.periodoActual = 2014;
                CargaInicialEventArgs argumentos = new CargaInicialEventArgs(
                    General.usuarioActivo.ipsesion, General.usuarioActivo.fkusuario.ToString(),
                    General.usuarioActivo.fechasesion)
                    {
                        TituloUno = "   " + ParametroGeneralPr.Instancia.ParametrosGenerales["nombre_empresa"].valor,
                        TituloDos = " " + ParametroGeneralPr.Instancia.ParametrosGenerales["complemento_nombre_empresa"].valor,
                        NombreProducto = General.appProducto,
                        DerechoCopia = General.appDerechoCopia,
                        Version = General.appVersion,

                    };
                OnCargaInicialEvent(this, argumentos);
                argumentos = null;
            }
        }

        public bool CambiarClave(usuario unUsuario)
        {
            CambioClave asistente = new CambioClave();
            bool respuesta = false;
            try
            {
                asistente.UsuarioVerificado = unUsuario;
                asistente.ShowDialog();
                //VERIFICAMOS CLAVE ANTERIOR
                if (asistente.Registrar)
                {
                    UsuarioPr usuario = new UsuarioPr();
                    unUsuario.clave = asistente.NuevaClave;
                    unUsuario.Modificado = true;
                    int i = usuario.Grabar(unUsuario);
                    if (i == 0)
                        throw new Exception("No se pudo completar el cambio de clave. \nPor favor consulte con el Administrador del sistema.");

                    General.Mensaje("Nueva clave registrada.", MessageBoxIcon.Information);
                    respuesta = true;
                    usuario = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                asistente.Dispose();
            }
            return respuesta;
        }

        public void CierraSesion()
        {
            UsuarioSesionActivaPr sesion = new UsuarioSesionActivaPr();
            sesion.Borrar(General.usuarioActivo);
            sesion = null;
        }

        public bool VerificaUsuario(string unLoginUsuario, string unaClave)
        {
            //General.ObtenerIP();
            bool respuesta = false; int i = 0;
            try
            {
                UsuarioSesionActivaPr sesion = new UsuarioSesionActivaPr();
                usuario objetoUsuario = UsuarioPr.Instancia.RegistroPorLogin(unLoginUsuario + " " + unaClave);
                if (objetoUsuario == null)
                    throw new Exception("El nombre de usuario o la clave \nintroducidos no son correctos.");
                else
                {
                    if (!objetoUsuario.MenusAsignados && !objetoUsuario.administrador)
                        throw new Exception("No cuenta con opciones asignadas en el sistema. \nPor favor consulte con el Administrador del mismo.");
                    if (!objetoUsuario.activo)
                        throw new Exception("No esta autorizado para ingresar al sistema. \nPor favor consulte con el Administrador del mismo.");

                    General.usuarioActivo = UsuarioSesionActivaPr.Instancia.Registro(objetoUsuario);

                    if (General.usuarioActivo == null)
                    {
                        i = sesion.Grabar(new usuariosesionactiva() { fkusuario = objetoUsuario, idusuario = 0, ipsesion = General.ipLocal });
                    }
                    else
                    {
                        if (General.usuarioActivo.fkusuario.multisesion)
                            i = 1;
                        else
                        {
                            if (Object.Equals(General.ipLocal, General.usuarioActivo.ipsesion))
                                if (Object.Equals(General.CifrarClave(unLoginUsuario + " " + unaClave), General.usuarioActivo.fkusuario.clave))
                                    throw new Exception("Usted ya tiene sesion iniciada en este equipo");
                                else
                                    i = sesion.Grabar(new usuariosesionactiva() { fkusuario = objetoUsuario });
                            else
                                throw new Exception("Usted tiene sesion iniciada en el equipo '" + General.usuarioActivo.ipsesion + "', no puede continuar");
                        }
                    }

                    if (i == 0)
                        throw new Exception("No se pudo registrar inicio de sesion \nPor favor consulte con el Administrador de sistemas");
                    else
                    {
                        respuesta = true;
                    }

                    if (General.usuarioActivo.fkusuario.CambioClave)
                    {
                        General.Mensaje("Clave expirada", MessageBoxIcon.Information);
                        if (!CambiarClave(General.usuarioActivo.fkusuario))
                        {
                            CierraSesion();
                            throw new Exception("Cambio de clave cancelado. \nNo puede continuar");
                        }
                    }
                }
            }
            catch (Exception)
            {
                respuesta = false;
                throw;
            }
            return respuesta;
        }

        #region MENUS
        public BaseItem[] GeneraMenuLateral()
        {
            return objetoMenu.CargarMenuLateral();
        }

        public ToolStripItem[] GeneraMenuSuperior()
        {
            return objetoMenu.CargarMenuSuperior();
        }
        #endregion MENUS

        #endregion USUARIOS MENUS Y PARAMETROS
    }

    #region InterfazVentanaPrincipal
    public interface IViewPrincipal
    {
        //EVENTOS PARA VISTAS
        void OnCargaDatos(object sender, CargaInicialEventArgs e);
    }
    #endregion InterfazVentanaPrincipal

    #region ARGUMENTOS
    public class CargaInicialEventArgs
    {
        //VARIABLES
        string direccionIp;
        DateTime fechaServidor;
        string nombreUsuario;
        string tituloUno;
        string tituloDos;
        string nombreProducto;
        string derechoCopia;
        string version;

        public string DireccionIp { get { return direccionIp; } set { direccionIp = value; } }
        public string NombreUsuario { get { return nombreUsuario; } set { nombreUsuario = value; } }
        public string TituloUno { get { return tituloUno; } set { tituloUno = value; } }
        public string TituloDos { get { return tituloDos; } set { tituloDos = value; } }
        public string NombreProducto { get { return nombreProducto; } set { nombreProducto = value; } }
        public string DerechoCopia { get { return derechoCopia; } set { derechoCopia = value; } }
        public string Version { get { return version; } set { version = value; } }
        public DateTime FechaServidor { get { return fechaServidor; } set { fechaServidor = value; } }

        //CONTRUCTORES
        private CargaInicialEventArgs() { }
        public CargaInicialEventArgs(string unaDireccionIp, string unNombreUsuario, DateTime unaFechaServidor)
        {
            this.direccionIp = unaDireccionIp;
            this.fechaServidor = unaFechaServidor;
            this.nombreUsuario = unNombreUsuario;
        }
    }
    #endregion ARGUMENTOS

    #region InterfazVentanas
    public interface IAccesoMetodos
    {
        string Modulo { get; set; }
        string UnaBusqueda { get; set; }
        bool EsPieDetalle { get; set; }
        bool EsEditable { get; set; }
        bool RaiseEvent { get; set; }
        object ProveedorInstancia { get; set; }
        void Agregar();
        Form Examinar(short opcion, out object unObjetolocal);
        void Grabar();
        void Borrar();
        void Actualizar();
        void Filtrar(string valor);
        void Busqueda();
        void Imprimir();

        void EstablecerObjetoLocal(object unObjetoLocal);
        object ObtenerObjetoLocal();
    }
    #endregion InterfazVentanaPrincipal
}
