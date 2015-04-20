using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Equin.ApplicationFramework;
using LinqToDB;
using System.Drawing.Imaging;
using System.Reflection;

namespace ModeloDB
{

    public static class UrlHelpers
    {
        public static string ToQueryString(object request, string separator = ",")
        {

            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }
    }

    /// <summary>
    /// Clase con extenciones para Colecciones y Objects
    /// </summary>
    public static class SoporteList
    {
        public static bool Es<T>(this object obj)
        {
            return obj is T;
        }

        public static T ObtenerObjetoBLV<T>(object Objeto) where T : class
        {
            ObjectView<T> listaInterna = Objeto as ObjectView<T>;
            if (listaInterna == null)
                throw new Exception(string.Format("Tipo ObjectView<{0}> no definido", typeof(T).Name));
            else
                return (T)listaInterna.Object;
        }

        public static List<T> ObtenerLista<T>(object lista, bool modificados = false)
        {
            BindingListView<T> listaInterna = lista as BindingListView<T>;

            if (listaInterna == null)
                throw new Exception(string.Format("Tipo BindingListView<{0}> no definido", typeof(T).Name));
            else
            {
                if (modificados)
                    return ((IEnumerable<Estructura.IMaestras>)listaInterna.SourceLists[0]).Where(x => x.Modificado == true).Cast<T>().ToList();
                else
                    return (List<T>)listaInterna.SourceLists[0];
            }
        }

        //[System.Diagnostics.DebuggerHidden]
        public static object ToFBinding<T>(this List<T> lista)
        {
            FBindingList<T> salida = new FBindingList<T>(lista);
            return salida;

        }

        [System.Diagnostics.DebuggerHidden]
        public static void CargarGrid<T>(this List<T> lista, DataGridView unObjetoGrid, BindingSource unBS = null)
        {
            //BindingList<T> salida = new BindingList<T>(lista) { AllowNew = true, AllowEdit = true };
            //BindingListView<T> salida = new BindingListView<T>(lista);
            FBindingList<T> salida = new FBindingList<T>(lista);
            if (unBS == null)
                unObjetoGrid.DataSource = salida;
            else
            {
                unBS.DataSource = salida;
                unObjetoGrid.DataSource = unBS;
            }
            lista = null;
        }

        [System.Diagnostics.DebuggerHidden]
        public static void CargarGrid<T>(this IEnumerable<T> lista, DataGridView unObjetoGrid)
        {
            //BindingList<T> salida = new BindingList<T>(lista) { AllowNew = true, AllowEdit = true };
            //BindingListView<T> salida = new BindingListView<T>(lista.ToList());
            FBindingList<T> salida = new FBindingList<T>(lista.ToList());
            unObjetoGrid.DataSource = salida;
            //lista = null;
        }

