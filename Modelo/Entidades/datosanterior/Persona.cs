using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Persona: EPersona
    {
        new public const string nombreTabla = "personas";
        public Persona Objeto { get { return this; } }

        public Persona() { }

        public Persona(int Id, int Version) { this.id = Id; this.version = Version; }
    }
}
