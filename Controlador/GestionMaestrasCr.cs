using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Delegados;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Entidades;
using Proveedores;
using System.Drawing;
using System.Reflection;
//using System.Runtime.InteropServices;

namespace Controladores
{
    public class GestionMaestrasCr
    {
        /**[DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
        */

        #region PROPIEDADES
        public object ProveedorInstancia { get; set; }
        public bool requerido = false;
        private static GestionMaestrasCr instancia;
        public static GestionMaestrasCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new GestionMaestrasCr();
                return instancia;
            }
        }

        DelegadosFn objetoDelegado = new DelegadosFn();

        public ImageList Imagenes { get { return General.Imagenes; } }

        public void EstableceImagenes(ImageList listaImagenes)
        {
            General.Imagenes = listaImagenes;
        }
        #endregion PROPIEDADES

        #region DEFINICION DE EVENTOS Y DELEGADOS
        public delegate void ListadoDelegado(object sender, ViewLoadEventArgs e);
        public delegate void AfectarDelegado(object sender, AfectarObjetosEventArgs e);
        public event ListadoDelegado ListaCargadaEvent;
        public event AfectarDelegado DespuesAfectarObjetoEvent;
        public event AfectarDelegado AntesAfectarObjetoEvent;

        #endregion DEFINICION DE EVENTOS Y DELEGADOS

        #region REGISTRO DE EVENTOS
        public void RegisterView(IView view)
        {
            this.ListaCargadaEvent += new ListadoDelegado(view.VistaCargada);
            this.DespuesAfectarObjetoEvent += new AfectarDelegado(view.DespuesAfectarObjeto);
            this.AntesAfectarObjetoEvent += new AfectarDelegado(view.AntesAfectarObjeto);
        }
        public void UnregisterView(IView view)
        {
            this.ListaCargadaEvent -= new ListadoDelegado(view.VistaCargada);
            this.DespuesAfectarObjetoEvent -= new AfectarDelegado(view.DespuesAfectarObjeto);
            this.AntesAfectarObjetoEvent -= new AfectarDelegado(view.AntesAfectarObjeto);
        }
        #endregion REGISTRO DE EVENTOS

        #region FILTROS
        public void RaiseFiltrar(string modulo, string filtro, DataGridView objetoGrid, dynamic listaOriginal)
        {
            switch (modulo)
            {
                case "BarrioPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Barrio>(((IEnumerable<Barrio>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro) || x.Parroquia.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Barrio>(((IEnumerable<Barrio>)listaOriginal).ToList());
                    }
                    break;
                case "CiudadPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Canton>(((IEnumerable<Canton>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro) || x.Provincia.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Canton>(((IEnumerable<Canton>)listaOriginal).ToList());
                    }
                    break;
                case "EstadoPersonaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<EstadoPersona>(((IEnumerable<EstadoPersona>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<EstadoPersona>(((IEnumerable<EstadoPersona>)listaOriginal).ToList());
                    }
                    break;
                case "GeneroPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Genero>(((IEnumerable<Genero>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Genero>(((IEnumerable<Genero>)listaOriginal).ToList());
                    }
                    break;
                case "MenuSistemaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<MenuSistema>(((IEnumerable<MenuSistema>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro) || x.Padre.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<MenuSistema>(((IEnumerable<MenuSistema>)listaOriginal).ToList());
                    }
                    break;
                case "ParroquiaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Parroquia>(((IEnumerable<Parroquia>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Parroquia>(((IEnumerable<Parroquia>)listaOriginal).ToList());
                    }
                    break;
                case "PerfilPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Perfil>(((IEnumerable<Perfil>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Perfil>(((IEnumerable<Perfil>)listaOriginal).ToList());
                    }
                    break;
                case "ProvinciaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Provincia>(((IEnumerable<Provincia>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Provincia>(((IEnumerable<Provincia>)listaOriginal).ToList());
                    }
                    break;
                case "TipoPersonaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<TipoPersona>(((IEnumerable<TipoPersona>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<TipoPersona>(((IEnumerable<TipoPersona>)listaOriginal).ToList());
                    }
                    break;
                case "TipoSangrePr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<TipoSangre>(((IEnumerable<TipoSangre>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<TipoSangre>(((IEnumerable<TipoSangre>)listaOriginal).ToList());
                    }
                    break;
                case "PersonaPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Persona>(((IEnumerable<Persona>)listaOriginal).Where(x => x.NombreCompleto.ToUpper().Contains(filtro) || x.Identificacion.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Persona>(((IEnumerable<Persona>)listaOriginal).ToList());
                    }
                    break;
                case "UsuarioPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Usuario>(((IEnumerable<Usuario>)listaOriginal).Where(x => x.Descripcion.ToUpper().Contains(filtro) || x.Identificacion.ToUpper().Contains(filtro) || x.LoginUsuario.ToUpper().Contains(filtro) || x.Persona.NombreCompleto.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Usuario>(((IEnumerable<Usuario>)listaOriginal).ToList());
                    }
                    break;
                case "BancoPr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Banco>(((IEnumerable<Banco>)listaOriginal).Where(x => x.Nombre.ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Banco>(((IEnumerable<Banco>)listaOriginal).ToList());
                    }
                    break;
                case "CuentaContablePr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<CuentaContable>(((IEnumerable<CuentaContable>)listaOriginal).Where(x => x.Codigo.Contains(filtro) || x.CodigoPadre.Contains(filtro) || x.Nombre.ToUpper().Contains(filtro) || x.Padre.ToString().ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<CuentaContable>(((IEnumerable<CuentaContable>)listaOriginal).ToList());
                    }
                    break;
                case "ContablePr":
                    {
                        if (filtro != string.Empty)
                            objetoGrid.DataSource = new BindingList<Contable>(((IEnumerable<Contable>)listaOriginal).Where(x => x.Numero.ToString().Contains(filtro) || x.TipoContable.ToString().ToUpper().Contains(filtro) || x.Beneficiario.ToString().ToUpper().Contains(filtro) || x.UsuarioRegistra.ToString().ToUpper().Contains(filtro) || x.UsuarioModifica.ToString().ToUpper().Contains(filtro)).ToList());
                        else
                            objetoGrid.DataSource = new BindingList<Contable>(((IEnumerable<Contable>)listaOriginal).ToList());
                    }
                    break;
                default:
                    break;
            }

        }
        #endregion FILTROS

        #region DISPARADORES DE EVENTOS (RAISES Y ON)
        public void OnListaCargada(object sender, ViewLoadEventArgs e)
        {
            if (ListaCargadaEvent != null)
            {
                ListaCargadaEvent(sender, e);
            }
        }

        public void OnDespuesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (DespuesAfectarObjetoEvent != null)
            {
                DespuesAfectarObjetoEvent(sender, e);
            }
        }

        public object RaiseListLoad(object sender, string modulo, int rowIndex, int colIndex = 0)
        {
            int totalLista = 0;
            object proveedorInstancia = null;
            try
            {

                proveedorInstancia = CargaGrid(modulo, ((DataGridView)sender));
                totalLista = ((DataGridView)sender).RowCount;
                if (ListaCargadaEvent != null)
                {
                    ViewLoadEventArgs argumentos = new ViewLoadEventArgs(modulo);

                    argumentos.ColIndex = colIndex;
                    argumentos.RowCount = totalLista;
                    //DEFINIMOS ROWINDEX
                    if (totalLista <= rowIndex)
                        argumentos.RowIndex = totalLista - 1;
                    else
                        if (totalLista > rowIndex)
                            argumentos.RowIndex = rowIndex;

                    ListaCargadaEvent(sender, argumentos);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    General.Mensaje(ex.Message, MessageBoxIcon.Exclamation);
                else
                    General.Mensaje(ex.InnerException.Message, MessageBoxIcon.Exclamation);
                    
            }

            return proveedorInstancia;
        }

        public void RaiseGrabarLista(object sender)
        {
            AfectarObjetosEventArgs e = new AfectarObjetosEventArgs();
            if (AntesAfectarObjetoEvent != null)
            {
                AntesAfectarObjetoEvent(sender, e);
            }

            if (DespuesAfectarObjetoEvent != null)
            {
                objetoDelegado.ProveedorInstancia = this.ProveedorInstancia;
                e.Completado = objetoDelegado.ObtenerGrabarLista().Invoke(e.Modulo, e.Lista);

                DespuesAfectarObjetoEvent(sender, e);
            }
        }

        public void RaiseGrabar(object sender)
        {
            AfectarObjetosEventArgs e = new AfectarObjetosEventArgs();
            if (AntesAfectarObjetoEvent != null)
            {
                AntesAfectarObjetoEvent(sender, e);
            }

            if (DespuesAfectarObjetoEvent != null)
            {
                objetoDelegado.ProveedorInstancia = this.ProveedorInstancia;
                e.Completado = objetoDelegado.ObtenerGestionObjeto("grabar").Invoke(e.Modulo, e.Objeto);

                DespuesAfectarObjetoEvent(sender, e);
            }
        }

        public void RaiseBorrar(object sender)
        {
            AfectarObjetosEventArgs e = new AfectarObjetosEventArgs();
            if (AntesAfectarObjetoEvent != null)
            {
                AntesAfectarObjetoEvent(sender, e);
            }

            if (DespuesAfectarObjetoEvent != null)
            {
                objetoDelegado.ProveedorInstancia = this.ProveedorInstancia;
                e.Completado = objetoDelegado.ObtenerGestionObjeto("borrar").Invoke(e.Modulo, e.Objeto);

                DespuesAfectarObjetoEvent(sender, e);
            }

        }

        public void RaiseImprimir(DataGridView unObjetoGrid, string unModulo)
        {
            Type tipoControlador = Type.GetType("Controladores." + unModulo.Replace("Pr", "Cr"));
            MethodInfo metodoImprimir = tipoControlador.GetMethod("ImprimirLista");
            metodoImprimir.Invoke(Activator.CreateInstance(tipoControlador), new[] { unObjetoGrid.DataSource });

            /*switch (unModulo)
            {
                case "ContablePr":
                    ContableCr proveedor = new ContableCr();
                    proveedor.ImprimirLista(unObjetoGrid.DataSource);
                    break;
            }*/
        }
        #endregion DISPARADORES DE EVENTOS (RAISES)

        #region ORDENADORES
        /// <summary>
        /// Clase usada para ejecucion de Foreach de lista generica haciendo uso de 
        /// delegados
        /// </summary>
        /// <typeparam name="T">Tipo de dato que se pasa con refleccion</typeparam>
        private class Adapter<T>
        {
            private readonly Action<object> act;

            public Adapter(Action<object> act)
            {
                this.act = act;
            }

            public void Do(T o)
            {
                act(o);
            }
        }

        public void OrdenarGrid(DataGridView objetoGrid, int columnIndex, string modulo)
        {
            try
            {

                //OBTENER LOS DETALLES DE LA COLUMNA ACTUAL (NOMBRE Y DIRECCION DE ORDENADO)
                string strColumnName = objetoGrid.Columns[columnIndex].Name;
                SortOrder strSortOrder = getSortOrder(objetoGrid, columnIndex);

                //TOLIST()
                //OBTENEMOS LOS TIPOS (BINDINGLIST<> DEL DATASOURCE, IENUMERABLE<> DEL BINDINGLIST, TIPOENTIDAD)
                Type tipoListaGrid = objetoGrid.DataSource.GetType();
                Type iListaGrid = tipoListaGrid.GetInterface(typeof(IEnumerable<>).Name);
                Type tipoEntidad = iListaGrid.GetGenericArguments()[0];
                //OBTENEMOS EL METODO GENERICO TOLIST PARA OBTENER LA LISTA DEL BINDINGLIST (EJECUCION BINDINGLIST.TOLIST())
                MethodInfo metodoInfo = typeof(Enumerable).GetMethod("ToList");
                MethodInfo metodoGenerico = metodoInfo.MakeGenericMethod(tipoEntidad);
                object listaConvertida = metodoGenerico.Invoke(metodoInfo, new object[] { objetoGrid.DataSource });

                //SORT()
                //CREAMOS INSTANCIA DEL COMPARADORGENERICO
                object comparador = Activator.CreateInstance(
                    typeof(ComparadorGenerico<>).MakeGenericType(tipoEntidad),
                    new object[] { strColumnName.Replace("col", ""), strSortOrder, null });
                //OBTENEMOS EL METODO 'SORT()' DE LA LISTA GENERICA (LIST<>) Y LO EJECUTAMOS PARA ORDENAR
                metodoInfo = listaConvertida.GetType().GetMethod("Sort", new Type[] { comparador.GetType() });
                metodoInfo.Invoke(listaConvertida, new[] { comparador });

                //CLEAR()
                //OBTENEMOS EL METODO 'CLEAR()' DEL BINDINGLIST Y LO EJECUTAMOS PARA BORRAR
                metodoInfo = tipoListaGrid.GetMethod("Clear");
                metodoInfo.Invoke(objetoGrid.DataSource, null);

                //ADD()
                //OBTENEMOS EL METODO 'ADD()' DEL BINDINGLIST PARA AGREGAR LOS ITEMS DE LA LISTA ORDENADA
                metodoInfo = tipoListaGrid.GetMethod("Add");
                //CREAMOS UN OBJETO ACCION QUE EJECUTARÁ EL METODO 'ADD()' DENTRO DEL FOREACH DE LA LISTA
                Action<object> addDelegado = o => metodoInfo.Invoke(objetoGrid.DataSource, new[] { o });
                //CREAMOS LA INSTANCIA DE LA ACCION Y OBTENEMOS EL METODO 'DO()' DEL MISMO
                object adapter = Activator.CreateInstance(typeof(Adapter<>).MakeGenericType(tipoEntidad), addDelegado);
                MethodInfo metodoDo = adapter.GetType().GetMethod("Do");
                //CREAMOS EL DELEGADO A PARTIR DEL OBJETO ACCION PARA EL AGREGADO DE OBJETOS
                Type tipoAccion = typeof(Action<>).MakeGenericType(tipoEntidad);
                Delegate adaptadorDelegado = Delegate.CreateDelegate(tipoAccion, adapter, metodoDo);
                //OBTENEMOS EL METODO 'FOREACH()' DE LA LISTA GENERICA (LIST<>) Y LO EJECUTAMOS PARA AGREGAR LOS ITEMS AL BINDINGLIST
                MethodInfo foreachMethod = listaConvertida.GetType().GetMethod("ForEach");
                foreachMethod.Invoke(listaConvertida, new object[] { adaptadorDelegado });

                /*switch (modulo)
                {
                    case "BarrioPr":
                        List<Barrio> lstBarrios = ((IEnumerable<Barrio>)objetoGrid.DataSource).ToList();
                        lstBarrios.Sort(new ComparadorGenerico<Barrio>(strColumnName.Replace("col", ""), strSortOrder, null));
                        System.ComponentModel.BindingList<Barrio> blsBarrios = ((System.ComponentModel.BindingList<Barrio>)objetoGrid.DataSource);
                        blsBarrios.Clear();
                        lstBarrios.ForEach(delegate(Barrio x) { blsBarrios.Add(x); });
                        objetoGrid.DataSource = null;
                        objetoGrid.DataSource = blsBarrios;
                        break;
                    case "ContablePr":
                        List<Contable> lstContable = ((IEnumerable<Contable>)objetoGrid.DataSource).ToList();
                        lstContable.Sort(new ComparadorGenerico<Contable>(strColumnName.Replace("col", ""), strSortOrder, null));
                        //listaContables.Sort(new IContableComparer(strColumnName, strSortOrder));
                        System.ComponentModel.BindingList<Contable> blsContable = ((System.ComponentModel.BindingList<Contable>)objetoGrid.DataSource);
                        blsContable.Clear();
                        lstContable.ForEach(delegate(Contable x) { blsContable.Add(x); });
                        objetoGrid.DataSource = null;
                        objetoGrid.DataSource = blsContable;
                        break;
                    case "MenuSistemaPr":
                        List<MenuSistema> lstMenus = ((IEnumerable<MenuSistema>)objetoGrid.DataSource).ToList();
                        lstMenus.Sort(new ComparadorGenerico<MenuSistema>(strColumnName.Replace("col", ""), strSortOrder, null));
                        System.ComponentModel.BindingList<MenuSistema> blsMenus = ((System.ComponentModel.BindingList<MenuSistema>)objetoGrid.DataSource);
                        blsMenus.Clear();
                        lstMenus.ForEach(delegate(MenuSistema x) { blsMenus.Add(x); });
                        objetoGrid.DataSource = null;
                        objetoGrid.DataSource = blsMenus;
                        break;
                }*/
                objetoGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection = strSortOrder;

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    General.Mensaje(ex.Message);
                else
                    General.Mensaje(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// OBTENER EL ORDENADO ACTUAL DE LA COLUMNA Y DEVOLVERLO
        /// ESTABLECER EL NUEVO ORDENADO PARA LAS COLUMNAS
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns>ORDENADO DE LA COLUMNA ACTUAL</returns>
        private SortOrder getSortOrder(DataGridView objetoGrid, int columnIndex)
        {
            if (objetoGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                objetoGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                objetoGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                objetoGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }
        #endregion ORDENADORES

        #region FUNCIONES GENERALES
        private object CargaGrid(string modulo, DataGridView objetoGrid)
        {
            objetoDelegado.ProveedorInstancia = this.ProveedorInstancia;
            return objetoDelegado.ObtenerEstructuraGrid(modulo, objetoGrid);
        }

        public void ControlEdicionGrid(DataGridView unGrid)
        {
            if (unGrid.CurrentRow != null)
                if (unGrid.CurrentRow.Index == unGrid.NewRowIndex)
                {
                    unGrid.CancelEdit();
                    unGrid.EndEdit();
                }
                else
                    unGrid.EndEdit();
            requerido = false;
            int c = 0, f = 0;
            for (f = 0; f < unGrid.RowCount - 1; f++)
                for (c = 0; c < unGrid.ColumnCount - 1; c++)
                    if (unGrid.Columns[c].HeaderText.Contains('.'))
                        if ((unGrid[c, f].Value == null) || (unGrid[c, f].Value.ToString().Trim() == General.itemCero))
                        {
                            unGrid[c, f].Style.ForeColor = System.Drawing.Color.White;
                            unGrid[c, f].Style.BackColor = System.Drawing.Color.Red;
                            requerido = true;
                        }
        }

        public UserControl CargarControlUsuario(string unNombreControl)
        {
            try
            {
                Type unTipo = null;
                object unControl = null;
                unTipo = Type.GetType("Controladores.ControlesUsuario." + unNombreControl + ", Controladores");
                if (unTipo != null)
                    unControl = Activator.CreateInstance(unTipo);
                else
                    throw new Exception("Instancia de objeto '" + unNombreControl + "' no definida");

                UserControl objeto = (UserControl)unControl;
                return objeto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion FUNCIONES GENERALES
    }

    #region INTERFAZ PARA GESTIONAR EVENTOS EN MAESTRAS
    //INTERFAZ PARA GESTIONAR EVENTOS
    public interface IView
    {
        //EVENTOS PARA VISTAS
        void VistaCargada(object sender, ViewLoadEventArgs e);
        void AntesAfectarObjeto(object sender, AfectarObjetosEventArgs e);
        void DespuesAfectarObjeto(object sender, AfectarObjetosEventArgs e);
    }
    #endregion INTERFAZ PARA GESTIONAR EVENTOS EN MAESTRAS

    #region INTERFAZ PARA CONTROLES DE USUARIOS
    //INTERFAZ PARA CONTROLES DE USUARIOS
    public interface IControlesUsuario
    {
        object Objeto { get; set; }
        string Modulo { get; set; }
        void OnDobleClick();
    }
    #endregion INTERFAZ PARA CONTROLES DE USUARIOS

    #region ARGUMENTOS PARA EVENTOS
    public class ViewLoadEventArgs
    {
        //VARIABLES
        private string modulo;
        private int _rowCount;
        private int _rowIndex;
        private int _colIndex;
        private List<object> listaObjetos;
        private List<object> listaValores;

        public List<object> ListaObjetos
        { get { return listaObjetos; } set { listaObjetos = value; } }

        public List<object> ListaValores
        { get { return listaValores; } set { listaValores = value; } }

        public string Modulo
        { get { return modulo; } set { modulo = value; } }

        public int RowCount
        { get { return _rowCount; } set { _rowCount = value; } }

        public int RowIndex
        { get { return _rowIndex; } set { _rowIndex = value; } }

        public int ColIndex
        { get { return _colIndex; } set { _colIndex = value; } }

        //CONTRUCTORES
        public ViewLoadEventArgs() { }
        public ViewLoadEventArgs(string _modulo)
        {
            this.modulo = _modulo;
        }

        public ViewLoadEventArgs(string _modulo, int rowCount, int rowIndex, int colIndex)
        {
            this.modulo = _modulo;
            this._rowCount = rowCount;
            this._rowIndex = rowIndex;
            this._colIndex = colIndex;
        }
    }

    public class AfectarObjetosEventArgs
    {
        //VARIABLES
        private short accion;
        private bool completado;
        private object _objeto;
        private string _modulo;
        private int _rowIndex = -1;
        private int _colIndex = -1;
        private object _lista;
        private List<object> _listaValores;

        public short Accion { get { return accion; } set { accion = value; } }
        public bool Completado { get { return completado; } set { completado = value; } }
        public object Objeto { get { return _objeto; } set { _objeto = value; } }
        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public object Lista { get { return _lista; } set { _lista = value; } }
        public List<object> ListaValores { get { return _listaValores; } set { _listaValores = value; } }
        public int RowIndex { get { return _rowIndex; } set { _rowIndex = value; } }
        public int ColIndex { get { return _colIndex; } set { _colIndex = value; } }

        //CONTRUCTORES
        public AfectarObjetosEventArgs() { }
        public AfectarObjetosEventArgs(string modulo, object objeto, int rowIndex, int colIndex)
        {
            this._modulo = modulo;
            this._objeto = objeto;
            this._rowIndex = rowIndex;
            this._colIndex = colIndex;
        }
        public AfectarObjetosEventArgs(string modulo, object objeto, int rowIndex, int colIndex, object lista)
        {
            this._modulo = modulo;
            this._objeto = objeto;
            this._lista = lista;
            this._rowIndex = rowIndex;
            this._colIndex = colIndex;
        }
        public AfectarObjetosEventArgs(string modulo, object objeto, object lista)
        {
            this._modulo = modulo;
            this._objeto = objeto;
            this._lista = lista;
        }
    }

    #endregion ARGUMENTOS PARA EVENTOS
}
