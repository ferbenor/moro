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

namespace WindowsApp
{
    public partial class Form2W : Form, IView
    {
        private string modulo = null;
        private bool raiseEvent = false;
        private object valorOld = null;

        public string Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        public Form2W()
        {
            InitializeComponent();


        }
        private Proveedores.DgvPlus _MiDGView1 = new Proveedores.DgvPlus();     //Mi DGV, que traduce el 'Enter' en 'Tab'
        private Proveedores.MiDGView _MiDGView2 = new Proveedores.MiDGView();    //Mi DGV, que controla la posicion de la celda actual
        private void Form1_Load(object sender, EventArgs e)
        {
            //Construir el primer DGV
        _MiDGView1.Dock = DockStyle.Left;                                          //Acoplarlo a la izquierda
        _MiDGView1.ColumnCount = 4;                                                //con cuatro columnas
        _MiDGView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;     //Ajustarlo al tamaño
        _MiDGView1.Columns[0].HeaderText = "Caso A";                               //Etiquetar columna
        _MiDGView1.Columns[0].Tag = 2;
        this.Controls.Add(_MiDGView1);                                               //Añadirlo al form
        //
        //Construir el segundo DGV
        _MiDGView2.Dock = DockStyle.Right;
        _MiDGView2.ColumnCount = 4;
        _MiDGView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _MiDGView2.Columns[0].HeaderText = "Caso B";
        this.Controls.Add(_MiDGView2);
        //
        //La ventana (aspecto)
        this.Width = this._MiDGView1.Width + this._MiDGView2.Width + 25;           //Ajustar el ancho del form
        this.Text = "Pep/Rafa DataGridView";  

            //GestionMaestrasCr.Instancia.RegisterView(this);
            //this.dgrGenero.AutoGenerateColumns = false;
            //raiseEvent = true;
            //GestionMaestrasCr.Instancia.RaiseListLoad(this.dgrGenero, this.Modulo, 0);
            //raiseEvent = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionMaestrasCr.Instancia.UnregisterView(this);
        }

        public void Eliminar()
        {
            raiseEvent = true;
            GestionMaestrasCr.Instancia.RaiseBorrar(this.dgrGenero);
            raiseEvent = false;
        }

        public void Grabar()
        {
            raiseEvent = true;
            if (this.dgrGenero.CurrentRow.Index == this.dgrGenero.NewRowIndex)
                this.dgrGenero.CancelEdit();
            else
                this.dgrGenero.EndEdit();
            GestionMaestrasCr.Instancia.RaiseGrabarLista(this.dgrGenero);
            raiseEvent = false;
        }

        public void VistaCargada(object sender, ViewLoadEventArgs e)
        {
            if (raiseEvent)
            {
                if (e.RowIndex > -1 && e.ColIndex > -1)
                {
                    this.dgrGenero.CurrentCell = dgrGenero.Rows[e.RowIndex].Cells[e.ColIndex];
                }
            }
        }

        public void DespuesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (e.Completado == true && raiseEvent == true)
            {
                GestionMaestrasCr.Instancia.RaiseListLoad(sender, this.modulo, e.RowIndex, e.ColIndex);
            }
        }

        public void Actualizar()
        {
            raiseEvent = true;
            if (this.dgrGenero.Rows.Count > 0)
                GestionMaestrasCr.Instancia.RaiseListLoad(this.dgrGenero, this.modulo, this.dgrGenero.CurrentRow.Index, this.dgrGenero.CurrentCell.ColumnIndex);
            else
                GestionMaestrasCr.Instancia.RaiseListLoad(this.dgrGenero, this.modulo, 0, 0);

            raiseEvent = false;
        }

        public void Filtrar(string unTexto)
        {

        }

        private void dgrGenero_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Object.Equals(this.valorOld, this.dgrGenero.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))

                if (this.dgrGenero.CurrentRow.Index != this.dgrGenero.NewRowIndex)
                {
                    DataGridViewRow fila = this.dgrGenero.CurrentRow;
                    this.dgrGenero.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                    this.valorOld = null;
                }
        }

        private void dgrGenero_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.valorOld = this.dgrGenero.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //SendKeys.Send("{F4}");

        }

        public void AntesAfectarObjeto(object sender, AfectarObjetosEventArgs e)
        {
            if (raiseEvent)
            {
                if (e.RowIndex > -1 && e.ColIndex > -1)
                {
                    this.dgrGenero.CurrentCell = dgrGenero.Rows[e.RowIndex].Cells[e.ColIndex];
                }
            }
        }

    }
}
