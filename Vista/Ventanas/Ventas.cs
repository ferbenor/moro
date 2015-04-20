using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Proveedores;
using ModeloDB;

namespace WindowsApp
{
    public partial class Ventas : Form, IAccesoMetodos
    {
        #region VARIABLES Y PROPIEDADES
        /// <summary>
        /// CAMPOS CLAVE DEL REGISTRO
        /// </summary>
        private WhereBuilder expresion = new WhereBuilder();
        private List<object> parametros = new List<object>();
        private int idRegistro = 0;

        private Control[] listaControles = null;
        private bool raiseEvent = false;
        private EstadoBarraEnum estadoBarra = EstadoBarraEnum.NINGUNO;
        public bool RaiseEvent { get { return this.raiseEvent; } set { this.raiseEvent = value; } }
        public object ProveedorInstancia { get; set; }
        public string Modulo { get; set; }
        public bool EsEditable { get; set; }
        public string UnaBusqueda { get; set; }

        private bool tieneFiltro = false;

        public string PieDetalle { get; set; }
        public object ColumnasGrid { get; set; }
        public bool RegistroEditable { get; set; }
        StringBuilder unaCondicion = new StringBuilder();

        BindingSource bs = new BindingSource();

        private venta objetoLocal = new venta();

        #endregion VARIABLES Y PROPIEDADES

        #region CONSTRUCTOR Y METODOS PARA EVENTOS DE VENTANA
        public Ventas()
        {
            InitializeComponent();
            this.listaControles = General.ArrayControles(this);
            this._dgrFKDetallesVenta.AutoGenerateColumns = false;
            //ContablePr.Instancia.ArmarGridDetalle(this._dgrFKDetallesOrdenesPedido);
            //this.EsEditable = true;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            try
            {
                this.RegistrarControles();
                //APARIENCIA Y DISEÑO
                VentanaPrincipalCr.Instancia.Apariencia(this);
                this.colVer.Image = General.Imagenes.Images["Listar.ico"];
                this._txtCliente.ButtonCustom.Image = General.Imagenes.Images["Agregar.png"];
                this._txtCliente.ButtonCustom2.Image = General.Imagenes.Images["Eliminar.ico"];
                this.stcEdiciones.Tabs["tabEdicion"].Visible = false;
                this.stcEdiciones.Tabs["tabLista"].Visible = true;
                this.dgrLista.AutoGenerateColumns = false;
                this._dgrFKDetallesVenta.AutoGenerateColumns = false;
                //GENERAR COLUMNAS
                this.dgrLista.SetColumnasGrid(this.ColumnasGrid);
                this._dgrFKDetallesVenta.SetColumnasGrid(this.ColumnasGrid, 1);
                //DATOS INICIALES Y VINCULACION DE CONTROLES
                this.bs.DataSource = VentaPr.Instancia.ObtenerDatos();
                this.dgrLista.DataSource = this.bs;

                this._cboLugar.DisplayMember = "descripcion";
                this._cboLugar.ValueMember = "objeto";
                this._cboLugar.DataSource = CantonPr.Instancia.Registros();
                this._lblAnulado.DataBindings.Add(new Binding("Visible", this.bs, "esanulado", true));
                this._txtNumero.DataBindings.Add(new Binding("Text", this.bs, "id", true));
                this._cboLugar.DataBindings.Add(new Binding("SelectedValue", this.bs, "fkcanton", true));
                this._dtpFecha.DataBindings.Add(new Binding("Value", this.bs, "fecha", true));
                this._txtCliente.DataBindings.Add(new Binding("Text", this.bs, "fkcliente", true));
                this._txtDireccion.DataBindings.Add(new Binding("Text", this.bs, "direccion", true));
                this._txtTelefono.DataBindings.Add(new Binding("Text", this.bs, "telefono", true));
                this.chkEditable.DataBindings.Add(new Binding("Checked", this.bs, "eseditable", true));
                this._dgrFKDetallesVenta.DataBindings.Add(new Binding("DataSource", this.bs, "FDetalle", true));
                //VALIDACIONES ADICIONALES
                tieneFiltro = GestionMaestrasCr.Instancia.Filtro(this.bs.DataSource, "");
                this._dgrFKDetallesVenta.PermitirEventosInternos = true;
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        private void Ventas_Activated(object sender, EventArgs e)
        {
            ((Principal)this.MdiParent).tstFiltrar.Visible = tieneFiltro;
            ((Principal)this.MdiParent).EscribeConteo(this.dgrLista.RowCount);
            GestionOpciones(true);
        }

        private void Ventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = VerificaCambios();
            switch (resultado)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    this.Guardar();
                    break;
            }

            if (!e.Cancel)
                this.objetoLocal = null;
        }
        #endregion CONSTRUCTOR Y METODOS PARA EVENTOS DE VENTANA

