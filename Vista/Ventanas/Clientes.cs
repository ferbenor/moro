using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controladores;
using System.Globalization;
using System.Drawing.Imaging;
using Entidades;
using Proveedores;

namespace WindowsApp
{
    public partial class Clientes : Form, IAccesoMetodos
    {
        #region VARIABLES Y PROPIEDADES
        /// <summary>
        /// CAMPOS CLAVE DEL REGISTRO
        /// </summary>
        private int idRegistro = 0;
        private bool editando = false;

        private Control[] listaControles = null;
        private bool raiseEvent = false;
        private EstadoBarraEnum estadoBarra = EstadoBarraEnum.NINGUNO;
        public bool RaiseEvent { get { return this.raiseEvent; } set { this.raiseEvent = value; } }
        public object ProveedorInstancia { get; set; }
        public string Modulo { get; set; }
        public bool EsEditable { get; set; }
        public string UnaBusqueda { get; set; }
        public string PieDetalle { get; set; }
        public object ColumnasGrid { get; set; }
        public bool RegistroEditable { get; set; }
        public short Periodo { get; set; }
        public short Tipo { get; set; }
        public short Numero { get; set; }
        private bool cambiosPendientes = false;
        private object oldValue = null;

        private Cliente objetoLocal = new Cliente();

        #endregion VARIABLES Y PROPIEDADES

