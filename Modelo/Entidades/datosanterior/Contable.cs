using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class Contable : Instrumental
    {
        #region VARIABLES
        private int numero;
        private short periodo = General.periodoActual;
        private TipoContable tipoContable;
        private DateTime fecha;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        private Persona beneficiario;
        private decimal valor;
        private string observacion;
        private Usuario usuarioRegistra;
        private Usuario usuarioModifica;
        private bool editable;
        private bool anulado;
        private List<DetalleContable> detalleContable;
        private const string nombreTabla = "contables";
        #endregion VARIABLES

        #region PROPIEDADES

        public int Numero { get { return this.numero; } }
        public short Periodo { get { return this.periodo; } set { this.periodo = value; } }
        public short IdTipoContable { get; set; }
        public TipoContable TipoContable
        {
            get
            {
                if (this.tipoContable == null)
                    this.tipoContable = General.tipoContableCero;
                return this.tipoContable;
            }
            set { this.tipoContable = value; if (value == null) this.IdTipoContable = 0; else this.IdTipoContable = value.Id; }
        }
        public string DescripcionContable { get { return this.periodo + " - " + this.TipoContable.Descripcion + " - " + String.Format("{0:00000000}", this.numero) + " - " + String.Format("{0:yyyy-MM-dd}", this.fecha) + " - " + this.valor; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public DateTime FechaCreacion { get { return this.fechaCreacion; } }
        public string FechaCreacionChr { get { if (this.fechaCreacion == new DateTime(1, 1, 1)) return ""; else return this.fechaCreacion.ToString("ddd, dd MMM yyyy HH:mm:ss"); } }
        public DateTime FechaModificacion { get { return this.fechaModificacion; } }
        public string FechaModificacionChr { get { if (this.fechaModificacion == new DateTime(0001, 1, 1)) return ""; else return this.fechaModificacion.ToString("ddd, dd MMM yyyy HH:mm:ss"); } }
        public int IdBeneficiario { get; set; }
        public Persona Beneficiario
        {
            get
            {
                if (this.beneficiario == null)
                    this.beneficiario = General.personaVacio;
                return this.beneficiario;
            }
            set { this.beneficiario = value; if (value == null) this.IdBeneficiario = 0; else this.IdBeneficiario = value.Id; }
        }
        public decimal Valor { get { return this.valor; } /*set { this.valor = value; }*/ }
        public string Observacion { get { return this.observacion; } set { this.observacion = value; } }
        public short IdUsuarioRegistra { get; set; }
        public Usuario UsuarioRegistra
        {
            get
            {
                if (this.usuarioRegistra == null)
                    return General.usuarioActivo.Usuario;
                else
                    return this.usuarioRegistra;
            }
            set { this.usuarioRegistra = value; }
        }
        public short IdUsuarioModifica { get; set; }
        public Usuario UsuarioModifica
        {
            get
            {
                if (this.usuarioModifica == null)
                    return General.usuarioActivo.Usuario;
                else
                    return this.usuarioModifica;
            }
            set { this.usuarioModifica = value; }
        }
        public bool EsEditable { get { return this.editable; } set { this.editable = value; } }
        public bool EsAnulado { get { return this.anulado; } set { this.anulado = value; } }
        public Contable Objeto { get { return this; } }
        public List<DetalleContable> DetalleContable { get { if (detalleContable == null) { this.detalleContable = new List<DetalleContable>(); return this.detalleContable; } else return detalleContable; } set { this.detalleContable = value; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public Contable() { }

        public Contable(int Numero) { this.numero = Numero; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("numero", true, System.Data.DbType.Int32, 0, this.Numero, true));
            lc.Add(new CamposTabla("periodo", true, System.Data.DbType.Int16, 0, this.periodo));
            lc.Add(new CamposTabla("idtipocontable", true, System.Data.DbType.Int16, 0, this.TipoContable.Id));
            lc.Add(new CamposTabla("fecha", false, System.Data.DbType.DateTime, 0, this.fecha));
            lc.Add(new CamposTabla("fechacreacion", false, System.Data.DbType.DateTime, 0, this.FechaCreacion, false, true));
            lc.Add(new CamposTabla("#fechamodificacion", false, System.Data.DbType.DateTime, 0, "NOW()"));
            lc.Add(new CamposTabla("idpersona", false, System.Data.DbType.Int32, 0, this.Beneficiario.Id));
            lc.Add(new CamposTabla("valor", false, System.Data.DbType.Decimal, 0, this.valor));
            lc.Add(new CamposTabla("observacion", false, System.Data.DbType.String, 255, this.observacion));
            lc.Add(new CamposTabla("idusuarioregistra", false, System.Data.DbType.Int16, 0, this.UsuarioRegistra.Id) { NoUpdate = true });
            lc.Add(new CamposTabla("idusuariomodifica", false, System.Data.DbType.Int16, 0, this.UsuarioModifica.Id));
            lc.Add(new CamposTabla("eseditable", false, System.Data.DbType.Boolean, 0, this.editable));
            lc.Add(new CamposTabla("esanulado", true, System.Data.DbType.Boolean, 0, this.anulado));
            return lc;
        }

        public virtual string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public virtual string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public virtual string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public virtual string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, numero, "where periodo = " + General.periodoActual + " and idtipocontable = " + this.TipoContable.Id);
        }
        public override string ToString()
        {
            return this.DescripcionContable;
        }
        public void SetId(int unId)
        {
            this.numero = unId;
        }

        public void SetValores(int unNumero, short unPeriodo, short unIdTipoContable, DateTime unaFecha, DateTime unaFechaCreacion,
            DateTime unaFechaModificacion, int unIdBeneficiario, decimal unValor, string unaObservacion,
            short unIdUsuarioRegistra, short unIdUsuarioModifica, bool esEditable)
        {
            this.numero = unNumero;
            this.periodo = unPeriodo;
            this.IdTipoContable = unIdTipoContable;
            this.fecha = unaFecha;
            this.fechaCreacion = unaFechaCreacion;
            this.fechaModificacion = unaFechaModificacion;
            this.IdBeneficiario = unIdBeneficiario;
            this.valor = unValor;
            this.observacion = unaObservacion;
            this.IdUsuarioRegistra = unIdUsuarioRegistra;
            this.IdUsuarioModifica = unIdUsuarioModifica;
            this.editable = esEditable;
        }

        public void Limpiar()
        {
            this.numero = 0;
            this.periodo = General.periodoActual;
            this.TipoContable = null;
            this.fecha = General.usuarioActivo.FechaSesion;
            this.fechaCreacion = General.usuarioActivo.FechaSesion;
            this.fechaModificacion = General.usuarioActivo.FechaSesion;
            this.Beneficiario = null;
            this.valor = 0;
            this.observacion = null;
            this.UsuarioRegistra = null;
            this.UsuarioModifica = null;
            this.editable = true;
            this.detalleContable = null;

        }
        #endregion FUNCIONES LOCALES

    }

    #region INTERFAZ PARA ORDENAR COLMNAS
    /*public class IContableComparer : IComparer<Contable>
    {
        string memberName = string.Empty; // especifica el nombre del miembro para ser clasificado
        System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.None; // especifica tipo SortOrder.

        /// <summary>
        /// Constructor para establecer el orden de la columna y el orden de clasificacion
        /// </summary>
        /// <param name="strMemberName"></param>
        /// <param name="sortingOrder"></param>
        public IContableComparer(string strMemberName, System.Windows.Forms.SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }

        /// <summary>
        /// Compara dos datos basado en el nombre del miembro y el orden de clasificacion
        /// y retorna el resultado.
        /// </summary>
        /// <param name="Objeto1"></param>
        /// <param name="Objeto2"></param>
        /// <returns></returns>
        public int Compare(Contable Objeto1, Contable Objeto2)
        {
            int returnValue = 1;
            switch (memberName)
            {
                case "colNumero":
                    if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        returnValue = Objeto1.Numero.CompareTo(Objeto2.Numero);
                    }
                    else
                    {
                        returnValue = Objeto2.Numero.CompareTo(Objeto1.Numero);
                    }

                    break;
                case "colTipo":
                    if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        returnValue = Objeto1.TipoContable.ToString().CompareTo(Objeto2.TipoContable.ToString());
                    }
                    else
                    {
                        returnValue = Objeto2.TipoContable.ToString().CompareTo(Objeto1.TipoContable.ToString());
                    }
                    break;
                case "colBeneficiario":
                    if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        returnValue = Objeto1.Beneficiario.ToString().CompareTo(Objeto2.Beneficiario.ToString());
                    }
                    else
                    {
                        returnValue = Objeto2.Beneficiario.ToString().CompareTo(Objeto1.Beneficiario.ToString());
                    }
                    break;
                default:
                    if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        returnValue = Objeto1.Fecha.CompareTo(Objeto2.Fecha);
                    }
                    else
                    {
                        returnValue = Objeto2.Fecha.CompareTo(Objeto1.Fecha);
                    }
                    break;
            }
            return returnValue;
        }
    }*/
    #endregion INTERFAZ PARA ORDENAR COLMNAS
}

