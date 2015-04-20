using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using LinqToDB;
using LinqToDB.Data;
using System.Linq.Dynamic;

namespace Proveedores
{
    public class PersonaPr : InstrumentalPr
    {

        #region VARIABLES
        private static PersonaPr instancia = null;

        private List<tipopersona> lsTipoPersona;
        private List<tipodocumento> lsTipoDocumento;
        private List<genero> lsGenero;
        private List<parroquia> lsParroquia;
        #endregion VARIABLES

        #region PROPIEDADES
        public static PersonaPr Instancia { get { if (instancia == null) instancia = new PersonaPr(); return instancia; } set { instancia = value; } }

        public List<tipopersona> ListaTipoPersona
        {
            get { if (this.lsTipoPersona == null) this.lsTipoPersona = TipoPersonaPr.Instancia.Registros(); return this.lsTipoPersona; }
            set { this.lsTipoPersona = value; }
        }
        public List<tipodocumento> ListaTipoDocumento
        {
            get { if (this.lsTipoDocumento == null) this.lsTipoDocumento = TipoDocumentoPr.Instancia.Registros(); return this.lsTipoDocumento; }
            set { this.lsTipoDocumento = value; }
        }
        public List<genero> ListaGenero
        {
            get { if (this.lsGenero == null) this.lsGenero = GeneroPr.Instancia.Registros(); return this.lsGenero; }
            set { this.lsGenero = value; }
        }

        public List<parroquia> ListaParroquia
        {
            get { if (this.lsParroquia == null) this.lsParroquia = ParroquiaPr.Instancia.Registros(); return this.lsParroquia; }
            set { this.lsParroquia = value; }
        }

        #endregion PROPIEDADES

        public PersonaPr()
        { }

        public persona RegistroPorIdentificacion(string unaIdentificacion)
        {
            return Registros("identificacion == @0", unaIdentificacion).SingleOrDefault();
        }

        public persona Registro(int unId)
        {
            return Registros("id == @0", unId).SingleOrDefault();
        }

        public List<persona> Registros(string expresion = null, params object[] parametros)
        {
            List<persona> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.personas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                    .OrderBy(x => x.apellido).ThenBy(x => x.nombre).Select(x =>
                        //CONYUGE, PERSONA, ESTADOSPERSONA
                    x.Relacionar(
                        x.fkestadospersona
                    ).Relacionar(
                        x.fkparroquia
                    )).ToList();
            }

            for (int ix = 0; ix < registros.Count; ix++)
            {
                persona item = registros[ix];
                item = CargarRelaciones(item);
            }

            return registros;
        }

        private persona CargarRelaciones(persona unObjeto)
        {
            int ix;
            ix = ListaTipoPersona.FindIndex(x => x.id == unObjeto.idtipopersona);
            if (ix > -1)
                unObjeto.fktipospersona = ListaTipoPersona[ix];

            ix = ListaTipoDocumento.FindIndex(x => x.id == unObjeto.idtipodocumento);
            if (ix > -1)
                unObjeto.fktiposdocumento = ListaTipoDocumento[ix];

            ix = ListaGenero.FindIndex(x => x.id == unObjeto.idgenero);
            if (ix > -1)
                unObjeto.fkgenero = ListaGenero[ix];

            return unObjeto;
        }

