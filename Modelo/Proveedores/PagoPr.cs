using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using LinqToDB;
using System.Linq.Dynamic;
using LinqToDB.Data;

namespace Proveedores
{
    public class PagoPr
    {
        #region VARIABLES
        private static PagoPr proveedor = null;
        public cliente objetoCliente;
        private List<formapago> lsFormaPago;
        #endregion VARIABLES

        #region PROPIEDADES
        public static PagoPr Instancia { get { if (proveedor == null) proveedor = new PagoPr(); return proveedor; } set { proveedor = value; } }

        public List<formapago> ListaFormaPago
        {
            get { if (this.lsFormaPago == null) this.lsFormaPago = FormaPagoPr.Instancia.Registros(); return lsFormaPago; }
            set { this.lsFormaPago = value; }
        }

        #endregion PROPIEDADES

        public PagoPr()
        { }


        public conveniopago RegistroPorId(int unIdentificadorpagos)
        {
            return this.Registros("identificadorpago == @0", unIdentificadorpagos).SingleOrDefault();
        }

        public List<conveniopago> Registros(string expresion = null, params object[] parametros)
        {
            List<conveniopago> registros = null;
            using (ispDB db = new ispDB())
            {
                this.ListaFormaPago = db.formaspagos.ToList();
                registros = (from op in db.ordenespedidos.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                             from id in db.identificadorespagos.Where(x => x.id == op.ididentificadorpago)
                             from cp in db.conveniospagos.Where(x => x.identificadorpagos == id.id)
                             join pg in db.pagos.DefaultIfEmpty() on new { cp.identificadorpagos, cp.idformapago } equals new { pg.identificadorpagos, pg.idformapago }
                             into gpg
                             select new conveniopago()
                             {
                                 identificadorpagos = cp.identificadorpagos,
                                 idformapago = cp.idformapago,
                                 fkformaspago = cp.fkformaspago,
                                 fkpagos = gpg.ToList()
                             }).ToList();
            }
            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }
            return registros;
        }

        private conveniopago CargarRelaciones(conveniopago unObjeto)
        {
            int ix;
            ix = ListaFormaPago.FindIndex(x => x.id == unObjeto.fkformaspago.id);
            if (ix > -1)
                unObjeto.fkformaspago = ListaFormaPago[ix];

            return unObjeto;
        }

