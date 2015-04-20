using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Estructura;
using System.Collections;

namespace Delegados
{

    public class DelegadosFn
    {
        public object ProveedorInstancia { get; set; }

        private const string errorTipo = "No se ha especificado proveedor para instancia de maestras";
        public delegate bool DelegadoGrabar(string modulo, object objeto);
        public delegate bool DelegadoBorrar(string modulo, object objeto);
        public delegate bool DelegadoBorraL(string modulo, IList lista);
        public delegate bool DelegadoFiltro(object unaLista, string unTexto);

        object cnn; object trn; Type unTipo; object unObjeto; MethodInfo method;

        #region FUNCIONES DELEGADAS
        public DelegadoGrabar ObtenerGrabarLista()
        {
            DelegadoGrabar objDelegado = GrabarListas;

            return objDelegado;
        }

        public DelegadoBorraL ObtenerBorrarLista()
        {
            DelegadoBorraL objDelegado = BorrarLista;

            return objDelegado;
        }

        public DelegadoBorrar ObtenerGestionObjeto(string opcion)
        {
            DelegadoBorrar objDelegado = null;
            if (opcion == "grabar")
                objDelegado = GrabarObjeto;
            else if (opcion == "borrar")
                objDelegado = BorrarObjeto;

            return objDelegado;
        }

        public object ObtenerEstructuraGrid(string opcion, DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            unObjeto = null; method = null;
            Type unTipo = Type.GetType("Proveedores." + opcion + ",Proveedores");
            if (unTipo == null)
                throw new Exception(errorTipo, new Exception(errorTipo));
            if (this.ProveedorInstancia != null)
                if (unTipo == this.ProveedorInstancia.GetType())
                    unObjeto = this.ProveedorInstancia;
            if (unObjeto == null)
                //unObjeto = Activator.CreateInstance(unTipo);
                unObjeto = unTipo.GetProperty("Instancia").GetValue(null, null);
            method = unTipo.GetMethod("ArmarGrid", BindingFlags.Instance | BindingFlags.Public);
            method.Invoke(unObjeto, new object[] { objetoGrid, expresion, parametros });
            //unObjeto = null;
            method = null;
            return unObjeto;

        }

        public DelegadoFiltro ObtenerFiltro()
        {
            DelegadoFiltro objDelegado = Filtrar;

            return objDelegado;
        }
        #endregion FUNCIONES DELEGADAS

        #region FUNCIONES Y METODOS PARA DELEGADOS
        /*private List<object> ListaObjetos(string modulo, string valorWhere = null)
        {
            List<object> lista = null;
            unTipo = Type.GetType("Proveedores." + modulo + ", Proveedores"); unObjeto = Activator.CreateInstance(unTipo);
            method = unTipo.GetMethod("Registros", BindingFlags.Instance | BindingFlags.Public);
            if (valorWhere == null)
                lista = (List<object>)method.Invoke(unObjeto, null);
            else
                lista = (List<object>)method.Invoke(unObjeto, new[] { valorWhere });
            unObjeto = null; unTipo = null; method = null;
            return lista;
        }*/

