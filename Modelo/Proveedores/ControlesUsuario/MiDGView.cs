using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using System.Linq.Expressions;
using Entidades;
using ModeloDB;
using System.ComponentModel;

namespace Proveedores
{
    public class MiDGView : System.Windows.Forms.DataGridView
    {
        //Prepocesar mensajes
        public override bool PreProcessMessage(ref System.Windows.Forms.Message msg)
        {
            if (msg.Msg == 257 && (int)msg.WParam == 13) //Si es //KeyDown// y //Enter//
            {
                int MiCol = 0;
                int MiFil = this.CurrentCell.RowIndex - 1;
                if (this.CurrentCell.ColumnIndex < this.ColumnCount - 1) //Si noSalimos del limite
                    MiCol = this.CurrentCell.ColumnIndex + 1; //Siguiente columna
                if (MiFil > -1) this.CurrentCell = this[MiCol, MiFil]; //Posicionar columna
            }
            return base.PreProcessMessage(ref msg);
        }
    }
    //
    //Nuestra personalizacion para DGVPlus ---------------------------------------------------------------

    public delegate void AntesBuscarCellEventHandler(AntesBuscarCellEventArgs e);
    public delegate void ValidacionGridEventHandler(ValidacionGridEventArgs e);

    public class DgvPlus : DevComponents.DotNetBar.Controls.DataGridViewX
    {
        private bool permitirEventosInternos = false;

        int Columna = 0;
        int Fila = 0;
        public Dictionary<string, string> ColumnasSalto = new Dictionary<string, string>();

        public bool PermitirEventosInternos
        {
            get { return permitirEventosInternos; }
            set { permitirEventosInternos = value; }
        }

        private List<columnasgrid> ColumnasGrid { get; set; }

        #region EVENTOS PERSONALIZADOS

        /// <summary>
        /// Tiene lugar cuando se ejecuta los eventos CellValidating y CellClick siempre y cuando la propiedad PermitirEventosInternos tenga el valor True
        /// </summary>
        [Category("Personalizadas")]
        [Description("Tiene lugar antes de buscar el objeto cuando se ejecuta el metodo CellValidating y OnCellClick cuando la propiedad PermitirEventosInternos tiene el valor True")]
        [DisplayName("AntesBuscarCell")]
        public event AntesBuscarCellEventHandler AntesBuscarCell;
        public virtual void OnAntesBuscarCell(AntesBuscarCellEventArgs e)
        {
            AntesBuscarCellEventHandler handler = AntesBuscarCell;
            if (handler != null)
                handler(e);
        }

        /// <summary>
        /// Tiene lugar cuando se ejecuta los eventos CellValidating y CellClick siempre y cuando la propiedad PermitirEventosInternos tiene el valor True
        /// </summary>
        [Category("Personalizadas")]
        [Description("Tiene lugar cuando se ejecuta los metodos OnCellValidating y OnCellClick cuando la propiedad PermitirEventosInternos tenga el valor True")]
        [DisplayName("ValidarGrid")]
        public event ValidacionGridEventHandler ValidarGrid;
        public virtual void OnValidarGrid(ValidacionGridEventArgs e)
        {
            ValidacionGridEventHandler handler = ValidarGrid;
            if (handler != null)
                handler(e);
        }

        #endregion EVENTOS PERSONALIZADOS

        #region CONSTRUCTORES

        public DgvPlus()
        {
            this.CellBeginEdit += new DataGridViewCellCancelEventHandler(DgvPlus_CellBeginEdit);
            this.DataError += new DataGridViewDataErrorEventHandler(DgvPlus_DataError);
            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DgvPlus_EditingControlShowing);
            this.CellValidating += new DataGridViewCellValidatingEventHandler(DgvPlus_CellValidating);
            this.CellClick += new DataGridViewCellEventHandler(DgvPlus_CellClick);
            this.CurrentCellDirtyStateChanged += new EventHandler(DgvPlus_CurrentCellDirtyStateChanged);
            this.KeyPress += new KeyPressEventHandler(DgvPlus_KeyPress);
            this.KeyDown += new KeyEventHandler(DgvPlus_KeyDown);
        }

