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

namespace WindowsApp
{
    public partial class Contables1 : Form, IView, IAccesoMetodos
    {
        #region VARIABLES Y PROPIEDADES
        private bool raiseEvent = false;

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
        private bool registroNuevo = false;
        private object oldValue = null;
        private string tipoEvento;

        private object objetoLocal = null;

        #endregion VARIABLES Y PROPIEDADES

        public Contables1()
        {
            InitializeComponent();
        }

        private void Contables_Load(object sender, EventArgs e)
        {
            this.RegistrarControles();
            GestionMaestrasCr.Instancia.RegisterView(this);
            VentanaPrincipalCr.Instancia.Apariencia(this);
            this._dgrDetalle.AutoGenerateColumns = false;
            this.GestionOpciones();
            //this.ProveedorInstancia = ContableCr.Instancia.RaiseEstructuraGridDetalle(this._dgrDetalle);
            this._dgrDetalle.DataError += new DataGridViewDataErrorEventHandler(dgrDetalle_DataError);

            if (this.EsEditable)
                this.Nuevo();
        }

        #region FUNCIONES DE IACCESOMETODOS
        public void Nuevo()
        {
            this.spvValidador.ClearFailedValidations();
            DialogResult resultado = VerificaCambios();
            if (resultado == System.Windows.Forms.DialogResult.Yes)
                this.Guardar();
            if (resultado != System.Windows.Forms.DialogResult.Cancel)
            {
                this._dgrDetalle.ControlEdicionGrid();

                this.RaiseEvent = true;

                this.objetoLocal = ContableCr.Instancia.ConstruirObjeto(this.objetoLocal, true);
                ContableCr.Instancia.RaiseCargaVista(objetoLocal);

                if (this.objetoLocal != null)
                {
                    //OBJETOS QUE AL CARGAR DEBEN ESTAR DESABILITADOS PERO AL AGREGAR DEBEN HABILITARSE
                    this._cboTipo.Enabled = true;
                    this._cboTipo.SelectedIndex = 0;
                    
                    this.RegistroEditable = true;
                    this.GestionOpciones();
                    
                    this.registroNuevo = true;
                }
                else
                    MessageBox.Show("No se pudo iniciar objeto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.RaiseEvent = false;
            }
        }

        public void Editar()
        {
        }

        public Form Examinar(short opcion, out object unObjetolocal)
        {
            unObjetolocal = null;
            return null;
        }

        public void EstablecerObjetoLocal(object unObjetoLocal)
        {
            this.objetoLocal = unObjetoLocal;
        }

        public object ObtenerObjetoLocal()
        {
            return this.objetoLocal;
        }

        public void Guardar()
        {
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
                if (this.RegistroEditable)
                    if (this.cambiosPendientes)
                    {
                        this._dgrDetalle.ControlEdicionGrid();
                        if (this._dgrDetalle.RowCount > 1)
                        {
                            decimal diferencia = 0;
                            decimal.TryParse(this._txtDiferencia.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out diferencia);
                            if (diferencia != 0)
                                MessageBox.Show("Asiento no cuadrado por favor verifique", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                this.RaiseEvent = true;
                                this.tipoEvento = "grabado";
                                GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
                                GestionMaestrasCr.Instancia.RaiseGrabar(this._dgrDetalle);
                                this.RaiseEvent = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Registre detalle de comprobante por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this._dgrDetalle.Focus();
                        }
                    }
        }

        public void Eliminar()
        {
            if (!cambiosPendientes && !registroNuevo)
            {
                this.RaiseEvent = true;
                this.tipoEvento = "anulado";
                GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
                GestionMaestrasCr.Instancia.RaiseBorrar(this._dgrDetalle);
                this.RaiseEvent = false;
            }
        }

        public void Actualizar()
        {
            this.spvValidador.ClearFailedValidations();
            this.RaiseEvent = true;
            if (this.objetoLocal != null)
                ContableCr.Instancia.Buscar(this.objetoLocal, false);
            this.RaiseEvent = false;
        }

        public void Cancelar()
        {
            //throw new NotImplementedException();
        }

        public void Buscar()
        {
            this.spvValidador.ClearFailedValidations();
            DialogResult resultado = VerificaCambios();
            if (resultado == System.Windows.Forms.DialogResult.Yes)
                this.Guardar();
            if (resultado != System.Windows.Forms.DialogResult.Cancel)
            {
                this.RaiseEvent = true;
                ContableCr.Instancia.Buscar(this.objetoLocal);
                this.RaiseEvent = false;
            }
        }

        public void Filtrar(string unTexto)
        {

        }

        public void Imprimir()
        {
            if (!cambiosPendientes && !registroNuevo)
            {
                ContableCr.Instancia.ImprimirObjeto(this.objetoLocal);
            }
        }
        #endregion FUNCIONES DE IACCESOMETODOS

        #region METODOS DE EVENTOS IVIEW
        public void VistaCargada(object sender, ViewLoadEventArgs e)
        {
            if (this.RaiseEvent)
            {
                this.RegistroEditable = (bool)e.ListaObjetos[0];
                this.objetoLocal = e.ListaObjetos[1];
                ContableCr.Instancia.SumarValores();
                cambiosPendientes = false;
                if (this.EsEditable)
                {
                    GestionOpciones();

                    //ContableCr.Instancia.RaiseEstructuraGridDetalle(this._dgrDetalle);
                }
                //OBJETOS QUE AL CARGAR DEBEN ESTAR DESABILITADOS
                this._cboTipo.Enabled = false;
                this.registroNuevo = false;

            }


        }

        public void AntesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (this.RaiseEvent)
            {
                e.Modulo = this.Modulo;
                e.Objeto = ContableCr.Instancia.ConstruirObjeto(this.objetoLocal);
            }
        }

        public void DespuesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (this.RaiseEvent)
            {
                if (e.Completado)
                {
                    if (e.Accion == 0)
                    {
                        this._cboTipo.Enabled = false;
                        this.objetoLocal = e.Objeto;
                        this.Actualizar();
                        MessageBox.Show("Registro " + this.tipoEvento + " correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion METODOS DE EVENTOS IVIEW

        #region METODOS PARA EVENTOS DE VENTANA
        private void Contables_Activated(object sender, EventArgs e)
        {
            ((Principal)this.MdiParent).EscribeConteo(1);
            GestionOpciones();
        }

        private void Contables_FormClosing(object sender, FormClosingEventArgs e)
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
            {
                this.objetoLocal = null;
                this._dgrDetalle.DataSource = null;
            }


        }

        private void Contables_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionMaestrasCr.Instancia.UnregisterView(this);
        }
        #endregion METODOS PARA EVENTOS DE VENTANA

        private void RegistrarControles()
        {
            //ASIGNACION DE PROPIEDADES
            this._cboTipo.DisplayMember = "Descripcion";
            this._cboTipo.ValueMember = "Objeto";

            //REGISTRO DE CONTROLES
            ContableCr.Instancia.LimpiarControles();
            foreach (Control item in this.Controls)
            {
                RegistraControl(item);
            }
        }

        private void RegistraControl(Control unControl)
        {
            if (unControl.Controls.Count > 0 && unControl.GetType().BaseType.Name != "DataGridViewX")
                foreach (Control item in unControl.Controls)
                {
                    RegistraControl(item);
                }
            else
                if (unControl.Name.StartsWith("_"))
                    ContableCr.Instancia.RegistrarControles(unControl);
        }

        private void GestionOpciones()
        {
            Principal padre = (Principal)this.ParentForm;
            padre.tsbActualizar.Visible = true;
            padre.mnuActualizar.Visible = true;
            //padre.tstFiltrar.Visible = false;
            //padre.tsbFiltrar.Visible = false;
            //padre.mnuFiltrar.Visible = false;
            padre.tsbBuscar.Visible = true;
            padre.mnuBuscar.Visible = true;
            padre.tsbImprimir.Visible = true;
            padre.mnuImprimir.Visible = true;

            //OPCIONES DE EDICION SEGUN 'ESEDITABLE' Y 'REGISTROEDITABLE'
            padre.tsbNuevo.Visible = this.EsEditable;
            padre.mnuNuevo.Visible = this.EsEditable;
            padre.tsbCancelar.Visible = false;
            padre.mnuCancelar.Visible = false;
            padre.tsbGuardar.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;
            padre.mnuGuardar.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;

            padre.tsbEliminar.Text = "Anular";
            padre.mnuEliminar.Text = "Anular";
            padre.tsbEliminar.ToolTipText = "Anular (Ctrl + Supr)";

            padre.tsbEliminar.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;
            padre.mnuEliminar.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;
            padre.separEditar1.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;

            //padre.mnuPrevio.Visible = false;
            padre.separEditar2.Visible = false;

            //CONTROLAMOS EL ESTADO DE MODIFICACION DE LOS OBJETOS DE INGRESO DE DATOS
            this._dgrDetalle.ReadOnly = !RegistroEditable ? !RegistroEditable : !this.EsEditable;
            this.btnConsultar.Visible = !RegistroEditable ? RegistroEditable : this.EsEditable;
            this._txtDetalle.ReadOnly = !RegistroEditable ? !RegistroEditable : !this.EsEditable;
            this._dtpFecha.Enabled = !RegistroEditable ? RegistroEditable : this.EsEditable;
            this._dgrDetalle.AllowUserToAddRows = !RegistroEditable ? RegistroEditable : this.EsEditable;
            this._dgrDetalle.AllowUserToDeleteRows = !RegistroEditable ? RegistroEditable : this.EsEditable;

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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.oldValue = this._txtBeneficiario.Text;
            this._txtBeneficiario.Text = ContableCr.Instancia.BuscarBeneficiario(ref this.objetoLocal);
            if (!object.Equals(this.oldValue, this._txtBeneficiario.Text))
                this.cambiosPendientes = true;
        }

        private void dgrDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                this.RaiseEvent = true;
                ContableCr.Instancia.SumarValores();
                this.RaiseEvent = false;
            }
            cambiosPendientes = true;
        }

        void dgrDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgrDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.RaiseEvent = true;
            ContableCr.Instancia.SumarValores();
            cambiosPendientes = true;
            this.RaiseEvent = false;
        }

        private void dgrDetalle_Leave(object sender, EventArgs e)
        {
            if (this.RegistroEditable)
            {
                if (this._dgrDetalle.CurrentCell != null)
                    if ((this._dgrDetalle.CurrentRow.Index != this._dgrDetalle.NewRowIndex) && this._dgrDetalle.IsCurrentCellInEditMode)
                        this._dgrDetalle.CancelEdit();
                this._dgrDetalle.ControlEdicionGrid();
            }
        }

        private void dtpFecha_Enter(object sender, EventArgs e)
        {
            this.oldValue = this._dtpFecha.Value;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!object.Equals(this.oldValue, this._dtpFecha.Value))
                this.cambiosPendientes = true;
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            this.cambiosPendientes = true;
        }


    }
}