        #region CONSTRUCTOR Y METODOS PARA EVENTOS DE VENTANA
        public Clientes()
        {
            InitializeComponent();
            this.listaControles = General.ArrayControles(this);
            this.EsEditable = true;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.RegistrarControles();
                //ASIGNAR APARIENCIA
                VentanaPrincipalCr.Instancia.Apariencia(this);
                this.colVer.Image = General.Imagenes.Images["Listar.ico"];
                this.stcEdiciones.Tabs["tabEdicion"].Visible = false;
                this.stcEdiciones.Tabs["tabLista"].Visible = true;
                //General.ShowTabPage(this.tabEdiciones, tabLista);
                //General.HideTabPage(this.tabEdiciones, tabEdicion);
                //this.Actualizar();
                GestionBarra(EstadoBarraEnum.NINGUNO);
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        private void Clientes_Activated(object sender, EventArgs e)
        {
            ((Principal)this.MdiParent).EscribeConteo(1);
            GestionOpciones(true);
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
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
        private void CargarCampos()
        {
            ////EN ESTA SECCION SE ESTABLECEN LOS GRIDS////
            ///this._dgrDetalle.DataSource = null;
            ///this._dgrDetalle.DataSource = SoporteList<DetalleObjeto>.ToBindingList(objetoLocal.DetalleObjeto);

            ///////////////////////////////////////////////
            General.CargarControles(this.listaControles, this.objetoLocal);

            //CAMPOS ADICIONALES DE TRATAMIENTO PERSONALIZADO
            this._lblEstado.Text = this.objetoLocal.EstadoPersona.Descripcion;
            this._lblEstado.ForeColor = this.objetoLocal.IdEstadoPersona == 2 ? System.Drawing.Color.Red : System.Drawing.Color.Blue;
            this.cambiosPendientes = false;
        }

        private void GuardarCampos()
        {
            General.GuardarObjeto(this.listaControles, this.objetoLocal);
        }

        private void CargarCombos()
        {
            ClientePr.Instancia.LimpiarListas();
            General.CargarCombos(this._cboTipoPersona, "Objeto", "Descripcion", ClientePr.Instancia.ListaTipoPersona);
            General.CargarCombos(this._cboTipoDocumento, "Objeto", "Descripcion", ClientePr.Instancia.ListaTipoDocumento);
            General.CargarCombos(this._cboGenero, "Objeto", "Descripcion", ClientePr.Instancia.ListaGenero);
            General.CargarCombos(this._cboEstadoCivil, "Objeto", "Descripcion", ClientePr.Instancia.ListaEstadoCivil);
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
                if (registro.Cells["id"].Value.ToString().Equals(unId.ToString()))
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
            this.objetoLocal = new Cliente();
            this.GestionBarra(EstadoBarraEnum.EDITANDO);
            General.LimpiarControles(this.listaControles);
            CargarCombos();

            //this._txtIdentificacionSN.Focus();
            this._cboTipoPersona.Focus();
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
                    CargarCombos();
                    //this.objetoLocal = ClientePr.Instancia.RegistroPorId((int)ValorCelda("id"));
                }
                if (this.objetoLocal == null)
                    throw new Exception("El actual registro fue modificado, anulado o eliminado\npor favor verifique");
                else
                {
                    this.idRegistro = this.objetoLocal.Id;
                }
                CargarCampos();
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
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                {
                    //this.tipoEvento = "grabado";
                    //GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
                    //GestionMaestrasCr.Instancia.RaiseGrabar(null);
                    this.GuardarCampos();
                    try
                    {
                        //ClientePr.Instancia.Grabar(this.objetoLocal, cnx, trx);
                        this.idRegistro = this.objetoLocal.Id;

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
            if (this._txtIdRO.Text != "0")
                if (MessageBox.Show("Esta seguro de anular el registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.objetoLocal = new Cliente((int)ValorCelda("id"));
                    //ClientePr.Instancia.Borrar(this.objetoLocal);

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

                //if (!ClientePr.Instancia.Registros(this.dgrLista, this.txtBusqueda.Text))
                //{
                //    this.txtBusqueda.Focus();
                //    this.txtBusqueda.SelectAll();
                //    this.lblMensaje.Visible = true;
                //    return;
                //}
                GestionBarra(EstadoBarraEnum.NINGUNO);
                SeleccionFila(columna, idRegistro);
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        public void Filtrar(string unTexto)
        {

        }

        public void Imprimir()
        {
            if (!cambiosPendientes)
            {
                ClienteCr.Instancia.ImprimirObjeto(this.objetoLocal);
            }
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
            this._txtConyugueRO.Tag = 1;
            this._txtBarrioRO.Tag = 3;
            this._txtProfesionRO.Tag = 4;

            this._bbqConyugue.Tag = this._txtConyugueRO;
            this._bbqProfesion.Tag = this._txtProfesionRO;
            this._bbqBarrio.Tag = this._txtBarrioRO;


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
            switch (unEstado)
            {
                case EstadoBarraEnum.EXAMINANDO:
                    this.pnlBusqueda.Visible = false;
                    this.SuspendLayout();
                    this.stcEdiciones.Tabs["tabEdicion"].Visible = true;
                    this.stcEdiciones.Tabs["tabLista"].Visible = false;

                    this.tabEdicion.Text = "Examinando registro";
                    General.ActivarControles(this.listaControles, false);
                    break;
                case EstadoBarraEnum.EDITANDO:
                    if (objetoLocal.Id != 0)
                        this.editando = true;
                    this.SuspendLayout();
                    if (this.tabLista.Visible)
                    {
                        //this.dgrLista.Dock = DockStyle.None;
                        this.stcEdiciones.Tabs["tabEdicion"].Visible = true;
                        this.stcEdiciones.Tabs["tabLista"].Visible = false;
                    }
                    this.tabEdicion.Text = "Editando registro";
                    General.ActivarControles(this.listaControles, true);
                    this._cboTipoPersona_SelectedIndexChanged(null, null);
                    GestionOpciones();
                    break;
                case EstadoBarraEnum.BUSCANDO:
                    this.pnlBusqueda.Visible = true;
                    this.txtBusqueda.Text = "";
                    this.txtBusqueda.Focus();
                    break;
                case EstadoBarraEnum.NINGUNO:
                    this.editando = false;
                    this.pnlBusqueda.Visible = false;
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
            this._txtIdentificacionSN.ReadOnly = this.editando;

            padre.tsbEliminar.Text = "Inactivar";
            padre.tsbEliminar.ToolTipText = "Inactivar (Ctrl + Supr)";
            if (ventanaActiva)
                this.GestionBarra(this.estadoBarra);
        }

        private DialogResult VerificaCambios()
        {
            if (this.cambiosPendientes)
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios pendientes?", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                return resultado;
            }
            else
                return DialogResult.No;
        }
        #endregion METODOS CONTROL DE VENTANA

        #region METODOS EVENTOS CONTROLES
        private void _cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._cboTipoPersona.SelectedIndex != 0)
            {
                this.pnlDatosNatural.Visible = true;
                this._txtRazonSocial.Text = "";
                this._txtRazonSocial.ReadOnly = true;
                this.rfvValidador04.Enabled = false;
            }
            else
            {
                this._txtRazonSocial.ReadOnly = false;
                this.rfvValidador04.Enabled = true;
                this.pnlDatosNatural.Visible = false;
            }
        }

        private void dtpFecha_Enter(object sender, EventArgs e)
        {
            this.oldValue = this._dtpFechaIngreso.Value;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!object.Equals(this.oldValue, this._dtpFechaIngreso.Value))
                this.cambiosPendientes = true;
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            this.cambiosPendientes = true;
        }

        private void _txtIdentificacion_Leave(object sender, EventArgs e)
        {
            //ClienteCr.Instancia.BuscarCliente(ref this.objetoLocal);
        }

        private void _cboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._cboEstadoCivil.SelectedIndex == 1)
                this._txtConyugueRO.Focus();
            //else
            //    this._txtCorreo.Focus();
        }

        //private void _cboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (_cboEstadoCivil.SelectedIndex != 1)
        //    {
        //        this.lblConyugue.Visible = false;
        //        this._txtConyugue.Visible = false;
        //        this.bbqConyugue.Visible = false;
        //    }
        //    else
        //    {
        //        this.lblConyugue.Visible = true;
        //        this._txtConyugue.Visible = true;
        //        this.bbqConyugue.Visible = true;
        //        this._txtConyugue.Focus();
        //    }
        //}

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            this.ofdDialogo.Filter = "Archivos de imagen (.Bmp, .Jpg, .Gif, .Png)|*.Jpg;*.Bmp;*.Gif;*.Png";
            if (this.ofdDialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image imagen = Image.FromFile(this.ofdDialogo.FileName);
                if (!imagen.RawFormat.Equals(ImageFormat.Bmp) && !imagen.RawFormat.Equals(ImageFormat.Jpeg)
                    && !imagen.RawFormat.Equals(ImageFormat.Gif) && !imagen.RawFormat.Equals(ImageFormat.Png))
                    MessageBox.Show("Formato de imagen no admitido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    this._picFoto.Image = imagen;
                    this.cambiosPendientes = true;
                }
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea quitar la imagen ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this._picFoto.Image = null;
            this.cambiosPendientes = true;
        }

        private void bbqBuscarQuitar_BotonPulsado(object sender, BotonPulsadoEventArgs e)
        {
            Control texto = ((Control)sender).Tag as Control;
            this.oldValue = texto.Text;
            //if (e.Boton == 1)
                //texto.Text = ClienteCr.Instancia.BuscarObjeto(ref this.objetoLocal, short.Parse(texto.Tag.ToString()));
            //else
                //texto.Text = ClienteCr.Instancia.QuitarObjeto(ref this.objetoLocal, short.Parse(texto.Tag.ToString()));
            if (!object.Equals(this.oldValue, texto.Text))
                this.cambiosPendientes = true;
        }

        private void dgrLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                this.Examinar();
        }

        private void dgrLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                if (this.dgrLista.CurrentCell != null)
                    if (((DataGridView)sender).CurrentCell.ColumnIndex == 0)
                        this.Examinar();
        }

        private void btnAceptarB_Click(object sender, EventArgs e)
        {
            this.Actualizar();
            //GestionBarra(EstadoBarraEnum.NINGUNO);
        }
        #endregion METODOS EVENTOS CONTROLES

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.btnAceptar.PerformClick();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.lblMensaje.Visible = false;
        }

        private void verificarRegistro(string unCodigo)
        {

            //CargarCombos();
            //Cliente objeto = ClientePr.Instancia.RegistroPorIdentidad(unCodigo);
            //if (objeto != null)
            {
                //this.objetoLocal = objeto;
                this.Examinar(EstadoBarraEnum.EDITANDO);
            }
        }

        private void _txtIdentificacionSN_Leave(object sender, EventArgs e)
        {
            if (this.editando)
                verificarRegistro(((Control)sender).Text);
        }
    }
}