        public int Grabar(persona item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        /// <summary>
        /// Graba una lista de registros que generalmente proviene de un DataSource tipo Object
        /// </summary>
        /// <param name="lista">De tipo BindingListView contenedora de los registros</param>
        /// <returns>Numero generado para PK en Insert o registros afectados en Update</returns>
        public int Grabar(IEnumerable<persona> items)
        {
            return items.Where(x => x.Modificado).GrabarListaT(x => x.id);
        }

        public int Borrar(persona item)
        {
            item.idestadopersona = 2;
            return item.BorrarObjetoT();
        }

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
                if (!objetoGrid.ReadOnly)
                {
                    objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
                    objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
                    objetoGrid.ForeColor = System.Drawing.Color.Black;
                    objetoGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
                objetoGrid.Columns["colParroquiaBoton"].Visible = !objetoGrid.ReadOnly;
            }

            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colGenero"]).DataSource = this.ListaGenero;
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colTipoPersona"]).DataSource = this.ListaTipoPersona;
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colTipoDocumento"]).DataSource = this.ListaTipoDocumento;
        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 && e.RowIndex > -1)
                {
                    DataGridViewColumn campo = (DataGridViewColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.BuscarParroquia();
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.BeginEdit(false);
                        campo.DataGridView.CurrentRow.Cells["colParroquiaDocumento"].Value = ParroquiaPr.Instancia.RegistroPorId((int)objeto);
                        campo.DataGridView.EndEdit();
                    }
                    else
                        campo.DataGridView.EndEdit();
                }
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message.ToString());
            }
        }

        void objetoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && ((DataGridView)sender).ReadOnly == false)
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 8)
                {
                    objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(9, ((DataGridView)sender).CurrentCell.RowIndex));
                }
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn()
            {
                Name = "colApellido",
                HeaderText = "Apellidos.",
                DataPropertyName = "apellido",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombres.",
                DataPropertyName = "nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewComboBoxExColumn colTipoPersona = new DataGridViewComboBoxExColumn()
            {
                Name = "colTipoPersona",
                HeaderText = "Tipo persona.",
                DataPropertyName = "fktipospersona",
                ValueMember = "Objeto",
                DisplayMember = "descripcion",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList

            };

            DataGridViewComboBoxExColumn colTipoDocumento = new DataGridViewComboBoxExColumn()
            {
                Name = "colTipoDocumento",
                HeaderText = "Documento.",
                DataPropertyName = "fktiposdocumento",
                ValueMember = "Objeto",
                DisplayMember = "descripcion",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList

            };

            DataGridViewTextBoxColumn colIdentificacion = new DataGridViewTextBoxColumn()
            {
                Name = "colIdentificacion",
                HeaderText = "Identificación.",
                DataPropertyName = "identificacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdentificacion.MaxInputLength = 13;

            DataGridViewComboBoxExColumn colGenero = new DataGridViewComboBoxExColumn()
            {
                Name = "colGenero",
                HeaderText = "Genero.",
                DataPropertyName = "fkgenero",
                ValueMember = "Objeto",
                DisplayMember = "descripcion",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn()
            {
                Name = "colCorreo",
                HeaderText = "Correo",
                DataPropertyName = "correo",
                Width = 200
            };

            DataGridViewTextBoxColumn colEstadoPersona = new DataGridViewTextBoxColumn()
            {
                Name = "colEstadoPersona",
                HeaderText = "Estado",
                DataPropertyName = "fkestadospersona",
                Width = 100,
            };

            DataGridViewTextBoxColumn colParroquiaDocumento = new DataGridViewTextBoxColumn()
            {
                Name = "colParroquiaDocumento",
                HeaderText = "Parroquia",
                DataPropertyName = "fkparroquia",
                Width = 300
            };

            DataGridViewButtonXColumn colParroquiaBoton = new DataGridViewButtonXColumn()
            {
                Name = "colParroquiaBoton",
                HeaderText = "<-",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colParroquiaDocumento",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };
            colParroquiaBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            DataGridViewTextBoxColumn colReferenciaDireccion = new DataGridViewTextBoxColumn()
            {
                Name = "colReferenciaDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "referenciadireccion",
                Width = 300
            };

            DataGridViewTextBoxColumn colFechaServidor = new DataGridViewTextBoxColumn()
            {
                Name = "colFechaServidor",
                HeaderText = "Creado",
                DataPropertyName = "fechaservidor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colFechaServidor.ReadOnly = true;

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colId,
                colApellido,
                colNombre,
                colTipoPersona,
                colTipoDocumento,
                colIdentificacion,
                colGenero,
                colCorreo,
                colParroquiaDocumento,
                colParroquiaBoton,
                colReferenciaDireccion,
                colEstadoPersona,
                colFechaServidor,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
