using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class ActividadEconomica: Instrumental
    {
        #region VARIABLES
        private short id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private ActividadEconomicaAux padre;
        private short nivel;
        private short orden;
        private bool activo;
        private SectorEconomicoAux sectorEconomico;
        private bool vinculada = false;
        private const string nombreTabla = "actividadeseconomicas";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public short IdPadre { get; set; }
        public short IdSectorEconomico { get; set; }

        public ActividadEconomicaAux Padre
        {
            get
            {
                if (this.padre == null)
                    return General.actividadEconomicaAuxCero;
                else
                    return this.padre;
            }
            set
            {
                this.padre = value;
                if (value == null) this.IdPadre = 0;
                else this.IdPadre = value.Id;

            }
        }
        public SectorEconomicoAux SectorEconomico
        {
            get
            {
                if (this.sectorEconomico == null)
                    return General.sectorEconomicoAuxCero;
                else
                    return this.sectorEconomico;
            }
            set { this.sectorEconomico = value; }
        }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public string IdNombre { get { if (this.id == 0) return General.itemVacio; else return this.id.ToString() + "-" + this.descripcion; } }
        public short Nivel { get{return this.nivel;} set{this.nivel = value;} }
        public short Orden { get{return this.orden;} set{this.orden = value;} }
        public bool Activo { get{return this.activo;} set{this.activo = value;} }
        public bool Vinculada { get { return this.vinculada; } }
        public ActividadEconomica Objeto { get { return this; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ActividadEconomica() { }

        public ActividadEconomica(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.id, true));
            lc.Add(new CamposTabla("codigo", false, System.Data.DbType.String, 20, this.codigo));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 20, this.nombre));
            lc.Add(new CamposTabla("descripcion", false, System.Data.DbType.String, 500, this.descripcion));
            lc.Add(new CamposTabla("idpadre", false, System.Data.DbType.Int16, 0, this.Padre.Id));
            lc.Add(new CamposTabla("nivel", false, System.Data.DbType.Int16, 0, this.nivel));
            lc.Add(new CamposTabla("orden", false, System.Data.DbType.Int16, 0, this.orden));
            lc.Add(new CamposTabla("idsector", false, System.Data.DbType.Int16, 0, this.sectorEconomico.Id));
            lc.Add(new CamposTabla("activo", false, System.Data.DbType.Boolean, 0, this.activo));
            lc.Add(new CamposTabla("case when (select count(s.codigo) from " + nombreTabla + " s where s.idpadre = " + nombreTabla + ".id) = 0 then false else true end vinculado", false, System.Data.DbType.Boolean, 0, -1, false, true));
            return lc;
        }

        public string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, id);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.IdNombre))
                return "";
            else
                return this.IdNombre;
        }

        #endregion FUNCIONES LOCALES
    }
}
