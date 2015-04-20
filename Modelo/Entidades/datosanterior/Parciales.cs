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

    

    public partial class tipopersona 
    {
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.descripcion;
        }

        #endregion
    }

    public partial class profesion 
    {
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombre;
        }

        #endregion
    }

    [Table(Schema = "public", Name = "barrios")]
    public partial class barrio
    {
        #region PROPIEDADES
        List<string> _a = new List<string>();
        public List<string> MyProperty { get { return _a; } set { _a = value;} }
        [PrimaryKey, NotNull]
        public int id { get; set; }            // integer

        string _nombre;
        [Column(Storage="_nombre"),  NotNull]
        public string nombre { get { return _nombre; } set { _nombre = value; this.OnPropertyChanged("nombre", value); } }            // character varying(200)
        [Column, NotNull]
        public int idparroquia { get; set; }            // smallint
        [Column, NotNull]
        public bool activo { get; set; }            // boolean
        public barrio Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        parroquia _fkparroquia;
        /// <summary>
        /// fk_barrios_parroquias
        /// </summary>
        [Association(ThisKey = "idparroquia", OtherKey = "id", CanBeNull = false)]
        public parroquia fkparroquia { get { return this._fkparroquia; } set { this._fkparroquia = value; if (value == null) this.idparroquia = 0; else this.idparroquia = value.id; } }

        /// <summary>
        /// fk_clientes_barrios_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idbarrio", CanBeNull = false)]
        public IEnumerable<cliente> fkclientes { get; set; }

        /// <summary>
        /// fk_ordenespedidos_barrios_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idbarrio", CanBeNull = false)]
        public IEnumerable<ordenpedido> fkordenespedidos { get; set; }

        /// <summary>
        /// fk_oficinas_barrios_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idbarrio", CanBeNull = false)]
        public IEnumerable<sucursal> fkoficinas { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public barrio Relacionar(parroquia fkparroquia)
        {
            this.fkparroquia = fkparroquia;
            return this;
        }

        public barrio Relacionar(IEnumerable<cliente> fkclientes)
        {
            this.fkclientes = fkclientes;
            return this;
        }

        public barrio Relacionar(IEnumerable<ordenpedido> fkordenespedidos)
        {
            this.fkordenespedidos = fkordenespedidos;
            return this;
        }

        public barrio Relacionar(IEnumerable<sucursal> fkoficinas)
        {
            this.fkoficinas = fkoficinas;
            return this;
        }

        #endregion
    }

    public partial class barrio 
    {

        public string nombreubicacion { get { return (this.fkparroquia == null ? string.Empty : this.fkparroquia.nombrecompleto).TrimStart(); } }

        public string nombrecompleto { get { return string.Format("{0} Barrio: {1}", (this.fkparroquia == null ? string.Empty : this.fkparroquia.nombrecompleto), this.nombre).TrimStart(); } }

        public barrio()
        {
            this.PropertyCambiado += new PropertyCambiadoEventHandler(barrio_PropertyCambiado);
        }

        void barrio_PropertyCambiado(object sender, PropertyCambiadoEventArgs e)
        {
            throw new NotImplementedException();
        }

        void barrio_PropertyCambiado(object sender, PropertyCambiadoEventHandler e)
        {

        }

        void barrio_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombre;
        }

        #endregion
    }

    [Table(Schema = "public", Name = "cantones")]
    public partial class canton
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public short id { get; set; }            // smallint
        [Column, NotNull]
        public string nombre { get; set; }            // character varying(50)
        [Column, NotNull]
        public short idprovincia { get; set; }            // smallint
        public canton Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        provincia _fkprovincia;
        /// <summary>
        /// fk_cantones_provincias
        /// </summary>
        [Association(ThisKey = "idprovincia", OtherKey = "id", CanBeNull = false)]
        public provincia fkprovincia { get { return this._fkprovincia; } set { this._fkprovincia = value; if (value == null) this.idprovincia = 0; else this.idprovincia = value.id; } }

        /// <summary>
        /// fk_parroquias_cantones_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idcanton", CanBeNull = false)]
        public IEnumerable<parroquia> fkparroquias { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public canton Relacionar(provincia fkprovincia)
        {
            this.fkprovincia = fkprovincia;
            return this;
        }

        public canton Relacionar(IEnumerable<parroquia> fkparroquias)
        {
            this.fkparroquias = fkparroquias;
            return this;
        }

        #endregion
    }

    public partial class parroquia 
    {
        public string nombrecompleto { get { return string.Format("{0} Parroquia: {1}", (this.fkcantone == null ? string.Empty : this.fkcantone.nombrecompleto), this.nombre).TrimStart(); } }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombrecompleto;
        }

        #endregion
    }

    public partial class canton 
    {
        public string nombrecompleto { get { return string.Format("{0} Canton: {1}", (this.fkprovincia == null ? string.Empty : this.fkprovincia.nombrecompleto), this.nombre).TrimStart(); } }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombre;
        }

        #endregion
    }

    public partial class provincia 
    {
        public string nombrecompleto { get { return "Provincia: " + this.nombre; } }
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.nombre;
        }

        #endregion
    }

    public partial class usuario 
    {
        private bool menusAsignados = false;
        private bool reseteaClave = false;

        public string identificacion { get { return this.fkpersona.identificacion; } set { this.fkpersona.identificacion = value; } }
        public string nombrecompleto { get { return "Usuario: " + this.descripcion; } }
        public bool ReseteaClave { get { return this.reseteaClave; } set { this.reseteaClave = value; } }
        public string FechaCambioChr { get { if (this.fechacambio == new DateTime(1900, 1, 1)) return ""; else return this.fechacambio.ToString(); } }
        public string FechaCreacionChr { get { if (this.fechacreacion == new DateTime(1900, 1, 1)) return ""; else return this.fechacreacion.ToString(); } }

        [Column(Name = "case when (select count(p.idperfil) from perfilesmenus p, usuariosperfiles u where p.idperfil = u.idperfil and idusuario = id) = 0 then false else true end menusasignados"
            , SkipOnInsert = true, SkipOnUpdate = true, Storage = "menusAsignados", IsColumn = false)]
        public bool MenusAsignados { get { return menusAsignados; } set { this.menusAsignados = value; } }
        public bool CambioClave
        {
            get
            {
                if (General.CifrarClave(this.loginusuario + " " + this.loginusuario) == this.clave)
                    return true;
                else
                {
                    TimeSpan dias = new TimeSpan(Sql.DateTime.Ticks - fechacambio.Ticks);
                    if (dias.Days > diasvigencia || this.clave == "")
                        return true;
                    else
                        return false;
                }
            }
        }

        public usuario()
        {
            this.fkpersona = new persona();
            this.fkpersona.fkestadospersona = General.estadoPersonaCero;

        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.descripcion).Trim();
        }

        #endregion

    }

    public partial class menu 
    {
        private bool vinculado;

        public bool Vinculado { get { return this.vinculado; } set { this.vinculado = value; } }
        public string NombreCompleto { get { if (this.id == 0) return General.itemCero; else return this.id.ToString("000") + "-" + this.nombre; } }
        private menu padre;
        public menu Padre { get { if (padre == null) this.padre = new menu(); return padre; } set { this.padre = value; if (value != null) this.idpadre = value.id; } }

        public System.Drawing.Image Imagen { get { return ModeloDB.ImagenCombo.Imagenes.Images[this.icono]; } }

        public menu()
        {
            this.fkcolumnasgrid = new List<columnasgrid>();
        }

        public string CadenaSelectAsignados()
        {
            return @"select m.id, m.idpadre, m.nombre, m.titulo, m.visible, m.contenedor, m.formulario, m.modulo, m.busqueda, m.piedetalle, m.icono, not contenedor as editable, m.tabla
            from menus as m where id in(select idpadre from menus 
            where id in(select idpadre from menus where id in(select idpadre from menus 
            where id in(select idpadre from menus where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo))))) 
            union 
            select m.id, m.idpadre, m.nombre, m.titulo, m.visible, m.contenedor, m.formulario, m.modulo, m.busqueda, m.piedetalle, m.icono, not contenedor as editable, m.tabla
            from menus as m where id in(select idpadre from menus 
            where id in(select idpadre from menus 
            where id in(select idpadre from menus 
            where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo)))) 
            union 
            select m.id, m.idpadre, m.nombre, m.titulo, m.visible, m.contenedor, m.formulario, m.modulo, m.busqueda, m.piedetalle, m.icono, not contenedor as editable, m.tabla 
            from menus as m where id in(select idpadre from menus 
            where id in(select idpadre from menus 
            where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo))) 
            union 
            select m.id, m.idpadre, m.nombre, m.titulo, m.visible, m.contenedor, m.formulario, m.modulo, m.busqueda, m.piedetalle, m.icono, not contenedor as editable, m.tabla
            from menus as m where id in(select idpadre from menus 
            where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo)) 
            union 
            select m.id, m.idpadre, m.nombre, m.titulo, m.visible, m.contenedor, m.formulario, m.modulo, m.busqueda, m.piedetalle, m.icono, cast(min(cast(p.editable as int)) as boolean) editable, m.tabla
            from menus as m, perfilesmenus p, usuariosperfiles u where m.id = p.idmenu and p.idperfil = u.idperfil and u.idusuario=@codigo 
            group by m.id,m.idpadre,m.nombre,m.titulo,m.formulario,m.visible,m.contenedor,m.modulo,m.icono order by nombre";
        }

        #region FUNCIONES ESTATICAS

        public static object Filtro(string unTexto)
        {
            Predicate<menu> predicado = x =>
                x.nombre.ToLower().Contains(unTexto.ToLower()) ||
                x.Padre.ToString().ToLower().Contains(unTexto.ToLower())
                ;
            return predicado;
        }

        #endregion FUNCIONES ESTATICAS

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.NombreCompleto;
        }

        #endregion
    }

    public partial class fraccionperiodo , IComparable
    {
        Mes objetoMes;
        public Mes ObjetoMes
        {
            get
            {
                if (this.objetoMes == null)
                    return General.mesCero;
                else
                    return this.objetoMes;
            }
            set
            {
                this.objetoMes = value;
                if (value == null) this.mes = 0;
                else this.mes = value.Id

            }
        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.fkperiodo == null ? "" : this.fkperiodo.anio.ToString() + "-") + this.mes.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is periodo)
            {
                periodo oVar = obj as periodo;
                return String.Compare(this.ToString(), oVar.ToString(), true);
            }
            else if (obj is string)
            {
                return String.Compare(this.ToString(), obj as string);
            }
            else
            {
                return -1;
            }
        }

        #endregion
    }

    public partial class pagoregistrado
    {
        public const string funcion = "fn_reg_pagos";

        [Column(Name = "identificadorpago")]
        public int identificadorpago { get; set; }

        [Column(Name = "numeropago")]
        public short numeropago { get; set; }
    }

    public partial class pago 
    {


        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.fkconveniospago.fkformaspago.ToString() + " " + this.valor).Trim();
        }

        #endregion INVALIDACIONES (OVERRIDE)
    }


    [Table(Schema = "public", Name = "contables")]
    public partial class contable
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int idperiodo { get; set; }            // integer
        [PrimaryKey, NotNull]
        public short idtipocontable { get; set; }            // smallint
        [PrimaryKey, NotNull]
        public int numero { get; set; }            // integer
        [Column, NotNull]
        public DateTime fecha { get; set; }            // date
        [Column, Nullable]
        public DateTime? fechacreacion { get; set; }            // timestamp without time zone
        [Column, Nullable]
        public DateTime? fechamodificacion { get; set; }            // timestamp without time zone
        [Column, Nullable]
        public int? idpersona { get; set; }            // integer
        string _beneficiario;
        [Column, Nullable]
        public string beneficiario { get { return _beneficiario; } set { this._beneficiario = value; } }            // integer
        [Column, Nullable]
        public decimal? valor { get; set; }            // numeric(15,5)
        [Column, Nullable]
        public string observacion { get; set; }            // character varying(255)
        [Column, Nullable]
        public int? idusuarioregistra { get; set; }            // smallint
        [Column, Nullable]
        public int? idusuariomodifica { get; set; }            // smallint
        [Column, NotNull]
        public bool eseditable { get; set; }            // boolean
        [Column, NotNull]
        public bool esanulado { get; set; }            // boolean
        public contable Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_contables_personas
        /// </summary>
        [Association(ThisKey = "idpersona", OtherKey = "id", CanBeNull = true)]
        public persona fkpersona { get; set; }

        /// <summary>
        /// fk_contables_tiposcontable
        /// </summary>
        [Association(ThisKey = "idtipocontable", OtherKey = "id", CanBeNull = false)]
        public tipocontable fktiposcontable { get; set; }

        /// <summary>
        /// fk_contables_periodos
        /// </summary>
        [Association(ThisKey = "idperiodo", OtherKey = "id", CanBeNull = false)]
        public fraccionperiodo fkfraccionperiodo { get; set; }

        /// <summary>
        /// fk_detallescontables_contables_BackReference
        /// </summary>
        [Association(ThisKey = "idperiodo, idtipocontable, numero", OtherKey = "periodo, idtipocontable, numerocontable", CanBeNull = true)]
        public List<detallecontable> fkdetallescontables { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public contable Relacionar(persona fkpersona)
        {
            this.fkpersona = fkpersona;
            return this;
        }

        public contable Relacionar(tipocontable fktiposcontable)
        {
            this.fktiposcontable = fktiposcontable;
            return this;
        }

        public contable Relacionar(fraccionperiodo fkperiodo)
        {
            this.fkfraccionperiodo = fkperiodo;
            return this;
        }

        public contable Relacionar(List<detallecontable> fkdetallescontables)
        {
            this.fkdetallescontables = fkdetallescontables;
            return this;
        }

        #endregion
    }

    public partial class contable 
    {
        public string Periodo
        {
            get
            {
                try
                {
                    return this.fkfraccionperiodo.fkperiodo.ToString();
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        public contable()
        {
            this.fkdetallescontables = new List<detallecontable>();
        }

        public contable(contable unContable)
        {
            this.idperiodo = unContable.idperiodo;
            this.idtipocontable = unContable.idtipocontable;
            this.numero = unContable.numero;
            this.fecha = unContable.fecha;
            this.fkpersona = unContable.fkpersona;
            this.fkfraccionperiodo = unContable.fkfraccionperiodo;
            this.fkdetallescontables = unContable.fkdetallescontables;
            this.fktiposcontable = unContable.fktiposcontable;
            this.fkusuariomodifica = unContable.fkusuariomodifica;
            this.fkusuarioregistra = unContable.fkusuarioregistra;
            this.idpersona = unContable.idpersona;
            this.idusuariomodifica = unContable.idusuariomodifica;
            this.idusuarioregistra = unContable.idusuarioregistra;
            this.esanulado = unContable.esanulado;
            this.eseditable = unContable.eseditable;
            this.fechacreacion = unContable.fechacreacion;
            this.fechamodificacion = unContable.fechamodificacion;
            this.observacion = unContable.observacion;
            this.valor = unContable.valor;

        }

        FBindingList<detallecontable> _fdetalle;
        public FBindingList<detallecontable> FDetalle
        {
            get
            {
                if (_fdetalle == null)
                    this._fdetalle = (FBindingList<detallecontable>)this.fkdetallescontables.ToFBinding();
                return this._fdetalle;
            }
        }

        public string TotalDebe { get { return this.fkdetallescontables.Sum(x => x.valordebe).ToString("N5"); } }

        public string TotalHaber { get { return this.fkdetallescontables.Sum(x => x.valorhaber).ToString("N5"); } }

        public string Diferencia { get { return this.fkdetallescontables.Sum(x => x.valordebe - x.valorhaber).ToString("N5"); } }
        /// <summary>
        /// fk_contable_usuarios
        /// </summary>
        [Association(ThisKey = "idusuarioregistra", OtherKey = "id", CanBeNull = false)]
        public usuario fkusuarioregistra { get; set; }

        /// <summary>
        /// fk_contable_usuarios
        /// </summary>
        [Association(ThisKey = "idusuariomodifica", OtherKey = "id", CanBeNull = false)]
        public usuario fkusuariomodifica { get; set; }

        public contable Relacionar(usuario fkusuarioregistra, usuario fkusuariomodifica)
        {
            this.fkusuarioregistra = fkusuarioregistra;
            this.fkusuariomodifica = fkusuariomodifica;
            return this;
        }

        public override void IntegrarAsociados()
        {
            this.idperiodo = (int?)this.fkfraccionperiodo.id ?? 0;
            this.idtipocontable = (short?)this.fktiposcontable.id ?? 0;
        }

        public static object Filtro(string unTexto)
        {
            Predicate<contable> predicado = x =>
                x.fktiposcontable.descripcion.ToLower().Contains(unTexto.ToLower()) ||
                x.fkpersona.NombreCompleto.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        public override string ToString()
        {
            return this.numero.ToString();
        }
    }

    [Table(Schema = "public", Name = "detallescontables")]
    public partial class detallecontable
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int idperiodo { get; set; }            // smallint
        [PrimaryKey, NotNull]
        public short idtipocontable { get; set; }            // smallint
        [PrimaryKey, NotNull]
        public int numerocontable { get; set; }            // integer
        [PrimaryKey, NotNull]
        public short registro { get; set; }            // smallint
        [PrimaryKey, NotNull]
        public int idcuentacontable { get; set; }            // integer
        [Column, Nullable]
        public string detallecuenta { get; set; }            // character varying(255)
        decimal _valordebe = 0;
        [Column, NotNull]
        public decimal valordebe { get { return _valordebe; } set { this._valordebe = value; if (value > 0) this.valorhaber = 0; } }            // numeric(15,5)
        decimal _valorhaber = 0;
        [Column, NotNull]
        public decimal valorhaber { get { return _valorhaber; } set { this._valorhaber = value; if (value > 0) this._valordebe = 0; } }            // numeric(15,5)
        [Column, NotNull]
        public short tipomovimiento { get; set; }            // smallint
        public detallecontable Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_detallescontables_contables
        /// </summary>
        [Association(ThisKey = "idperiodo, idtipocontable, numerocontable", OtherKey = "idperiodo, idtipocontable, numero", CanBeNull = false)]
        public contable fkcontable { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public detallecontable Relacionar(cuentacontable fkcuentascontable)
        {
            this.fkcuentascontable = fkcuentascontable;
            return this;
        }

        public detallecontable Relacionar(contable fkcontable)
        {
            this.fkcontable = fkcontable;
            return this;
        }

        #endregion
    }

    public partial class detallecontable 
    {
        public string CodigoCuenta { get; set; }
        public detallecontable()
        {

        }

        public detallecontable(detallecontable unItem)
        {
            this.idtipocontable = unItem.idtipocontable;
            this.idperiodo = unItem.idperiodo;
            this.detallecuenta = unItem.detallecuenta;
            this.fkcontable = unItem.fkcontable;
            this.fkcuentascontable = unItem.fkcuentascontable;
            this.idcuentacontable = unItem.idcuentacontable;
            this.numerocontable = unItem.numerocontable;
            this.registro = unItem.registro;
            this.tipomovimiento = unItem.tipomovimiento;
            this._valordebe = unItem.valordebe;
            this._valorhaber = unItem.valorhaber;
        }

        cuentacontable _fkcuentascontable;
        /// <summary>
        /// fk_detallescontables_cuentascontables
        /// </summary>
        [Association(ThisKey = "idcuentacontable", OtherKey = "id", CanBeNull = false)]
        public cuentacontable fkcuentascontable
        {
            get
            {
                if (this._fkcuentascontable == null)
                    return General.cuentaContableCero;
                else
                    return this._fkcuentascontable;
            }
            set
            {
                this._fkcuentascontable = value;
                if (value == null) { this.CodigoCuenta = null; this.idcuentacontable = 0; }
                else { this.CodigoCuenta = value.codigo; this.idcuentacontable = value.id; }
            }
        }
    }

    public partial class ordenpedido 
    {
        //private decimal total;
        //private decimal cancelado;
        //private decimal saldo;

        public decimal total { get; set; }
        public decimal cancelado { get; set; }
        public decimal saldo { get; set; }
        public string identificacion { get { return this.fkcliente.identificacion; } }
        //public List<conveniopago> ConveniosPago { get { return this.fkidentificadorespago.fkconveniospago.ToList(); } set { this.fkidentificadorespago.fkconveniospago = value; } }
        public string telefonos()
        {
            return string.Format("{0} {1}",
                String.IsNullOrEmpty(this.fkcliente.telefono) ? string.Empty : " Fijo: " + this.fkcliente.telefono,
                String.IsNullOrEmpty(this.fkcliente.celular) ? string.Empty : " Movil: " + this.fkcliente.celular).TrimStart();
        }

        ///// <summary>
        ///// fk_detallesordenespedidos_ordenespedidos_BackReference
        ///// </summary>
        //[Association(ThisKey = "id", OtherKey = "idordenpedido", CanBeNull = false)]
        //new public IEnumerable<detallesordenespedido> fkdetallesordenespedido { get; set; }

        //new public ordenpedido Relacionar(IEnumerable<detallesordenespedido> fkdetallesordenespedido)
        //{
        //    this.fkdetallesordenespedido = fkdetallesordenespedido;
        //    return this;
        //}
    }

    [Table(Schema = "public", Name = "detallesordenespedidos")]
    public partial class detalleordenpedido 
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int idordenpedido { get; set; }            // integer
        [Column, NotNull]
        public int idproducto { get; set; }            // integer
        [Column(Name = "cantidad"), NotNull]
        public short Cantidad { get { return this.cantidad; } set { this.cantidad = value; this.total = this.cantidad * this.precio; } }            // smallint
        [Column(Name = "precio"), NotNull]
        public decimal Precio { get { return this.precio; } set { this.precio = value; this.total = this.cantidad * this.precio; } }            // numeric(8,2)
        //public detalleordenpedido Objeto { get { return this; } }
        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_detallesordenespedidos_productos
        /// </summary>
        private producto unProducto;
        private short cantidad;
        private decimal precio;
        private decimal total;
        [Association(ThisKey = "idproducto", OtherKey = "id", CanBeNull = false)]
        public producto fkproducto
        {
            get
            {
                if (this.unProducto == null)
                { this.unProducto = General.productoCero; this.idproducto = this.unProducto.id; }
                return this.unProducto;
            }
            set
            {
                this.unProducto = value;
                if (value == null) { this.idproducto = 0; this.precio = 0; } else { this.idproducto = value.id; this.precio = value.precio1; this.total = this.cantidad * this.precio; }
            }
        }

        //public short Cantidad { get { return this.cantidad; } set { this.cantidad = value; this.total = this.cantidad * this.precio; } }
        //public decimal Precio { get { return this.precio; } set { this.precio = value; this.total = this.cantidad * this.precio; } }
        public decimal Total { get { return this.total; } }
        public detalleordenpedido Objeto { get { return this; } }

        /// <summary>
        /// fk_detallesordenespedidos_ordenespedidos
        /// </summary>
        [Association(ThisKey = "idordenpedido", OtherKey = "id", CanBeNull = false)]
        public ordenpedido fkordenespedido { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public detalleordenpedido Relacionar(producto fkproducto)
        {
            this.fkproducto = fkproducto;
            return this;
        }

        public detalleordenpedido Relacionar(ordenpedido fkordenespedido)
        {
            this.fkordenespedido = fkordenespedido;
            return this;
        }

        #endregion
    }



    public partial class cuentacontable 
    {
        private bool vinculado;

        [Column(Storage = "vinculado", IsColumn = false, SkipOnInsert = true, SkipOnUpdate = true, Name = "case when (select count(c.codigo) from cuentascontables c where c.idpadre = cuentascontables.id and c.periodo = year(now())) = 0 then false else true end vinculado", DataType = LinqToDB.DataType.Boolean), Nullable]
        public bool Vinculado { get { return this.vinculado; } internal set { this.vinculado = value; } }

        private cuentacontable padre;
        public cuentacontable Padre { get { return padre; } set { this.padre = value; if (value != null) { this.idpadre = value.id; } } }

        public string codigopadre { get; set; }

        #region FUNCIONES ESTATICAS

        public static object Filtro(string unTexto)
        {
            Predicate<cuentacontable> predicado = x =>
                x.codigo.Contains(unTexto) ||
                x.nombre.ToLower().Contains(unTexto.ToLower()) ||
                x.codigopadre.Contains(unTexto) ||
                x.Padre.ToString().ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        #endregion FUNCIONES ESTATICAS

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return string.Format("{0} {1}", this.codigo, this.nombre).TrimStart();
        }

        #endregion INVALIDACIONES (OVERRIDE)
    }

    public partial class estadoordenpedido 
    {
        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class banco 
    {
        [Sql.Expression("select max(id) as id from bancos")]
        public static long ContractSequence { get; set; }

        public banco()
        {

        }

        public static object Filtro(string unTexto)
        {
            Predicate<banco> predicado = x =>
                x.nombre.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        public override string ToString()
        {
            return this.nombre;
        }

    }

    public partial class producto 
    {
        public producto()
        {
            if (this.fkunidadesdemedida == null)
                this.fkunidadesdemedida = General.unidadCero;
            if (this.fkmarca == null)
                this.fkmarca = General.marcaCero;
        }

        public static object Filtro(string unTexto)
        {
            Predicate<producto> predicado = x =>
                x.descripcion.ToLower().Contains(unTexto.ToLower()) ||
                x.fkmarca.descripcion.ToLower().Contains(unTexto.ToLower()) ||
                x.fkunidadesdemedida.descripcion.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        public override string ToString()
        {
            return this.descripcion + (this.fkmarca == null ? "" : " - " + this.fkmarca.descripcion);
        }
    }

    public partial class cuentabanco 
    {
        public cuentabanco()
        {

        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class documento 
    {
        public documento()
        {

        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class parametrogeneral 
    {
        public parametrogeneral()
        {

        }

        public override string ToString()
        {
            return this.nombre + " - " + this.valor;
        }
    }

    public partial class operadoratelefonia 
    {
        public operadoratelefonia()
        {

        }

        public override string ToString()
        {
            return this.nombre;
        }
    }

    public partial class iteminventario 
    {
        public iteminventario()
        {

        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class formapago 
    {
        public formapago()
        {

        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class estadopersona 
    {
        public estadopersona()
        {

        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    public partial class perfil 
    {
        public perfil()
        {

        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.descripcion;
        }

        #endregion INVALIDACIONES (OVERRIDE)
    }

    public partial class tipocontable 
    {
        public tipocontable()
        {

        }

        #region INVALIDACIONES (OVERRIDE)
        public override string ToString()
        {
            return this.descripcion;
        }
        #endregion INVALIDACIONES (OVERRIDE)
    }

    public partial class unidaddemedida 
    {
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.descripcion;
        }

        #endregion
    }

    public partial class usuariosesionactiva 
    {
        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return this.fechasesion.ToString();
        }

        #endregion
    }

    public partial class perfilmenu 
    {
        public string Descripcion { get { return this.fkmenu.ToString(); } }
        public bool Asignado { get; set; }

        public static object Filtro(string unTexto)
        {
            Predicate<perfilmenu> predicado = x =>
                x.Descripcion.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.fkmenu == null ? base.ToString() : "Asignado: " + this.Asignado + " " + this.fkmenu);
        }

        #endregion
    }

    public partial class usuarioperfil 
    {
        public string Descripcion { get { return this.fkperfile.ToString(); } }
        public bool Asignado { get; set; }

        #region INVALIDACIONES (OVERRIDE)

        public static object Filtro(string unTexto)
        {
            Predicate<usuarioperfil> predicado = x =>
                x.Descripcion.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        public override string ToString()
        {
            return (this.fkperfile == null ? base.ToString() : "Asignado: " + this.Asignado + " " + this.fkperfile);
        }

        #endregion
    }

    public partial class tarjetacredito 
    {
        public bool Asignado { get; set; }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.descripcion);
        }

        #endregion
    }

    public partial class marca 
    {
        public bool Asignado { get; set; }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.descripcion);
        }

        #endregion
    }

    [Table(Schema = "public", Name = "empresas")]
    public partial class empresa 
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public short id { get; set; }            // smallint
        [Column, Nullable]
        public string nombre { get; set; }            // character varying(50)
        [Column, Nullable]
        public string identificacion { get; set; }            // character(13)
        [Column, Nullable]
        public string razonsocial { get; set; }            // character varying(100)
        [Column, Nullable]
        public string nombrecomercial { get; set; }            // character varying(250)
        [Column, Nullable]
        public int? idpersonagerente { get; set; }            // integer
        [Column, Nullable]
        public int idpersonacontador { get; set; }            // integer
        [Column, NotNull]
        public bool obligadocontabilidad { get; set; }            // boolean
        [Column, Nullable]
        public string contribuyenteespecial { get; set; }            // character varying(5)
        [Column, Nullable]
        public bool activo { get; set; }            // boolean
        [Column, Nullable]
        public byte[] logo { get; set; }            // bytea
        public empresa Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        private persona _fkpersonacontador;
        /// <summary>
        /// fk_empresas_personas_contador
        /// </summary>
        [Association(ThisKey = "idpersonacontador", OtherKey = "id", CanBeNull = true)]
        public persona fkpersonascontador
        {
            get { return this._fkpersonacontador; }
            set { this._fkpersonacontador = value; if (value == null) this.idpersonacontador = 0; else this.idpersonacontador = value.id; }
        }

        private persona _fkpersonagerente;
        /// <summary>
        /// fk_empresas_personas_gerente
        /// </summary>
        [Association(ThisKey = "idpersonagerente", OtherKey = "id", CanBeNull = true)]
        public persona fkpersonasgerente
        {
            get { return this._fkpersonagerente; }
            set { this._fkpersonagerente = value; if (value == null) this.idpersonagerente = null; else this.idpersonagerente = value.id; }
        }

        /// <summary>
        /// fk_oficinas_empresas_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idempresa", CanBeNull = false)]
        public IEnumerable<sucursal> fkoficinas { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public empresa Relacionar(persona fkpersonascontador, persona fkpersonasgerente)
        {
            this.fkpersonascontador = fkpersonascontador;
            this.fkpersonasgerente = fkpersonasgerente;
            return this;
        }

        public empresa Relacionar(IEnumerable<sucursal> fkoficinas)
        {
            this.fkoficinas = fkoficinas;
            return this;
        }

        public static object Filtro(string unTexto)
        {
            Predicate<empresa> predicado = x =>
                x.nombre.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        #endregion

        public empresa()
        {

        }

        #region INVALIDACIONES (OVERRIDE)

        public override void IntegrarAsociados()
        {
            if (this.fkpersonascontador != null)
                this.idpersonacontador = this.fkpersonascontador.id;
            if (this.fkpersonasgerente != null)
                this.idpersonagerente = this.fkpersonasgerente.id;
        }

        public override string ToString()
        {
            return (this.nombre);
        }

        #endregion
    }

    [Table(Schema = "public", Name = "sucursales")]
    public partial class sucursal 
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int id { get; set; }            // integer
        [Column, Nullable]
        public short? idempresa { get; set; }            // smallint
        [Column, Nullable]
        public string nombre { get; set; }            // character varying(100)
        [Column, Nullable]
        public short? codigoestablecimiento { get; set; }            // smallint
        [Column, Nullable]
        public int? idbarrio { get; set; }            // integer
        [Column, Nullable]
        public string direccion { get; set; }            // character varying(255)
        [Column, Nullable]
        public int? idpersonaencargado { get; set; }            // integer
        [Column, Nullable]
        public string correo { get; set; }            // character varying(250)
        [Column, Nullable]
        public string telefono { get; set; }            // character varying(13)
        public sucursal Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        private persona _fkpersona;
        /// <summary>
        /// fk_oficinas_personas
        /// </summary>
        [Association(ThisKey = "idpersonaencargado", OtherKey = "id", CanBeNull = true)]
        public persona fkpersona { get { return this._fkpersona; } set { this._fkpersona = value; if (value == null) this.idpersonaencargado = 0; else this.idpersonaencargado = value.id; } }

        private empresa _fkempresa;
        /// <summary>
        /// fk_oficinas_empresas
        /// </summary>
        [Association(ThisKey = "idempresa", OtherKey = "id", CanBeNull = true)]
        public empresa fkempresa { get { return this._fkempresa; } set { this._fkempresa = value; if (value == null)this.idempresa = 0; else this.idempresa = value.id; } }

        private barrio _fkbarrio;
        /// <summary>
        /// fk_oficinas_barrios
        /// </summary>
        [Association(ThisKey = "idbarrio", OtherKey = "id", CanBeNull = true)]
        public barrio fkbarrio { get { return this._fkbarrio; } set { this._fkbarrio = value; if (value == null) this.idbarrio = 0; else this.idbarrio = value.id; } }

        /// <summary>
        /// fk_telefonosoficinas_oficinas_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idoficina", CanBeNull = false)]
        public List<telefonosucursal> fktelefonossucursal { get; set; }

        /// <summary>
        /// fk_periodos_oficinas_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idoficina", CanBeNull = false)]
        public IEnumerable<periodo> fkperiodos { get; set; }

        #endregion

        public sucursal()
        {
            this.fktelefonossucursal = new List<telefonosucursal>();
        }

        #region RELACIONES (FUNCIONES)

        public sucursal Relacionar(persona fkpersona)
        {
            this.fkpersona = fkpersona;
            return this;
        }

        public sucursal Relacionar(empresa fkempresa)
        {
            this.fkempresa = fkempresa;
            return this;
        }

        public sucursal Relacionar(barrio fkbarrio)
        {
            this.fkbarrio = fkbarrio;
            return this;
        }

        public sucursal Relacionar(List<telefonosucursal> fktelefonosoficina)
        {
            this.fktelefonossucursal = fktelefonosoficina;
            return this;
        }

        public sucursal Relacionar(IEnumerable<periodo> fkperiodos)
        {
            this.fkperiodos = fkperiodos;
            return this;
        }

        public static object Filtro(string unTexto)
        {
            Predicate<sucursal> predicado = x =>
                x.nombre.ToLower().Contains(unTexto.ToLower());
            return predicado;
        }

        #endregion

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return (this.nombre);
        }

        #endregion
    }

    public partial class telefonooficina 
    {
        public telefonooficina()
        {

        }

        #region INVALIDACIONES (OVERRIDE)

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }

    [Table(Schema = "public", Name = "conveniospagos")]
    public partial class conveniopago
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int identificadorpagos { get; set; }            // integer
        [Column, NotNull]
        public string idformapago { get; set; }            // character varying(5)
        [Column, NotNull]
        public decimal valor { get; set; }            // numeric(18,2)
        [Column, NotNull]
        public short pagos { get; set; }            // smallint
        public conveniopago Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_conveniospagos_identificadorespagos
        /// </summary>
        [Association(ThisKey = "identificadorpagos", OtherKey = "id", CanBeNull = false)]
        public identificadorpago fkidentificadorespagos { get; set; }

        formapago _fkformaspago;
        /// <summary>
        /// fk_conveniospagos_formaspagos
        /// </summary>
        [Association(ThisKey = "idformapago", OtherKey = "id", CanBeNull = false)]
        public formapago fkformaspago
        {
            get { return this._fkformaspago; }
            set
            {
                this._fkformaspago = value;
                if (value == null)
                {
                    this.idformapago = null;
                    if (this.fkpagos != null)
                        this.fkpagos.ForEach(delegate(pago x) { x.idformapago = value.id; });
                }
                else
                    this.idformapago = value.id;
            }
        }

        /// <summary>
        /// fk_pagos_conveniospagos_BackReference
        /// </summary>
        [Association(ThisKey = "identificadorpagos, idformapago", OtherKey = "identificadorpagos, idformapago", CanBeNull = false)]
        public List<pago> fkpagos { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public conveniopago Relacionar(identificadorpago fkidentificadorespagos)
        {
            this.fkidentificadorespagos = fkidentificadorespagos;
            return this;
        }

        public conveniopago Relacionar(formapago fkformaspago)
        {
            this.fkformaspago = fkformaspago;
            return this;
        }

        public conveniopago Relacionar(List<pago> fkpagos)
        {
            this.fkpagos = fkpagos;
            return this;
        }

        #region CONSTRUCTORES

        public conveniopago()
        {

        }

        #endregion CONSTRUCTORES
        #endregion

    }

    public partial class estadosfactura 
    {

    }

    [Table(Schema = "public", Name = "ventas")]
    public partial class venta
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int id { get; set; }            // integer
        [Column, NotNull]
        public int idcliente { get; set; }            // integer
        [Column, NotNull]
        public DateTime fecha { get; set; }            // date
        [Column, Nullable]
        public string direccion { get; set; }            // smallint
        [Column, NotNull]
        public string telefono { get; set; }            // smallint
        [Column, NotNull]
        public string observacion { get; set; }            // character varying(255)
        [Column, NotNull]
        public short idestadofactura { get; set; }            // smallint
        [Column, NotNull]
        public int idusuarioregistra { get; set; }            // smallint
        [Column, NotNull]
        public int idusuarioanula { get; set; }            // smallint
        [Column, Nullable]
        public int? ididentificadorpago { get; set; }            // integer
        [Column, NotNull]
        public bool esanulado { get; set; }            // boolean
        [Column, NotNull]
        public DateTime fechaservidor { get; set; }            // timestamp (3) without time zone
        [Column, NotNull]
        public int idbarrio { get; set; }            // integer
        [Column, Nullable]
        public DateTime? fechaanulacion { get; set; }            // timestamp (3) without time zone
        [Column, Nullable]
        public bool eseditable { get; set; }            // timestamp (3) without time zone
        public venta Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_ventas_barrios
        /// </summary>
        [Association(ThisKey = "idbarrio", OtherKey = "id", CanBeNull = false)]
        public barrio fkbarrio { get; set; }

        /// <summary>
        /// fk_ventas_barrios
        /// </summary>
        [Association(ThisKey = "idcanton", OtherKey = "id", CanBeNull = false)]
        public canton fkcanton { get; set; }

        /// <summary>
        /// fk_ventas_clientes
        /// </summary>
        [Association(ThisKey = "idcliente", OtherKey = "idpersona", CanBeNull = false)]
        public cliente fkcliente { get; set; }

        /// <summary>
        /// fk_ventas_estadosfacturas
        /// </summary>
        [Association(ThisKey = "idestadofactura", OtherKey = "id", CanBeNull = false)]
        public estadosfactura fkestadosfactura { get; set; }

        /// <summary>
        /// fk_ventas_identificadorespagos
        /// </summary>
        [Association(ThisKey = "ididentificadorpago", OtherKey = "id", CanBeNull = true)]
        public identificadorpago fkidentificadorespago { get; set; }

        /// <summary>
        /// fk_ventas_usuarios
        /// </summary>
        [Association(ThisKey = "idusuarioregistra", OtherKey = "id", CanBeNull = false)]
        public usuario fkusuario { get; set; }

        /// <summary>
        /// fk_ventas_usuarios1
        /// </summary>
        [Association(ThisKey = "idusuarioanula", OtherKey = "id", CanBeNull = true)]
        public usuario fkusuarios1 { get; set; }

        /// <summary>
        /// fk_detallesventas_ventas_BackReference
        /// </summary>
        [Association(ThisKey = "id", OtherKey = "idventa", CanBeNull = false)]
        public List<detalleventa> fkdetallesventa { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public venta Relacionar(barrio fkbarrio)
        {
            this.fkbarrio = fkbarrio;
            return this;
        }

        public venta Relacionar(cliente fkcliente)
        {
            this.fkcliente = fkcliente;
            return this;
        }

        public venta Relacionar(estadosfactura fkestadosfactura)
        {
            this.fkestadosfactura = fkestadosfactura;
            return this;
        }

        public venta Relacionar(identificadorpago fkidentificadorespago)
        {
            this.fkidentificadorespago = fkidentificadorespago;
            return this;
        }

        public venta Relacionar(usuario fkusuario, usuario fkusuarios1)
        {
            this.fkusuario = fkusuario;
            this.fkusuarios1 = fkusuarios1;
            return this;
        }

        public venta Relacionar(List<detalleventa> fkdetallesventa)
        {
            this.fkdetallesventa = fkdetallesventa;
            return this;
        }

        #endregion
    }

    public partial class venta 
    {
        public venta()
        {
            this.fkdetallesventa = new List<detalleventa>();
        }
        public string Cliente { get { return string.Format("Identificacion : {0}\nNombre         : {1}", this.fkcliente.identificacion, this.fkcliente.nombrecompleto); } }

        FBindingList<detalleventa> _fdetalle;
        public FBindingList<detalleventa> FDetalle
        {
            get
            {
                if (_fdetalle == null)
                    this._fdetalle = (FBindingList<detalleventa>)this.fkdetallesventa.ToFBinding();
                return this._fdetalle;
            }
        }

    }

    public partial class alineacion 
    {

        public override string ToString()
        {
            return this.nombre;
        }
    }

    public partial class tipocolumna 
    {

        public override string ToString()
        {
            return this.nombre;
        }
    }

    public partial class ColumnaSis : ColumnSchema
    {
        public override string ToString()
        {
            return this.ColumnName == null ? "" : this.ColumnName;
        }
    }

    [Table(Schema = "public", Name = "columnasgrids")]
    public partial class columnasgrid
    {
        #region PROPIEDADES

        [PrimaryKey, NotNull]
        public int idmenu { get; set; }            // integer
        string _nombre;
        [PrimaryKey, NotNull]
        public string nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                this.cabecera = this.nombre == null ? null : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.nombre);
                this.propertyname = this._nombre;
            }
        }            // character varying(255)
        [PrimaryKey, NotNull]
        public short identificador { get; set; }            // smallint
        [Column, NotNull]
        public short orden { get; set; }            // smallint
        [Column, Nullable]
        public short idtipocolumna { get; set; }            // smallint
        [Column, Nullable]
        public string cabecera { get; set; }            // character varying(255)
        [Column, Nullable]
        public string formatofecha { get; set; }            // character varying(255)
        [Column, Nullable]
        public DateTime fechaminima { get; set; }            // date
        [Column, Nullable]
        public string propertyname { get; set; }            // character varying(255)
        [Column, Nullable]
        public string valuemember { get; set; }            // character varying(255)
        [Column, Nullable]
        public string displaymember { get; set; }            // character varying(255)
        [Column, Nullable]
        public string tag { get; set; }            // character varying(255)
        [Column, Nullable]
        public string busqueda { get; set; }            // character varying(255)
        [Column, Nullable]
        public short idalineacion { get; set; }            // smallint
        [Column, Nullable]
        public short width { get; set; }            // smallint
        [Column, Nullable]
        public short maxlength { get; set; }            // smallint
        [Column, Nullable]
        public bool sololectura { get; set; }            // boolean
        [Column, Nullable]
        public bool visible { get; set; }            // boolean
        public columnasgrid Objeto { get { return this; } }

        #endregion

        #region RELACIONES (PROPIEDADES)

        /// <summary>
        /// fk_columnasgrids_menus
        /// </summary>
        [Association(ThisKey = "idmenu", OtherKey = "id", CanBeNull = false)]
        public menu fkcolumnasgrid { get; set; }

        #endregion

        #region RELACIONES (FUNCIONES)

        public columnasgrid Relacionar(alineacion fkalineacion)
        {
            this.fkalineacion = fkalineacion;
            return this;
        }

        public columnasgrid Relacionar(tipocolumna fktiposcolumna)
        {
            this.fktiposcolumna = fktiposcolumna;
            return this;
        }

        public columnasgrid Relacionar(menu fkcolumnasgrid)
        {
            this.fkcolumnasgrid = fkcolumnasgrid;
            return this;
        }

        #endregion
    }

    public partial class columnasgrid 
    {
        public columnasgrid()
        {
            this.visible = true;
            //this.formatofecha = "yyyy-MM-dd hh:mm:ss";
            this.fechaminima = new DateTime(1900, 02, 01);

        }



        private ColumnaSis columna;

        public ColumnaSis Columna
        {
            get
            {
                if (this.columna == null) this.columna = new ColumnaSis();
                this.columna.ColumnName = this.nombre;
                return this.columna;
            }

            set
            {
                this.columna = value;
                this.nombre = value.ColumnName;
                this.cabecera = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.nombre);
                this.propertyname = this.nombre;
            }
        }
        alineacion _fkalineacion;
        /// <summary>
        /// fk_columnasgrids_alineacion
        /// </summary>
        [Association(ThisKey = "idalineacion", OtherKey = "id", CanBeNull = true)]
        public alineacion fkalineacion
        {
            get { if (this._fkalineacion == null) this._fkalineacion = General.alineacionCero; return this._fkalineacion; }
            set
            {
                this._fkalineacion = value;
                if (value == null)
                {
                    this.idalineacion = 0;
                }
                else
                    this.idalineacion = value.id; ;
            }
        }

        private tipocolumna _fktiposcolumna;
        /// <summary>
        /// fk_columnasgrids_tiposcolumnas
        /// </summary>
        [Association(ThisKey = "idtipocolumna", OtherKey = "id", CanBeNull = true)]
        public tipocolumna fktiposcolumna
        {
            get { if (this._fktiposcolumna == null) this._fktiposcolumna = General.tipocolumnaCero; return this._fktiposcolumna; }
            set
            {
                this._fktiposcolumna = value;
                if (value == null)
                {
                    this.idtipocolumna = 0;
                }
                else
                    this.idtipocolumna = value.id; ;
            }
        }

    }

    public partial class periodo 
    {


        public override string ToString()
        {
            return this.anio.ToString();
        }
    }

    public partial class detalleventa 
    {

        public detalleventa()
        { }
        public string CodigoProducto { get; set; }
        producto _fkproducto;
        /// <summary>
        /// fk_detallesventas_productos
        /// </summary>
        [Association(ThisKey = "idproducto", OtherKey = "id", CanBeNull = false)]
        public producto fkproducto
        {
            get
            {
                if (this._fkproducto == null)
                {
                    this._fkproducto = General.productoCero; this.idproducto = this._fkproducto.id;
                }
                return this._fkproducto;
            }
            set
            {
                this._fkproducto = value; if (value == null) { this.idproducto = 0; this.CodigoProducto = null; this.precio = 0; } else { this.idproducto = value.id; this.CodigoProducto = value.codigo; this.precio = value.precio1; }
            }
        }
    }

    public partial class bodega 
    {
        public bodega()
        {
            this.activo = true;
        }
        public override void IntegrarAsociados()
        {
            this.idbarrio = this.fkbarrio.id;
            this.idsucursal = this.fksucursale.id;
            this.idusuario = fkusuario.id;
        }
        public override string ToString()
        {
            return (this.fksucursale != null ? this.fksucursale.nombre : "") + " " + this.descripcion;
        }
    }

    public partial class inventario 
    {
        public inventario()
        { }
        FBindingList<detallesinventario> _fdetalle;
        public FBindingList<detallesinventario> FDetalle
        {
            get
            {
                if (_fdetalle == null)
                    this._fdetalle = (FBindingList<detallesinventario>)this.fkdetallesinventarios.ToFBinding();
                return this._fdetalle;
            }
        }
    }
    public partial class detallesinventario 
    {
        public string Codigo { get; set; }
        public decimal Total { get; set; }
        public detallesinventario()
        { }

        /// <summary>
        /// fk_detallesinventarios_productos
        /// </summary>
        [Association(ThisKey = "idproducto", OtherKey = "id", CanBeNull = false)]
        public producto fkproducto { get; set; }
        public override void IntegrarAsociados()
        {
            this.Codigo = fkproducto == null ? string.Empty : fkproducto.codigo;
            this.idproducto = fkproducto == null ? 0 : fkproducto.id;
            this.precio = fkproducto == null ? 0 : fkproducto.precio1;

            this.idperiodo = fkinventario == null ? 0 : fkinventario.idperiodo;
            this.tipo = fkinventario == null ? "" : fkinventario.tipo;
            this.numero = fkinventario == null ? 0 : fkinventario.numero;

            this.Total = this.cantidad * this.precio;
        }
    }
}