        #region LISTADO, CARGA Y LIMPIEZA DE CONTROLES DEL FORMULARIO

        private void CargarControlesAdicionales()
        {
            //if (string.IsNullOrEmpty(this._txtIdentificacionSN.Text))
            //    this._txtIdentificacionSN.Text = this.objetoLocal.fkcliente.identificacion;

            //this.txtCliente.Text = this.objetoLocal.fkcliente.nombrecompleto;
            //this.txtDireccion.Text = this.objetoLocal.fkcliente.referenciadireccion;
            //this.txtTelefono.Text = this.objetoLocal.telefonos();
        }

        private void CargarCampos()
        {
            ////EN ESTA SECCION SE ESTABLECEN LOS GRIDS////
            ///this._dgrDetalle.DataSource = null;
            ///this._dgrDetalle.DataSource = SoporteList<DetalleObjeto>.ToBindingList(objetoLocal.DetalleObjeto);

            ///////////////////////////////////////////////
            //General.CargarControles(this.listaControles, this.objetoLocal);
            //this.CargarControlesAdicionales();

            //this._dgrDetalleOrdenPedido.DataSource = SoporteList<detallesordenespedido>.ToBindingList(this.objetoLocal.fkdetallesordenespedido.ToList());
            //this.objetoLocal.fkdetallesordenespedido.CargarGrid(this._dgrFKDetallesOrdenesPedido);
            //this.objetoLocal.fkidentificadorespago.fkconveniospago.CargarGrid(this._conveniosPagos1.ObjetoGrid);

            //CAMPOS ADICIONALES DE TRATAMIENTO PERSONALIZADO
            //this._lblMensaje.Text = this.objetoLocal.fkestadosordenespedido.descripcion;
            //this._lblMensaje.ForeColor = this.objetoLocal.idestadoordenpedido == 2 ? System.Drawing.Color.Red : System.Drawing.Color.Blue;
            //this._conveniosPagos1.Objeto = this.objetoLocal.fkidentificadorespago;
        }

        private void GuardarCampos()
        {
            General.GuardarObjeto(this.listaControles, this.objetoLocal);
        }

        private void CargarCombos()
        {
            //OrdenPedidoPr.Instancia.LimpiarListas();
            //General.CargarCombos(this.cboBuscarEstado, "id", "descripcion", EstadoOrdenPedidoPr.Instancia.Registros());
            //General.CargarCombos(this._conveniosPagos1.colFormaPago,"id","Objeto",FormaPagoPr.Instancia.RegistrosActivos());
            //General.CargarCombos(this._cboTipoDocumento, "Objeto", "Descripcion", ClientePr.Instancia.ListaTipoDocumento);
            //General.CargarCombos(this._cboGenero, "Objeto", "Descripcion", ClientePr.Instancia.ListaGenero);
            //General.CargarCombos(this._cboEstadoCivil, "Objeto", "Descripcion", ClientePr.Instancia.ListaEstadoCivil);
            //if (this._cboTipoPersona.Items.Count > 0) this._cboTipoPersona.SelectedIndex = 1;
            //if (this._cboEstadoCivil.Items.Count > 0) this._cboEstadoCivil.SelectedIndex = 0;
            //if (this._cboGenero.Items.Count > 0) this._cboGenero.SelectedIndex = 0;
            //if (this._cboTipoDocumento.Items.Count > 0) this._cboTipoDocumento.SelectedIndex = 0;
        }

