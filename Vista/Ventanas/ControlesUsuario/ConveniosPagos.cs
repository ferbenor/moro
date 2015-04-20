using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloDB;
using Proveedores;
using DevComponents.DotNetBar.Controls;

namespace WindowsApp
{
    public enum TipoEvento { Setear, Obtener }
    public partial class ConveniosPagos : UserControl, IControlesUsuario
    {
        FBindingList<conveniopago> listaConvenios = null;
        ConveniosPagosEventArgs e = new ConveniosPagosEventArgs();

        #region DEFINICION PARA EVENTOS

        public delegate void ConveniosPagosEventHandler(object sender, ConveniosPagosEventArgs e);

        public event ConveniosPagosEventHandler Valores;

        protected virtual void OnValores(ConveniosPagosEventArgs e)
        {
            ConveniosPagosEventHandler handler = Valores;
            if (handler != null)
            {
                handler(this, e);
                if (e.ListaValores.Count == 0 && e.TipoEvento == TipoEvento.Obtener)
                    throw new Exception("Valores para forma de pago no definidos");
            }
        }

        #endregion DEFINICION PARA EVENTOS

        #region PROPIEDADES

        private identificadorpago identificadorPago;
        public object IdentificadorPago
        {
            get { if (this.identificadorPago == null) this.identificadorPago = new identificadorpago(); return this.identificadorPago; }
            set { this.identificadorPago = (identificadorpago)value; if (value != null) this.identificadorPago.fkconveniospago.CargarGrid(this.dgrLista); else this.dgrLista.Visible = false; }
        }

        public object DataSource { get { return this.dgrLista.DataSource; } set { this.dgrLista.DataSource = value; } }

        public DataGridViewButtonXColumn ColEliminar { get { return this.colEliminar; } }
        public DataGridViewButtonXColumn ColBuscar { get { return this.colBuscar; } }

        public DataGridView ObjetoGrid { get { return this.dgrLista; } }

        public object Columnas { get; set; }

        public string Modulo { get; set; }

        /// <summary>
        /// Identificador de pagos
        /// </summary>
        public object Objeto
        {
            get
            {
                if (this.identificadorPago == null)
                    this.identificadorPago = new identificadorpago();
                return this.identificadorPago;
            }
            set
            {
                this.identificadorPago = (identificadorpago)value;
                if (value != null)
                {
                    this.identificadorPago.fkconveniospago.CargarGrid(this.dgrLista);
                    this.listaConvenios = (FBindingList<conveniopago>)this.dgrLista.DataSource;
                    this.TotalPagado = this.listaConvenios.Sum(x => x.valor);
                    e.TotalPagado = this.TotalPagado;
                    e.TipoEvento = TipoEvento.Setear;
                    OnValores(e);
                }
                else
                    this.dgrLista.Visible = false;
            }
        }

        public decimal TotalPagado { get; set; }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public ConveniosPagos()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTORES

        #region METODOS

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            //throw new NotImplementedException();
        }

        public bool Verificar()
        {
            //throw new NotImplementedException();
            return false;
        }

        private void FormasPagos_Load(object sender, EventArgs e)
        {
            this.colBuscar.Tag = "colFormaPago";

            this.dgrLista.AutoGenerateColumns = false;
            this.dgrLista.CellValidating += new DataGridViewCellValidatingEventHandler(objetoGrid_CellValidating);
            this.dgrLista.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
            this.dgrLista.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
            this.dgrLista.ForeColor = System.Drawing.Color.Black;
            this.dgrLista.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }

