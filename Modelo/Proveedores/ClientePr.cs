using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;

using ModeloDB;
using LinqToDB;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace Proveedores
{
    public class ClientePr
    {
        #region VARIABLES
        private static ClientePr proveedor = null;
        public cliente objetoCliente;
        private List<tipopersona> lsTipoPersona;
        private List<tipodocumento> lsTipoDocumento;
        private List<genero> lsGenero;
        private List<estadocivil> lsEstadoCivil;
        private List<profesion> lsProfesion;
        public List<object> lsParametrosBuscar = new List<object>();
        #endregion VARIABLES

        #region PROPIEDADES
        public static ClientePr Instancia { get { if (proveedor == null) proveedor = new ClientePr(); return proveedor; } set { proveedor = value; } }

        public List<tipopersona> ListaTipoPersona
        {
            //get { if (this.lsTipoPersona == null) this.lsTipoPersona = TipoPersonaPr.Instancia.Registros("order by descripcion"); return lsTipoPersona; }
            get { if (this.lsTipoPersona == null) using (ModeloDB.ispDB db = new ModeloDB.ispDB()) { this.lsTipoPersona = db.tipospersonas.OrderBy(x => x.descripcion).ToList(); } return lsTipoPersona; }
            set { lsTipoPersona = value; }
        }
        public List<tipodocumento> ListaTipoDocumento
        {
            //get { if (this.lsTipoDocumento == null) this.lsTipoDocumento = TipoDocumentoPr.Instancia.Registros("Order by descripcion"); return lsTipoDocumento; }
            get { if (this.lsTipoDocumento == null) using (ModeloDB.ispDB db = new ModeloDB.ispDB()) { this.lsTipoDocumento = db.tiposdocumentos.OrderBy(x => x.descripcion).ToList(); } return lsTipoDocumento; }
            set { lsTipoDocumento = value; }
        }
        public List<genero> ListaGenero
        {
            //get { if (this.lsGenero == null) this.lsGenero = GeneroPr.Instancia.Registros(); return lsGenero; }
            get { if (this.lsGenero == null) using (ModeloDB.ispDB db = new ModeloDB.ispDB()) { this.lsGenero = db.generos.OrderBy(x => x.descripcion).ToList(); } return lsGenero; }
            set { lsGenero = value; }
        }
        public List<estadocivil> ListaEstadoCivil
        {
            //get { if (this.lsEstadoCivil == null) this.lsEstadoCivil = EstadoCivilPr.Instancia.Registros(); return lsEstadoCivil; }
            get { if (this.lsEstadoCivil == null) using (ModeloDB.ispDB db = new ModeloDB.ispDB()) { this.lsEstadoCivil = db.estadosciviles.OrderBy(x => x.nombre).ToList(); } return lsEstadoCivil; }
            set { lsEstadoCivil = value; }
        }
        public List<profesion> ListaProfesion
        {
            //get { if (this.lsProfesion == null) this.lsProfesion = ProfesionPr.Instancia.Registros(); return lsProfesion; }
            get { if (this.lsProfesion == null) using (ModeloDB.ispDB db = new ModeloDB.ispDB()) { this.lsProfesion = db.profesiones.OrderBy(x => x.nombre).ToList(); } return lsProfesion; }
            set { lsProfesion = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ClientePr()
        { }
        #endregion CONSTRUCTORES

        public void BuscarCliente(object unObjeto)
        {
            venta objeto = (venta)unObjeto;
            cliente item = (cliente)BuscarListaPr.BuscarObjeto(TipoConsulta.Clientes);
            if (item != null)
            {
                objeto.fkcliente = item;
                objeto.idcliente = item.id;
            }
        }

        #region CARGAS DE REGISTROS
        public cliente RegistroPorId(int unId)
        {
            return this.Registros("fkpersona.id == @0", unId).SingleOrDefault();
        }

        public cliente RegistroPorIdentificacion(string unaIdentificacion)
        {
            return this.Registros("fkpersona.identificacion == @0", unaIdentificacion).SingleOrDefault();
        }

        public List<cliente> Registros(string expresion, params object[] parametros)
        {
            List<cliente> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.clientes.Where(String.IsNullOrEmpty(expresion) ? "idpersona == -1" : expresion, parametros).Select(x =>
                    //CONYUGE, PERSONA, ESTADOSPERSONA
                    x.Relacionar(
                        x.fkconyuge,
                        x.fkpersona.Relacionar(
                            x.fkpersona.fkestadospersona)
                        //BARRIO, PARROQUIA, CANTON, PROVINCIA
                    ).Relacionar(x.fkbarrio.Relacionar(
                        x.fkbarrio.fkparroquia.Relacionar(
                            x.fkbarrio.fkparroquia.fkcantone.Relacionar(
                                x.fkbarrio.fkparroquia.fkcantone.fkprovincia)))
                    )).ToList();
            }

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }

            return registros;
        }

        private cliente CargarRelaciones(cliente unObjeto)
        {
            int ix;
            ix = ListaTipoPersona.FindIndex(x => x.id == unObjeto.fkpersona.idtipopersona);
            if (ix > -1)
                unObjeto.fkpersona.fktipospersona = ListaTipoPersona[ix];

            ix = ListaTipoDocumento.FindIndex(x => x.id == unObjeto.fkpersona.idtipodocumento);
            if (ix > -1)
                unObjeto.fkpersona.fktiposdocumento = ListaTipoDocumento[ix];

            ix = ListaGenero.FindIndex(x => x.id == unObjeto.fkpersona.idgenero);
            if (ix > -1)
                unObjeto.fkpersona.fkgenero = ListaGenero[ix];

            ix = ListaEstadoCivil.FindIndex(x => x.id == unObjeto.idestadocivil);
            if (ix > -1)
                unObjeto.fkestadoscivile = ListaEstadoCivil[ix];

            ix = ListaProfesion.FindIndex(x => x.id == unObjeto.idprofesion);
            if (ix > -1)
                unObjeto.fkprofesione = ListaProfesion[ix];

            return unObjeto;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION
        public void LimpiarListas()
        {
            this.lsTipoPersona = null;
            this.lsTipoDocumento = null;
            this.lsGenero = null;
            this.lsEstadoCivil = null;
            this.lsProfesion = null;
        }

        public int Grabar(cliente item)
        {
            int i = 0;
            PersonaPr.Instancia.Grabar(item.fkpersona);
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    if (item.idpersona == 0)
                        item.idpersona = item.fkpersona.id;
                    db.InsertOrReplace(item);
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
                return i;
            }
        }

        public int Borrar(cliente item)
        {
            int i = 0;
            item.fkpersona.idestadopersona = 2;
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    i = db.InsertOrReplace(item.fkpersona);
                    db.CommitTransaction();
                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }
            return i;
        }
        #endregion FUNCIONES DE GESTION

        //#region ARMAR GRID
        //public void ArmarGrid(DataGridView objetoGrid)
        //{
        //    if (objetoGrid.Columns.Count == 0)
        //        objetoGrid.Columns.AddRange(ColumnasGrid());

        //    //CARGA DE LISTAS
        //    objetoGrid.ReadOnly = true;
        //    objetoGrid.AllowUserToAddRows = false;
        //    objetoGrid.AllowUserToDeleteRows = false;
        //}

        //public DataGridViewColumn[] ColumnasGrid()
        //{
        //    DataGridViewTextBoxColumn colTipoContable = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colTipoContable",
        //        HeaderText = "Tipo",
        //        DataPropertyName = "TipoContable",
        //        Width = 100
        //    };

        //    DataGridViewTextBoxColumn colPeriodo = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colPeriodo",
        //        HeaderText = "Periodo",
        //        DataPropertyName = "Periodo",
        //        Width = 50
        //    };
        //    colPeriodo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        //    DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colNumero",
        //        HeaderText = "Numero",
        //        DataPropertyName = "Numero",
        //        Width = 60
        //    };
        //    colNumero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    colNumero.DefaultCellStyle.Format = "0000000";

        //    DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colFecha",
        //        HeaderText = "Fecha",
        //        DataPropertyName = "Fecha",
        //        Width = 100
        //    };
        //    colFecha.DefaultCellStyle.Format = "ddd, dd MMM yyyy";

        //    DataGridViewTextBoxColumn colFechaCreacionChr = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colFechaCreacionChr",
        //        HeaderText = "Registrado",
        //        DataPropertyName = "FechaCreacionChr",
        //        Width = 150
        //    };
        //    //colFechaRegistro.DefaultCellStyle.Format = "ddd, dd MMM yyyy HH:mm:ss";

        //    DataGridViewTextBoxColumn colFechaModificacionChr = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colFechaModificacionChr",
        //        HeaderText = "Modificado",
        //        DataPropertyName = "FechaModificacionChr",
        //        Width = 150
        //    };
        //    //colFechaModificacion.DefaultCellStyle.Format = "ddd, dd MMM yyyy HH:mm:ss";

        //    DataGridViewTextBoxColumn colBeneficiario = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colBeneficiario",
        //        HeaderText = "Beneficiario",
        //        DataPropertyName = "Beneficiario",
        //        Width = 250
        //    };

        //    DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colValor",
        //        HeaderText = "Valor",
        //        DataPropertyName = "Valor",
        //        Width = 100
        //    };
        //    colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        //    DataGridViewTextBoxColumn colUsuarioRegistra = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colUsuarioRegistra",
        //        HeaderText = "Registrado por",
        //        DataPropertyName = "UsuarioRegistra",
        //        Width = 200
        //    };

        //    DataGridViewTextBoxColumn colUsuarioModifica = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colUsuarioModifica",
        //        HeaderText = "Modificado por",
        //        DataPropertyName = "UsuarioModifica",
        //        Width = 200
        //    };


        //    DataGridViewCheckBoxColumn colEditable = new DataGridViewCheckBoxColumn()
        //    {
        //        Name = "colEditable",
        //        HeaderText = "Editable",
        //        DataPropertyName = "Editable",
        //        SortMode = DataGridViewColumnSortMode.Automatic,
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        //    };

        //    DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
        //    {
        //        colNumero,
        //        colPeriodo,
        //        colTipoContable,
        //        colFecha,
        //        colBeneficiario,
        //        colValor,
        //        colEditable,
        //        colUsuarioRegistra,
        //        colFechaCreacionChr,
        //        colUsuarioModifica,
        //        colFechaModificacionChr

        //    };
        //    return listaColumnas;
        //}
        //#endregion ARMAR GRID

        //#region ARMAR GRID DETALLE
        //public void ArmarGridDetalle(DataGridView objetoGrid)
        //{
        //    if (objetoGrid.Columns.Count == 0)
        //    {
        //        objetoGrid.Columns.AddRange(ColumnasGridDetalle());
        //        if (!objetoGrid.ReadOnly)
        //        {
        //            objetoGrid.CellValidating += new DataGridViewCellValidatingEventHandler(objetoGrid_CellValidating);
        //            objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
        //            objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
        //            objetoGrid.ForeColor = System.Drawing.Color.Black;
        //            objetoGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        //        }
        //    }
        //    objetoGrid.Columns["colCodigoBoton"].Visible = !objetoGrid.ReadOnly;
        //}

        //void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 1 && e.RowIndex > -1)
        //        {
        //            DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
        //            campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
        //            if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
        //                campo.DataGridView.EndEdit();
        //            if (!campo.DataGridView.IsCurrentCellDirty)
        //                campo.DataGridView.NotifyCurrentCellDirty(true);
        //            else
        //                campo.DataGridView.NotifyCurrentCellDirty(false);
        //            object objeto = BuscarListaPr.BuscarCuentaMovimiento();
        //            if (objeto != null)
        //            {
        //                campo.DataGridView.NotifyCurrentCellDirty(false);
        //                campo.DataGridView.BeginEdit(false);
        //                campo.DataGridView.CurrentRow.Cells["colCuenta"].Value = (CuentaContable)objeto;
        //                campo.DataGridView.EndEdit();
        //            }
        //            else
        //                campo.DataGridView.EndEdit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        General.Mensaje(ex.Message.ToString());
        //    }
        //}

        //void objetoGrid_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F4 && ((DataGridView)sender).ReadOnly == false)
        //        if (((DataGridView)sender).CurrentCell.ColumnIndex == 0 || ((DataGridView)sender).CurrentCell.ColumnIndex == 1)
        //        {
        //            objetoGrid_CellClick(sender, new DataGridViewCellEventArgs(1, ((DataGridView)sender).CurrentCell.RowIndex));
        //        }
        //}

        //void objetoGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    DataGridView grid = (DataGridView)sender;
        //    if (grid.CurrentRow.Cells[e.ColumnIndex].IsInEditMode)
        //    {
        //        if (grid.CurrentCell.ColumnIndex == 0)
        //        {
        //            CuentaContable objeto = null;
        //            objeto = new CuentaContablePr().RegistroPorCodigo(grid.EditingControl.Text, tipoSeleccionCuenta.Movimiento);
        //            if (objeto == null)
        //                grid.CurrentRow.Cells["colCuenta"].Value = null;
        //            else
        //                grid.CurrentRow.Cells["colCuenta"].Value = objeto;
        //            if (objeto == null)
        //            {
        //                General.Mensaje(General.itemNoEncontrado);
        //                e.Cancel = true;
        //            }
        //        }
        //    }
        //}

        //public DataGridViewColumn[] ColumnasGridDetalle()
        //{
        //    DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colCodigo",
        //        HeaderText = "Codigo",
        //        DataPropertyName = "CodigoCuenta",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        //        MaxInputLength = 20,
        //        Tag = "colValorDebe"
        //    };

        //    DataGridViewButtonXColumn colCodigoBoton = new DataGridViewButtonXColumn()
        //    {
        //        Name = "colCodigoBoton",
        //        HeaderText = "",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        //        Tag = "colCodigo",
        //        Image = General.Imagenes.Images["Listar.ico"],
        //        ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        //    };
        //    colCodigoBoton.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

        //    DataGridViewTextBoxColumn colCuenta = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colCuenta",
        //        HeaderText = "Contable",
        //        DataPropertyName = "CuentaContable",
        //        ReadOnly = true,
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        //    };

        //    DataGridViewTextBoxColumn colValorDebe = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colValorDebe",
        //        HeaderText = "Debe",
        //        DataPropertyName = "ValorDebe",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        //    };
        //    colValorDebe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    colValorDebe.DefaultCellStyle.Format = "C5";

        //    DataGridViewTextBoxColumn colValorHaber = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colValorHaber",
        //        HeaderText = "Haber",
        //        DataPropertyName = "ValorHaber",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        //    };
        //    colValorHaber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    colValorHaber.DefaultCellStyle.Format = "C5";

        //    DataGridViewTextBoxColumn colDetalle = new DataGridViewTextBoxColumn()
        //    {
        //        Name = "colDetalle",
        //        HeaderText = "Detalle",
        //        DataPropertyName = "DetalleCuenta",
        //        MaxInputLength = 255,
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        //    };

        //    DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
        //    {
        //        colCodigo,
        //        colCodigoBoton,
        //        colCuenta,
        //        colValorDebe,
        //        colValorHaber,
        //        colDetalle
        //    };
        //    return listaColumnas;
        //}
        //#endregion ARMAR GRID DETALLE
    }
}
