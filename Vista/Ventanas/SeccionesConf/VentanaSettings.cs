using System;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CustomConfigExample
{
    public class VentanaSettings : ConfigurationElement
    {
        public VentanaSettings() { }

        public VentanaSettings(string nombre) { this["name"] = nombre; }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("AltoPieVentana", DefaultValue = "182")]
        public int AltoPieVentana
        {
            get { return (int)this["AltoPieVentana"]; }
            set { this["AltoPieVentana"] = value; }
        }

        [ConfigurationProperty("AltoCabecera", DefaultValue = "125")]
        public int AltoCabecera
        {
            get { return (int)this["AltoCabecera"]; }
            set { this["AltoCabecera"] = value; }
        }

        //[ConfigurationProperty("Enable", DefaultValue = "Yes")]
        //private string pEnable
        //{
        //    get { return this["Enable"].ToString(); }
        //    set { this["Enable"] = value; }
        //}

        //public bool Enable
        //{
        //    get { return pEnable.ToLower() == "yes"; }
        //    set { pEnable = value ? "Yes" : "No"; }
        //}

        //[ConfigurationProperty("DevA")]
        //public AShapeSetting DevA
        //{
        //    get { return (AShapeSetting)this["DevA"]; }
        //}

        //[ConfigurationProperty("DevB")]
        //public AShapeSetting DevB
        //{
        //    get { return (AShapeSetting)this["DevB"]; }
        //}


    }

    public class Ventanas : ConfigurationElementCollection
    {
        internal const string PropertyName = "name";

        public VentanaSettings this[int index]
        {
            get
            {
                return base.BaseGet(index) as VentanaSettings;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new VentanaSettings this[string responseString]
        {
            get
            {
                if (base.BaseGet(responseString) == null)
                {
                    this.BaseAdd(new VentanaSettings(responseString));

                }
                return (VentanaSettings)BaseGet(responseString);
            }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new VentanaSettings();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((VentanaSettings)element).Name;
        }
    }
}
