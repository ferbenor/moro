using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloDB;
using Proveedores;
using System.Windows.Forms;
using DevComponents.Editors.DateTimeAdv;

namespace Controladores
{
    public class ClienteCr
    {
        #region COLECCION DE CONTROLES, PROVEEDORES E INSTANCIA
        private ClientePr proveedor = new ClientePr();

        public object Proveedor { get { return proveedor; } }

        private ColeccionControl controles = new ColeccionControl();

        public ColeccionControl Controles
        {
            get { return controles; } set { controles = value; }
        }

        private static ClienteCr instancia;
        public static ClienteCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new ClienteCr();
                return instancia;
            }
        }
        #endregion COLECCION DE CONTROLES, PROVEEDORES E INSTANCIA

        public void LimpiarControles()
        {
            this.Controles.Clear();
        }

        public void RegistrarControles(Control unControl)
        {
            this.Controles.Add(unControl);
        }

        #region DISPARADORES DE EVENTOS (RAISES)
        //public object RaiseEstructuraGridDetalle(DataGridView objetoGrid)
        //{
        //    proveedor.ArmarGridDetalle(objetoGrid);
        //    return this.proveedor;
        //}

        public void RaiseCargaVista(object unObjetoLocal)
        {
            if (unObjetoLocal != null)
            {
                cliente registro = (cliente)unObjetoLocal;
                //TipoContablePr tipoContablePr = new TipoContablePr();

                try
                {
                    List<object> listaValores = new List<object>();
                    ViewLoadEventArgs argumentos = new ViewLoadEventArgs();

                    //ASIGNACION DE VALORES A CONTROLES
                    //SE ASIGNA LA CARGA DE TODOS LOS CONTROLES QUE PRESETAN LOS DATOS DEL OBJETO ENTIDAD
                    //DATOS PERSONA
                    ((DateTimeInput)this.controles["_dtpFechaIngreso"]).Value = registro.fechaingreso;
                    this.controles["_txtId"].Text = registro.id.ToString();
                    this.controles["_txtApellido"].Text = registro.apellido;
                    this.controles["_txtNombre"].Text = registro.nombre;
                    ((ComboBox)this.controles["_cboTipoPersona"]).DataSource = this.proveedor.ListaTipoPersona;
                    ((ComboBox)this.controles["_cboTipoPersona"]).SelectedValue = registro.tipopersona;
                    ((ComboBox)this.controles["_cboTipoDocumento"]).DataSource = this.proveedor.ListaTipoDocumento;
                    ((ComboBox)this.controles["_cboTipoDocumento"]).SelectedValue = registro.tipodocumento;
                    this.controles["_txtIdentificacionSN"].Text = registro.identificacion;
                    ((ComboBox)this.controles["_cboGenero"]).DataSource = this.proveedor.ListaGenero;
                    ((ComboBox)this.controles["_cboGenero"]).SelectedValue = registro.genero;
                    //DATOS CLIENTE
                    this.controles["_txtRazonSocial"].Text = registro.razonsocial;
                    this.controles["_txtTelefonoSN"].Text = registro.telefono;
                    ((PictureBox)this.controles["_picFoto"]).Image = registro.foto;
                    this.controles["_txtBarrio"].Text = registro.barrio.ToString();
                    this.controles["_txtDireccion"].Text = registro.referenciadireccion;
                    this.controles["_txtCelularSN"].Text = registro.celular;
                    //this.controles["_txtCorreo"].Text = registro.Correo;
                    ((ComboBox)this.controles["_cboEstadoCivil"]).DataSource = this.proveedor.ListaEstadoCivil;
                    ((ComboBox)this.controles["_cboEstadoCivil"]).SelectedValue = registro.fkestadoscivile;
                    this.controles["_txtConyugue"].Text = registro.fkconyuge.ToString();
                    this.controles["_txtProfesion"].Text = registro.fkprofesione.nombre;
                    this.controles["_txtInfAdicional"].Text = registro.informacionadicional;
                    this.controles["_lblEstado"].Text = registro.estadopersona.descripcion;
                    this.controles["_lblEstado"].ForeColor = registro.estadopersona.id == 2 ? System.Drawing.Color.Red : System.Drawing.Color.Blue;
                    //PASO DE VALORES AL FORMULARIO PARA ASIGNACION DE VARIABLES LOCALES
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
            }
        }

        public object ConstruirObjeto(object unObjetoLocal, bool limpiar = false)
        {
            cliente registro = null;
            if (unObjetoLocal != null)
            {
                registro = (cliente)unObjetoLocal;
                if (!limpiar)
                {
                    //SE ESTABLECEN LOS VALORES PROVENIENTES DE (TEXTOX, COMBOBOX, DATETPICKER, CHECKBOX, ETC)
                    //QUE NO PUEDAN OBTENER VALORES DE MANERA AUTOMATIZADA COMO GRID, BOTONES DE BUSQUEDA, ETC
                    //DATOS PERSONA
                    registro.razonsocial = this.controles["_txtRazonSocial"].Text;
                    registro.fechaingreso = ((DateTimeInput)this.controles["_dtpFechaIngreso"]).Value; 
                    registro.apellido = this.controles["_txtApellido"].Text;
                    registro.nombre = this.controles["_txtNombre"].Text;
                    registro.tipopersona = (tipopersona)((ComboBox)this.controles["_cboTipoPersona"]).SelectedValue;
                    registro.tipodocumento = (tipodocumento)((ComboBox)this.controles["_cboTipoDocumento"]).SelectedValue;
                    registro.identificacion = this.controles["_txtIdentificacionSN"].Text;
                    registro.genero = (genero)((ComboBox)this.controles["_cboGenero"]).SelectedValue;
                    //DATOS CLIENTE
                    registro.telefono = this.controles["_txtTelefonoSN"].Text;
                    registro.foto = ((PictureBox)this.controles["_picFoto"]).Image;
                    registro.referenciadireccion = this.controles["_txtDireccion"].Text;
                    registro.celular = this.controles["_txtCelularSN"].Text;
                    //registro.Correo = this.controles["_txtCorreo"].Text;
                    registro.fkestadoscivile = (estadocivil)((ComboBox)this.controles["_cboEstadoCivil"]).SelectedValue;
                    registro.informacionadicional = this.controles["_txtInfAdicional"].Text;
                }
                else
                {
                    registro = new cliente();
                }
            }
            else
            {
                registro = new cliente();
            }
            return registro;
        }

        public void ImprimirObjeto(object unCliente)
        {
            try
            {
                cliente objeto = (cliente)unCliente;
                Proveedores.Colecciones.ClienteCl coleccion = new Proveedores.Colecciones.ClienteCl();
                coleccion.Add(objeto);
                Reportes reporte = new Reportes() { Reporte = "ClientesRp", FuenteDatos = "ClienteCl", Lista = coleccion.ObtenerItems() };
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

        public void BuscarCliente(ref object unObjeto)
        {
            try
            {
                object nuevoObjeto = this.proveedor.RegistroPorIdentificacion(this.Controles["_txtIdentificacionSN"].Text);
                if (nuevoObjeto != null)
                {
                    unObjeto = nuevoObjeto;
                    this.RaiseCargaVista(unObjeto);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    General.Mensaje(ex.Message);
                else
                    General.Mensaje(ex.InnerException.Message);
            }
        }

        public void Buscar(object unObjeto, bool buscar = true)
        {
            cliente objeto = unObjeto as cliente;
            try
            {
                DialogResult respuesta = DialogResult.Yes;
                if (objeto == null)
                    objeto = new cliente();
                if (buscar == true)
                {
                    object valor = BuscarListaPr.BuscarCliente();
                    if (valor != null)
                    {
                        //Cliente clienteEncontrado = this.proveedor.RegistroPorId((int)valor);
                        //if (clienteEncontrado != null)
                        //{
                        //    objeto = clienteEncontrado;
                        //    respuesta = DialogResult.Yes;
                        //}
                        //else
                        //    respuesta = DialogResult.No;
                    }
                    else
                        respuesta = DialogResult.No;
                }
                //if (buscar == false)
                //    objeto = this.proveedor.RegistroPorId(objeto.Id);

                if (respuesta == DialogResult.Yes)
                    this.RaiseCargaVista(objeto);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    General.Mensaje(ex.Message);
                else
                    General.Mensaje(ex.InnerException.Message);
            }
            finally { }
        }

         public string BuscarObjeto(ref object unObjetoLocal, short unaOpcion)
        {
            cliente registro = (cliente)unObjetoLocal;
            string valorDevuelto = null;
            switch (unaOpcion)
            {
                case 1:
                    {
                        persona entidad = (persona)BuscarListaPr.BuscarPersona();
                        if (entidad != null)
                        {
                            registro.fkconyuge = entidad;
                            valorDevuelto = registro.fkconyuge.ToString();
                        }
                    }
                    break;
                case 3:
                    {
                        barrio entidad = (barrio)BuscarListaPr.BuscarBarrio();
                        if (entidad != null)
                        {
                            registro.fkbarrio = entidad;
                            valorDevuelto = entidad.ToString();
                        }
                    }
                    break;
                case 4:
                    {
                        profesion entidad = (profesion)BuscarListaPr.BuscarProfesion();
                        if (entidad != null)
                        {
                            registro.fkprofesione = entidad;
                            valorDevuelto = entidad.ToString();
                        }
                    }
                    break;
            }
            return valorDevuelto;
        }

        public string QuitarObjeto(ref object unObjetoLocal, short unaOpcion)
        {
            cliente registro = (cliente)unObjetoLocal;
            string valorDevuelto = null;
            switch (unaOpcion)
            {
                case 1:
                    registro.fkconyuge = null;
                    valorDevuelto = registro.fkconyuge.ToString();
                    break;
                case 3:
                    registro.fkbarrio = null;
                    valorDevuelto = registro.barrio.ToString();
                    break;
                case 4:
                    registro.fkprofesione = null;
                    valorDevuelto = registro.fkprofesione.ToString();
                    break;
            }
            return valorDevuelto;
        }
        #endregion METODOS GENERALES
    }
}
