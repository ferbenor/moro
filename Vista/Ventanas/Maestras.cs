using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Controladores;
using Proveedores;
using CustomConfigExample;

namespace WindowsApp
{
    public partial class Maestras : Form, IView, IAccesoMetodos
    {
        #region VARIABLES Y PROPIEDADES
        private bool tieneFiltro = false;
        private object valorOld = null;
        private object listaOriginal;
        private bool raiseEvent = false;
        private bool cambiosPendientes = false;

        UserControl unaCabecera;
        UserControl unPiePagina;

        public bool RaiseEvent { get { return this.raiseEvent; } set { this.raiseEvent = value; } }
        public string Modulo { get; set; }
        public bool EsEditable { get; set; }
        public string UnaBusqueda { get; set; }
        public object ProveedorInstancia { get; set; }
        public string PieDetalle { get; set; }
        public object ColumnasGrid { get; set; }
        private bool CambiosPendientes { get { return this.cambiosPendientes; } set { this.cambiosPendientes = value; } }
        #endregion VARIABLES Y PROPIEDADES

        public Maestras()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgrLista.ReadOnly = !this.EsEditable;
            this.dgrLista.AllowUserToAddRows = this.EsEditable;
            GestionMaestrasCr.Instancia.RegisterView(this);
            this.dgrLista.AutoGenerateColumns = false;
            this.dgrLista.SetColumnasGrid(this.ColumnasGrid);
            this.dgrLista.AllowUserToResizeColumns = true;
            this.dgrLista.PermitirEventosInternos = true;

            this.pnlPiePagina.Height = SeccionVentanas.Default.Ventanas[this.Name].AltoPieVentana;

            this.Actualizar();

            tieneFiltro = GestionMaestrasCr.Instancia.Filtro(this.dgrLista.DataSource, "");

            this.dgrLista.DataError += new DataGridViewDataErrorEventHandler(dgrLista_DataError);
            this.dgrLista.CurrentCellDirtyStateChanged += new EventHandler(dgrLista_CurrentCellDirtyStateChanged);
            this.dgrLista.CellValueChanged += new DataGridViewCellEventHandler(dgrLista_CellValueChanged);