        //public static bool Filtrar<T>(Equin.ApplicationFramework.BindingListView<T> unaLista, string unTexto) where T : Instrumental1
        public static bool Filtrar<T>(FBindingList<T> unaLista, string unTexto) where T : Instrumental1
        {
            bool respuesta = true;
            object a = null;
            System.Reflection.MethodInfo metodo = typeof(T).GetMethod("Filtro", new Type[] { typeof(string) });
            if (metodo == null)
                //General.Mensaje(string.Format("Metodo 'public [Object]Predicate<{0}> Filtro(String)' no definido para el tipo '{0}'", typeof(T).Name));
                respuesta = false;
            else
                a = metodo.Invoke(null, new object[] { unTexto });
            if (a != null)
                unaLista.Filter((Predicate<T>)a);

            return respuesta;
        }

        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            T aux = list[newIndex];
            list[newIndex] = list[oldIndex];
            list[oldIndex] = aux;
        }
    }

    public static class SoporteList<T>
    {
        public static BindingList<T> ToBindingList(List<T> lista)
        {
            BindingList<T> salida = new BindingList<T>(lista) { AllowNew = true, AllowEdit = true };
            lista = null;
            return salida;
        }


    }

    /// <summary>
    /// Provides a generic collection that supports data binding and additionally supports sorting.
    /// See http://msdn.microsoft.com/en-us/library/ms993236.aspx
    /// If the elements are IComparable it uses that; otherwise compares the ToString()
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class FBindingList<T> : BindingList<T>
    {
        private bool _isSorted;

        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        private List<T> allItems = new List<T>();
        private Predicate<T> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public FBindingList()
        {
            base.AllowEdit = true;
            base.AllowNew = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FBindingList{T}"/> class.
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        /// </summary>
        public FBindingList(IList<T> list)
            : base(list)
        {
            base.AllowEdit = true;
            base.AllowNew = true;
            allItems.AddRange(list);
        }

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        #region FUNCIONES PARA SORTED

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented
        /// </summary>
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            //DEVOLVEMOS LOS ITEMS A SU POSICION ORIGINAL
            int ix = -1;
            List<T> list = Items as List<T>;
            for (int i = 0; i < allItems.Count; i++)
            {
                ix = list.IndexOf(allItems[i]);
                list.Move(ix, i);
            }

            _isSorted = false; //thanks Luca
        }

        /// <summary>
        /// Sorts the items if overridden in a derived class
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (_sortDirection == ListSortDirection.Descending)
                RemoveSortCore();
            else
            {
                _sortProperty = prop;
                _sortDirection = direction;

                List<T> list = Items as List<T>;
                if (list == null) return;

                list.Sort(Compare);

                _isSorted = true;
            }
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


        private int Compare(T lhs, T rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; //nulls are equal
            }
            if (rhsValue == null)
            {
                return 1; //first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }

        #endregion

        #region FUNCIONES PARA FILTERED

        public void Filter(Predicate<T> Predicate)
        {
            predicate = Predicate;
            Filter();
        }

        private void Filter()
        {
            base.Items.Clear();
            foreach (T obj in allItems)
            {
                if ((predicate == null) || predicate(obj))
                    base.Items.Add(obj);
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion FUNCIONES PARA FILTERED

        #region FUNCIONES PARA MANIPULACION DE DATOS

        protected override void InsertItem(int index, T item)
        {
            allItems.Add(item);
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            allItems.Remove(Items[index]);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            allItems.Clear();
            base.ClearItems();
        }

        protected override void SetItem(int index, T item)
        {
            allItems[allItems.IndexOf(Items[index])] = item;
            base.SetItem(index, item);
        }

        #endregion FUNCIONES PARA MANIPULACION DE DATOS

    }

    public class PropertyComparer<T> : System.Collections.Generic.IComparer<T>
    {
        private PropertyDescriptor _property;
        private ListSortDirection _direction;

        public PropertyComparer(PropertyDescriptor property,
            ListSortDirection direction)
        {
            _property = property;
            _direction = direction;
        }

        #region IComparer<T>

        public int Compare(T xWord, T yWord)
        {
            // Get property values
            object xValue = GetPropertyValue(xWord, _property.Name);
            object yValue = GetPropertyValue(yWord, _property.Name);

            // Determine sort order
            if (_direction == ListSortDirection.Ascending)
            {
                return CompareAscending(xValue, yValue);
            }
            else
            {
                return CompareDescending(xValue, yValue);
            }
        }

        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion

        // Compare two property values of any type
        private int CompareAscending(object x, object y)
        {
            int result;

            // If values implement IComparer
            if (x is IComparable)
            {
                result = ((IComparable)x).CompareTo(y);
            }
            // If values don't implement IComparer but are equivalent
            else if (x.Equals(y))
            {
                result = 0;
            }
            // Values don't implement IComparer and are not equivalent,
            // so compare as typed values
            else result = ((IComparable)x).CompareTo(y);

            // Return result
            return result;
        }

        private int CompareDescending(object x, object y)
        {
            // Return result adjusted for ascending or descending sort order ie
            // multiplied by 1 for ascending or -1 for descending
            return -CompareAscending(x, y);
        }

        private object GetPropertyValue(T value, string property)
        {
            // Get property
            PropertyInfo propertyInfo = value.GetType().GetProperty(property);

            // Return value
            return propertyInfo.GetValue(value, null);
        }
    }


    public enum EstadoBarraEnum { EXAMINANDO, EDITANDO, BUSCANDO, NINGUNO }
    public enum TipoSeleccionCuentaEnum { Todas, Grupo, Movimiento };
    public enum TipoCargaSubObjetosEnum { Individual, PorLista, Ninguno };

    public static class General
    {

        #region OBJETOS CERO
        public static banco bancoCero = new banco() { nombre = General.itemCero };
        public static unidaddemedida unidadCero = new unidaddemedida() { descripcion = General.itemCero };
        public static estadoordenpedido estadoOrdenPedidoCero = new estadoordenpedido() { id = 1, descripcion = "PENDIENTE" };
        public static parroquia parroquiaCero = new parroquia() { nombre = General.itemVacio };
        public static provincia provinciaCero = new provincia() { nombre = General.itemVacio };
        public static tipocontable tipoContableCero = new tipocontable() { descripcion = General.itemCero };
        public static persona personaCero = new persona() { apellido = General.itemCero, nombre = "" };
        public static persona personaVacio = new persona();
        public static cliente clienteVacio = new cliente();
        public static cuentacontable cuentaContableCero = new cuentacontable() { nombre = General.itemVacio };
        //public static CuentaContableAux cuentaContableAuxCero = new CuentaContableAux(-1) { Nombre = General.itemVacio };
        //public static SectorEconomicoAux sectorEconomicoAuxCero = new SectorEconomicoAux(-1) { Descripcion = General.itemVacio };
        //public static ActividadEconomicaAux actividadEconomicaAuxCero = new ActividadEconomicaAux(-1) { Descripcion = General.itemVacio };
        //public static MenuSistemaAux menuSistemaAuxCero = new MenuSistemaAux() { Nombre = General.itemCero };
        public static canton cantonCero = new canton() { nombre = General.itemVacio };
        public static barrio barrioCero = new barrio() { nombre = General.itemVacio };
        public static documento documentoCero = new documento() { descripcion = General.itemCero };
        public static Mes mesCero = new Mes(1, "ENERO");
        public static tipopersona tipoPersonaCero = new tipopersona() { descripcion = General.itemCero };
        public static tipodocumento tipoDocumentoCero = new tipodocumento() { descripcion = General.itemCero };
        public static genero generoCero = new genero() { descripcion = General.itemCero };
        public static estadopersona estadoPersonaCero = new estadopersona() { id = 1, descripcion = "PENDIENTE" };
        public static usuario usuarioCero = new usuario() { descripcion = "" };
        public static contable contableCero = new contable();
        public static List<detallecontable> detalleContableCero = new List<detallecontable>();
        public static estadocivil estadoCivilCero = new estadocivil() { nombre = General.itemVacio };
        public static profesion profesionCero = new profesion() { nombre = General.itemVacio };
        public static producto productoCero = new producto() { descripcion = General.itemVacio };
        public static iteminventario itemInventarioCero = new iteminventario() { descripcion = General.itemVacio };
        public static formapago formaPagoCero = new formapago() { descripcion = General.itemVacio };
        public static identificadorpago identificadorPagosCero = new identificadorpago();
        public static DateTime fechaCero = new DateTime(1900, 1, 1);
        public static DateTime fechaActual = DateTime.Now;
        public static marca marcaCero = new marca() { descripcion = General.itemVacio };
        public static alineacion alineacionCero = new alineacion() { nombre = "NotSet" };
        public static tipocolumna tipocolumnaCero = new tipocolumna() { nombre = "DataGridViewTextBoxColumn" };
        #endregion OBJETOS CERO

        #region CONSTANTES
        public static List<DataGridViewColumn> listaColumnasSoloLectura;
        public static DateTime fechaServidor = Sql.DateTime;
        public const decimal porcentajeIva = (Decimal)0.12;
        public const string itemVacio = "";
        public const string itemNoEncontrado = "Busqueda sin resultados";
        public const string itemCero = "Seleccione";

        public const string BDFechaActual = "CURRENT_DATE";
        public const string BDFechaHoraActual = "NOW()";
        #endregion CONSTANTES

        #region PROPIEDADES
        public static System.Data.IDbConnection miConexion;
        public static short periodoActual;
        public static ImageList Imagenes { get { return ImagenCombo.Imagenes; } set { ImagenCombo.Imagenes = value; } }
        public static usuariosesionactiva usuarioActivo;
        public static System.Drawing.Image imagenLogo;
        public static string ipLocal;
        public static string appCompania;
        public static string appProducto;
        public static string appVersion;
        public static string appDerechoCopia;
        public static string appComentario;
        #endregion PROPIEDADES

        #region FUNCIONES CARGA DE DATOS

        public static BindingListView<T> ToBindingList<T>(List<T> lista)
        {
            //BindingList<T> salida = new BindingList<T>(lista) { AllowNew = true, AllowEdit = true };
            BindingListView<T> salida = new BindingListView<T>(lista);
            lista = null;
            return salida;
        }

        public static void CargarCombos(ComboBoxEx unCombo, string unValor, string unTexto, object unaLista)
        {
            unCombo.ValueMember = unValor;
            unCombo.DisplayMember = unTexto;
            unCombo.DataSource = unaLista;
        }

        public static void CargarCombos(DataGridViewComboBoxExColumn unCombo, string unValor, string unTexto, object unaLista)
        {
            unCombo.ValueMember = unValor;
            unCombo.DisplayMember = unTexto;
            unCombo.DataSource = unaLista;
        }

        public static bool CargaGrids(object unDataReader, DataGridView unObjetoGrid)
        {
            System.Data.DataTable tablaDatos = new System.Data.DataTable();

            tablaDatos.Load((System.Data.IDataReader)unDataReader);

            //BindingSource fuente = new BindingSource();
            //fuente.DataSource = tablaDatos;
            if (tablaDatos.Rows.Count > 0)
            {
                unObjetoGrid.DataSource = tablaDatos;
                return true;
            }
            else
                return false;
        }

        #endregion FUNCIONES CARGA DE DATOS

        #region FUNCIONES

        /*public static LinqToDB.DataProvider.IDataProvider GetDataProvider()
        {
            //return new SqlServerDataProvider("", SqlServerVersion.v2012);
            //return new LinqToDB.DataProvider.Informix.InformixDataProvider();
            return new LinqToDB.DataProvider.PostgreSQL.PostgreSQLDataProvider();
        }

        public static System.Data.IDbConnection GetConnection()
        {
            LinqToDB.Common.Configuration.AvoidSpecificDataProviderAPI = true;

            //var dbConnection = new SqlConnection(@"Server=.\SQL;Database=Northwind;Trusted_Connection=True;Enlist=False;");
            var dbConnection = new Npgsql.NpgsqlConnection("Server=25.92.143.78;Port=5432;User Id=postgres;Password=temporal;Database=isp;Pooling=true;");
            //var dbConnection = new IBM.Data.Informix.IfxConnection("host=10.100.8.193;protocol=onsoctcp;service=1525;server=ol_mirror;dataBase=solverfin2014;uid=informix;pwd=informix");
            //return LinqToDB.DataProvider.Informix.InformixTools.CreateDataConnection(dbConnection);
            return dbConnection;
        }*/

        public static List<ImagenCombo> ListaImagenes()
        {
            short i = 0;
            List<ImagenCombo> lista = new List<ImagenCombo>();
            foreach (var item in Imagenes.Images.Keys)
            {
                lista.Add(new ImagenCombo(item, i++));
            }
            return lista;
        }


        public static System.Drawing.Icon ObtenerIcono(string unNombreIcono)
        {
            return System.Drawing.Icon.FromHandle(new System.Drawing.Bitmap(General.Imagenes.Images[unNombreIcono]).GetHicon());
        }

        public static byte[] Image2Bytes(Image pImagen)
        {
            byte[] mImage = null;
            try
            {
                if (pImagen != null)
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        pImagen.Save(ms, pImagen.RawFormat);
                        mImage = ms.GetBuffer();
                        ms.Close();
                    }
                else { mImage = null; }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return mImage;
        }

        public static Image Bytes2Image(byte[] binario)
        {
            if (binario == null) return null;
            MemoryStream ms = new MemoryStream(binario);
            System.Drawing.Image imagen = null;
            try
            {
                imagen = System.Drawing.Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return imagen;

        }

        public static Image ObtenerImagen()
        {
            Image imagen = null;
            OpenFileDialog ofdDialogo = new OpenFileDialog();
            ofdDialogo.Filter = "Archivos de imagen (.Jpg, .Gif, .Png)|*.Jpg;*.Gif;*.Png";
            if (ofdDialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imagen = Image.FromFile(ofdDialogo.FileName);
                if (!imagen.RawFormat.Equals(ImageFormat.Jpeg)
                    && !imagen.RawFormat.Equals(ImageFormat.Gif) && !imagen.RawFormat.Equals(ImageFormat.Png))
                    MessageBox.Show("Formato de imagen no admitido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return imagen;
        }

        #endregion FUNCIONES

        #region FUNCIONES PARA MESSAGEBOX

        public static void Mensaje(string unMensaje, MessageBoxIcon icono = MessageBoxIcon.Information)
        {
            MessageBox.Show(unMensaje, "Aviso", MessageBoxButtons.OK, icono);
        }
        public static void Mensaje(string unMensaje, MessageBoxButtons botones, MessageBoxIcon icono = MessageBoxIcon.Information)
        {
            MessageBox.Show(unMensaje, "Aviso", botones, icono);
        }
        public static void Mensaje(string unMensaje, MessageBoxButtons botones, MessageBoxDefaultButton porDefault, MessageBoxIcon icono = MessageBoxIcon.Information)
        {
            MessageBox.Show(unMensaje, "Aviso", botones, icono, porDefault);
        }
        #endregion FUNCIONES PARA MESSAGEBOX

        public static string CifrarClave(string valorOriginal)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(valorOriginal);
            StringBuilder valorHash = new StringBuilder();
            data = provider.ComputeHash(data);
            for (int i = 0; i < data.Length; i++)
                valorHash.Append(data[i].ToString("x2").ToLower());

            return valorHash.ToString();
        }

        public static void ObtenerIP()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus.ToString() == "Up")
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                Console.WriteLine(ip.Address.ToString());
                        }
            }
        }

        public static void ObtenerIP1()
        {
            StringBuilder direccionesIP = new StringBuilder();
            //Obtener interfaz de red
            NetworkInterface[] arrInterfaz = NetworkInterface.GetAllNetworkInterfaces();
            //Verificamos conexiones activas
            foreach (NetworkInterface item in arrInterfaz)
            {
                if (item.OperationalStatus.ToString() == "Up")
                {
                    try
                    {
                        direccionesIP.Append(item.GetIPProperties().UnicastAddresses[1].Address.ToString().Trim());
                    }
                    catch
                    {
                        try
                        {
                            IPInterfaceProperties ipInterfaz = item.GetIPProperties();
                            direccionesIP.Append(ipInterfaz.UnicastAddresses[0].Address.ToString().Trim());
                        }
                        catch
                        {
                            direccionesIP.Append("IP NO DETECTADA");
                        }
                    }
                    break;
                }
            }
            ipLocal = direccionesIP.ToString();
            direccionesIP.Clear();
            direccionesIP = null;
        }

        #region Interfaz

        static private ToolTip globo = new ToolTip();
        public static void Interfaz(Control unControl)
        {
            foreach (Control item in unControl.Controls)
                Controles(item);
        }

        private static void Controles(Control unControl)
        {
            if (unControl.Controls.Count > 0)
                foreach (Control item in unControl.Controls)
                    Controles(item);
            else
            {
                if (unControl.Name.EndsWith("SN"))
                    SoloNumeros(unControl);

                Type tipoControl = unControl.GetType();

                if (tipoControl.Name == "ButtonX")
                {
                    unControl.MouseEnter += new EventHandler(AsignaGlobo);
                    AsignaImagen(unControl);
                }

                switch (tipoControl.Name)
                {
                    case "TextBoxX":
                        //unControl.BackColor = System.Drawing.Color.White;
                        break;
                    case "DateTimeInput":
                        AsignaColorFondoDateTimeInput(unControl);
                        break;
                    case "ComboBoxEx":
                        AsignaColorFondoComboBox(unControl);
                        break;
                }

                //if (unControl.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                //    unControl.BackColor = System.Drawing.Color.White;

                //if (unControl.GetType().ToString() == "DevComponents.Editors.DateTimeAdv.DateTimeInput")
                //    AsignaColorFondoDateTimeInput(unControl);

                //if (unControl.GetType().ToString() == "DevComponents.DotNetBar.Controls.ComboBoxEx")
                //    AsignaColorFondoComboBox(unControl);
            }
        }

        static void AsignaGlobo(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX boton = (DevComponents.DotNetBar.ButtonX)sender;

            //Asignar ToolTipText
            globo.RemoveAll();
            globo.IsBalloon = true;
            globo.ToolTipIcon = ToolTipIcon.Info;
            globo.ToolTipTitle = "Click aquí";
            globo.SetToolTip(boton, "Para " + (boton.Text.Length == 0 ? boton.Name.Substring(3) : boton.Text.ToLower()));
        }

        static void AsignaImagen(object sender)
        {
            DevComponents.DotNetBar.ButtonX boton = (DevComponents.DotNetBar.ButtonX)sender;
            boton.TextColor = System.Drawing.Color.Black;
            // Asignar Imagenes
            if (boton.Name.Contains("btnAceptar") || boton.Name.Contains("btnSeleccionar") || boton.Name.Contains("btnRegistrar"))
                boton.Image = General.Imagenes.Images["Aceptar.png"];
            if (boton.Name.Contains("btnSalir") || boton.Name.Contains("btnCancelar"))
                boton.Image = General.Imagenes.Images["Salir.png"];
            if (boton.Name.Contains("btnBuscar") || boton.Name.Contains("btnConsultar"))
                boton.Image = General.Imagenes.Images["Listar.ico"];
            if (boton.Name.Contains("btnQuitar"))
                boton.Image = General.Imagenes.Images["Eliminar.ico"];
            if (boton.Name.Contains("btnCargar"))
                boton.Image = General.Imagenes.Images["Agregar.png"];
            return;
        }

        static void AsignaColorFondoDateTimeInput(object sender)
        {
            DevComponents.Editors.DateTimeAdv.DateTimeInput calendario = (DevComponents.Editors.DateTimeAdv.DateTimeInput)sender;
            //calendario.DisabledBackColor = System.Drawing.Color.White;
            calendario.DisabledForeColor = System.Drawing.Color.Black;
            return;
        }

        static void AsignaColorFondoComboBox(object sender)
        {
            DevComponents.DotNetBar.Controls.ComboBoxEx combo = (DevComponents.DotNetBar.Controls.ComboBoxEx)sender;
            //combo.DisabledBackColor = System.Drawing.Color.White;
            combo.DisabledForeColor = System.Drawing.Color.Black;
            return;
        }

        #endregion Interfaz

        #region Validadores
        public static void QuitarSoloNumeros(Control unControl)
        {
            unControl.KeyPress -= new KeyPressEventHandler(Numeros);
        }

        public static void SoloNumeros(Control unControl)
        {
            unControl.KeyPress += new KeyPressEventHandler(Numeros);
        }

        private static void Numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar) && e.KeyChar != 13)
                e.Handled = false;
            else
                e.Handled = true;
        }

        static public void SoloDecimales(Control unControl)
        {
            unControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Decimales);
        }

        static private void Decimales(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool esDecimal = false;
            int numeroDecimales = 0;
            for (int i = 0; i < ((Control)sender).Text.Length; i++)
            {
                if (((Control)sender).Text[i] == '.' || ((Control)sender).Text[i] == ',')
                    esDecimal = true;

                if (esDecimal && numeroDecimales++ >= 5)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46 || e.KeyChar == 44)
                e.Handled = (esDecimal) ? true : false;
            else
                e.Handled = true;
        }

        public static bool ValidarCedula(string unaCedula)
        {
            if (unaCedula.Trim().Length != 10)
                return false;

            int digitoVerificador = 0;
            for (int i = 0; i < 9; i++)
            {
                int j = Convert.ToInt32(unaCedula[i].ToString());
                if ((i + 1) % 2 != 0)
                {
                    j = j * 2;
                    if (j > 9)
                        j -= 9;
                }
                digitoVerificador += j;
            }
            if (digitoVerificador % 10 != 0)
                digitoVerificador = 10 - (digitoVerificador % 10);
            else
                digitoVerificador = 0;
            if (Convert.ToInt32(unaCedula[9].ToString()) != digitoVerificador)
                return false;
            return true;
        }

        #endregion Validadores

        #region METODOS GESTION VENTANAS Y BARRAS
        private static List<Control> lista = new List<Control>();
        public static Control[] ArrayControles(Control unControl)
        {
            lista.Clear();
            for (int i = 0; i < unControl.Controls.Count; i++)
            {
                AgregaControl(unControl.Controls[i]);
            }

            return lista.ToArray();
        }

        private static void AgregaControl(Control unControl)
        {
            if (unControl.Controls.Count > 0 && unControl.GetType().BaseType.Name != "DataGridViewX" && unControl.GetType().Name != "ButtonBQ" && unControl.GetType().Name != "ConveniosPagos")
                for (int i = 0; i < unControl.Controls.Count; i++)
                {
                    AgregaControl(unControl.Controls[i]);
                }
            else
            {
                if (unControl.Name.StartsWith("_"))
                    lista.Add(unControl);
            }
        }

        public static void CargarControles1(Control unContenedor, object unObjeto, System.Reflection.PropertyInfo[] unaListaPropiedades)
        {
            object valor = null;
            if (unContenedor.Controls.Count > 0)
                for (int i = 0; i < unContenedor.Controls.Count; i++)
                {
                    CargarControles1(unContenedor.Controls[i], unObjeto, unaListaPropiedades);
                }
            else
            {
                Type tipo = unContenedor.GetType();
                if (tipo.Name == "TextBoxX" || tipo.Name == "PictureBox" || tipo.Name == "ComboBoxEx" || tipo.Name == "DateTimeInput" || tipo.Name == "CheckBox")
                    foreach (System.Reflection.PropertyInfo item in unaListaPropiedades)
                    {
                        if (unContenedor.Name.Contains(item.Name))
                        {
                            if (item.GetGetMethod() != null)
                                valor = item.GetValue(unObjeto, null);

                            switch (unContenedor.GetType().Name)
                            {
                                case "TextBoxX":
                                    unContenedor.Text = valor == null ? "" : valor.ToString();
                                    break;
                                case "PictureBox":
                                    ((PictureBox)unContenedor).Image = (Image)valor;
                                    break;
                                case "ComboBoxEx":
                                    ((ComboBox)unContenedor).SelectedValue = valor;
                                    break;
                                case "DateTimeInput":
                                    ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unContenedor).Value = (DateTime)valor;
                                    break;
                                case "CheckBox":
                                    ((CheckBox)unContenedor).Checked = (bool)valor;
                                    break;
                            }
                        }
                    }
            }
        }

        private static string ExtraeNombre(Control unControl)
        {
            if (unControl.Name.EndsWith("RO", false, null) || unControl.Name.EndsWith("SN", false, null))
                return unControl.Name.ToLower().Substring(4, unControl.Name.Length - 6);
            else
                return unControl.Name.ToLower().Substring(4, unControl.Name.Length - 4);
        }

        public static void CargarControles(Control[] unaListaControles, object unObjeto)
        {
            Control unControl = null;
            object valor = null;

            for (int i = 0; i < unaListaControles.Count(); i++)
            {
                Application.DoEvents();
                unControl = unaListaControles[i];

                Type tipo = unControl.GetType();
                if (tipo.Name == "TextBoxX" || tipo.Name == "PictureBox" || tipo.Name == "ComboBoxEx" || tipo.Name == "DateTimeInput" || tipo.Name == "CheckBox")
                {
                    object nombre = ExtraeNombre(unControl);

                    System.Reflection.PropertyInfo item = unObjeto.GetType().GetProperty(nombre.ToString());
                    if (item != null)
                    {
                        if (item.GetGetMethod() != null)
                            valor = item.GetValue(unObjeto, null);

                        switch (tipo.Name)
                        {
                            case "TextBoxX":
                                unControl.Text = valor == null ? "" : valor.ToString();
                                break;
                            case "PictureBox":
                                ((PictureBox)unControl).Image = null;
                                ((PictureBox)unControl).Image = (Image)valor;
                                break;
                            case "ComboBoxEx":
                                ((ComboBox)unControl).SelectedIndex = -1;
                                ((ComboBox)unControl).SelectedValue = valor;
                                break;
                            case "DateTimeInput":
                                ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value = (DateTime)valor;
                                break;
                            case "CheckBox":
                                ((CheckBox)unControl).Checked = (bool)valor;
                                break;
                        }
                    }
                    else
                        General.Mensaje("Propiedad '" + nombre.ToString() + "' no definida");
                }
            }
        }

        public static void LimpiarControles(Control[] unaListaControles)
        {
            Control unControl = null;
            for (int i = 0; i < unaListaControles.Count(); i++)
            {
                Application.DoEvents();
                unControl = unaListaControles[i];
                switch (unControl.GetType().Name)
                {
                    case "Label":
                        ((Label)unControl).Text = "";
                        break;
                    case "TextBoxX":
                        ((TextBox)unControl).Clear();
                        break;
                    case "PictureBox":
                        ((PictureBox)unControl).Image = null;
                        break;
                    case "ComboBoxEx":
                        ((ComboBox)unControl).SelectedIndex = -1;
                        break;
                    case "DateTimeInput":
                        ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value = General.fechaActual;
                        break;
                    case "CheckBox":
                        ((CheckBox)unControl).Checked = false;
                        break;
                    case "DgvPlus":
                        ((DataGridView)unControl).Rows.Clear();
                        break;
                }
            }
        }

        public static void ActivarControles(Control[] unaColeccionControl, bool esActivo)
        {

            for (int i = 0; i < unaColeccionControl.Count(); i++)
            {
                Application.DoEvents();
                Control unControl = unaColeccionControl[i];

                Type tipo = unControl.GetType();
                {
                    switch (tipo.Name)
                    {
                        case "TextBoxX":
                            if (!unControl.Name.EndsWith("RO"))
                                ((TextBox)unControl).ReadOnly = !esActivo;
                            else
                            {
                                TextBoxX texto = unControl as TextBoxX;
                                if (texto != null)
                                {
                                    texto.ButtonCustom.Visible = esActivo;
                                    texto.ButtonCustom2.Visible = esActivo;
                                }
                            }
                            break;
                        case "ComboBoxEx":
                            ((ComboBox)unControl).Enabled = esActivo;
                            break;
                        case "DateTimeInput":
                            ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Enabled = esActivo;
                            break;
                        case "CheckBox":
                            ((CheckBox)unControl).Enabled = esActivo;
                            break;
                        case "ButtonX":
                            unControl.Visible = esActivo;
                            break;
                        case "ButtonBQ":
                            unControl.Visible = esActivo;
                            break;
                        case "DgvPlus":
                            ((DataGridView)unControl).ReadOnly = !esActivo;
                            ((DataGridView)unControl).AllowUserToAddRows = esActivo;
                            ((DataGridView)unControl).AllowUserToDeleteRows = esActivo;
                            break;
                        case "ConveniosPagos":
                            unControl.Enabled = esActivo;
                            break;
                    }
                }
            }
        }

        public static void GuardarObjeto(Control[] unaListaControles, object unObjeto)
        {
            Control unControl = null;
            object valor = null; bool establecer = true;
            for (int i = 0; i < unaListaControles.Count(); i++)
            {
                Application.DoEvents();
                establecer = true;
                unControl = unaListaControles[i];

                Type tipo = unControl.GetType();
                if (tipo.Name == "TextBoxX" || tipo.Name == "PictureBox" || tipo.Name == "ComboBoxEx" || tipo.Name == "DateTimeInput" || tipo.Name == "CheckBox")
                {
                    object nombre = ExtraeNombre(unControl);

                    System.Reflection.PropertyInfo item = unObjeto.GetType().GetProperty(nombre.ToString());
                    if (item != null)
                    {
                        switch (tipo.Name)
                        {
                            case "TextBoxX":
                                if (!unControl.Name.EndsWith("RO"))
                                    valor = unControl.Text;
                                else
                                    establecer = false;
                                break;
                            case "PictureBox":
                                valor = ((PictureBox)unControl).Image;
                                break;
                            case "ComboBoxEx":
                                valor = ((ComboBox)unControl).SelectedValue;
                                break;
                            case "DateTimeInput":
                                valor = ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value;
                                break;
                            case "CheckBox":
                                valor = ((CheckBox)unControl).Checked;
                                break;
                        }
                        if (item.GetSetMethod() != null && establecer)
                            item.SetValue(unObjeto, valor, null);
                    }
                }
            }
        }

        private static List<TabPage> AllTabPages = new List<TabPage>();
        public static void HideTabPage(TabControl unTabControl, TabPage unTabPage)
        {
            if (unTabControl.Contains(unTabPage))
            {
                foreach (TabPage t in unTabControl.TabPages)
                {
                    if (!AllTabPages.Contains(t))
                        AllTabPages.Add(t);
                }
                unTabControl.TabPages.Remove(unTabPage);
            }
        }

        public static void ShowTabPage(TabControl unTabControl, TabPage unTabPage)
        {
            if ((AllTabPages.Contains(unTabPage)) && (!unTabControl.TabPages.Contains(unTabPage)))
                unTabControl.TabPages.Add(unTabPage);
        }

        public static void GestionBarraEnabled(EstadoBarraEnum unEstadoBarra, ToolStrip unaBarra, int totalRegistros)
        {
            foreach (object elemento in unaBarra.Items)
            {
                if (elemento.GetType().Name == "ToolStripButton" && !((ToolStripButton)elemento).Name.Contains("Filtrar"))
                {
                    ((ToolStripButton)elemento).Enabled = false;
                }
            }
            if (totalRegistros == 0 && unEstadoBarra == EstadoBarraEnum.NINGUNO)
            {
                unaBarra.Items["tsbNuevo"].Enabled = true;
                unaBarra.Items["tsbBuscar"].Enabled = true;
                unaBarra.Items["tsbActualizar"].Enabled = true;
                unaBarra.Items["tsbCerrar"].Enabled = true;
            }
            else if (totalRegistros > 0 && unEstadoBarra == EstadoBarraEnum.NINGUNO)
            {
                unaBarra.Items["tsbNuevo"].Enabled = true;
                unaBarra.Items["tsbEditar"].Enabled = true;
                unaBarra.Items["tsbBuscar"].Enabled = true;
                unaBarra.Items["tsbEliminar"].Enabled = true;
                unaBarra.Items["tsbActualizar"].Enabled = true;
                unaBarra.Items["tsbImprimir"].Enabled = true;
                unaBarra.Items["tsbCerrar"].Enabled = true;
            }

            switch (unEstadoBarra)
            {
                case EstadoBarraEnum.EXAMINANDO:
                    unaBarra.Items["tsbEditar"].Enabled = true;
                    unaBarra.Items["tsbCancelar"].Enabled = true;
                    unaBarra.Items["tsbImprimir"].Enabled = true;
                    unaBarra.Items["tsbCerrar"].Enabled = true;
                    break;
                case EstadoBarraEnum.EDITANDO:
                    unaBarra.Items["tsbCancelar"].Enabled = true;
                    unaBarra.Items["tsbGuardar"].Enabled = true;
                    unaBarra.Items["tsbActualizar"].Enabled = true;
                    unaBarra.Items["tsbCerrar"].Enabled = true;
                    break;
                case EstadoBarraEnum.BUSCANDO:
                    unaBarra.Items["tsbNuevo"].Enabled = false;
                    unaBarra.Items["tsbEliminar"].Enabled = false;
                    unaBarra.Items["tsbCancelar"].Enabled = true;
                    unaBarra.Items["tsbCerrar"].Enabled = true;
                    break;
            }
        }
        #endregion METODOS GESTION VENTANAS Y BARRAS

        //EJEMPLO LLAMAR A BUSQUEDA FLOTANTE
        //object objeto = BuscarListaCr.Instancia.Buscar("Barrios", "barrios", "id = @codigo or upper(nombre) like @nombre", "id, nombre as \"Descripcion\"", true);

        //METODO PARA GUARDAR DETALLES
        //LLAMADA
        //GeneroPr registro = new GeneroPr(1,"","");
        //respuesta = registro.GrabarLista(_objetos);

        //DEFINICION
        //public bool GrabarLista(List<object> listaObjetos)
        //{
        //    bool respuesta = false;
        //    int i = 0;
        //    object cnn = null;
        //    object trn = null;
        //    string cadenaSQL = null;
        //    List<CamposTabla> listaParametros = new List<CamposTabla>();

        //    cadenaSQL = this.obj.CadenaGuardar();
        //    listaParametros = this.obj.ListaParametros;

        //    //INICIAMOS CONEXION Y TRANSACCION
        //    cnn = Proveedor.DAO.CreaConexion();
        //    trn = Proveedor.DAO.CreaTransaccion(cnn);
        //    try
        //    {

        //        Proveedor.DAO.PreparaCMD(cadenaSQL, listaParametros);
        //        foreach (GeneroPr item in listaObjetos)
        //        {
        //            if (item.Modificado == true)
        //            {
        //                listaParametros.Clear();
        //                listaParametros.Add(new CamposTabla("id", item.Id));
        //                listaParametros.Add(new CamposTabla("nombre", item.Nombre));
        //                listaParametros.Add(new CamposTabla("abreviatura", item.Abreviatura));
        //                i = Proveedor.DAO.EjecutarCmdPreparado(listaParametros);
        //            }
        //        }
        //        Proveedor.DAO.Commit(trn);
        //    }
        //    catch (Exception ex)
        //    {
        //        Proveedor.DAO.RollBack(trn);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Proveedor.DAO.Close(cnn);
        //    }
        //    return respuesta;
        //}
    }
}
