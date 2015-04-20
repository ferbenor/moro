using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using LinqToDB;
using ModeloDB;
using System.ComponentModel;

namespace Proveedores
{
    public static class Extenciones
    {
        #region EXTENCIONES (UTIL)

        public static T Cast<T>(this object o)
        {
            return (T)o;
        }

        [System.Diagnostics.DebuggerHidden]
        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                UnaryExpression ubody = null;

                BinaryExpression bbody = propertyLambda.Body as BinaryExpression;
                if (bbody != null)
                    ubody = (UnaryExpression)bbody.Left;
                else
                    ubody = (UnaryExpression)propertyLambda.Body;

                member = ubody.Operand as MemberExpression;
            }
            if (member == null)
                throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format("Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }

        public static object ToNullableExpression<T, V>(this Expression<Func<T, V>> source, ITable<T> db) where V : struct
        {
            //VERIFICAMOS QUE EXISTA LA FUENTE
            if (source == null)
                throw new ArgumentNullException("source");
            //CONVERTIMOS LA EXPRESION EN EXPRESION NULL
            var body = Expression.Convert(source.Body, typeof(V?));
            //EXTRAEMOS PARAMETROS
            var parameters = source.Parameters;
            //EJECUTAMOS SENTENCIA MAX CON LA NUEVA EXPRESION Y DEVOLVEMOS EL VALOR MAXIMO O EN SU CASO NULL
            return db.Max(Expression.Lambda<Func<T, V?>>(body, parameters));
        }
        #endregion EXTENCIONES (UTIL)

        #region EXTENCIONES (GESTION OBJETOS)

        [System.Diagnostics.DebuggerHidden]
        public static int GrabarObjetoT<T, V>(this T objeto, Expression<Func<T, V>> propiedadMax) where T : Instrumental1
        {
            int i = 0;
            PropertyInfo campo = null;
            using (ispDB db = new ispDB())
            {
                try
                {
                    //DEFINIMOS VALOR DEFAULT PARA 'N' (VALOR MAX DE LA TABLA SEGUN EXPRESION)
                    object n = default(V);
                    db.BeginTransaction();
                    if (propiedadMax != null)
                    {
                        //OBTENER CAMPO SEGUN EXPRESION
                        campo = GetPropertyInfo(objeto, propiedadMax);
                        //CONVERTIR EXPRESION EN EXPRESION NULL PARA OBTENER NULL EN CASOS QUE HO HAY REGISTROS
                        n = typeof(Extenciones).GetMethod("ToNullableExpression")
                            .MakeGenericMethod(new Type[] { typeof(T), typeof(V) })
                            .Invoke(null, new object[] { propiedadMax, db.GetTable<T>() });
                        //n = db.GetTable<T>().Max(propiedadMax);
                        //SI REGISTRO CONTIENE CERO EN SU CAMPO SEGUN EXPRESION SE ASIGNA EL VALOR SUMANDO 1
                        if (campo.GetValue(objeto, null).Equals(default(V)))
                        {
                            n = Calculator<V>.Add((V)n, (V)Convert.ChangeType(1, typeof(V)));
                            campo.SetValue(objeto, n, null);
                        }
                    }
                    //ALMACENAMOS EL REGISTRO
                    i = db.InsertOrReplace(objeto);
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        [System.Diagnostics.DebuggerHidden]
        public static int GrabarListaT<T, V>(this IEnumerable<T> lista, Expression<Func<T, V>> propiedadMax) where T : Instrumental1
        {
            int i = 0; int x = 0;
            PropertyInfo campo = null;
            if (lista.Count() == 0)
                return 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    object n = default(V);
                    db.BeginTransaction();
                    if (propiedadMax != null)
                    {
                        campo = GetPropertyInfo(lista.ElementAt(0), propiedadMax);
                        n = typeof(Extenciones).GetMethod("ToNullableExpression")
                            .MakeGenericMethod(new Type[] { typeof(T), typeof(V) })
                            .Invoke(null, new object [] { propiedadMax, db.GetTable<T>() });
                        //n = db.GetTable<T>().Max(expr);
                        if (n == null)
                            n = default(V);
                    }
                    foreach (T item in lista)
                    {
                        if (propiedadMax != null)
                        {
                            if (campo.GetValue(item, null).Equals(default(V)))
                            {
                                n = Calculator<V>.Add((V)n, (V)Convert.ChangeType(1, typeof(V)));
                                campo.SetValue(item, n, null);
                            }
                        }
                        i = db.InsertOrReplace(item);
                        if (i == 0)
                            i = x;
                    }
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        [System.Diagnostics.DebuggerHidden]
        public static int GrabarAsignacion<T>(this List<T> lista, string expresion, params object[] parametros) where T : Instrumental1
        {
            int i = 0; int x = 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    db.GetTable<T>().Where(expresion, parametros).Delete();
                    int total = lista.Count();
                    for (int ix = 0; ix < total; ix++)
                    {
                        T objeto = lista.ElementAt(ix);
                        x = db.Insert<T>(objeto);
                        if (i == 0)
                            i = x;
                    }
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        [System.Diagnostics.DebuggerHidden]
        public static int GrabarDetalle<T>(this IEnumerable<T> lista, string expresionDelete, params object[] parametros) where T : Instrumental1
        {
            int i = 0; int x = 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    db.GetTable<T>().Where(expresionDelete, parametros).Delete();
                    int total = lista.Count();
                    for (int ix = 0; ix < total; ix++)
                    {
                        T objeto = lista.ElementAt(ix);
                        x = db.Insert<T>(objeto);
                        if (i == 0)
                            i = x;
                    }
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    i = 0;
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        [System.Diagnostics.DebuggerHidden]
        public static int BorrarObjetoT<T>(this T objeto) where T : Instrumental1
        {
            int i = 0;

            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    i = db.Delete(objeto);
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        [System.Diagnostics.DebuggerHidden]
        public static int BorrarListaT<T>(this List<T> lista) where T : Instrumental1
        {
            int i = 0; int x = 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    foreach (T item in lista)
                    {
                        i = db.Delete<T>(item);
                        if (i == 0)
                            i = x;
                    }
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }

        #endregion EXTENCIONES (GESTION OBJETOS)

        #region EXTENCIONES (BINDINGLISTVIEW)

        public static object ObjetoBLV(this object Obj)
        {
            if (Obj == null)
                return null;
            //OBTENEMOS LOS TIPOS (BINDINGLIST<> DEL DATASOURCE, IENUMERABLE<> DEL BINDINGLIST, TIPOENTIDAD)
            Type tipoListaGrid = Obj.GetType();
            Type tipoEntidad = tipoListaGrid.GetGenericArguments()[0];
            //OBTENEMOS EL METODO GENERICO TOLIST PARA OBTENER LA LISTA DEL BINDINGLIST (EJECUCION BINDINGLIST.TOLIST())
            MethodInfo metodoInfo = typeof(SoporteList).GetMethod("ObtenerObjetoBLV");
            MethodInfo metodoGenerico = metodoInfo.MakeGenericMethod(tipoEntidad);
            object listaConvertida = metodoGenerico.Invoke(metodoInfo, new object[] { Obj });

            return listaConvertida;
        }

        public static object ListaBLV(this object Obj, bool modificados = false)
        {
            //OBTENEMOS LOS TIPOS (BINDINGLIST<> DEL DATASOURCE, IENUMERABLE<> DEL BINDINGLIST, TIPOENTIDAD)
            Type tipoListaGrid = Obj.GetType();
            Type tipoEntidad = tipoListaGrid.GetGenericArguments()[0];
            //OBTENEMOS EL METODO GENERICO TOLIST PARA OBTENER LA LISTA DEL BINDINGLIST (EJECUCION BINDINGLIST.TOLIST())
            MethodInfo metodoInfo = typeof(SoporteList).GetMethod("ObtenerLista");
            MethodInfo metodoGenerico = metodoInfo.MakeGenericMethod(tipoEntidad);
            object listaConvertida = metodoGenerico.Invoke(metodoInfo, new object[] { Obj, modificados });

            return listaConvertida;
        }

        
        #endregion EXTENCIONES (BINDINGLISTVIEW)
    }
}