            try
            {
                if (!string.IsNullOrEmpty(this.PieDetalle))
                    if (this.PieDetalle.Trim().Length > 0)
                    {
                        unPiePagina = GestionMaestrasCr.Instancia.CargarControlUsuario(this.PieDetalle);
                        unPiePagina.Dock = DockStyle.Fill;
                        unPiePagina.AutoScroll = true;
                        this.pnlPiePagina.Controls.Add(unPiePagina);
                        this.pnlPiePagina.Visible = true;
                        this.espPiePagina.Visible = true;
                        this.unPiePagina.Enabled = this.EsEditable;
                    }

                if (!string.IsNullOrEmpty(this.UnaBusqueda))
                    if (this.UnaBusqueda.Trim().Length > 0)
                    {
                        unaCabecera = GestionMaestrasCr.Instancia.CargarControlUsuario(this.UnaBusqueda);
                        unaCabecera.Dock = DockStyle.Fill;
                        unaCabecera.AutoScroll = true;
                        this.pnlCabecera.Controls.Add(unaCabecera);
                        this.pnlCabecera.Visible = true;
                    }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(ex.InnerException.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region FUNCIONES DE IACCESOMETODOS
        public void Nuevo()
        {
            this.RaiseEvent = true;
            this.dgrLista.ControlEdicionGrid();

            int colNew;
            if (this.dgrLista.Tag == null)
                colNew = 1;
            else
                Int32.TryParse(this.dgrLista.Tag.ToString(), out colNew);

            this.dgrLista.CurrentCell = this.dgrLista.Rows[this.dgrLista.NewRowIndex].Cells[colNew];
            this.RaiseEvent = false;
        }

        public void Editar()
        {
        }

        public Form Examinar(short opcion, out object unObjetolocal)
        {
            Principal form = (Principal)this.MdiParent;
            unObjetolocal = this.dgrLista.CurrentRow.DataBoundItem;
            return form.EjecutarMenu(opcion);
        }

        public void EstablecerObjetoLocal(object unObjetoLocal)
        {

        }

        public object ObtenerObjetoLocal()
        {
            return null;
        }

        public void Guardar()
        {
            this.dgrLista.ControlEdicionGrid();
            if (GestionMaestrasCr.Instancia.requerido)
            {
                MessageBox.Show("Error al guardar, algunos datos son requeridos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.unPiePagina != null)
                if (((IControlesUsuario)this.unPiePagina).Verificar())
                {
                    MessageBox.Show("Error al guardar, algunos datos son requeridos en el pie de pagina", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            this.RaiseEvent = true;
            GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
            GestionMaestrasCr.Instancia.RaiseGrabarLista(this.dgrLista);
            this.RaiseEvent = false;
        }

        public void Eliminar()
        {
            if (this.dgrLista.Rows.Count > 1)
                if (this.dgrLista.CurrentRow.Index != this.dgrLista.NewRowIndex)
                {
                    DialogResult res = MessageBox.Show("Esta seguro de eliminar el registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.RaiseEvent = true;
                        GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
                        GestionMaestrasCr.Instancia.RaiseBorrarLista(this.dgrLista);
                        this.RaiseEvent = false;
                    }
                }
        }

        public void Actualizar()
        {
            this.RaiseEvent = true;
            GestionMaestrasCr.Instancia.ProveedorInstancia = this.ProveedorInstancia;
            if ((this.dgrLista.Rows.Count > 0 && this.dgrLista.AllowUserToAddRows == false) || (this.dgrLista.Rows.Count > 1 && this.dgrLista.AllowUserToAddRows == true))
                this.ProveedorInstancia = GestionMaestrasCr.Instancia.RaiseListLoad(this.dgrLista, this.Modulo, this.dgrLista.CurrentRow.Index, this.dgrLista.CurrentCell.ColumnIndex);
            else
                this.ProveedorInstancia = GestionMaestrasCr.Instancia.RaiseListLoad(this.dgrLista, this.Modulo, 0, 0);
            this.RaiseEvent = false;
        }

        public void Cancelar()
        {

        }

        public void Buscar()
        {
        }

        public void Filtrar(string unTexto)
        {
            GestionMaestrasCr.Instancia.Filtro(this.dgrLista.DataSource, unTexto);
        }

        public void Imprimir()
        {
            GestionMaestrasCr.Instancia.RaiseImprimir(this.dgrLista, this.Modulo);
        }
        #endregion FUNCIONES DE IACCESOMETODOS

        #region METODOS DE EVENTOS IVIEW
        public void VistaCargada(object sender, ViewLoadEventArgs e)
        {
            if (this.RaiseEvent)
            {
                if (e.RowIndex > -1 && e.ColIndex > -1)
                {
                    this.dgrLista.CurrentCell = dgrLista.Rows[e.RowIndex].Cells[e.ColIndex];
                }
                listaOriginal = this.dgrLista.DataSource;
                this.CambiosPendientes = false;
            }
        }

        public void AntesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (this.RaiseEvent)
            {
                e.Modulo = this.Modulo;
                e.Objeto = this.dgrLista.CurrentRow.DataBoundItem;
                e.RowIndex = this.dgrLista.CurrentRow.Index;
                e.ColIndex = this.dgrLista.CurrentCell.ColumnIndex;

                if (e.ListaSeleccionados == null)
                    e.ListaSeleccionados = new List<object>();

                DataGridViewCell[] ls = new DataGridViewCell[this.dgrLista.SelectedCells.Count];
                this.dgrLista.SelectedCells.CopyTo(ls, 0);

                foreach (int item in ls.GroupBy(x => x.RowIndex).Select(x => x.First().RowIndex))
                {
                    e.ListaSeleccionados.Add(this.dgrLista.Rows[item].DataBoundItem);
                }
                e.Lista = this.dgrLista.DataSource;
            }
        }

        public void DespuesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (e.Completado == true && this.RaiseEvent == true)
            {
                this.CambiosPendientes = false;
                GestionMaestrasCr.Instancia.RaiseListLoad(sender, e.Modulo, e.RowIndex, e.ColIndex);
            }
        }

        #endregion METODOS DE EVENTOS IVIEW

        #region METODOS PARA EVENTOS DE VENTANA
        private void Maestras_Activated(object sender, EventArgs e)
        {
            ((Principal)this.MdiParent).tstFiltrar.Visible = tieneFiltro;
            ((Principal)this.MdiParent).EscribeConteo(this.dgrLista.Rows.Count);
            GestionOpciones();
        }

        private void Maestras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.CambiosPendientes)
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios pendientes?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    this.listaOriginal = null;
                    this.dgrLista.DataSource = null;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SeccionVentanas.Default.Ventanas[this.Name].AltoPieVentana = this.pnlPiePagina.Height;
                SeccionVentanas.Default.Save();
                GestionMaestrasCr.Instancia.UnregisterView(this);

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion METODOS PARA EVENTOS DE VENTANA

        #region METODOS PARA EVENTOS DE GRID

        private void dgrLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.valorOld = this.dgrLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (this.dgrLista.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewComboBoxExCell")
            {
                SendKeys.Send("{F4}");
                this.dgrLista.CurrentCell.Style.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void dgrLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this.dgrLista.CurrentCell.Style.ForeColor = System.Drawing.Color.Black;
            this.dgrLista.CurrentCell.Style.BackColor = System.Drawing.Color.SkyBlue;
            if (this.dgrLista.CurrentCell.GetType().Name == "DataGridViewComboBoxExCell" || this.dgrLista.CurrentCell.GetType().Name == "DataGridViewDateTimeInputCell")
                this.dgrLista.NotifyCurrentCellDirty(true);
        }

        void dgrLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgrLista.ReadOnly)
                if (this.dgrLista.Columns[e.ColumnIndex].Name != "colModificado")
                    if (!Object.Equals(this.valorOld, this.dgrLista.CurrentCell.Value))
                        if (this.dgrLista.CurrentRow.Index != this.dgrLista.NewRowIndex)
                        {
                            this.dgrLista.CurrentRow.Cells["colModificado"].Value = true;
                            DataGridViewRow fila = this.dgrLista.CurrentRow;
                            this.dgrLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue; //#F3F781
                            this.valorOld = null;
                            this.CambiosPendientes = true;
                            // Dispara evento GestionOpciones en VentanaPrincipalCr
                        }
        }

        void dgrLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!this.dgrLista.ReadOnly)
            {
                this.valorOld = this.dgrLista.CurrentCell.Value;
                if (this.dgrLista.CurrentCell.GetType().Name == "DataGridViewCheckBoxCell")
                    this.dgrLista.EndEdit();

                this.dgrLista_RowEnter(this.dgrLista, new DataGridViewCellEventArgs(this.dgrLista.CurrentCell.ColumnIndex, this.dgrLista.CurrentCell.RowIndex));
            }
        }

