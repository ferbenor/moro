using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloDB;
using Proveedores;
using System.Windows.Forms;
using DevComponents.Editors.DateTimeAdv;

namespace WindowsApp
{
    public class ContableCr
    {
        public ContablePr proveedor = new ContablePr();
        private ColeccionControl controles = new ColeccionControl();

        public ColeccionControl Controles
        {
            get { return controles; }
            set { controles = value; }
        }

        private static ContableCr instancia;
        public static ContableCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new ContableCr();
                return instancia;
            }
        }

        public void LimpiarControles()
        {
            this.Controles.Clear();
        }

        public void RegistrarControles(Control unControl)
        {
            this.Controles.Add(unControl);
        }

        #region DISPARADORES DE EVENTOS (RAISES)

        public void RaiseCargaVista(object unObjetoLocal)
        {
            if (unObjetoLocal != null)
            {
                contable registro = (contable)unObjetoLocal;
                //TipoContablePr tipoContablePr = new TipoContablePr();

                try
                {
                    List<object> listaValores = new List<object>();

                    ViewLoadEventArgs argumentos = new ViewLoadEventArgs();

                    //ASIGNACION DE VALORES A CONTROLES
                    this.controles["_lblAnulado"].Visible = registro.esanulado ? true : false;
                    this.controles["_txtNumero"].Text = registro.numero.ToString("0000000");
                    ((ComboBox)this.controles["_cboTipo"]).DataSource = proveedor.ListaTipoContable;
                    ((ComboBox)this.controles["_cboTipo"]).SelectedValue = registro.fktiposcontable;
                    ((DateTimeInput)this.controles["_dtpFecha"]).Value = registro.fecha;
                    this.controles["_txtBeneficiario"].Text = registro.fkpersona.ToString();
                    this.controles["_txtDetalle"].Text = registro.observacion;

                    //ASIGNACION DE DATOS AL DETALLE
                    ((DataGridView)this.controles["_dgrDetalle"]).DataSource = null;
                    ((DataGridView)this.controles["_dgrDetalle"]).DataSource = SoporteList<detallecontable>.ToBindingList(registro.fkdetallescontables.ToList());
                    //if (((DataGridView)this.controles[5]).DataSource == null)
                    //    ((DataGridView)this.controles[5]).DataSource = SoporteList<DetalleContable>.ToBindingList(registro.DetalleContable);
                    //else
                    //{
                    //    System.ComponentModel.BindingList<DetalleContable> listaDetalle = (System.ComponentModel.BindingList<DetalleContable>)((DataGridView)this.controles[5]).DataSource;
                    //    listaDetalle.Clear();
                    //    registro.DetalleContable.ForEach(delegate(DetalleContable x) { listaDetalle.Add(x); });
                    //}
                    //PASO DE VALORES AL FORMULARIO PARA ASIGNACION DE VARIABLES LOCALES
                    listaValores.Add(registro.eseditable);
                    listaValores.Add(registro);
                    argumentos.ListaObjetos = listaValores;
                    GestionMaestrasCr.Instancia.OnListaCargada(null, argumentos);

                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                        General.Mensaje(ex.Message.ToString());
                    else
                        General.Mensaje(ex.InnerException.Message.ToString());
                }
                finally
                {
                }
            }
        }

        public object ConstruirObjeto(object unObjetoLocal, bool limpiar = false)
        {
            contable registro = null;
            if (unObjetoLocal != null)
            {
                registro = (contable)unObjetoLocal;
                if (!limpiar)
                {
                    registro.fktiposcontable = (tipocontable)((ComboBox)this.controles["_cboTipo"]).SelectedValue;
                    registro.fecha = ((DateTimeInput)this.controles["_dtpFecha"]).Value;
                    registro.observacion = this.controles["_txtDetalle"].Text;
                }
                else
                {
                    registro = new contable() { fecha = General.usuarioActivo.fechasesion, eseditable = true };
                }
            }
            else
            {
                registro = new contable() { fecha = General.usuarioActivo.fechasesion, eseditable = true };
            }

            return registro;
        }

        public void ImprimirObjeto(object unContable)
        {
            try
            {
                contable objeto = (contable)unContable;
                Proveedores.Colecciones.DetalleContableCl coleccion = new Proveedores.Colecciones.DetalleContableCl();
                coleccion.AddRange(objeto.fkdetallescontables.ToList());
                Reportes reporte = new Reportes() { Reporte = "ContablesRp", FuenteDatos = "DetalleContableCl", Lista = coleccion.ObtenerItems() };
                reporte.ShowDialog();
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }

        }

        public void ImprimirLista(object unOrigenDatos)
        {
            try
            {
                string reporte = null;
                List<contable> listaObjetos = ((IEnumerable<contable>)unOrigenDatos).ToList();
                Proveedores.Colecciones.DetalleContableCl coleccion = new Proveedores.Colecciones.DetalleContableCl();
                coleccion.AddRangeLista(listaObjetos);
                Impresiones dialogo = new Impresiones();
                dialogo.ShowDialog();
                if (dialogo.DialogResult != DialogResult.Cancel)
                {
                    if (dialogo.DialogResult == DialogResult.Yes)
                        reporte = "ListaContablesRp";
                    else
                        reporte = "ContablesRp";

                    Reportes visorReporte = new Reportes() { Reporte = reporte, FuenteDatos = "DetalleContableCl", Lista = coleccion.ObtenerItems() };
                    visorReporte.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }

        }
        #endregion DISPARADORES DE EVENTOS (RAISES)

        #region METODOS GENERALES
        public string BuscarBeneficiario(ref object unObjetoLocal)
        {
            contable registro = (contable)unObjetoLocal;
            persona objeto = (persona)BuscarListaPr.BuscarBeneficiarios();
            if (objeto != null)
                registro.fkpersona = objeto;
            return registro.fkpersona.ToString();
        }

        public void SumarValores()
        {
            List<detallecontable> detalle = ((IEnumerable<detallecontable>)((DataGridView)this.controles["_dgrDetalle"]).DataSource).ToList();
            decimal debe = detalle.Sum(x => x.valordebe);
            decimal haber = detalle.Sum(x => x.valorhaber);
            decimal diferencia = debe - haber;

            this.controles["_txtValorDebe"].Text = debe.ToString("C5");
            this.controles["_txtValorHaber"].Text = haber.ToString("C5");
            this.controles["_txtDiferencia"].Text = diferencia.ToString("C5");
            this.controles["_txtDiferencia"].ForeColor = (debe < haber ? System.Drawing.Color.Red : System.Drawing.Color.Black);

            debe = 0; haber = 0; diferencia = 0; detalle = null;
        }

        public void Buscar(object unObjeto, bool buscar = true)
        {
            contable objeto = unObjeto as contable;
            try
            {
                DialogResult respuesta = DialogResult.Yes;
                if (objeto == null)
                    objeto = new contable();

                BusquedaContables f = new BusquedaContables();
                if (buscar == true)
                {
                    this.proveedor = new ContablePr();
                    this.proveedor.ListaTipoContable = null;
                    f.listaTipos = this.proveedor.ListaTipoContable;
                    f.objeto = objeto;
                    f.ShowDialog();

                    respuesta = f.DialogResult;

                    if (respuesta == DialogResult.Yes)
                        objeto = f.objeto;
                }
                if (buscar == false)
                {
                    objeto = this.proveedor.RegistroPorId(objeto.idperiodo, objeto.fktiposcontable, objeto.numero);
                }

                if (respuesta == DialogResult.Yes)
                    this.RaiseCargaVista(objeto);
                f = null;

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    General.Mensaje(ex.Message);
                else
                    General.Mensaje(ex.InnerException.Message);
            }
        }
        #endregion METODOS GENERALES
    }
}
