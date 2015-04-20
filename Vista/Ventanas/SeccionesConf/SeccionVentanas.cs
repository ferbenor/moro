using System;
using System.Configuration;
using System.Text;

namespace CustomConfigExample
{
	class SeccionVentanas : ConfigurationSection
	{
		private SeccionVentanas() { }

		#region Public Methods

		///<summary>
		///Get this configuration set from the application's default config file
		///</summary>
		public static SeccionVentanas Open()
		{
			System.Reflection.Assembly assy = System.Reflection.Assembly.GetEntryAssembly();
			return Open(assy.Location);
		}

		///<summary>
		/// Get this configuration set from a specific config file
		///</summary>
		public static SeccionVentanas Open(string path)
		{
			if ((object)instance == null)
			{
				if (path.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
					spath = path.Remove(path.Length - 7);
				else
					spath = path;
				Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
                if (config.Sections["SeccionVentanas"] == null)
				{
					instance = new SeccionVentanas();
                    config.Sections.Add("SeccionVentanas", instance);
					config.Save(ConfigurationSaveMode.Modified);
				}
				else
                    instance = (SeccionVentanas)config.Sections["SeccionVentanas"];
			}
			return instance;
		}

		///<summary>
		///Create a full copy of the current properties
		///</summary>
		public SeccionVentanas Copy()
		{
			SeccionVentanas copy = new SeccionVentanas();
            string xml = SerializeSection(this, "SeccionVentanas", ConfigurationSaveMode.Full);
			System.Xml.XmlReader rdr = new System.Xml.XmlTextReader(new System.IO.StringReader(xml));
			copy.DeserializeSection(rdr);
			return copy;
		}

		///<summary>
		///Save the current property values to the config file
		///</summary>
		public void Save()
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            SeccionVentanas section = (SeccionVentanas)config.Sections["SeccionVentanas"];
			//
			// TODO: Add code to copy all properties from "this" to "section"
			//
            //section.SectorConfig = this.SectorConfig;
			section.Ventanas = this.Ventanas;
			config.Save(ConfigurationSaveMode.Full); //Try with "Modified" to see the difference
		}

		#endregion Public Methods

		#region Properties

		public static SeccionVentanas Default
		{
			get { return defaultInstance; }
		}

        //[ConfigurationProperty("Sector")]
        //public SomeSettings SectorConfig
        //{
        //    get { return (SomeSettings)this["Sector"]; }
        //    set { this["Sector"] = value; }
        //}

        [ConfigurationProperty("Ventanas")]
		public Ventanas Ventanas
		{
            get { return (Ventanas)this["Ventanas"]; }
            set { this["Ventanas"] = value; }
		}

		#endregion Properties

		#region Fields
		private static string spath;
		private static SeccionVentanas instance = null;
		private static readonly SeccionVentanas defaultInstance = SeccionVentanas.Open();
		#endregion Fields
	}
}