        void dgrLista_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
                MessageBox.Show(e.Exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Cancel = true;
        }

        private void dgrLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.dgrLista.ReadOnly)
            {
                if (e.KeyChar == (char)Keys.Space)
                {
                    for (int i = 0; i < this.dgrLista.SelectedCells.Count; i++)
                    {
                        if (this.dgrLista.SelectedCells[i].GetType().Name == "DataGridViewCheckBoxCell")
                        {
                            this.dgrLista.SelectedCells[i].Value = !(bool)this.dgrLista.SelectedCells[i].Value;
                        }
                    }
                }
            }
        }

        private void dgrLista_Leave(object sender, EventArgs e)
        {
            if (!this.dgrLista.ReadOnly)
                if (this.EsEditable)
                {
                    if (this.dgrLista.CurrentCell != null)
                        if ((this.dgrLista.CurrentRow.Index != this.dgrLista.NewRowIndex) && this.dgrLista.IsCurrentCellInEditMode)
                            this.dgrLista.CancelEdit();
                    this.dgrLista.ControlEdicionGrid();
                }
        }

        private void dgrLista_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && this.unPiePagina != null && this.dgrLista.CurrentRow != null)
            {
                object objeto = this.dgrLista.Rows[e.RowIndex].DataBoundItem;
                ((IControlesUsuario)this.unPiePagina).Cargar(ref objeto, this.Modulo, null);
            }
        }

        #endregion METODOS PARA EVENTOS GRID

        private void TablasSimples(ref Principal padre)
        {
            //padre.tstFiltrar.Visible = false;
            //padre.tsbFiltrar.Visible = false;
            //padre.mnuFiltrar.Visible = false;
        }

        private void GestionOpciones()
        {
            Principal padre = (Principal)this.ParentForm;
            padre.tsbCancelar.Visible = false;
            padre.tsbActualizar.Visible = true;
            padre.tsbEditar.Visible = false;
            padre.tsbBuscar.Visible = false;
            padre.tsbImprimir.Visible = false;

            //OPCIONES DE EDICION SEGUN 'ESEDITABLE'
            padre.tsbNuevo.Visible = this.EsEditable;
            padre.tsbNuevo.Enabled = this.EsEditable;
            padre.tsbGuardar.Visible = this.EsEditable;
            padre.tsbGuardar.Enabled = this.EsEditable;

            padre.tsbEliminar.Text = "Eliminar";
            padre.mnuEliminar.Text = "Eliminar";
            padre.tsbEliminar.ToolTipText = "Eliminar (Ctrl + Supr)";

            padre.tsbEliminar.Visible = this.EsEditable;
            padre.tsbEliminar.Enabled = this.EsEditable;
            padre.separEditar1.Visible = this.EsEditable;

            switch (this.Modulo)
            {
                case "MenuSistemaPr":
                    {
                        //padre.tsbBusqueda.Visible = true;
                        //padre.mnuBuqueda.Visible = true;
                    }
                    break;
                case "UsuarioSesionActivaPr":
                    {
                        padre.tsbNuevo.Visible = false;
                        padre.tsbGuardar.Visible = false;
                    }
                    break;
                case "TipoCuentaPr":
                    {
                        TablasSimples(ref padre);
                    }
                    break;
                case "TipoDocumentoPr":
                    {
                        TablasSimples(ref padre);
                    }
                    break;
                case "ContablePr":
                    {
                        padre.tsbNuevo.Visible = false;
                        padre.tsbGuardar.Visible = false;
                        padre.tsbEliminar.Visible = false;
                        padre.tsbBuscar.Visible = false;
                        padre.tsbActualizar.Visible = false;
                        padre.tsbImprimir.Visible = true;
                        padre.tsbImprimir.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
            padre.separEditar2.Visible = false;
        }

    }
}
