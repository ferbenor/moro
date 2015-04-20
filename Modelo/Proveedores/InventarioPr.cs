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
    public class InventarioPr
    {
        #region VARIABLES

        private static InventarioPr instancia = null;
        private enum Tipo { INGRESO, EGRESO, TRANSFERENCIA }

        #endregion

        #region PROPIEDADES

        public static InventarioPr Instancia { get { if (instancia == null) instancia = new InventarioPr(); return instancia; } set { instancia = value; } }

        #endregion

        #region CONSTRUCTORES

        public InventarioPr()
        { }
        public object ObtenerDatos(string expresion = null, params object[] parametros)
        {
            return this.Registros(expresion, parametros).ToFBinding(); ;
        }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS

        public inventario RegistroPorId(int unId)
        {
            return this.Registros("id == @0", unId).SingleOrDefault();
        }

        public List<inventario> Registros(string expresion, params object[] parametros)
        {
            List<inventario> registros = null;
            //List<conveniopago> conveniosPagos = null;
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            using (ispDB db = new ispDB())
            {
                //INFORMACION GENERAL DE COMPROBANTES
                try
                {
                    registros =
                        (from op in db.inventarios.Where(String.IsNullOrEmpty(expresion) ? "numero > -1" : expresion, parametros)//.Select(x => x.Relacionar(x.fkbodegas1.Relacionar(x.fkbodegas1.fksucursale.Relacionar(x.fkbodegas1.fksucursale.fkbarrio)), x.fkbodegas2.Relacionar(x.fkbodegas2.fksucursale.Relacionar(x.fkbodegas2.fksucursale.fkbarrio))))
                         from bd1 in db.bodegas.Where(x => x.id == op.idbodega1 && x.idsucursal == op.idsucursalbodega1).DefaultIfEmpty()
                         from bd2 in db.bodegas.Where(x => x.id == op.idbodega2 && x.idsucursal == op.idsucursalbodega2).DefaultIfEmpty()
                         join dt in db.detallesinventarios
                            .Join(db.productos
                            .Join(db.unidadesdemedidas, x => x.idunidaddemedida, y => y.id, (x, y) => new producto()
                                {
                                    id = x.id,
                                    codigo = x.codigo,
                                    idunidaddemedida = x.idunidaddemedida,
                                    descripcion = x.descripcion,
                                    utilidadprecio1 = x.utilidadprecio1,
                                    precio1 = x.precio1,
                                    utilidadprecio2 = x.utilidadprecio2,
                                    precio2 = x.precio2,
                                    utilidadprecio3 = x.utilidadprecio3,
                                    precio3 = x.precio3,
                                    utilidadprecio4 = x.utilidadprecio4,
                                    precio4 = x.precio4,
                                    ultimocosto = x.ultimocosto,
                                    fkunidadesdemedida = y
                                }), x => x.idproducto, y => y.id, (x, y) => new detallesinventario()
                                {
                                    idperiodo = x.idperiodo,
                                    tipo = x.tipo,
                                    numero = x.numero,
                                    Codigo = x.fkproducto.codigo,
                                    idproducto = x.idproducto,
                                    registro = x.registro,
                                    cantidad = x.cantidad,
                                    precio = x.precio,
                                    Total = x.cantidad * x.precio,
                                    fkproducto = y
                                }).DefaultIfEmpty()
                         on new { op.idperiodo, op.tipo, op.numero } equals new { dt.idperiodo, dt.tipo, dt.numero }
                         into rg
                         select op.Relacionar(rg.ToList()).Relacionar(bd1,bd2)/*new inventario()
                         {
                             idperiodo = op.idperiodo,
                             //fkperiodo = op.fkperiodo,
                             tipo = op.tipo,
                             numero = op.numero,
                             idbodega1 = op.idbodega1,
                             idsucursalbodega1 = op.idsucursalbodega1,
                             //fkbodegas1 = op.fkbodegas1,
                             idbodega2 = op.idbodega2,
                             idsucursalbodega2 = op.idsucursalbodega2,
                             //fkbodegas2 = op.fkbodegas2,
                             fecha = op.fecha,
                             fecharegistro = op.fecharegistro,
                             idauditoria = op.idauditoria,
                             observacion = op.observacion,
                             esanulado = op.esanulado,
                             fkdetallesinventarios = rg.ToList(),
                         }*/).ToList();

                    //        conveniosPagos =
                    //            (from op in db.ventas.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                    //             from id in db.identificadorespagos.Where(x => x.id == op.ididentificadorpago)
                    //             from cp in db.conveniospagos.Where(x => x.identificadorpagos == id.id).DefaultIfEmpty()
                    //             from fp in db.formaspagos.Where(x => x.id == cp.idformapago)
                    //             join pg in db.pagos.DefaultIfEmpty()
                    //             on new { cp.identificadorpagos, cp.idformapago } equals new { pg.identificadorpagos, pg.idformapago }
                    //             into gpg
                    //             select cp.Relacionar(gpg.ToList()).Relacionar(fp)
                    //             ).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                //ASIGNACION DE CONVENIOS PAGO
                //foreach (venta item in registros)
                //{
                //    item.fkidentificadorespago.fkconveniospago =
                //        conveniosPagos.Where(x => x.identificadorpagos == item.ididentificadorpago).ToList();
                //}
                //watch.Stop();
                //Console.Write("Tiempo: " + watch.Elapsed.ToString(@"hh\:mm\:ss\.fff"));
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(object unItem)
        {
            inventario item = (inventario)unItem;
            int i = 0;
            fraccionperiodo periodo = PeriodoPr.Instancia.RegistroPorId((short)item.fecha.Year, (short)item.fecha.Month);
            if (periodo == null)
                throw new Exception("Periodo no registrado");
            if (!periodo.cerrado)

                using (ispDB db = new ispDB())
                {
                    try
                    {
                        //item.fkfraccionperiodo = periodo;
                        //item.IntegrarAsociados();

                        //db.BeginTransaction();
                        //if (item.numero == 0)
                        //{
                        //    item.numero = db.inventarios.Where(x => x.idperiodo == item.idperiodo)
                        //        .GroupBy(x => Sql.GroupBy.None, (idx, g) => g.Max(y => y.numero)).Single();
                        //    item.numero++;
                        //}

                        //i = db.InsertOrReplace(item);

                        //db.detallesinventarios.Where(x => x.idperiodo == item.idperiodo && x.tipo == item.tipo && x.numero == item.numero).Delete();

                        //for (int ix = 0; ix < item.fkdetallesinventarios.Count(); ix++)
                        //{
                        //    detallesinventario detalle = item.fkdetallesinventarios.ElementAt(ix);
                        //    detalle.idperiodo = item.idperiodo;
                        //    detalle.tipo = item.tipo;
                        //    detalle.numero = item.numero;
                        //    detalle.registro = (short)ix;

                        //    db.InsertOrReplace(detalle);
                        //}
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


        public int Borrar(inventario item)
        {
            item.esanulado = true;
            return item.numero;
            //return item.GrabarObjetoT(x => x.numero);
        }
        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID

        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<contable>.ToBindingList(this.Registros());
            objetoGrid.ReadOnly = true;
            objetoGrid.AllowUserToAddRows = false;
            objetoGrid.AllowUserToDeleteRows = false;
        }

        #endregion ARMAR GRID

        #region ARMAR GRID DETALLE
        public void ArmarGridDetalle(DataGridView objetoGrid)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGridDetalle());
                objetoGrid.CellValidating += new DataGridViewCellValidatingEventHandler(objetoGrid_CellValidating);
                objetoGrid.KeyDown += new KeyEventHandler(objetoGrid_KeyDown);
                objetoGrid.CellClick += new DataGridViewCellEventHandler(objetoGrid_CellClick);
                objetoGrid.ForeColor = System.Drawing.Color.Black;
                objetoGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            }
            //objetoGrid.DataSource = SoporteList<ordenpedido>.ToBindingList(this.Registros());
            //objetoGrid.ReadOnly = true;
            //objetoGrid.AllowUserToAddRows = false;
            //objetoGrid.AllowUserToDeleteRows = false;
            objetoGrid.Columns["colCodigoProductoBoton"].Visible = !objetoGrid.ReadOnly;
        }

        void objetoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    DataGridViewTextBoxColumn campo = (DataGridViewTextBoxColumn)((DataGridView)sender).Columns[((DataGridView)sender).Columns[e.ColumnIndex].Tag.ToString()];
                    campo.DataGridView.CurrentCell = campo.DataGridView.CurrentRow.Cells[campo.Index];
                    if (campo.DataGridView.CurrentRow.Index == campo.DataGridView.NewRowIndex)
                        campo.DataGridView.EndEdit();
                    if (!campo.DataGridView.IsCurrentCellDirty)
                        campo.DataGridView.NotifyCurrentCellDirty(true);
                    else
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                    object objeto = BuscarListaPr.BuscarProducto();
                    if (objeto != null)
                    {
                        campo.DataGridView.NotifyCurrentCellDirty(false);
                        campo.DataGridView.BeginEdit(false);
                        campo.DataGridView.CurrentRow.Cells["colProducto"].Value = objeto;
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
                if (grid.CurrentCell.ColumnIndex == 0)
                {
                    producto objeto = null;
                    objeto = ProductoPr.Instancia.RegistroPorCodigo(grid.EditingControl.Text);
                    if (objeto == null)
                        grid.CurrentRow.Cells["colProducto"].Value = null;
                    else
                        grid.CurrentRow.Cells["colProducto"].Value = objeto;
                    if (objeto == null)
                    {
                        General.Mensaje(General.itemNoEncontrado);
                        e.Cancel = true;
                    }
                }
            }
            grid.InvalidateRow(grid.CurrentRow.Index);
        }

        public DataGridViewColumn[] ColumnasGridDetalle()
        {
            DataGridViewTextBoxColumn colCodigoProducto = new DataGridViewTextBoxColumn()
            {
                Name = "colCodigoProducto",
                HeaderText = "Id",
                DataPropertyName = "idproducto",
                MaxInputLength = 4,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                //MaxInputLength = 20,
                Tag = "colCantidad"
            };
            colCodigoProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewButtonXColumn colCodigoProductoBoton = new DataGridViewButtonXColumn()
            {
                Name = "colCodigoProductoBoton",
                HeaderText = "->",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Tag = "colCodigoProducto",
                Image = General.Imagenes.Images["Listar.ico"],
                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
            };

            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn()
            {
                Name = "colProducto",
                HeaderText = "Producto",
                DataPropertyName = "fkproducto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
                //Width = 200
            };

            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn()
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "cantidad",
                MaxInputLength = 4,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCantidad.DefaultCellStyle.Format = "N0";

            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn()
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                DataPropertyName = "precio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPrecio.DefaultCellStyle.Format = "N2";

            //DataGridViewCheckBoxColumn colGrabaIva = new DataGridViewCheckBoxColumn()
            //{
            //    Name = "colGrabaIva",
            //    HeaderText = "GrabaIva",
            //    DataPropertyName = "GrabaIva",
            //    ReadOnly = true,
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //};

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn()
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "total",
                //Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            };
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotal.DefaultCellStyle.Format = "N2";

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colCodigoProducto,
                colCodigoProductoBoton,
                colProducto,
                colCantidad,
                colPrecio,
                //colGrabaIva,
                colTotal
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID DETALLE
    }
}
