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
    public class OrdenPedidoPr
    {
        #region VARIABLES
        private static OrdenPedidoPr instancia = null;

        #endregion

        #region PROPIEDADES
        public static OrdenPedidoPr Instancia { get { if (instancia == null) instancia = new OrdenPedidoPr(); return instancia; } set { instancia = value; } }

        #endregion

        #region CONSTRUCTORES
        public OrdenPedidoPr()
        { }
        #endregion CONSTRUCTORES

        #region CARGAS DE REGISTROS
        public ordenpedido RegistroPorId(int unId)
        {
            return this.Registros("fkordenpedido.id == @0", unId).SingleOrDefault();
        }
        public List<ordenpedido> Registros(string expresion, params object[] parametros)
        {
            List<ordenpedido> registros = null;
            List<conveniopago> conveniosPagos = null;
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            using (ispDB db = new ispDB())
            {
                //INFORMACION GENERAL DE COMPROBANTES
                try
                {
                    registros =
                        (from op in db.ordenespedidos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                         join dt in db.detallesordenespedidos
                            .Join(db.productos.Join(
                                db.unidadesdemedidas, x => x.idunidaddemedida, y => y.id, (x, y) => new producto()
                                    {
                                        id = x.id,
                                        idunidaddemedida = x.idunidaddemedida,
                                        descripcion = x.descripcion,
                                        ultimocosto = x.ultimocosto,
                                        idmarca = x.idmarca,
                                        utilidadprecio1 = x.utilidadprecio1,
                                        precio1 = x.precio1,
                                        utilidadprecio2=x.utilidadprecio2,
                                        precio2 = x.precio2,
                                        utilidadprecio3=x.utilidadprecio3,
                                        precio3 = x.precio3,
                                        utilidadprecio4=x.utilidadprecio4,
                                        precio4 = x.precio4,
                                         fkmarca = x.fkmarca,
                                        fkunidadesdemedida = y
                                    }), x => x.idproducto, y => y.id, (x, y) => new detalleordenpedido()
                            {
                                idordenpedido = x.idordenpedido,
                                idproducto = x.idproducto,
                                Cantidad = x.Cantidad,
                                Precio = x.Precio,
                                fkproducto = y
                            }).DefaultIfEmpty()
                         on op.id equals dt.idordenpedido
                         into rg
                         select new ordenpedido()
                         {
                             id = op.id,
                             fecha = op.fecha,
                             ididentificadorpago = op.ididentificadorpago,
                             idbarrio = op.idbarrio,
                             idcliente = op.idcliente,
                             idestadoordenpedido = op.idestadoordenpedido,
                             idusuarioanula = op.idusuarioanula,
                             idusuarioregistra = op.idusuarioregistra,
                             cancelado = op.cancelado,
                             esanulado = op.esanulado,
                             fechaanulacion = op.fechaanulacion,
                             fechaservidor = op.fechaservidor,
                             fkbarrio = op.fkbarrio,
                             fkcliente = new cliente()
                             {
                                 idpersona = op.fkcliente.idpersona,
                                 fechaingreso = op.fkcliente.fechaingreso,
                                 telefono = op.fkcliente.telefono,
                                 celular = op.fkcliente.celular,
                                 informacionadicional = op.fkcliente.informacionadicional,
                                 razonsocial = op.fkcliente.razonsocial,
                                 certificadovotacion = op.fkcliente.certificadovotacion,
                                 fkpersona = op.fkcliente.fkpersona
                             },
                             fkusuario = op.fkusuario,
                             fkusuarios1 = op.fkusuarios1,
                             fkestadosordenespedido = op.fkestadosordenespedido,
                             fkidentificadorespago = op.fkidentificadorespago,
                             observacion = op.observacion,
                             saldo = op.saldo,
                             total = op.total,
                             fkdetallesordenespedido = rg.ToList()
                         }).ToList();


                    conveniosPagos =
                        (from op in db.ordenespedidos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                         from id in db.identificadorespagos.Where(x => x.id == op.ididentificadorpago)
                         from cp in db.conveniospagos.Where(x => x.identificadorpagos == id.id).DefaultIfEmpty()
                         from fp in db.formaspagos.Where(x => x.id == cp.idformapago)
                         join pg in db.pagos.DefaultIfEmpty()
                         on new { cp.identificadorpagos, cp.idformapago } equals new { pg.identificadorpagos, pg.idformapago }
                         into gpg
                         select cp.Relacionar(gpg.ToList()).Relacionar(fp)
                         ).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                //ASIGNACION DE CONVENIOS PAGO
                foreach (ordenpedido item in registros)
                {
                    item.fkidentificadorespago.fkconveniospago =
                        conveniosPagos.Where(x => x.identificadorpagos == item.ididentificadorpago).ToList();
                }
                watch.Stop();
                Console.Write("Tiempo: " + watch.Elapsed.ToString(@"hh\:mm\:ss\.fff"));
            }
            return registros;
        }
        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(ordenpedido item)
        {
            int i = 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    PagoPr.Instancia.Grabar(item.fkidentificadorespago.fkconveniospago);
                    if (item.id == 0)
                    {
                        item.id = db.ordenespedidos.Max(x => x.id);
                        item.id++;
                    }
                    i = db.InsertOrReplace(item);

                    db.detallesordenespedidos.Where(x => x.idordenpedido == item.id).Delete();

                    for (int ix = 0; ix < item.fkdetallesordenespedido.Count(); ix++)
                    {
                        detalleordenpedido detalle = item.fkdetallesordenespedido.ElementAt(ix);
                        if (detalle.idordenpedido == 0)
                            detalle.idordenpedido = item.id;
                    }
                    db.BulkCopy(item.fkdetallesordenespedido);
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

        public int Borrar(ordenpedido item)
        {
            item.esanulado = true;
            return item.BorrarObjetoT();
        }
        #endregion FUNCIONES DE GESTION

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