        #endregion CONSTRUCTORES

        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {
            System.ComponentModel.CancelEventArgs cancel = new System.ComponentModel.CancelEventArgs();
            if (keyData == Keys.Enter)
            {
                try
                {
                    Columna = 0;
                    Fila = this.CurrentCell.RowIndex;
                    if (Fila == this.RowCount) Fila = 0;
                    if (ColumnasSalto.ContainsKey(this.CurrentCell.OwningColumn.Name.Substring(3)))
                    {
                        Columna = this.CurrentRow.Cells["COL" + ColumnasSalto[this.CurrentCell.OwningColumn.Name.Substring(3)]].ColumnIndex;
                        if (Columna <= this.CurrentCell.ColumnIndex)
                            Fila++;
                    }
                    else
                        Columna = SiguienteColumna(this.CurrentCell.ColumnIndex);
                    if (Fila > -1) this.CurrentCell = this[Columna, Fila];
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }
            else
                return base.ProcessDialogKey(keyData);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Columna = 0;
                Fila = this.CurrentCell.RowIndex;
                Columna = SiguienteColumna(this.CurrentCell.ColumnIndex);
                if (Fila == this.RowCount)
                    Fila = 0;
                if (Fila > -1) this.CurrentCell = this[Columna, Fila];
            }
            else
                base.OnKeyDown(e);
        }

        private int SiguienteColumna(int curCol)
        {
            if (curCol < this.ColumnCount - 1)
                if (this.CurrentRow.Cells[curCol + 1].Visible)
                    return curCol += 1;
                else
                    return SiguienteColumna(curCol + 1);
            else
            {
                Fila += 1;
                return SiguienteColumna(-1);
            }
        }

