using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionLoaders
{
    public class Setters
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification="Esto no es más que un método de prueba para ver el IL generado")]
        public int IntProperty { get; set; }
        public int? NullableIntProperty { get; set; }

        public string StringProperty { get; set; }

        public void SetIntPropertyValue(object value)
        {
            IntProperty = (int)((short)value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Nullabe")]
        public void SetNullableIntPropertyValue(object value)
        {
            if (value == null)
                NullableIntProperty = null;
            else
            {
                short shortValue = (short)value;
                NullableIntProperty = shortValue;
            }
           
        }

        public void SetStringPropertyValue(object value)
        {
            StringProperty = (string)value;
        }

        //Metodo que se generaria si fuese entero.
        //NetReflector --> a partir de un ensamblado se coge el IL
        public static void SetIntPropertyValue(object instance, object value)
        {
            ((Setters)(instance)).IntProperty = (int)value;
        }
    }
}