        private void _dgrLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!this.dgrLista.ReadOnly)
            {
                if (this.dgrLista.CurrentCell.GetType().Name == "DataGridViewComboBoxEx")
                    this.dgrLista.EndEdit();
            }
        }

        private object CrearConvenio(object unaFormaPago, object unConvenioPago)
        {
            int ix = 0;
            //if (this.dgrLista.CurrentRow.Index == this.dgrLista.NewRowIndex)
            //ix = this.dgrLista.NewRowIndex;
            //else
            //ix = this.dgrLista.CurrentRow.Index;

            bool nuevo = false;
            object convenioPago = null;
            e.ListaValores.Clear();
            e.TipoEvento = TipoEvento.Obtener;
            this.OnValores(e);

            if (unConvenioPago == null)
                nuevo = true;
            if (e.ListaValores != null)
                if (e.ListaValores.Count > 0)
                {
                    formapago formaPago = (formapago)unaFormaPago;

                    Type unTipo = Type.GetType("Proveedores." + formaPago.modulo + ", Proveedores");
                    if (unTipo == null)
                        MessageBox.Show("Modulo no definido para forma de pago " + formaPago.descripcion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        Form unForm = (Form)Activator.CreateInstance(unTipo);
                        ((IControlesUsuario)unForm).Cargar(ref unConvenioPago, null, e.ListaValores);
                        //ENFOQUE A OTRO CONTROL PARA DEFINIR ESTADO SIN ACCION PARA EL GRID
                        unForm.ShowDialog();
                        convenioPago = ((IControlesUsuario)unForm).Objeto;
                        if (convenioPago != null)
                        {
                            this.checkBox1.Focus();
                            ((conveniopago)convenioPago).fkformaspago = formaPago;
                            if (nuevo)
                                this.listaConvenios.Add((conveniopago)convenioPago);
                            else
                                this.dgrLista.InvalidateRow(this.dgrLista.CurrentRow.Index);

                            ix = this.dgrLista.NewRowIndex;

                            this.TotalPagado = this.listaConvenios.Sum(x => x.valor);
                            e.TotalPagado = this.TotalPagado;
                            e.TipoEvento = TipoEvento.Setear;
                            this.OnValores(e);
                        }

                        unForm = null;
                    }
                }
            //ESTABLECEMOS ENFOQUE AL GRID EN LA CELDA NUEVA PARA OTRA FORMA DE PAGO
            this.dgrLista.CurrentCell = this.dgrLista.Rows[ix].Cells[1];
            this.dgrLista.Focus();
            return convenioPago;
        }

        #endregion METODOS

        #region METODOS GRID

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn campo = null;
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    campo = (DataGridViewColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    //if (!campo.DataGridView.IsCurrentCellDirty)
                    //    campo.DataGridView.NotifyCurrentCellDirty(true);
                    //else
                    //    campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.BuscarFormaPago();
                    if (objeto != null)
                    {
                        objeto = CrearConvenio(objeto, campo.DataGridView.CurrentRow == null ? null : campo.DataGridView.CurrentRow.DataBoundItem);
                        if (objeto != null)
                        {
                            ////campo.DataGridView.NotifyCurrentCellDirty(false);
                            ////campo.DataGridView.BeginEdit(false);
                            //campo.DataGridView.InvalidateRow(campo.DataGridView.CurrentRow.Index);
                            ////campo.DataGridView.CurrentRow.Cells["colFormaPago"].Value = objeto;
                            ////campo.DataGridView.CurrentRow.DataBoundItem = objeto;
                            //campo.DataGridView.EndEdit();
                        }
                        else
                            campo.DataGridView.CancelEdit();
                    }
                    else
                        campo.DataGridView.EndEdit();
                }
            }
            catch (Exception ex)
            {
                if (campo != null)
                {
                    campo.DataGridView.NotifyCurrentCellDirty(false);
                    campo.DataGridView.CancelEdit();
                }
                General.Mensaje(ex.Message.ToString());
            }
        }

        void objetoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && ((DataGridView)sender).ReadOnly == false)
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 0 || ((DataGridView)sender).CurrentCell.ColumnIndex == 1)
                {
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(1, ((DataGridView)sender).CurrentCell.RowIndex));
                }
        }

        void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
            {
                if (grid.CurrentCell.ColumnIndex == 1)
                {
                    object objeto = null;
                    objeto = FormaPagoPr.Instancia.RegistroPorId(grid.EditingControl.Text.ToUpper());

                    this.dgrLista.CancelEdit();

                    if(objeto != null)
                        objeto = CrearConvenio(objeto, this.dgrLista.CurrentRow == null ? null : this.dgrLista.CurrentRow.DataBoundItem);
                    

                    //if (objeto == null)
                    //{
                    //    grid.CurrentRow.Cells["colFormaPago"].Value = null;

                    //}
                    //else
                    //    grid.CurrentRow.Cells["colFormaPago"].Value = objeto;

                    if (objeto == null)
                    {
                        General.Mensaje(General.itemNoEncontrado);
                        e.Cancel = true;
                    }
                }
            }
            grid.InvalidateRow(grid.CurrentRow.Index);
        }

        #endregion METODOS GRID

        #region SOBRECARGAS (OVERRIDES)

        protected override void OnEnabledChanged(EventArgs e)
        {
            //base.OnEnabledChanged(e);
            this.dgrLista.AllowUserToAddRows = this.Enabled;
            this.dgrLista.ReadOnly = !this.Enabled;
            this.colEliminar.Visible = this.Enabled;
        }

        #endregion

        #region ARMAR GRID

        public DataGridViewColumn[] ColumnasGridDetalle()
        {
            DataGridViewButtonXColumn colEliminar = new DataGridViewButtonXColumn()
            {
                Name = "colEliminar",
                HeaderText = "->",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                //Tag = "colFormaPago",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };

            DataGridViewTextBoxColumn colCodigoFormaPago = new DataGridViewTextBoxColumn()
            {
                Name = "colCodigoFormaPago",
                HeaderText = "Id",
                DataPropertyName = "idformapago",
                MaxInputLength = 5,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                //Tag = "colCantidad"
            };
            colCodigoFormaPago.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewButtonXColumn colCodigoFormaPagoBoton = new DataGridViewButtonXColumn()
            {
                Name = "colCodigoFormaPagoBoton",
                HeaderText = "->",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colFormaPago",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };

            DataGridViewTextBoxColumn colFormaPago = new DataGridViewTextBoxColumn()
            {
                Name = "colFormaPago",
                HeaderText = "Forma de pago",
                DataPropertyName = "fkformaspago",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                Tag = "colCodigoFormaPago",
                //Width = 200
            };

            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn()
            {
                Name = "colValor",
                HeaderText = "Valor",
                DataPropertyName = "valor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colValor.DefaultCellStyle.Format = "N2";

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colEliminar,
                colCodigoFormaPago,
                colCodigoFormaPagoBoton,
                colFormaPago,
                colValor
            };
            return listaColumnas;
        }

        #endregion ARMAR GRID

    }

    public class ConveniosPagosEventArgs : EventArgs
    {
        public List<Valores> ListaValores { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public decimal TotalPagado { get; set; }
        public ConveniosPagosEventArgs()
        {
            this.ListaValores = new List<Valores>();
        }

    }
}