        public identificadorpago Grabar(IEnumerable<conveniopago> items, ispDB pDB = null)
        {
            identificadorpago identificador;
            ispDB db = null;
            if (pDB == null)
                db = new ispDB();
            else
                db = pDB;

            try
            {
                if (pDB == null)
                    db.BeginTransaction();

                pagoregistrado pagoreg = null;

                foreach (conveniopago item in items)
                {
                    foreach (pago pago in item.fkpagos)
                    {
                        pagoreg = db.QueryProc<pagoregistrado>(pagoregistrado.funcion,
                        new DataParameter("pidentificadorpagos", pago.identificadorpagos, DataType.Int32),
                        new DataParameter("pidformapago", pago.idformapago, DataType.Int16),
                        new DataParameter("pnotificacion", pago.notificacion, DataType.Boolean),
                        new DataParameter("pfecha", Sql.DateTime, DataType.DateTime),
                        new DataParameter("pidusuariocobranza", pago.idusuariocobranzas, DataType.Int16),
                        new DataParameter("pvalor", pago.valor, DataType.Decimal),
                        new DataParameter("pdetalle", pago.detalle, DataType.VarChar),
                        new DataParameter("pidusuarioregistra", pago.idusuarioregistra, DataType.Int16),
                        new DataParameter("pidusuarioanula", pago.idusuarioanula, DataType.Int16),
                        new DataParameter("ttran", 1, DataType.Int16)
                        ).First();
                    }
                }

                if (pDB == null)
                    db.CommitTransaction();

                if (pagoreg == null)
                    throw new Exception("No se registro la forma de pago");

                List<conveniopago> convenios = db.
                    pagos.Where(x => x.identificadorpagos == pagoreg.identificadorpago).Select(x =>
                        x.Relacionar(x.fkconveniospago
                            .Relacionar(x.fkconveniospago.fkidentificadorespagos
                            ).Relacionar(x.fkconveniospago.fkformaspago)
                        ).Relacionar(x.fkusuario
                        )).ToList()
                        .GroupBy(x => x.fkconveniospago, (x, y) => new conveniopago()
                    {
                        fkformaspago = x.fkformaspago,
                        fkidentificadorespagos = x.fkidentificadorespagos,
                        fkpagos = y.ToList()
                    }).ToList();

                identificador = convenios.GroupBy(x => x.fkidentificadorespagos,
                    (x, y) => new identificadorpago()
                        {
                            id = x.id,
                            fkconveniospago = y.ToList()
                        }).Single();

            }
            catch (Exception)
            {
                if (pDB == null)
                    db.RollbackTransaction();
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return identificador;
        }

        public int Borrar(pago item)
        {
            //VERIFICAMOS PERIODO
            /*if (PeriodoPr.PeriodoCerrado(item.Periodo, item.Fecha.Month))
                throw new Exception("Periodo cerrado no puede continuar");*/

            item.anulado = true;
            return item.BorrarObjetoT();

        }

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
            {
                objetoGrid.Columns.AddRange(ColumnasGrid());
                /*if (!objetoGrid.ReadOnly)
                { }*/
            }
            //CARGA DE LISTAS
            objetoGrid.CancelEdit();
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<conveniopago>.ToBindingList(this.Registros());
            objetoGrid.Tag = "0";
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colIdentificadorpagos = new DataGridViewTextBoxColumn()
            {
                Name = "colIdentificadorpagos",
                HeaderText = "Identificadorpagos.",
                DataPropertyName = "Identificadorpagos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdentificadorpagos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colFormaPago = new DataGridViewTextBoxColumn()
            {
                Name = "colFormaPago",
                HeaderText = "FormaPago",
                DataPropertyName = "FormaPago",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn()
            {
                Name = "colNumero",
                HeaderText = "Numero",
                DataPropertyName = "Numero",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colNumero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colNotificacion = new DataGridViewTextBoxColumn()
            {
                Name = "colNotificacion",
                HeaderText = "Notificacion",
                DataPropertyName = "Notificacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn()
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colIdusuariocobranzas = new DataGridViewTextBoxColumn()
            {
                Name = "colIdusuariocobranzas",
                HeaderText = "Idusuariocobranzas.",
                DataPropertyName = "Idusuariocobranzas",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdusuariocobranzas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn()
            {
                Name = "colValor",
                HeaderText = "Valor",
                DataPropertyName = "Valor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colDetalle = new DataGridViewTextBoxColumn()
            {
                Name = "colDetalle",
                HeaderText = "Detalle",
                DataPropertyName = "Detalle",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colIdusuarioregistra = new DataGridViewTextBoxColumn()
            {
                Name = "colIdusuarioregistra",
                HeaderText = "Idusuarioregistra",
                DataPropertyName = "Idusuarioregistra",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdusuarioregistra.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colIdusuarioanula = new DataGridViewTextBoxColumn()
            {
                Name = "colIdusuarioanula",
                HeaderText = "Idusuarioanula",
                DataPropertyName = "Idusuarioanula",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colIdusuarioanula.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colAnulado = new DataGridViewTextBoxColumn()
            {
                Name = "colAnulado",
                HeaderText = "Anulado",
                DataPropertyName = "Anulado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colIdentificadorpagos,
                colFormaPago,
                colNumero,
                colNotificacion,
                colFecha,
                colIdusuariocobranzas,
                colValor,
                colDetalle,
                colIdusuarioregistra,
                colIdusuarioanula,
                colAnulado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID

    }
}