        public object ValorCelda(string unaColumna)
        {
            try
            {
                return this.dgrLista.CurrentRow.Cells[unaColumna].Value;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void SeleccionFila(int unaColumna, int unId)
        {
            int fila = -1;
            //fila = ((BindingSource)this.dgrLista.DataSource).Find("id", unId.ToString());
            //DataRow nfila = ((DataTable)((BindingSource)this.dgrLista.DataSource).DataSource).Select("id = " + unId).First<DataRow>();

            foreach (DataGridViewRow registro in this.dgrLista.Rows)
                if (registro.Cells["colnumero"].Value.ToString().Equals(unId.ToString()))
                {
                    fila = registro.Index;
                    break;
                }
            if (fila > -1)
            {
                this.dgrLista.CurrentCell = this.dgrLista.Rows[fila].Cells[unaColumna];
                //this.dgrLista.CurrentRow.Selected = true;
            }
        }
        #endregion LISTADO, CARGA Y LIMPIEZA DE CONTROLES DEL FORMULARIO

        #region FUNCIONES DE IACCESOMETODOS
        public void Nuevo()
        {
            this.raiseEvent = true;
            this.bs.AddNew();

            //this.objetoLocal = new contable();
            //this.objetoLocal.fkusuarioregistra = General.usuarioActivo.fkusuario;
            //this.objetoLocal.fkdetallescontables = new List<detallecontable>();

            //this.objetoLocal.fkdetallesordenespedido.CargarGrid(this._dgrFKDetallesOrdenesPedido);

            this.GestionBarra(EstadoBarraEnum.EDITANDO);
            //General.LimpiarControles(this.listaControles);
            //this.CargarControlesAdicionales();
            //CargarCombos();

            //this._txtIdentificacionSN.Focus();
            //this._cboTipoPersona.Focus();
            this.raiseEvent = false;
            //this.editando = true;
        }

        public void Editar()
        {
            Examinar(EstadoBarraEnum.EDITANDO);
        }

        private void Examinar(EstadoBarraEnum unEstadoBarra = EstadoBarraEnum.EXAMINANDO)
        {
            try
            {

                if (this.tabLista.Visible)
                {
                    //CargarCombos();
                    //this.objetoLocal = OrdenPedidoPr.Instancia.RegistroPorId((int)ValorCelda("id"));
                    //this.objetoLocal = (ordenpedido)this.dgrLista.CurrentRow.DataBoundItem.ObjetoBLV();
                    //this.objetoLocal = (contable)this.dgrLista.CurrentRow.DataBoundItem;
                }
                //if (this.objetoLocal == null)
                //    throw new Exception("El actual registro fue modificado, anulado o eliminado\npor favor verifique");
                //else
                //{
                //    this.idRegistro = this.objetoLocal.numero;
                //}
                //CargarCampos();
                //GestionOpciones();
                this.GestionBarra(unEstadoBarra);
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        public void Guardar()
        {
            this.Validate();
            this.bs.EndEdit();
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                {
                    //this.tipoEvento = "grabado";
                    //GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
                    //GestionMaestrasCr.Instancia.RaiseGrabar(null);
                    //this.GuardarCampos();
                    try
                    {
                        VentaPr.Instancia.Grabar(this.objetoLocal);
                        this.idRegistro = this.objetoLocal.id;

                        Actualizar();
                        GestionBarra(EstadoBarraEnum.NINGUNO);
                    }
                    catch (Exception ex)
                    {
                        General.Mensaje(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Informacion incompleta por favor verifique.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Cancelar()
        {
            if (estadoBarra != EstadoBarraEnum.BUSCANDO)
                this.Actualizar();
            this.GestionBarra(EstadoBarraEnum.NINGUNO);
        }

        public void Eliminar()
        {
            if (this._txtNumero.Text != "0")
                if (MessageBox.Show("Esta seguro de anular el registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.objetoLocal = new venta() { id = (int)ValorCelda("colnumero") };
                    VentaPr.Instancia.Borrar(this.objetoLocal);

                    this.Actualizar();
                }
        }

        public void Buscar()
        {
            GestionBarra(EstadoBarraEnum.BUSCANDO);
        }

        public void Actualizar()
        {
            try
            {
                this.lblMensaje.Visible = false;
                this.spvValidador.ClearFailedValidations();
                if (estadoBarra != EstadoBarraEnum.EDITANDO)
                    idRegistro = (int)ValorCelda("id");
                int columna = 1;
                if (this.dgrLista.CurrentCell != null)
                    columna = this.dgrLista.CurrentCell.ColumnIndex;

                VentaPr.Instancia.Registros(this.expresion.Compilar(), this.expresion.parametros).CargarGrid(this.dgrLista, this.bs);

                this.bs.DataSource = VentaPr.Instancia.ObtenerDatos(this.expresion.Compilar(), this.expresion.parametros);

                if (dgrLista.RowCount > 0)
                    GestionBarra(EstadoBarraEnum.NINGUNO);
                else
                    this.lblMensaje.Visible = true;
                SeleccionFila(columna, idRegistro);
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        public void Filtrar(string unTexto)
        {
            GestionMaestrasCr.Instancia.Filtro(this.bs.DataSource, unTexto);
        }

        public void Imprimir()
        {
            //if (!cambiosPendientes)
            //{
            //    ClienteCr.Instancia.ImprimirObjeto(this.objetoLocal);
            //}
        }

        public object ObtenerObjetoLocal()
        {
            return null;
        }

        public void EstablecerObjetoLocal(object unObjeto)
        { }

        #endregion FUNCIONES DE IACCESOMETODOS

        #region METODOS CONTROL DE VENTANA
        private void RegistrarControles()
        {
            //this._txtConyugueRO.Tag = 1;
            //this._txtBarrioRO.Tag = 3;
            //this._txtProfesionRO.Tag = 4;

            //this._bbqConyugue.Tag = this._txtConyugueRO;
            //this._bbqProfesion.Tag = this._txtProfesionRO;
            //this._bbqBarrio.Tag = this._txtBarrioRO;


            ////REGISTRO DE CONTROLES
            //ClienteCr.Instancia.LimpiarControles();
            //foreach (Control item in this.Controls)
            //{
            //    RegistraControl(item);
            //}
        }

        /*private void RegistraControl(Control unControl)
        {
            if (unControl.Controls.Count > 0)
                foreach (Control item in unControl.Controls)
                {
                    RegistraControl(item);
                }
            else
                if (unControl.Name.StartsWith("_"))
                    ClienteCr.Instancia.RegistrarControles(unControl);
        }*/

        private void GestionBarra(EstadoBarraEnum unEstado)
        {
            this.estadoBarra = unEstado;
            this.AcceptButton = null;
            switch (unEstado)
            {
                case EstadoBarraEnum.EXAMINANDO:
                    this.pnlBusqueda.Visible = false;
                    this.pnlBusquedaAvanzada.Visible = false;
                    this.SuspendLayout();
                    this.stcEdiciones.Tabs["tabEdicion"].Visible = true;
                    this.stcEdiciones.Tabs["tabLista"].Visible = false;

                    this.tabEdicion.Text = "Examinando registro";
                    General.ActivarControles(this.listaControles, false);
                    break;
                case EstadoBarraEnum.EDITANDO:
                    this.SuspendLayout();
                    if (this.tabLista.Visible)
                    {
                        //this.dgrLista.Dock = DockStyle.None;
                        this.stcEdiciones.Tabs["tabEdicion"].Visible = true;
                        this.stcEdiciones.Tabs["tabLista"].Visible = false;
                    }
                    this.tabEdicion.Text = "Editando registro";
                    General.ActivarControles(this.listaControles, true);
                    GestionOpciones();
                    break;
                case EstadoBarraEnum.BUSCANDO:
                    this.pnlBusqueda.Visible = true;
                    this.pnlBusquedaAvanzada.Visible = true;
                    this.pnlBusquedaAvanzada.Enabled = true;
                    this.txtBuscarOrdenSN.Text = "";
                    this.txtBuscarCliente.Text = "";
                    this.txtBuscarSector.PerformButtonCustom2Click();
                    this.txtBuscarCliente.Focus();
                    this.AcceptButton = this.btnBuscar;
                    break;
                case EstadoBarraEnum.NINGUNO:
                    this.pnlBusqueda.Visible = false;
                    this.pnlBusquedaAvanzada.Visible = false;
                    if (this.tabEdicion.Visible)
                    {
                        this.stcEdiciones.Tabs["tabEdicion"].Visible = false;
                        this.stcEdiciones.Tabs["tabLista"].Visible = true;
                    }
                    this.tabLista.Text = "Listado de registros";
                    this.dgrLista.Focus();
                    break;
            }
            General.GestionBarraEnabled(unEstado, ((Principal)this.MdiParent).tlsHerramientas, this.dgrLista.Rows.Count);
            this.ResumeLayout();
        }

        private void GestionOpciones(bool ventanaActiva = false)
        {
            Principal padre = (Principal)this.ParentForm;
            padre.OpcionesVisibles();

            //OPCIONES OCULTAS SEGUN LA VENTANA
            //padre.tsbImprimir.Visible = false;

            //OPCIONES DE EDICION SEGUN 'ESEDITABLE'
            //padre.tsbNuevo.Visible = this.EsEditable;
            //padre.tsbGuardar.Visible = this.EsEditable;
            //padre.tsbEliminar.Visible = this.EsEditable;

            //padre.tsbEliminar.Text = "Inactivar";
            //padre.tsbEliminar.ToolTipText = "Inactivar (Ctrl + Supr)";

            // CONTROLAMOS EL SOLO LECTURA DE LAS COLUMNAS
            //this._dgrFKDetallesOrdenesPedido.Columns["colProducto"].ReadOnly = true;
            //this._dgrFKDetallesOrdenesPedido.Columns["colTotal"].ReadOnly = true;

            if (ventanaActiva)
                this.GestionBarra(this.estadoBarra);
        }

        private DialogResult VerificaCambios()
        {
            //if (this.cambiosPendientes)
            //{
            //    DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios pendientes?", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    return resultado;
            //}
            //else
            //    return DialogResult.No;
            return DialogResult.No;
        }
        #endregion METODOS CONTROL DE VENTANA

        #region METODOS EVENTOS CONTROLES
        private void dgrLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
                this.Examinar();
        }

        private void dgrLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                if (this.dgrLista.CurrentCell != null)
                    if (((DataGridView)sender).CurrentCell.ColumnIndex == 0)
                        this.Examinar();
        }

        private void txtBuscarSector_ButtonCustomClick(object sender, EventArgs e)
        {
            cliente unCliente = ClientePr.Instancia.RegistroPorId((int)BuscarListaPr.BuscarBarrio());
            if (unCliente != null)
            {
                this.txtBuscarSector.Text = unCliente.nombrecompleto;
                this.txtBuscarSector.Tag = unCliente.id;
            }
        }

        private void txtBuscarSector_ButtonCustom2Click(object sender, EventArgs e)
        {
            this.txtBuscarSector.Text = "";
            this.txtBuscarSector.Tag = null;
        }

        #endregion

        #region METODOS PARA EVENTOS DE GRID

        void _dgrFKDetallesVenta_AntesBuscarCell(AntesBuscarCellEventArgs e)
        {
            
        }

        private void _dgrFKDetallesVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.bs.ResetBindings(false);
        }

        private void _dgrFKDetallesVenta_Leave(object sender, EventArgs e)
        {
            this._dgrFKDetallesVenta.ControlEdicionGrid();
        }
        #endregion METODOS PARA EVENTOS GRID

        private void _btnConsultarClientes_Click(object sender, EventArgs e)
        {
            int unIdCliente = BuscarListaPr.BuscarCliente();
            if (unIdCliente > -1)
            {
                //this.objetoLocal.fkpersona = pero.Instancia.RegistroPorId(unIdCliente);
                this.CargarControlesAdicionales();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            expresion.Limpiar();
            if (!string.IsNullOrEmpty(this.txtBuscarOrdenSN.Text))
                expresion.Donde("id", Comparacion.Igual, Convert.ToInt32(this.txtBuscarOrdenSN.Text));
            else
            {
                if (this.cboBuscarEstado.SelectedIndex != 0)
                    expresion.Donde("fkordenespedido.fkestadosordenespedido.id", Comparacion.Igual, this.cboBuscarEstado.SelectedValue);

                if (this.pnlBusquedaAvanzada.Enabled)
                {
                    if (this.dtpBuscarFecha.LockUpdateChecked)
                        expresion.Y("fkordenespedido.fecha", Comparacion.Igual, this.dtpBuscarFecha.Value);

                    if (this.txtBuscarSector.Tag != null)
                        expresion.Y("fkordenespedido.idbarrio", Comparacion.Igual, this.txtBuscarSector.Tag);

                    if (!String.IsNullOrEmpty(this.txtBuscarCliente.Text))
                        expresion.Y("(fkordenespedido.fkcliente.fkpersona.apellido + \" \" + fkordenespedido.fkcliente.fkpersona.nombre)", Comparacion.Contiene, this.txtBuscarCliente.Text);
                }
            }
            this.Actualizar();
        }

        private void txtBuscarOrden_TextChanged(object sender, EventArgs e)
        {
            this.pnlBusquedaAvanzada.Visible = this.pnlBusquedaAvanzada.Enabled = false;
            if (String.IsNullOrEmpty(this.txtBuscarOrdenSN.Text))
            {
                this.pnlBusquedaAvanzada.Visible = this.pnlBusquedaAvanzada.Enabled = true;
            }
        }

        private void _txtCliente_ButtonCustomClick(object sender, EventArgs e)
        {
            ClientePr.Instancia.BuscarCliente(this.bs.Current);
            this.bs.ResetBindings(false);
        }
             
    }
}