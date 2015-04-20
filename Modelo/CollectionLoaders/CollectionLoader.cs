using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics.CodeAnalysis;

namespace CollectionLoaders
{
    /// <summary>
    /// Delegado para definir el constructor a utilizar
    /// en la instancia de cada tipo
    /// </summary>
    /// <param name="parameters">Arreglo de parametros para cada constructor</param>
    /// <returns>Constructor</returns>
    public delegate object ParamsConstructorDelegate(params object[] parameters);

    public static class MyExtensions
    {
        /// <summary>
        /// Cuenta las palabras que forman una cadena
        /// </summary>
        /// <param name="str">
        ///     Especifica que el método actúa sobre la clase String.
        /// </param>
        /// <returns>
        ///      La cantidad de palabras que componen la cadena
        /// </returns>
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                  StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    /// <summary>
    /// Clase que permite cargar una lista a partir de un DataReader.
    /// </summary>
    /// <remarks>Esta clase contiene métodos que a partir de un IDataReader, 
    /// que tiene ciertos datos de la BD, y una clase cuyas propiedades mapean
    /// todos los campos del IDataReader, podemos obtener una lista de objetos del
    /// tipo de la clase que contienen los datos del DataReader.
    /// La principal caracteristica de la clase es la geralidad que ofrece, ya que
    /// es independiente del numero de campos que tenga el IDataReader y del 
    /// tipo de cada uno de estos datos.</remarks>
    public static class ListLoader
    {
        //private static bool paraListas;
        private static ParamsConstructorDelegate ctor;
        private static object[] paramCtor;

        #region METODOS DE EXTENCION PARA LISTAS
        /// <summary>
        /// Este metodo extensor carga una lista (list) a partir de elementos del tipo itemType que estan contenidos en el DataReader.
        /// </summary>
        /// <param name="list">Coleccion donde se van a almacenar los objetos obtenidos.</param>
        /// <param name="reader">Objeto que contiene los datos obtenidos de la BD.</param>
        /// <param name="itemType">Tipo de los elementos de la lista.</param>
        [SuppressMessage("Microsoft.Usage", "CA2200:RethrowToPreserveStackDetails", Justification = "Las excepciones TargetInvocationException despistan mucho, es mejor lanzar la InnerException que da una información más clara del error")]
        public static void LoadFromReader(this IList list, IDataReader reader, Type itemType, int indiceCtor = 0)
        {

            Type type = typeof(ListLoader);

            //Se invoca al metodo LoadFromReader(IList, IDataReader) a traves de reflection.
            MethodInfo mi = type.GetMethod("LoadFromReader", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(IList), typeof(IDataReader), typeof(int) }, null);
            mi = mi.MakeGenericMethod(new Type[] { itemType });
            try
            {
                mi.Invoke(null, new object[] { list, reader, indiceCtor });
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException == null)
                {
                    throw;
                }
                else
                {
                    //Si falla nos mostrara el mensaje real del metodo que se ha invocado
                    throw ex.InnerException;
                }
            }
        }

        /// <summary>
        /// Metodo extensor que carga una lista de objetos del tipo T a partir de un DataReader.
        /// </summary>
        /// <typeparam name="T">Tipo de los items que van a contener la lista.</typeparam>
        /// <param name="list">Lista a rellenar. Está tipada.</param>
        /// <param name="reader">Objeto que contiene los datos que se quieres obtener en la lista.</param>
        public static void LoadFromReader<T>(this IList<T> list, IDataReader reader, int indiceCtor = 0) where T : new()
        {
            LoadFromReaderImplementation<T>(list, reader, indiceCtor);
        }

        /// <summary>
        /// Metodo extensor que carga una lista de objetos del tipo T a partir de un DataReader.
        /// </summary>
        /// <typeparam name="T">Tipo de los items que van a contener la lista.</typeparam>
        /// <param name="list">Lista a rellenar.</param>
        /// <param name="reader">Objeto que contiene los datos que se quieres obtener en la lista.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Rendimiento: este método es más rápido que la sobrecarga LoadFromReader(this IList list, IDataReader reader, Type itemType) la cual requiere invocación de método mediante Reflection")]
        public static void LoadFromReader<T>(this IList list, IDataReader reader, int indiceCtor = 0) where T : new()
        {
            LoadFromReaderImplementation<T>(list, reader, indiceCtor);
        }

