using Controladores;
using DevComponents.DotNetBar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Collections.Specialized;

namespace WindowsApp
{
    public partial class Principal : Form, IViewPrincipal
    {
        decimal asignado = 0;
        Stopwatch watch = new Stopwatch();

        public Principal()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-EC", true);
            InitializeComponent();
            //SETEO DE TAGs CON OBJETOS RELACIONADOS
            this.tsbNuevo.Tag = this.mnuNuevo;
            this.tsbEditar.Tag = this.mnuEditar;
            this.tsbGuardar.Tag = this.mnuGuardar;
            this.tsbCancelar.Tag = this.mnuCancelar;
            this.tsbEliminar.Tag = this.mnuEliminar;
            this.tsbBuscar.Tag = this.mnuBuscar;
            this.tsbActualizar.Tag = this.mnuActualizar;
            this.tsbImprimir.Tag = this.mnuImprimir;
        }

        #region METODOS EVENTOS VENTANA
        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObtieneEstilos();
                VentanaPrincipalCr.Instancia.RegisterView(this);
                VentanaPrincipalCr.Instancia.EstablecerValores();
                this.CargaDeImagen();
                this.CargarMenuLateral();
                this.CargarMenuSuperior();
                MostrarProgreso("Listo", false, eProgressItemType.Marquee);
                timer1_Tick(null, null);

            }
            catch (Exception ex)
            {
                Entidades.General.Mensaje(ex.Message);
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.GuardaEstilos();
            VentanaPrincipalCr.Instancia.CierraSesion();
            VentanaPrincipalCr.Instancia.UnregisterView(this);
        }

        public void OnCargaDatos(object sender, CargaInicialEventArgs e)
        {
            this.Text = e.NombreProducto;
            this.txtXTitulo.Text = "<b><font size=\"+12\"><i> " + e.TituloUno + "</i><font color=\"#DF0101\">  " + e.TituloDos + "</font></font></b>";
            this.lblDerechos.Text = e.DerechoCopia + "\nVersión del producto " + e.Version;
            this.stbLabelFecha.Text = String.Format("{0:ddd, dd MMM yyyy}", e.FechaServidor);//#B02B2C
            this.stbLabelIp.Text = e.DireccionIp;
            this.stbLabelUsuario.Text = e.NombreUsuario;
        }
        #endregion METODOS EVENTOS VENTANA

        #region LLAMADAS OPCIONES
        private void tsbBoton_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;
            switch (((ToolStripButton)sender).Name)
            {
                case "tsbNuevo":
                    prNuevo();
                    break;
                case "tsbEditar":
                    prEditar();
                    break;
                case "tsbGuardar":
                    prGuardar();
                    break;
                case "tsbCancelar":
                    prCancelar();
                    break;
                case "tsbEliminar":
                    prEliminar();
                    break;
                case "tsbBuscar":
                    prBuscar();
                    break;
                case "tsbActualizar":
                    prActualizar();
                    break;
                case "tsbFiltrar":
                    prFiltrar();
                    break;
                case "tsbImprimir":
                    prImprimir();
                    break;
                case "tsbCerrar":
                    this.ActiveMdiChild.Close();
                    break;
            }
        }

        private void mnuMenu_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "mnuNuevo":
                    prNuevo();
                    break;
                case "mnuEditar":
                    prEditar();
                    break;
                case "mnuGuardar":
                    prGuardar();
                    break;
                case "mnuCancelar":
                    prCancelar();
                    break;
                case "mnuEliminar":
                    prEliminar();
                    break;
                case "mnuBuscar":
                    prBuscar();
                    break;
                case "mnuActualizar":
                    prActualizar();
                    break;
                case "mnuImprimir":
                    prImprimir();
                    break;
                case "mnuCerrar":
                    this.ActiveMdiChild.Close();
                    break;
            }
        }

        #endregion LLAMADAS OPCIONES

        #region PROCESOS OPCIONES
        private void prNuevo()
        {
            ((IAccesoMetodos)this.ActiveMdiChild).Nuevo();

        }

        private void prEditar()
        {
            ((IAccesoMetodos)this.ActiveMdiChild).Editar();

        }

        private void prGuardar()
        {
            MostrarProgreso("Grabando, por favor espere...", true, eProgressItemType.Marquee);
            ((IAccesoMetodos)this.ActiveMdiChild).Guardar();
            if (((IAccesoMetodos)this.ActiveMdiChild).Modulo == "MenuSistemaPr")
                this.CargarMenuLateral();

            MostrarProgreso("Listo", false, eProgressItemType.Marquee);
        }

        private void prCancelar()
        {
            MostrarProgreso("Cancelando, por favor espere...", true, eProgressItemType.Marquee);
            ((IAccesoMetodos)this.ActiveMdiChild).Cancelar();
            MostrarProgreso("Listo", false, eProgressItemType.Marquee);
        }

        private void prEliminar()
        {
            MostrarProgreso("Eliminando, por favor espere...", true, eProgressItemType.Marquee);
            ((IAccesoMetodos)this.ActiveMdiChild).Eliminar();
            MostrarProgreso("Listo", false, eProgressItemType.Marquee);
        }

        private void prBuscar()
        {
            MostrarProgreso("Esperando parametros de busqueda...", true, eProgressItemType.Marquee);
            ((IAccesoMetodos)this.ActiveMdiChild).Buscar();
            MostrarProgreso("Listo", false, eProgressItemType.Marquee);
        }

        private void prActualizar()
        {
            watch.Reset(); watch.Start();
            //DateTime tiempo1 = DateTime.Now;
            MostrarProgreso("Cargando lista, por favor espere...", true, eProgressItemType.Marquee);
            //this.tmrDoEvents_Tick(null, null);
            ((IAccesoMetodos)this.ActiveMdiChild).Actualizar();
            //DateTime tiempo2 = DateTime.Now;
            //TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            //watch.Stop();

            MostrarProgreso("Listo " + watch.Elapsed.ToString(), false, eProgressItemType.Standard);
        }

        private void prFiltrar()
        {
            watch.Reset(); watch.Start();
            //DateTime tiempo1 = DateTime.Now;
            MostrarProgreso("Filtrando lista, por favor espere...", true, eProgressItemType.Marquee);
            //this.tmrDoEvents_Tick(null, null);
            ((IAccesoMetodos)this.ActiveMdiChild).Filtrar(this.tstFiltrar.Text);
            //DateTime tiempo2 = DateTime.Now;
            //TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            //watch.Stop();

            MostrarProgreso("Listo " + watch.Elapsed.ToString(), false, eProgressItemType.Standard);
        }

        private void prImprimir()
        {
            MostrarProgreso("Imprimiendo...", true, eProgressItemType.Marquee);
            ((IAccesoMetodos)this.ActiveMdiChild).Imprimir();
            MostrarProgreso("Listo", false, eProgressItemType.Marquee);
        }

        #endregion PROCESOS OPCIONES

        #region APARIENCIA VENTANA
        private void CargaDeImagen()
        {
            this.tsbNuevo.Image = this.imgIconos.Images["Agregar.png"];
            this.mnuNuevo.Image = this.imgIconos.Images["Agregar.png"];
            this.tsbEditar.Image = this.imgIconos.Images["Editando.ico"];
            this.mnuEditar.Image = this.imgIconos.Images["Editando.ico"];
            this.tsbCancelar.Image = this.imgIconos.Images["Salir.png"];
            this.mnuCancelar.Image = this.imgIconos.Images["Salir.png"];
            this.tsbGuardar.Image = this.imgIconos.Images["Grabar.png"];
            this.mnuGuardar.Image = this.imgIconos.Images["Grabar.png"];
            this.tsbEliminar.Image = this.imgIconos.Images["Eliminar.ico"];
            this.mnuEliminar.Image = this.imgIconos.Images["Eliminar.ico"];
            this.tsbActualizar.Image = this.imgIconos.Images["Refrescar.ico"];
            this.mnuActualizar.Image = this.imgIconos.Images["Refrescar.ico"];
            this.tsbBuscar.Image = this.imgIconos.Images["Listar.ico"];
            this.mnuBuscar.Image = this.imgIconos.Images["Listar.ico"];
            this.tsbImprimir.Image = this.imgIconos.Images["Imprimir.png"];
            this.mnuImprimir.Image = this.imgIconos.Images["Imprimir.png"];
            this.tsbCerrar.Image = this.imgIconos.Images["Cerrar.png"];
            this.mnuCerrar.Image = this.imgIconos.Images["Cerrar.png"];
            this.tsbFiltrar.Image = this.imgIconos.Images["Filtro.ico"];
            this.tsbAyuda.Image = this.imgIconos.Images["Ayuda.png"];
            this.stbLabelTotales.Image = this.imgIconos.Images["Listas.ico"];
            this.stbLabelUsuario.Image = this.imgIconos.Images["Usuario.ico"];
            this.stbLabelIp.Image = this.imgIconos.Images["Ip.ico"];
            this.stbLabelFecha.Image = this.imgIconos.Images["Fecha.png"];
            this.stbLabelConsumo.Image = this.imgIconos.Images["Recolector.ico"];
            GestionMaestrasCr.Instancia.EstableceImagenes(this.imgIconos);
        }

        private void configuracion(string grupo, string clave, string valor)
        {
        }

        private void GuardaEstilos()
        {
            Properties.Settings.Default.BarraLogoVisible = this.espLogo.Expanded;
            Properties.Settings.Default.BarraMenuLateralVisible = this.espMenu.Expanded;
            Properties.Settings.Default.Save();
        }

        private void ObtieneEstilos()
        {
            this.espMenu.Expanded = Properties.Settings.Default.BarraMenuLateralVisible;
            this.espLogo.Expanded = Properties.Settings.Default.BarraLogoVisible;
        }

        private void MostrarProgreso(string mensaje, bool mostrar, eProgressItemType estilo)
        {
            if (mostrar)
                this.Cursor = Cursors.WaitCursor;
            else
            {
                this.Cursor = Cursors.Default;
            }
            this.tmrDoEvents.Enabled = mostrar;
            this.stbProgreso.ProgressType = estilo;
            this.stbProgreso.Visible = mostrar;
            this.stbLabelText.Text = mensaje;
        }

        public void EscribeConteo(int total, bool visible = true)
        {
            this.stbLabelTotales.Visible = visible;
            this.stbLabelTotales.Text = "Registros cargados: " + (total - 1).ToString();
        }

        public void OpcionesVisibles()
        {
            for (int i = 0; i < this.tlsHerramientas.Items.Count; i++)
            {
                if (!this.tlsHerramientas.Items[i].Name.Contains("Filtrar"))
                    this.tlsHerramientas.Items[i].Visible = true;
            }
        }
        #endregion APARIENCIA VENTANADA

        #region METODOS EVENTOS CONTROLES

        private void mnuEstado_Click(object sender, EventArgs e)
        {
            stbEstado.Visible = mnuEstado.Checked;
        }

        private void mnuLateral_Click(object sender, EventArgs e)
        {
            espMenu.Expanded = mnuLateral.Checked;
        }

        private void mnuLogo_Click(object sender, EventArgs e)
        {
            espLogo.Expanded = mnuLogo.Checked;
        }

        private void tbsPestañas_VisibleChanged(object sender, EventArgs e)
        {
            this.mnuEdicion.Visible = ((TabStrip)sender).Visible;
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            prActualizar();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            prNuevo();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                ((IAccesoMetodos)this.ActiveMdiChild).Cancelar();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            prEliminar();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            prGuardar();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            prBuscar();
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            prImprimir();
        }

        private void mnuImprimir_Click(object sender, EventArgs e)
        {
            prImprimir();
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mnuCalculadora_Click(object sender, EventArgs e)
        {
            Process proceso = new Process();
            try
            {
                proceso.StartInfo.FileName = "calc.exe";
                proceso.StartInfo.Arguments = "";
                proceso.Start();
            }
            catch (Exception)
            { }
            finally
            {
                proceso.Dispose();
            }
        }

        private void mnuExplorador_Click(object sender, EventArgs e)
        {
            Process proceso = new Process();
            try
            {
                proceso.StartInfo.FileName = "explorer.exe";
                proceso.StartInfo.Arguments = "";
                proceso.Start();
            }
            catch (Exception)
            {

            }
            finally
            {
                proceso.Dispose();
            }
        }

        private void radialMenu_ItemClick(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "RadialMenuItem")
            {
                RadialMenuItem boton = (RadialMenuItem)sender;
                switch (boton.Name)
                {
                    case "rdmCerrarTodo":
                        closeAllToolStripMenuItem.PerformClick();
                        break;
                    case "rdmCalculadora":
                        mnuCalculadora.PerformClick();
                        break;
                    case "rdmCerrarSesion":
                        mnuCerrarSesion.PerformClick();
                        break;
                    case "rdmSalir":
                        mnuExit.PerformClick();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            asignado = decimal.Divide(decimal.Divide(decimal.Parse(GC.GetTotalMemory(true).ToString()), 1024), 1024);
            this.stbLabelConsumo.Text = String.Format("Memoria: {0:N2}Mb", asignado);
        }

        private void tmrDoEvents_Tick(object sender, EventArgs e)
        {
            stbProgreso.Value += 10;
            stbProgreso.Increment(stbProgreso.Value);
            if (stbProgreso.Value > 95)
                stbProgreso.Value = 0;
            stbProgreso.Refresh();
        }

        private void espLogo_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (pnlLogo.Size.Height > 61)
                this.pnlLogo.Size = new Size(this.pnlLogo.Size.Width, 61);
        }

        private void stbLabelConsumo_DoubleClick(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Teclas.Enter)
                this.tsbFiltrar.PerformClick();
        }

        private void tsbBoton_EnabledChanged(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)((ToolStripButton)sender).Tag).Enabled = ((ToolStripButton)sender).Enabled;
        }

        private void tsbBoton_VisibleChanged(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)((ToolStripButton)sender).Tag).Visible = ((ToolStripButton)sender).Visible;
        }

        private void mnuImprimir_VisibleChanged(object sender, EventArgs e)
        {
            this.separEditar3.Visible = ((ToolStripMenuItem)sender).Visible;
            this.tssSeparador3.Visible = ((ToolStripMenuItem)sender).Visible;
        }

        private void tsbBoton_TextChanged(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)((ToolStripButton)sender).Tag).Text = ((ToolStripButton)sender).Text;
        }

        private void tstFiltrar_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.tslFiltro.Visible = ((ToolStripTextBox)sender).Visible;
                this.tsbFiltrar.Visible = ((ToolStripTextBox)sender).Visible;
            }
            catch (Exception)
            {

                throw;
            }

        }

        # endregion METODOS EVENTOS CONTROLES

        #region FUNCIONES PARA MENUS
        private void VerificaSubMenus(ToolStripMenuItem unItem)
        {
            foreach (ToolStripMenuItem item in unItem.DropDownItems)
            {
                if (item.DropDownItems.Count > 0)
                    VerificaSubMenus(item);
                else
                {
                    ((ToolStripMenuItem)item.OwnerItem).DropDownItemClicked -= new ToolStripItemClickedEventHandler(Principal_DropDownItemClicked);
                    ((ToolStripMenuItem)item.OwnerItem).DropDownItemClicked += new ToolStripItemClickedEventHandler(Principal_DropDownItemClicked);
                }
            }
        }

        private void CargarMenuLateral()
        {
            this.sdbMenuLateral.Panels.Clear();
            this.sdbMenuLateral.Panels.AddRange(VentanaPrincipalCr.Instancia.GeneraMenuLateral());
            this.sdbMenuLateral.Refresh();
        }

        private void CargarMenuSuperior()
        {
            this.mnuMenuSistema.DropDownItems.Clear();
            this.mnuMenuSistema.DropDownItems.AddRange(VentanaPrincipalCr.Instancia.GeneraMenuSuperior());
            foreach (ToolStripMenuItem item in this.mnuMenuSistema.DropDownItems)
            {
                VerificaSubMenus(item);
            }
            this.mnuMenuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuMenuSepar1,
                this.mnuCerrarSesion,
                this.mnuExit});
        }

        public Form EjecutarMenu(object unIdMenu)
        {
            if (unIdMenu.ToString() == "")
                return null;
            Type unTipo = null;
            Bitmap unaImagen;
            string unFormulario;
            string unModulo;
            string unTitulo;
            bool esEditable;
            string unaBusqueda;
            string unPieDetalle;
            object columnasGrid;
            Form form = null;

            try
            {

                VentanaPrincipalCr.Instancia.ObtenerDatosMenu((short)unIdMenu, out unaImagen,
                    out unFormulario, out unModulo, out unTitulo, out esEditable, out unaBusqueda, out unPieDetalle, out columnasGrid);


                object unObjeto = null;
                if (unFormulario != "")
                {
                    TimeSpan total = new TimeSpan(0);
                    this.SuspendLayout();
                    form = Application.OpenForms[unFormulario + unModulo];
                    if (form == null)
                    {
                        MostrarProgreso("Iniciando '" + unTitulo + "', por favor espere... ", true, eProgressItemType.Marquee);
                        unTipo = Type.GetType("WindowsApp." + unFormulario);
                        if (unTipo == null)
                            MessageBox.Show("Formulario no definido o invalido para esta opción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            unObjeto = Activator.CreateInstance(unTipo);
                            form = (Form)unObjeto;
                            ((IAccesoMetodos)form).Modulo = unModulo;
                            ((IAccesoMetodos)form).EsEditable = esEditable;
                            ((IAccesoMetodos)form).UnaBusqueda = unaBusqueda;
                            ((IAccesoMetodos)form).PieDetalle = unPieDetalle;
                            ((IAccesoMetodos)form).ColumnasGrid = columnasGrid;
                            form.Name = unFormulario + unModulo;
                            form.Icon = System.Drawing.Icon.FromHandle(unaImagen.GetHicon());
                            form.Text = unTitulo;
                            form.MdiParent = this;
                            DateTime tiempo1 = DateTime.Now;
                            MostrarProgreso("Cargando lista, por favor espere...", true, eProgressItemType.Marquee);
                            this.tmrDoEvents_Tick(null, null);
                            form.Show();
                            form.WindowState = FormWindowState.Maximized;
                            DateTime tiempo2 = DateTime.Now;
                            total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
                        }
                        MostrarProgreso("Listo " + total.ToString(), false, eProgressItemType.Standard);
                    }
                    else
                        form.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.ResumeLayout(true);
                unModulo = null;
                unTitulo = null;
            }
            return form;
        }

        private void Principal_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null)
                EjecutarMenu(e.ClickedItem.Tag);
        }

        private void sdbMenuLateral_ItemClick(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "ButtonItem")
            {
                ButtonItem boton = (ButtonItem)sender;
                if (boton.Tag != null)
                    EjecutarMenu(boton.Tag);
            }
        }
        #endregion FUNCIONES PARA MENUS

    }
}