        void DgvPlus_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (PermitirEventosInternos)
            {
                if (!this.ReadOnly)
                {
                    if (this.CurrentCell.GetType().Name == "DataGridViewCheckBoxCell")
                        this.EndEdit();
                }
            }
        }

        void DgvPlus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PermitirEventosInternos && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                DataGridViewColumn campo = this.Columns[e.ColumnIndex];
                try
                {
                    object objeto = null;
                    DataGridViewColumn columna = this.Columns[e.ColumnIndex];
                    if (this.Columns[e.ColumnIndex].GetType().Name == "DataGridViewButtonXColumn")
                    {
                        if (columna.Name.Contains("BEliminar"))
                            this.Rows.RemoveAt(e.RowIndex);
                        else
                        {
                            object nombreColumna = campo.Tag;
                            AntesBuscarCellEventArgs argumentos = new AntesBuscarCellEventArgs(e.ColumnIndex, e.RowIndex);
                            OnAntesBuscarCell(argumentos);
                            if (argumentos.TipoConsulta == TipoConsulta._NoSet)
                            {
                                columnasgrid registro = this.ColumnasGrid.Find(x => x.nombre.ToUpper() == columna.Name.Substring(3));
                                if (registro != null)
                                {
                                    TipoConsulta tipo;
                                    Enum.TryParse(registro.busqueda, out tipo);
                                    argumentos.TipoConsulta = tipo;
                                }
                            }
                            if (argumentos.TipoConsulta != TipoConsulta._NoSet)
                            {
                                if (!argumentos.Cancel)
                                {
                                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                                        campo.DataGridView.EndEdit();
                                    if (!campo.DataGridView.IsCurrentCellDirty)
                                        campo.DataGridView.NotifyCurrentCellDirty(true);
                                    else
                                        campo.DataGridView.NotifyCurrentCellDirty(false);
                                    if (e.RowIndex > -1)
                                    {
                                        if (columna.Name.Contains("BCliente"))
                                        {
                                            if (campo.Tag == null)
                                                nombreColumna = "colCliente";
                                            objeto = BuscarListaPr.BuscarObjeto(TipoConsulta.Clientes);
                                        }
                                        else
                                        {
                                            objeto = BuscarListaPr.BuscarObjeto(argumentos.TipoConsulta, false, true, argumentos.GetValoresAdicionales());
                                            if (argumentos.ColumnaObjeto != null)
                                                nombreColumna = argumentos.ColumnaObjeto;
                                        }
                                    }

                                    if (objeto != null)
                                    {
                                        OnValidarGrid(new ValidacionGridEventArgs(e.ColumnIndex, e.RowIndex) { EsBoton = true, Objeto = objeto });
                                        campo.DataGridView.NotifyCurrentCellDirty(false);
                                        campo.DataGridView.BeginEdit(false);
                                        campo.DataGridView.CurrentRow.Cells[nombreColumna.ToString()].Value = objeto;
                                        campo.DataGridView.InvalidateRow(e.RowIndex);
                                    }
                                }
                                campo.DataGridView.EndEdit();
                            }
                            else
                                ModeloDB.General.Mensaje("Tipo de consulta no definida");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModeloDB.General.Mensaje(ex.Message.ToString());
                }
            }
        }

        void DgvPlus_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (PermitirEventosInternos)
            {
                try
                {
                    if (this.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
                    {
                        AntesBuscarCellEventArgs argumentos = new AntesBuscarCellEventArgs(e.ColumnIndex, e.RowIndex);
                        OnAntesBuscarCell(argumentos);
                        if (argumentos.TipoConsulta == TipoConsulta._NoSet)
                        {
                            columnasgrid registro = this.ColumnasGrid.Find(x => x.nombre.ToUpper() == this.Columns[e.ColumnIndex].Name.Substring(3) && !string.IsNullOrEmpty(x.busqueda));
                            if (registro != null)
                            {
                                TipoConsulta tipo;
                                Enum.TryParse(registro.busqueda, out tipo);
                                argumentos.TipoConsulta = tipo;
                            }
                            else
                                return;
                        }
                        if (argumentos.TipoConsulta != TipoConsulta._NoSet)
                        {
                            if (!argumentos.Cancel)
                            {
                                object nombreColumna = this.Columns[e.ColumnIndex].Tag;
                                ValidacionGridEventArgs argumento = new ValidacionGridEventArgs(e.ColumnIndex, e.RowIndex) { Cancel = e.Cancel, EsBoton = false };
                                OnValidarGrid(argumento);
                                e.Cancel = argumento.Cancel;
                                if (!e.Cancel)
                                {
                                    object objeto = null;
                                    if (argumentos.ColumnaObjeto != null)
                                        nombreColumna = argumentos.ColumnaObjeto;
                                    if (!this.Columns.Contains((nombreColumna ?? "").ToString()))
                                    {
                                        e.Cancel = true;
                                        //this.CancelEdit();
                                        ModeloDB.General.Mensaje("Columna destino de objeto encontrado no definida");
                                    }
                                    else
                                    {
                                        objeto = BuscarListaPr.BuscarRegistro(argumentos.TipoConsulta, this.EditingControl.Text);
                                        if (objeto != null)
                                        {
                                            this.CurrentRow.Cells[nombreColumna.ToString()].Value = objeto;
                                            ((Instrumental1)this.CurrentRow.DataBoundItem).IntegrarAsociados();
                                        }
                                        else
                                        {
                                            e.Cancel = true;
                                            //this.CancelEdit();
                                            ModeloDB.General.Mensaje("Objeto no encontrado.");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            //this.CancelEdit();
                            ModeloDB.General.Mensaje("Tipo de consulta no definida");
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    //this.CancelEdit();
                    ModeloDB.General.Mensaje(ex.Message);
                }
            }
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            if (this.ColumnasGrid != null)
                foreach (DataGridViewColumn item in this.Columns)
                    item.ReadOnly = this.ColumnasGrid.Find(x => x.nombre.ToUpper() == item.Name.Substring(3)).sololectura;
        }
        void DgvPlus_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (PermitirEventosInternos)
            {
                this.CurrentCell.Style.ForeColor = System.Drawing.Color.Black;
                this.CurrentCell.Style.BackColor = System.Drawing.Color.SkyBlue;
                if (this.CurrentCell.GetType().Name == "DataGridViewComboBoxExCell" || this.CurrentCell.GetType().Name == "DataGridViewDateTimeInputCell")
                    this.NotifyCurrentCellDirty(true);
            }
        }

        void DgvPlus_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (PermitirEventosInternos)
            //{
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewComboBoxExCell")
            {
                SendKeys.Send("{F4}");
                this.CurrentCell.Style.ForeColor = System.Drawing.Color.Black;
            }
            //}
        }

        void DgvPlus_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (PermitirEventosInternos)
            {
                if (e.Exception != null)
                    ModeloDB.General.Mensaje(e.Exception.Message, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        void DgvPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PermitirEventosInternos)
            {
                if (!this.ReadOnly)
                {
                    if (e.KeyChar == (char)Keys.Space)
                    {
                        for (int i = 0; i < this.SelectedCells.Count; i++)
                        {
                            if (this.SelectedCells[i].GetType().Name == "DataGridViewCheckBoxCell")
                            {
                                this.SelectedCells[i].Value = !(bool)this.SelectedCells[i].Value;
                            }
                        }
                    }

                }
            }
        }

        void DgvPlus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && !this.ReadOnly & !this.CurrentRow.Selected)
                foreach (DataGridViewCell item in this.SelectedCells)
                    if (!item.OwningColumn.ReadOnly)
                        item.Value = null;
        }

        protected override void OnLeave(EventArgs e)
        {
            if (PermitirEventosInternos)
            {
                if (!this.ReadOnly)
                    if (this.Enabled)
                    {
                        if (this.CurrentCell != null)
                            if ((this.CurrentRow.Index != this.NewRowIndex) && this.IsCurrentCellInEditMode)
                                this.CancelEdit();
                        if (this.CurrentRow != null)
                        {
                            if (this.CurrentRow.Index == this.NewRowIndex)
                                this.CancelEdit();
                            this.EndEdit();
                        }
                    }
            }
            base.OnLeave(e);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);

            if (PermitirEventosInternos)
            {
                if (!this.ReadOnly && this.Columns.Contains("colModificado"))
                    if (this.Columns[e.ColumnIndex].Name != "colModificado")
                        if (this.CurrentRow.Index != this.NewRowIndex && this.Columns.Contains("colModificado"))
                            this.CurrentRow.Cells["colModificado"].Value = true;
            }
        }

        public bool ControlEdicionGrid()
        {
            if (this.CurrentRow != null)
            {
                if (this.CurrentRow.Index == this.NewRowIndex)
                    this.CancelEdit();
                this.EndEdit();
            }
            bool requerido = false;
            int c = 0, f = 0;
            for (f = 0; f < this.RowCount - 1; f++)
                for (c = 0; c < this.ColumnCount - 1; c++)
                    if (this.Columns[c].HeaderText.Contains('.'))
                        if ((this[c, f].Value == null) || (this[c, f].Value.ToString().Trim() == ModeloDB.General.itemCero))
                        {
                            this[c, f].Style.ForeColor = System.Drawing.Color.White;
                            this[c, f].Style.BackColor = System.Drawing.Color.Red;
                            requerido = true;
                        }
            return requerido;
        }

        public void SetColumnasGrid(object unColumnasGrid, short unIdentificador = 0)
        {
            List<columnasgrid> columnas = unColumnasGrid as List<columnasgrid>;
            if (columnas != null)
            {
                this.ColumnasGrid = columnas.Where(x => x.identificador == unIdentificador).ToList();
                this.Columns.AddRange(InstrumentalPr.GeneraColumnasGrid(columnas, unIdentificador));
            }
        }
    }

    #region ARGUMENTOS

    public class AntesBuscarCellEventArgs : DataGridViewCellCancelEventArgs
    {
        private TipoConsulta tipoConsulta = TipoConsulta._NoSet;
        /// <summary>
        /// Tipo de consulta que se ejecutará.
        /// </summary>
        public TipoConsulta TipoConsulta { get { return tipoConsulta; } set { tipoConsulta = value; } }
        /// <summary>
        /// Columna destino del objeto buscado. Al establecerla no se modifica la definida en la propiedad Tag de la columna.
        /// </summary>
        public string ColumnaObjeto { get; set; }
        /// <summary>
        /// Parametros adicionales enviados a la consulta de objetos.
        /// </summary>
        private object[] parametros;

        public AntesBuscarCellEventArgs(int columnIndex, int rowIndex)
            : base(columnIndex, rowIndex)
        {

        }

        /// <summary>
        /// Seteo de valores adicionales enviados a la consulta de objetos.
        /// </summary>
        /// <param name="valoresAdicionales"></param>
        public void SetValoresAdicionales(params object[] valoresAdicionales)
        {
            parametros = valoresAdicionales;
        }

        /// <summary>
        /// Valores adicionales enviados a la consulta de objetos.
        /// </summary>
        /// <returns></returns>
        internal object[] GetValoresAdicionales()
        {
            return parametros;
        }
    }

    public class ValidacionGridEventArgs : DataGridViewCellCancelEventArgs
    {
        public bool EsBoton { get; set; }
        public object Objeto { get; set; }

        public ValidacionGridEventArgs(int columnIndex, int rowIndex)
            : base(columnIndex, rowIndex)
        {

        }
    }

    #endregion ARGUMENTOS
}

