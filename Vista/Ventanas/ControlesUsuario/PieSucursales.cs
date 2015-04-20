using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedores;
using ModeloDB;
using DevComponents.DotNetBar.Controls;

namespace WindowsApp
{
    public partial class PieSucursales : UserControl, IControlesUsuario
    {
        #region VARIABLES

        private sucursal objetoLocal;

        #endregion VARIABLES

        #region PROPIEDADES

        public object Columnas { get; set; }

        public string Modulo { get; set; }

        public object Objeto { get; set; }

        #endregion PROPIEDADES

        private void PieOficinas_Load(object sender, EventArgs e)
        {
            this.dgrListaTelefonos.AutoGenerateColumns = false;
            this.dgrListaTelefonos.Columns.AddRange(InstrumentalPr.GeneraColumnasGrid(this.Columnas));
            //this.ArmarGrid(this.dgrListaTelefonos);

            this.dgrListaTelefonos.CellValueChanged += this.dgrLista_CellValueChanged;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            this.dgrListaTelefonos.ReadOnly = !this.Enabled;
            this.dgrListaTelefonos.AllowUserToAddRows = this.Enabled;
        }

        public void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null)
        {
            if (unObjeto != null)
            {
                ((DataGridViewComboBoxExColumn)this.dgrListaTelefonos.Columns["colOperadora"]).DataSource = SucursalPr.Instancia.lsOperadoras;
                this.objetoLocal = (sucursal)unObjeto;
                this.objetoLocal.fktelefonossucursal.CargarGrid(this.dgrListaTelefonos);
                this.dgrListaTelefonos.Visible = true;
            }
            else
            {
                this.dgrListaTelefonos.DataSource = unObjeto;
                this.dgrListaTelefonos.Visible = false;
            }
        }

        public Boolean Verificar()
        {
            return this.dgrListaTelefonos.ControlEdicionGrid();
        }

        #region METODOS PARA EVENTOS DE GRID

        void dgrLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgrListaTelefonos.ReadOnly)
                if (this.dgrListaTelefonos.Columns[e.ColumnIndex].Name != "colModificado")
                {
                    this.objetoLocal.Modificado = true;
                    if (this.dgrListaTelefonos.CurrentRow.Index != this.dgrListaTelefonos.NewRowIndex)
                    {
                        this.dgrListaTelefonos.CurrentRow.Cells["colModificado"].Value = true;
                    }
                }
        }

        #endregion METODOS PARA EVENTOS GRID


        #region ARMAR GRID TELEFONOS
        private void ArmarGrid(DgvPlus objetoGrid)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
                /*if (!objetoGrid.ReadOnly)
                { }*/
            }
            //CARGA DE LISTAS
            //objetoGrid.CancelEdit();
            //objetoLocal.fktelefonosoficina.CargarGrid(objetoGrid);
            //objetoGrid.Tag = "0";
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewComboBoxExColumn colOperadora = new DataGridViewComboBoxExColumn()
            {
                Name = "colOperadora",
                HeaderText = "Operadora.",
                DataPropertyName = "fkoperadorastelefonia",
                ValueMember = "Objeto",
                DisplayMember = "nombre",
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn()
            {
                Name = "colTelefono",
                HeaderText = "Telefono.",
                DataPropertyName = "Telefono",
                MaxInputLength = 13,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "activo",
                Visible = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colOperadora,
                colTelefono,
                colActivo,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID TELEFONOS

    }
}