        //[System.Diagnostics.DebuggerHidden]
        private bool GrabarListas(string modulo, object objeto)
        {
            bool respuesta = false; int i = 0;
            try
            {
                unTipo = Type.GetType("Proveedores." + modulo + ", Proveedores");
                //if (this.ProveedorInstancia != null)
                //    if (unTipo == this.ProveedorInstancia.GetType())
                //        unObjeto = this.ProveedorInstancia;
                //if (unObjeto == null)
                unObjeto = unTipo.GetProperty("Instancia").GetValue(null, null);

                //unTipo = Type.GetType("Proveedores." + modulo + ", Proveedores");
                //if (this.ProveedorInstancia != null)
                //    if (unTipo == this.ProveedorInstancia.GetType())
                //        unObjeto = this.ProveedorInstancia;
                //if (unObjeto == null)
                //    unObjeto = Activator.CreateInstance(unTipo);

                //OBTENEMOS CADENA SQL PARA GUARDAR

                //List<IMaestras> lista = ((IEnumerable<IMaestras>)objeto).Where(x => x.Modificado == true).ToList();

                //if (lista.Count() > 0)
                {
                    //method = unTipo.GetMethod("MkConn", BindingFlags.Instance | BindingFlags.Public); cnn = method.Invoke(unObjeto, null);
                    //method = unTipo.GetMethod("MkTran", BindingFlags.Instance | BindingFlags.Public); trn = method.Invoke(unObjeto, new object[] { cnn });
                    //method = unTipo.GetMethods().Where(x => x.Name.Contains("Grabar") && x.ToString().Contains("IEnumerable")).SingleOrDefault();
                    method = unTipo.GetMethod("Grabar", new Type[] { objeto.GetType() });
                    //if (method == null)
                    //    throw new Exception(string.Format("Metodo \"Grabar(IEnumerable({0}))\" no definido para el tipo \"{1}\"", unTipo.Name.Replace("Pr", ""), unTipo.Name));
                    //if (method == null)
                    //    method = unTipo.GetMethod("Grabar", BindingFlags.Instance | BindingFlags.Public);

                    //foreach (object item in lista)
                    //{
                    //    //i = (int)method.Invoke(unObjeto, new object[] { item, cnn, trn }); if (i > 0) respuesta = true;
                    //    i = (int)method.Invoke(unObjeto, new object[] { item }); if (i > 0) respuesta = true;
                    //}

                    i = (int)method.Invoke(unObjeto, new object[] { objeto }); if (i > 0) respuesta = true;

                    //lista = null;
                    //method = unTipo.GetMethod("Commit", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                //method = unTipo.GetMethod("Rollback", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            finally
            {
                //method = unTipo.GetMethod("CerrarConn", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { cnn });
                cnn = null; trn = null; unTipo = null; method = null; //unObjeto = null; 
            }
            return respuesta;
        }

        [System.Diagnostics.DebuggerHidden]
        private bool GrabarObjeto(string modulo, object objeto)
        {
            bool respuesta = false; int i = 0;
            try
            {
                unTipo = Type.GetType("Proveedores." + modulo + ", Proveedores");
                if (unTipo == null)
                    throw new Exception(errorTipo, new Exception(errorTipo));

                if (this.ProveedorInstancia != null)
                    if (unTipo == this.ProveedorInstancia.GetType())
                        unObjeto = this.ProveedorInstancia;
                if (unObjeto == null)
                    //unObjeto = Activator.CreateInstance(unTipo);
                    unObjeto = unTipo.GetProperty("Instancia").GetValue(null, null);

                method = unTipo.GetMethod("MkConn", BindingFlags.Instance | BindingFlags.Public); cnn = method.Invoke(unObjeto, null);
                method = unTipo.GetMethod("MkTran", BindingFlags.Instance | BindingFlags.Public); trn = method.Invoke(unObjeto, new object[] { cnn });
                method = unTipo.GetMethod("Grabar", BindingFlags.Instance | BindingFlags.Public);
                i = (int)method.Invoke(unObjeto, new object[] { objeto, cnn, trn });
                method = unTipo.GetMethod("Commit", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
            }
            catch (Exception ex)
            {
                respuesta = false;
                method = unTipo.GetMethod("Rollback", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                method = unTipo.GetMethod("CerrarConn", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { cnn });
                cnn = null; trn = null; unObjeto = null; unTipo = null;
            }
            if (i > 0) respuesta = true;
            return respuesta;
        }

        static readonly MethodInfo CastMethod = typeof(Enumerable).GetMethod("Cast");
        static readonly MethodInfo ToListMethod = typeof(Enumerable).GetMethod("ToList");

        [System.Diagnostics.DebuggerHidden]
        private bool BorrarLista(string modulo, IList lista)
        {
            bool respuesta = false;
            int i = 0;
            try
            {
                if (lista.Count == 0)
                    return respuesta;

                Type tipoEntidad = lista[0].GetType();
                var castItems = CastMethod.MakeGenericMethod(new Type[] { tipoEntidad }).Invoke(null, new object[] { lista });
                var list = ToListMethod.MakeGenericMethod(new Type[] { tipoEntidad }).Invoke(null, new object[] { castItems });
                unTipo = Type.GetType("Proveedores.Extenciones, Proveedores");
                if (unTipo == null)
                    throw new Exception(errorTipo, new Exception(errorTipo));

                MethodInfo method1 = unTipo.GetMethod("BorrarListaT", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(new Type[] { tipoEntidad });
                i = (int)method1.Invoke(null, new object[] { list });
            }
            catch (Exception ex)
            {
                respuesta = false;
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                cnn = null; trn = null; unObjeto = null; unTipo = null;
            }
            if (i > 0) respuesta = true;
            return respuesta;
        }

        //[System.Diagnostics.DebuggerHidden]
        private bool BorrarObjeto(string modulo, object objeto)
        {
            bool respuesta = false;
            int i = 0;
            try
            {
                unTipo = Type.GetType("Proveedores." + modulo + ", Proveedores");
                if (unTipo == null)
                    throw new Exception(errorTipo, new Exception(errorTipo));

                if (this.ProveedorInstancia != null)
                    if (unTipo == this.ProveedorInstancia.GetType())
                        unObjeto = this.ProveedorInstancia;
                if (unObjeto == null)
                    unObjeto = Activator.CreateInstance(unTipo);

                //method = unTipo.GetMethod("MkConn", BindingFlags.Instance | BindingFlags.Public); cnn = method.Invoke(unObjeto, null);
                //method = unTipo.GetMethod("MkTran", BindingFlags.Instance | BindingFlags.Public); trn = method.Invoke(unObjeto, new object[] { cnn });
                method = unTipo.GetMethod("Borrar", new Type[] { objeto.GetType() });
                i = (int)method.Invoke(unObjeto, new object[] { objeto });
                //method = unTipo.GetMethod("Commit", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
            }
            catch (Exception ex)
            {
                respuesta = false;
                //method = unTipo.GetMethod("Rollback", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { trn });
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                //method = unTipo.GetMethod("CerrarConn", BindingFlags.Instance | BindingFlags.Public); method.Invoke(unObjeto, new object[] { cnn });
                cnn = null; trn = null; unObjeto = null; unTipo = null;
            }
            if (i > 0) respuesta = true;
            return respuesta;
        }

        //[System.Diagnostics.DebuggerHidden]
        private bool Filtrar(object unaLista, string unTexto)
        {
            bool respuesta = false;
            int i = 0;
            try
            {
                unTipo = Type.GetType("ModeloDB.SoporteList, Entidades");
                if (unTipo == null)
                    throw new Exception(errorTipo);

                Type unTipoE = unaLista.GetType().GetGenericArguments()[0];

                method = unTipo.GetMethod("Filtrar");
                if (method != null)
                    method = method.MakeGenericMethod(new Type[] { unTipoE });

                if (method != null)
                {
                    respuesta = (bool)method.Invoke(null, new object[] { unaLista, unTexto });
                    //respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                cnn = null; trn = null; unObjeto = null; unTipo = null;
            }
            if (i > 0) respuesta = true;
            return respuesta;
        }
        #endregion FUNCIONES Y METODOS DELEGADOS

    }


}
