using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Mapping;
using LinqToDB;
using LinqToDB.Data;
using System.ComponentModel;
using LinqToDB.SchemaProvider;
using System.Globalization;

namespace ModeloDB
{

    public partial class estadocivil
    {
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombre;
        }

        #endregion
    }
}