        /// <summary>
        /// Metodo que realmente tiene el codigo necesario para cargar el DataReader en la lista de objetos.
        /// </summary>
        /// <typeparam name="T">Tipo del que serán los elementos de la lista a cargar.</typeparam>
        /// <param name="objeto">Lista a cargar.</param>
        /// <param name="reader">Estructura de la cual se obtendran los datos.</param>
        private static void LoadFromReaderImplementation<T>(object objeto, IDataReader reader, int indiceCtor) where T : new()
        {
            
            //Si alguno de los cast devuelve null, ya sabemos el tipo de la lista u objeto.
            IList<T> genericList = objeto as IList<T>;
            IList nonGenericList = objeto as IList;

            if (genericList == null && nonGenericList == null)
            {
                throw new ArgumentException("objeto debe implementar IList, IList<T> o Entidades.Instrumental", "list");
            }

            //Constructor indice [1] para instanciar el tipo con las claves principales PK
            //var ctor = Build(typeof(T));
            ctor = Build(typeof(T), indiceCtor);

            //El indice del array corresponde al ordinal de cada campo en el IDataReader.
            //Esto hace que la obtencion del método Setter que le corresponde a cada campo
            //sea inmediata.
            //El tipo T es una clase cuyas propiedades tienen el mismo nombre que los 
            //campos de la BD (que estan en el IDataReader).
            PropertySetter[] setters = GetPropertySetters(reader, typeof(T));

            while (reader.Read())
            {
                //Crea un objeto de tipo T con los datos del IDataReader ya introducidos.
                T item = CreateItemFromReader<T>(reader, setters);

                if (genericList != null)
                {
                    genericList.Add(item);
                }
                else
                {
                    nonGenericList.Add(item);
                }
            }
        }

        #endregion METODOS DE EXTENCION PARA LISTAS

        /// <summary>
        /// Metodo que crea un elemento de tipo T y le introduce los valores de
        /// los campos del IDataReader con los setters.
        /// </summary>
        /// <typeparam name="T">Tipo (Clase) que se instanciará para rellenarla con los datos del IDataReader.</typeparam>
        /// <param name="reader">Estructura que contiene los datos obtenidos de la BD.</param>
        /// <param name="setters">Métodos necesarios para establecer todos los valores de las 
        /// propiedades del objeto de tipo T.</param>
        /// <returns>Objeto de tipo T rellenado con los datos.</returns>
        private static T CreateItemFromReader<T>(IDataReader reader, PropertySetter[] setters) where T : new()
        {

            //ParamsConstructorDelegate ctor = Build(typeof(T));

            //Sabemos con seguridad que se puede hacer por la restriccion.
            //T item = new T();

            int fieldCount = reader.FieldCount;

            //CREACION DE VALORES SEGUN CONSTRUCTOR DE TIPO

            object[] paramVal = new object[paramCtor.Length];

            for (int i = 0; i < paramCtor.Length; i++)
            {
                paramVal[i] = reader[(string)paramCtor[i]];
            }

            //Instancia del tipo con el constructor de indice [1] para claves principales que son solo lectura
            T item = (T)ctor(paramVal);

            for (int fieldOrdinal = 0; fieldOrdinal < fieldCount; fieldOrdinal++)
            {
                PropertySetter setter = setters[fieldOrdinal];
                if (setter != null)
                {
                    object fieldValue = null;
                    if (reader.IsDBNull(fieldOrdinal))
                        switch (reader.GetFieldType(fieldOrdinal).Name)
                        {
                            case "Int16":
                                fieldValue = short.Parse("0");
                                break;
                            case "Int32":
                                fieldValue = 0;
                                break;
                            case "bool":
                                fieldValue = false;
                                break;
                            case "decimal":
                                fieldValue = 0.0M;
                                break;
                            case "DateTime":
                                fieldValue = new DateTime(1900, 1, 1);
                                break;
                            default:
                                fieldValue = null;
                                break;
                        }
                    else
                    {
                        fieldValue = reader.GetValue(fieldOrdinal);
                    }
                    //fieldValue = reader.IsDBNull(fieldOrdinal) ? null : reader.GetValue(fieldOrdinal);

                    //Se invoca como si fuese un metodo y le establece el valor fieldvalue.
                    setter(item, fieldValue);
                }
            }
            return item;
        }


        /// <summary>
        /// Representa un mapeo entre los ordinales de los campos del IDataReader y los Setters.
        /// Devuelve un array en el que su índice y el de los ordinales de los campos del 
        /// IDataReader tienen que coincidir.
        /// </summary>
        /// <remarks>Es importante que el vecor de Setter esté ordenado de forma que 
        /// si el campo número cero del IDataReader se llama ContactID, en la posicion
        /// número cero del vector exista un Setter llamado SetContactID...() para 
        /// que a la hora de invocar a los métodos dinámicos, esten claramente identificados.</remarks>
        /// <param name="reader">Estructura de datos que contiene los datos obtenidos de la BD.</param>
        /// <param name="itemType">Tipo de datos cuyas propiedades deben estar mapeadas con los
        /// campos de la BD.</param>
        /// <returns>Vector de Setters.</returns>
        private static PropertySetter[] GetPropertySetters(IDataReader reader, Type itemType)
        {
            int fieldCount = reader.FieldCount;

            PropertySetter[] propertySetters = new PropertySetter[fieldCount];

            //Posiblemente esta en la cache y lo devuelve, sino se crea y se devuelve.
            IPropertySetterDictionary settersDictionary = PropertyHelper.GetPropertySetters(itemType);

            //Recorremos todos los campos del IDataReader
            for (int fieldOrdinal = 0; fieldOrdinal < fieldCount; fieldOrdinal++)
            {
                PropertySetter setter;

                //Mapeo entre ordinal del campo y el nombre de la propiedad de la clase.
                //Aqui es importante que los campos del IDataReader se llamen exactamente
                //igual que las propiedades de la clase. Puesto que se buscará el nombre del
                //campo en el diccionario creado a partir de las propiedades de la clase.
                if (settersDictionary.TryGetValue(reader.GetName(fieldOrdinal), out setter))
                {
                    propertySetters[fieldOrdinal] = setter;
                }
            }
            return propertySetters;
        }

