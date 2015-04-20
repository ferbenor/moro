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

namespace WindowsApp
{
    public static class Teclas
    {
        #region CONSTANTES
        public const char A = (char)Keys.A;
        public const char Add = (char)Keys.Add;
        //public const char Alt = (char)Keys.Alt;
        public const char Apps = (char)Keys.Apps;
        public const char Attn = (char)Keys.Attn;
        public const char B = (char)Keys.B;
        public const char Back = (char)Keys.Back;
        public const char BrowserBack = (char)Keys.BrowserBack;
        public const char BrowserFavorites = (char)Keys.BrowserFavorites;
        public const char BrowserForward = (char)Keys.BrowserForward;
        public const char BrowserHome = (char)Keys.BrowserHome;
        public const char BrowserRefresh = (char)Keys.BrowserRefresh;
        public const char BrowserSearch = (char)Keys.BrowserSearch;
        public const char BrowserStop = (char)Keys.BrowserStop;
        public const char C = (char)Keys.C;
        public const char Cancel = (char)Keys.Cancel;
        public const char Capital = (char)Keys.Capital;
        public const char CapsLock = (char)Keys.CapsLock;
        public const char Clear = (char)Keys.Clear;
        //public const char Control = (char)Keys.Control;
        public const char ControlKey = (char)Keys.ControlKey;
        public const char Crsel = (char)Keys.Crsel;
        public const char D = (char)Keys.D;
        public const char D0 = (char)Keys.D0;
        public const char D1 = (char)Keys.D1;
        public const char D2 = (char)Keys.D2;
        public const char D3 = (char)Keys.D3;
        public const char D4 = (char)Keys.D4;
        public const char D5 = (char)Keys.D5;
        public const char D6 = (char)Keys.D6;
        public const char D7 = (char)Keys.D7;
        public const char D8 = (char)Keys.D8;
        public const char D9 = (char)Keys.D9;
        public const char Decimal = (char)Keys.Decimal;
        public const char Delete = (char)Keys.Delete;
        public const char Divide = (char)Keys.Divide;
        public const char Down = (char)Keys.Down;
        public const char E = (char)Keys.E;
        public const char End = (char)Keys.End;
        public const char Enter = (char)Keys.Enter;
        public const char EraseEof = (char)Keys.EraseEof;
        public const char Escape = (char)Keys.Escape;
        public const char Execute = (char)Keys.Execute;
        public const char Exsel = (char)Keys.Exsel;
        public const char F = (char)Keys.F;
        public const char F1 = (char)Keys.F1;
        public const char F10 = (char)Keys.F10;
        public const char F11 = (char)Keys.F11;
        public const char F12 = (char)Keys.F12;
        public const char F13 = (char)Keys.F13;
        public const char F14 = (char)Keys.F14;
        public const char F15 = (char)Keys.F15;
        public const char F16 = (char)Keys.F16;
        public const char F17 = (char)Keys.F17;
        public const char F18 = (char)Keys.F18;
        public const char F19 = (char)Keys.F19;
        public const char F2 = (char)Keys.F2;
        public const char F20 = (char)Keys.F20;
        public const char F21 = (char)Keys.F21;
        public const char F22 = (char)Keys.F22;
        public const char F23 = (char)Keys.F23;
        public const char F24 = (char)Keys.F24;
        public const char F3 = (char)Keys.F3;
        public const char F4 = (char)Keys.F4;
        public const char F5 = (char)Keys.F5;
        public const char F6 = (char)Keys.F6;
        public const char F7 = (char)Keys.F7;
        public const char F8 = (char)Keys.F8;
        public const char F9 = (char)Keys.F9;
        public const char FinalMode = (char)Keys.FinalMode;
        public const char G = (char)Keys.G;
        public const char H = (char)Keys.H;
        public const char HanguelMode = (char)Keys.HanguelMode;
        public const char HangulMode = (char)Keys.HangulMode;
        public const char HanjaMode = (char)Keys.HanjaMode;
        public const char Help = (char)Keys.Help;
        public const char Home = (char)Keys.Home;
        public const char I = (char)Keys.I;
        public const char IMEAccept = (char)Keys.IMEAccept;
        public const char IMEAceept = (char)Keys.IMEAceept;
        public const char IMEConvert = (char)Keys.IMEConvert;
        public const char IMEModeChange = (char)Keys.IMEModeChange;
        public const char IMENonconvert = (char)Keys.IMENonconvert;
        public const char Insert = (char)Keys.Insert;
        public const char J = (char)Keys.J;
        public const char JunjaMode = (char)Keys.JunjaMode;
        public const char K = (char)Keys.K;
        public const char KanaMode = (char)Keys.KanaMode;
        public const char KanjiMode = (char)Keys.KanjiMode;
        public const char KeyCode = (char)Keys.KeyCode;
        public const char L = (char)Keys.L;
        public const char LButton = (char)Keys.LButton;
        public const char LControlKey = (char)Keys.LControlKey;
        public const char LMenu = (char)Keys.LMenu;
        public const char LShiftKey = (char)Keys.LShiftKey;
        public const char LWin = (char)Keys.LWin;
        public const char LaunchApplication1 = (char)Keys.LaunchApplication1;
        public const char LaunchApplication2 = (char)Keys.LaunchApplication2;
        public const char LaunchMail = (char)Keys.LaunchMail;
        public const char Left = (char)Keys.Left;
        public const char LineFeed = (char)Keys.LineFeed;
        public const char M = (char)Keys.M;
        public const char MButton = (char)Keys.MButton;
        public const char MediaNextTrack = (char)Keys.MediaNextTrack;
        public const char MediaPlayPause = (char)Keys.MediaPlayPause;
        public const char MediaPreviousTrack = (char)Keys.MediaPreviousTrack;
        public const char MediaStop = (char)Keys.MediaStop;
        public const char Menu = (char)Keys.Menu;
        //public const char Modifiers = (char)Keys.Modifiers;
        public const char Multiply = (char)Keys.Multiply;
        public const char N = (char)Keys.N;
        public const char Next = (char)Keys.Next;
        public const char NoName = (char)Keys.NoName;
        public const char None = (char)Keys.None;
        public const char NumLock = (char)Keys.NumLock;
        public const char NumPad0 = (char)Keys.NumPad0;
        public const char NumPad1 = (char)Keys.NumPad1;
        public const char NumPad2 = (char)Keys.NumPad2;
        public const char NumPad3 = (char)Keys.NumPad3;
        public const char NumPad4 = (char)Keys.NumPad4;
        public const char NumPad5 = (char)Keys.NumPad5;
        public const char NumPad6 = (char)Keys.NumPad6;
        public const char NumPad7 = (char)Keys.NumPad7;
        public const char NumPad8 = (char)Keys.NumPad8;
        public const char NumPad9 = (char)Keys.NumPad9;
        public const char O = (char)Keys.O;
        public const char Oem1 = (char)Keys.Oem1;
        public const char Oem102 = (char)Keys.Oem102;
        public const char Oem2 = (char)Keys.Oem2;
        public const char Oem3 = (char)Keys.Oem3;
        public const char Oem4 = (char)Keys.Oem4;
        public const char Oem5 = (char)Keys.Oem5;
        public const char Oem6 = (char)Keys.Oem6;
        public const char Oem7 = (char)Keys.Oem7;
        public const char Oem8 = (char)Keys.Oem8;
        public const char OemBackslash = (char)Keys.OemBackslash;
        public const char OemClear = (char)Keys.OemClear;
        public const char OemCloseBrackets = (char)Keys.OemCloseBrackets;
        public const char OemMinus = (char)Keys.OemMinus;
        public const char OemOpenBrackets = (char)Keys.OemOpenBrackets;
        public const char OemPeriod = (char)Keys.OemPeriod;
        public const char OemPipe = (char)Keys.OemPipe;
        public const char OemQuestion = (char)Keys.OemQuestion;
        public const char OemQuotes = (char)Keys.OemQuotes;
        public const char OemSemicolon = (char)Keys.OemSemicolon;
        public const char Oemcomma = (char)Keys.Oemcomma;
        public const char Oemplus = (char)Keys.Oemplus;
        public const char Oemtilde = (char)Keys.Oemtilde;
        public const char P = (char)Keys.P;
        public const char Pa1 = (char)Keys.Pa1;
        public const char Packet = (char)Keys.Packet;
        public const char PageDown = (char)Keys.PageDown;
        public const char PageUp = (char)Keys.PageUp;
        public const char Pause = (char)Keys.Pause;
        public const char Play = (char)Keys.Play;
        public const char Print = (char)Keys.Print;
        public const char PrintScreen = (char)Keys.PrintScreen;
        public const char Prior = (char)Keys.Prior;
        public const char ProcessKey = (char)Keys.ProcessKey;
        public const char Q = (char)Keys.Q;
        public const char R = (char)Keys.R;
        public const char RButton = (char)Keys.RButton;
        public const char RControlKey = (char)Keys.RControlKey;
        public const char RMenu = (char)Keys.RMenu;
        public const char RShiftKey = (char)Keys.RShiftKey;
        public const char RWin = (char)Keys.RWin;
        public const char Return = (char)Keys.Return;
        public const char Right = (char)Keys.Right;
        public const char S = (char)Keys.S;
        public const char Scroll = (char)Keys.Scroll;
        public const char Select = (char)Keys.Select;
        public const char SelectMedia = (char)Keys.SelectMedia;
        public const char Separator = (char)Keys.Separator;
        //public const char Shift = (char)Keys.Shift;
        public const char ShiftKey = (char)Keys.ShiftKey;
        public const char Sleep = (char)Keys.Sleep;
        public const char Snapshot = (char)Keys.Snapshot;
        public const char Space = (char)Keys.Space;
        public const char Subtract = (char)Keys.Subtract;
        public const char T = (char)Keys.T;
        public const char Tab = (char)Keys.Tab;
        public const char U = (char)Keys.U;
        public const char Up = (char)Keys.Up;
        public const char V = (char)Keys.V;
        public const char VolumeDown = (char)Keys.VolumeDown;
        public const char VolumeMute = (char)Keys.VolumeMute;
        public const char VolumeUp = (char)Keys.VolumeUp;
        public const char W = (char)Keys.W;
        public const char X = (char)Keys.X;
        public const char XButton1 = (char)Keys.XButton1;
        public const char XButton2 = (char)Keys.XButton2;
        public const char Y = (char)Keys.Y;
        public const char Z = (char)Keys.Z;
        public const char Zoom = (char)Keys.Zoom;
        #endregion CONSTANTES
    }

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
            out string unaBusqueda, out string esPieDetalle, out object columnasGrid)
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
            columnasGrid = menu.fkcolumnasgrid;

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
                    General.fechaServidor)
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
                    unUsuario.clave = General.CifrarClave(unUsuario.loginusuario + " " + asistente.NuevaClave);
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
            UsuarioSesionActivaPr.Instancia.Borrar(General.usuarioActivo);
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
                        i = sesion.Grabar(new usuariosesionactiva() { fkusuario = objetoUsuario, idusuario = objetoUsuario.id, ipsesion = General.ipLocal });
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
        string PieDetalle { get; set; }
        bool EsEditable { get; set; }
        bool RaiseEvent { get; set; }
        object ProveedorInstancia { get; set; }
        object ColumnasGrid { get; set; }
        void Nuevo();
        void Editar();
        //Form Examinar(short opcion, out object unObjetolocal);
        void Guardar();
        void Eliminar();
        void Actualizar();
        void Cancelar();
        void Buscar();
        void Imprimir();
        void Filtrar(string unTexto);

        void EstablecerObjetoLocal(object unObjetoLocal);
        object ObtenerObjetoLocal();
    }
    #endregion InterfazVentanaPrincipal

}
