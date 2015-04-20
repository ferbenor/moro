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

namespace WindowsApp
{
    public partial class Asignaciones : Form, IAccesoMetodos
    {
        private bool tieneFiltro = false;
        private bool modificado = false;

        private object valorOld = null;

        public bool RaiseEvent { get; set; }
        public object ProveedorInstancia { get; set; }
        public string Modulo { get; set; }
        public string PieDetalle { get; set; }
        public bool EsEditable { get; set; }
        public object ColumnasGrid { get; set; }
        public string UnaBusqueda { get; set; }

        public Asignaciones()
        {
            InitializeComponent();
        }

        private void Asignaciones_Load(object sender, EventArgs e)
        {
            VentanaPrincipalCr.Instancia.Apariencia(this.gpbCabecera);
            this.dgrLista.ReadOnly = !this.EsEditable;

            if (this.Modulo != "PerfilPr")
                this.dgrLista.Columns.Remove("colEditable");

            this.dgrLista.AutoGenerateColumns = false;
            this.lblXTitulo.Text = "<b><font size=\"+6\"><font color=\"#4B610B\">" + this.Text + "</font></font></b>";
            this.gpbCabecera.Text = this.Modulo.Replace("Pr", "").ToUpper();

            this.Actualizar();

            tieneFiltro = GestionMaestrasCr.Instancia.Filtro(this.dgrLista.DataSource, "");

            this.dgrLista.CurrentCellDirtyStateChanged += new EventHandler(dgrLista_CurrentCellDirtyStateChanged);
        }

        void dgrLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgrLista.CurrentCell.GetType().Name == "DataGridViewCheckBoxCell")
                this.dgrLista.EndEdit();
        }

        public void Nuevo()
        {
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

        }

        public object ObtenerObjetoLocal()
        {
            return null;
        }

        public void Guardar()
        {
            if (!modificado)
                return;
            bool respuesta = false;
            if (this.dgrLista.CurrentRow.Index == this.dgrLista.NewRowIndex)
                this.dgrLista.CancelEdit();
            else
                this.dgrLista.EndEdit();
            respuesta = AsignacionCr.Instancia.RaiseGrabar(this.cboCabecera.SelectedItem, this.Modulo);
            if (respuesta)
            {
                this.modificado = false;
                this.Actualizar();
            }
        }

        public void Eliminar()
        {
        }

        public void Actualizar()
        {
            try
            {
                this.modificado = false;
                this.valorOld = this.cboCabecera.SelectedValue;
                AsignacionCr.Instancia.RaiseLlenaCombo(this.Modulo, this.cboCabecera);
                if (valorOld != null)
                    this.cboCabecera.SelectedValue = valorOld;
                if (this.cboCabecera.Items.Count > 0)
                {
                    this.btnConsultar.Enabled = true;
                    if (this.cboCabecera.SelectedValue == null)
                        this.cboCabecera.SelectedIndex = 0;
                    this.btnConsultar.PerformClick();
                }
                else
                    this.btnConsultar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        }

        private void dgrLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Object.Equals(this.valorOld, this.dgrLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))

                if (this.dgrLista.CurrentRow.Index != this.dgrLista.NewRowIndex)
                {
                    DataGridViewRow fila = this.dgrLista.CurrentRow;
                    this.dgrLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue; //#F3F781
                    this.valorOld = null;
                    this.modificado = true;
                    // Dispara evento GestionOpciones en VentanaPrincipalCr

                }
        }

        private void dgrLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            this.valorOld = this.dgrLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (this.dgrLista.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewComboBoxExCell")
                SendKeys.Send("{F4}");

        }

        private void dgrLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
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

        private void GestionOpciones()
        {
            Principal padre = (Principal)this.ParentForm;
            padre.tsbNuevo.Visible = false;
            padre.mnuNuevo.Visible = false;
            padre.tsbCancelar.Visible = false;
            padre.mnuCancelar.Visible = false;
            padre.tsbActualizar.Visible = true;
            padre.mnuActualizar.Visible = true;
            padre.tsbEliminar.Visible = false;
            padre.mnuEliminar.Visible = false;
            padre.tsbImprimir.Visible = false;
            padre.mnuImprimir.Visible = false;
            //padre.tstBuscar.Enabled = false;
            //padre.tstFiltrar.Visible = false;
            //padre.tsbFiltrar.Visible = false;
            //padre.mnuFiltrar.Visible = false;
            padre.tsbBuscar.Visible = false;
            padre.mnuBuscar.Visible = false;
            //padre.mnuPrevio.Visible = false;
            padre.separEditar2.Visible = false;

            //OPCIONES DE EDICION SEGUN 'ESEDITABLE'
            padre.tsbGuardar.Visible = this.EsEditable;
            padre.mnuGuardar.Visible = this.EsEditable;
            padre.separEditar1.Visible = this.EsEditable;
        }

        private void Asignaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dgrLista.DataSource = null;
        }

        private void Asignaciones_Activated(object sender, EventArgs e)
        {
            ((Principal)this.MdiParent).tstFiltrar.Visible = tieneFiltro;
            ((Principal)this.MdiParent).EscribeConteo(this.dgrLista.Rows.Count);
            GestionOpciones();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.cboCabecera.Enabled = false;
            AsignacionCr.Instancia.RaiseLlenaGrid(ref this.dgrLista, this.Modulo, this.cboCabecera.SelectedItem);
            this.cboCabecera.Enabled = true;
        }

        private void cboCabecera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.dgrLista.DataSource = null;
            this.btnConsultar.PerformClick();
        }
    }
}