        /// <summary>
        /// Representa un mapeo entre los ordinales de los campos del IDataReader y los Getters.
        /// Devuelve un array en el que su índice y el de los ordinales de los campos del 
        /// IDataReader tienen que coincidir.
        /// </summary>
        /// <param name="reader">Estructura de datos que contiene los datos obtenidos de la BD.</param>
        /// <param name="itemType">Tipo de datos cuyas propiedades deben estar mapeadas con los
        /// campos de la BD.</param>
        /// <returns>Vector de Getters.</returns>
        private static PropertyGetter[] GetPropertyGetters(IDataReader reader, Type itemType)
        {
            int fieldCount = reader.FieldCount;

            PropertyGetter[] propertyGetters = new PropertyGetter[fieldCount];

            //Posiblemente esta en la cache y lo devuelve, sino se crea y se devuelve.
            IPropertyGetterDictionary gettersDictionary = PropertyHelper.GetPropertyGetters(itemType);

            //Recorremos todos los campos del IDataReader
            for (int fieldOrdinal = 0; fieldOrdinal < fieldCount; fieldOrdinal++)
            {
                PropertyGetter getter;

                //Mapeo entre ordinal del campo y el nombre de la propiedad de la clase.
                //Aqui es importante que los campos del IDataReader se llamen exactamente
                //igual que las propiedades de la clase. Puesto que se buscará el nombre del
                //campo en el diccionario creado a partir de las propiedades de la clase.
                if (gettersDictionary.TryGetValue(reader.GetName(fieldOrdinal), out getter))
                {
                    propertyGetters[fieldOrdinal] = getter;
                }
            }
            return propertyGetters;
        }

        /// <sumary>
        /// Obtener constructor
        /// </sumary>
        static ParamsConstructorDelegate Build(Type type, int indiceCtor)
        {
            var mthd = new DynamicMethod(".ctor", type,
                new Type[] { typeof(object[]) });
            var il = mthd.GetILGenerator();
            var ctor = type.GetConstructors()[indiceCtor]; // not very robust, but meh...
            var ctorParams = ctor.GetParameters();
            paramCtor = new object[ctorParams.Length];
            for (int i = 0; i < ctorParams.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_0);
                switch (i)
                {
                    case 0: il.Emit(OpCodes.Ldc_I4_0); break;
                    case 1: il.Emit(OpCodes.Ldc_I4_1); break;
                    case 2: il.Emit(OpCodes.Ldc_I4_2); break;
                    case 3: il.Emit(OpCodes.Ldc_I4_3); break;
                    case 4: il.Emit(OpCodes.Ldc_I4_4); break;
                    case 5: il.Emit(OpCodes.Ldc_I4_5); break;
                    case 6: il.Emit(OpCodes.Ldc_I4_6); break;
                    case 7: il.Emit(OpCodes.Ldc_I4_7); break;
                    case 8: il.Emit(OpCodes.Ldc_I4_8); break;
                    default: il.Emit(OpCodes.Ldc_I4, i); break;
                }
                il.Emit(OpCodes.Ldelem_Ref);
                Type paramType = ctorParams[i].ParameterType;
                il.Emit(paramType.IsValueType ? OpCodes.Unbox_Any
                    : OpCodes.Castclass, paramType);
                paramCtor[i] = ctorParams[i].Name.ToLower();

            }
            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);
            return (ParamsConstructorDelegate)
                mthd.CreateDelegate(typeof(ParamsConstructorDelegate));
        }



        /// <summary>
        /// Metodo de prueba.
        /// </summary>
        public static void MostrarTipo<T>(T item, IDataReader reader)
        {
            PropertyGetter[] getters = GetPropertyGetters(reader, typeof(T));

            Type type = item.GetType();

            PropertyInfo[] props = type.GetProperties();

            int propCount = props.Length;

            System.Console.Out.WriteLine("Clase: " + item.GetType().FullName);
            for (int prop = 0; prop < propCount; prop++)
            {
                PropertyGetter getter = getters[prop];
                if (getter != null)
                {
                    //Se invoca como si fuese un metodo y le establece el valor fieldvalue.
                    object valor = getter(item);
                    System.Console.Out.Write("Propiedad: " + props[prop].Name + " ");
                    System.Console.Out.WriteLine("Valor: " + valor.ToString());
                }
            }
            System.Console.Out.WriteLine("---------------------------");
        }


    }
}
