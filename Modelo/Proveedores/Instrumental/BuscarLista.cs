using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;
using LinqToDB.Data;

namespace Proveedores
{
    public partial class frmBuscarL : Form
    {
        List<LinqToDB.Data.DataParameter> lp = new List<LinqToDB.Data.DataParameter>();

        public string FuncionBuscar;
        public object[] ParamsParametros;
        public string cadenaSql = null;
        public Dictionary<string, object> parametros = new Dictionary<string, object>();

        public string Tabla { get; set; }
        public string ValorWhere { get; set; }
        public string Campos { get; set; }
        public string Ordenar { get; set; }
        public bool Inicializado { get; set; }
        public DataGridViewRow FilaSeleccionada { get; set; }
        public object ObjetoSeleccionado { get; set; }

        public frmBuscarL()
        {
            InitializeComponent();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {

            this.AcceptButton = this.btnBuscar;
            this.txtBuscar.SelectAll();
        }

        private void frmBuscarL_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.FuncionBuscar != null)
                {


                    var columnas = typeof(BuscarListaPr).GetMethod(this.FuncionBuscar, new Type[] { }).Invoke(null, null);
                    if (columnas != null)
                    {
                        this.dgrLista.AutoGenerateColumns = false;
                        this.dgrLista.Columns.AddRange(columnas.Cast<DataGridViewColumn[]>());
                    }
                }

                if (this.Inicializado)
                {
                    this.txtBuscar.Text = " ";
                    this.btnBuscar.PerformClick();
                    this.txtBuscar.Text = "";
                }
                else
                {
                    this.txtBuscar.Text = "-5";
                    this.btnBuscar.PerformClick();
                    this.txtBuscar.Text = "";
                }

                Entidades.General.Interfaz(this);
                //Entidades.General.Interfaz(this.gpbCabecera);
            }
            catch (Exception ex)
            {
                Entidades.General.Mensaje(ex.Message, MessageBoxIcon.Exclamation);
            }
            this.txtBuscar.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.spvValidador.Validate();
            if (this.spvValidador.LastFailedValidationResults.Count == 0)
            {
                if (this.cadenaSql != null && this.parametros.Count > 0)
                    BuscarListaPr.LlenaGrid(this.dgrLista, cadenaSql, parametros.Select(x => new DataParameter(x.Key, x.Value)).ToArray());
                else if (this.FuncionBuscar != null)
                {
                    object lista = null;
                    var tipo = typeof(BuscarListaPr);
                    var funcion = tipo.GetMethod(this.FuncionBuscar, new Type[] { typeof(string) });
                    if (funcion == null)
                    {
                        funcion = tipo.GetMethod(this.FuncionBuscar, new Type[] { typeof(string), typeof(object[]) });
                        lista = funcion.Invoke(null, new object[] { this.txtBuscar.Text, this.ParamsParametros });
                    }
                    else
                        lista = funcion.Invoke(null, new[] { this.txtBuscar.Text });
                    this.dgrLista.DataSource = null;
                    this.dgrLista.DataSource = lista;
                }
                else
                {
                    int i = 0;
                    lp.Add(new LinqToDB.Data.DataParameter("nombre", this.txtBuscar.Text.Trim() + "%"));
                    int.TryParse(this.txtBuscar.Text.Trim(), out i);
                    lp.Add(new LinqToDB.Data.DataParameter("codigo", i));

                    BuscarListaPr.LlenaGrid(this.dgrLista, this.Tabla, "where " + this.ValorWhere, this.Campos, this.Ordenar, lp.ToArray());
                }


                if (this.dgrLista.Rows.Count == 0)
                    this.btnSeleccionar.Enabled = false;
                else
                    this.btnSeleccionar.Enabled = true;

            }
            this.txtBuscar.Focus();
            this.txtBuscar.SelectAll();
        }

        private void dgrLista_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnSeleccionar;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                if (this.dgrLista.Rows.Count > 0)
                    this.dgrLista.Focus();
        }

        private void dgrLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnSeleccionar.PerformClick();
            if (e.KeyCode == Keys.Up)
                if (this.dgrLista.Rows.Count > 0)
                    if (this.dgrLista.CurrentCell.RowIndex == 0)
                        this.txtBuscar.Focus();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.dgrLista.CurrentRow.DataBoundItem != null)
                this.ObjetoSeleccionado = this.dgrLista.CurrentRow.DataBoundItem;
            this.FilaSeleccionada = this.dgrLista.CurrentRow;

            this.Close();
        }

        public DataGridViewRow Seleccionar()
        {
            this.ShowDialog();
            return this.dgrLista.CurrentRow;
        }

        private void dgrLista_DoubleClick(object sender, EventArgs e)
        {
            this.btnSeleccionar.PerformClick();
        }
        
    }
}
