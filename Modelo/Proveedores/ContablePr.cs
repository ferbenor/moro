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
    public class ContablePr : InstrumentalPr
    {
        #region VARIABLES
        private static ContablePr instancia = null;
        private List<tipocontable> listaTipoContable;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ContablePr Instancia { get { if (instancia == null) instancia = new ContablePr(); return instancia; } set { instancia = value; } }

        public List<tipocontable> ListaTipoContable
        {
            get { if (this.listaTipoContable == null) this.listaTipoContable = TipoContablePr.Instancia.Registros(); return listaTipoContable; }
            set { listaTipoContable = value; }
        }

        #endregion PROPIEDADES

        public ContablePr()
        { }

        public void BuscarBeneficiario(object unObjeto)
        {
            contable objeto = (contable)unObjeto;
            persona item = (persona)BuscarListaPr.BuscarObjeto(TipoConsulta.Personas);
            if (item != null)
            {
                objeto.fkpersona = item;
                objeto.idpersona = item.id;
            }
        }

        public object ObtenerDatos(string expresion = null, params object[] parametros)
        {
            return this.Registros(expresion, parametros).ToFBinding(); ;
        }

        public contable RegistroPorId(int unPeriodo, object unTipo, int unNumero)
        {
            return Registros("idperiodo == @0 && idtipocontable == @1 && numero == @2", unPeriodo, ((tipocontable)unTipo).id, unNumero).SingleOrDefault();
        }

        public List<contable> Registros(string expresion = null, params object[] parametros)
        {
            List<contable> registros;
            List<detallecontable> detalles;
            using (ispDB db = new ispDB())
            {
                detalles = db.detallescontables.Where(String.IsNullOrEmpty(expresion) ? "numerocontable > -1" : expresion, parametros).OrderBy(x => x.tipomovimiento).ThenBy(x => x.fkcuentascontable.codigo).Select(x =>
                    //CONYUGE, PERSONA, ESTADOSPERSONA
                    x.Relacionar(
                        x.fkcuentascontable
                    ).Relacionar(
                        x.fkcontable.Relacionar(
                            x.fkcontable.fkpersona).Relacionar(x.fkcontable.fkfraccionperiodo.Relacionar(x.fkcontable.fkfraccionperiodo.fkperiodo))
                    )).ToList();
            }
            //if (detalles.Count > 0)

            registros = detalles.GroupBy(x => new { x.fkcontable.idperiodo, x.fkcontable.idtipocontable, x.fkcontable.numero }).Select(x =>
                new contable(x.First().fkcontable)
                {
                    fktiposcontable = this.ListaTipoContable.Find(y => y.id == x.First().fkcontable.idtipocontable),
                    fkdetallescontables = x.ToList()

                }).OrderBy(x => x.fkfraccionperiodo.fkperiodo.anio).ThenBy(x => x.fktiposcontable.descripcion).ThenBy(x => x.fecha).ToList();

            return registros;
        }

        public int Grabar(object unItem)
        {
            contable item = (contable)unItem;
            int i = 0;
            fraccionperiodo periodo = PeriodoPr.Instancia.RegistroPorId((short)item.fecha.Year, (short)item.fecha.Month);
            if (periodo == null)
                throw new Exception("Periodo no registrado");
            if (!periodo.cerrado)

                using (ispDB db = new ispDB())
                {
                    try
                    {
                        item.fkfraccionperiodo = periodo;
                        item.IntegrarAsociados();

                        db.BeginTransaction();
                        if (item.numero == 0)
                        {
                            item.numero = db.contables.Where(x => x.idperiodo == item.idperiodo && x.idtipocontable == item.idtipocontable)
                                .GroupBy(x => Sql.GroupBy.None, (idx, g) => g.Max(y => y.numero)).Single();
                            item.numero++;
                        }

                        i = db.InsertOrReplace(item);

                        db.detallescontables.Where(x => x.idperiodo == item.idperiodo && x.idtipocontable == item.idtipocontable && x.numerocontable == item.numero).Delete();

                        for (int ix = 0; ix < item.fkdetallescontables.Count(); ix++)
                        {
                            detallecontable detalle = item.fkdetallescontables.ElementAt(ix);
                            detalle.idperiodo = item.idperiodo;
                            detalle.idtipocontable = item.idtipocontable;
                            detalle.numerocontable = item.numero;
                            detalle.registro = (short)ix;

                            db.InsertOrReplace(detalle);
                        }

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

        public int Borrar(object unItem)
        {
            contable item = (contable)unItem;
            int i = 0;
            //VERIFICAMOS PERIODO
            if (PeriodoPr.PeriodoCerrado((short)item.fecha.Year, (short)item.fecha.Month))
                throw new Exception("Periodo cerrado no se puede continuar");

            //CONTRA ASIENTO PARA ANULAR CONTABLE
            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    item.esanulado = true;
                    i = db.InsertOrReplace(item);
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
    }
}
