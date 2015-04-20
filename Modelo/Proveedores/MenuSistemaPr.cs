using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using LinqToDB;
using LinqToDB.Data;
using System.Linq.Dynamic;
using CollectionLoaders;
using LinqToDB.SchemaProvider;

namespace Proveedores
{
    public class MenuSistemaPr
    {
        #region VARIABLES
        private static MenuSistemaPr instancia = null;

        public List<menu> listaMenus;
        List<menu> listaPadres;
        List<tipocolumna> listaTiposColumnas;
        List<alineacion> listaAlineaciones;
        #endregion VARIABLES

        #region PROPIEDADES
        public static MenuSistemaPr Instancia { get { if (instancia == null) instancia = new MenuSistemaPr(); return instancia; } set { instancia = value; } }

        public List<menu> ListaPadres
        {
            //get { if (this.listaPadres == null) this.listaPadres = RegistrosAux(); return listaPadres; }
            get { if (this.listaPadres == null) this.listaPadres = this.listaMenus.Where(x => x.contenedor == true).ToList(); return listaPadres; }
            set { listaPadres = value; }
        }
        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public MenuSistemaPr()
        { }

        #endregion CONSTRUCTORES

        #region FUNCIONES SISTEMA

        public List<tipocolumna> TiposColumnas()
        {
            using (ispDB db = new ispDB())
            {
                this.listaTiposColumnas = db.tiposcolumnas.ToList();
                return listaTiposColumnas;
            }
        }

        public List<alineacion> Alineaciones()
        {
            using (ispDB db = new ispDB())
            {
                this.listaAlineaciones = db.alineaciones.ToList();
                return this.listaAlineaciones;
            }
        }

        public void CargarTablas(ComboBox unCombo)
        {
            LinqToDB.SchemaProvider.GetSchemaOptions GetSchemaOptions =
                new LinqToDB.SchemaProvider.GetSchemaOptions();

            LinqToDB.SchemaProvider.TableSchema ts = new LinqToDB.SchemaProvider.TableSchema();
            using (ispDB dbcn = new ispDB())
            {
                var sp = dbcn.DataProvider.GetSchemaProvider();
                LinqToDB.SchemaProvider.DatabaseSchema db = sp.GetSchema(dbcn, GetSchemaOptions);
                unCombo.ValueMember = "TableName";
                unCombo.DisplayMember = "TableName";
                unCombo.DataSource = null;
                unCombo.DataSource = db.Tables.OrderBy(x => x.TableName).ToList();
            }
        }

        #endregion

        #region REGISTROS
        private menu RegistroAux(short unId)
        {
            menu objeto;
            using (ispDB db = new ispDB())
            {
                objeto = db.menus.Where(x => x.id == unId).First();
            }
            return objeto;
        }

        private List<menu> RegistrosAux()
        {
            using (ispDB db = new ispDB())
            {
                listaPadres = db.menus.OrderBy(x => x.nombre).Where(x => x.contenedor == true).ToList();
                listaPadres.Add(new menu());
            }
            return listaPadres;
        }

        public List<menu> MenusPorUsuario(usuario unUsuario)
        {
            Alineaciones();
            TiposColumnas();
            menu objeto = new menu();
            List<menu> registros = new List<menu>();

            using (ispDB db = new ispDB())
            {
                if (unUsuario.administrador == true)
                    registros =
                        db.menus.GroupJoin(
                        db.menus, x => x.id, y => y.idpadre, (x, y) => new menu()
                    {
                        id = x.id,
                        idpadre = x.idpadre,
                        nombre = x.nombre,
                        titulo = x.titulo,
                        visible = x.visible,
                        busqueda = x.busqueda,
                        contenedor = x.contenedor,
                        editable = true,
                        formulario = x.formulario,
                        icono = x.icono,
                        modulo = x.modulo,
                        piedetalle = x.piedetalle,
                        tabla = x.tabla,
                        Vinculado = (y.Count() == 0 ? false : true)
                    }).GroupJoin(db.columnasgrids.OrderBy(x => x.identificador).ThenBy(x => x.orden), x => x.id, y => y.idmenu, (x, y) => new menu()
                    {
                        id = x.id,
                        idpadre = x.idpadre,
                        nombre = x.nombre,
                        titulo = x.titulo,
                        visible = x.visible,
                        busqueda = x.busqueda,
                        contenedor = x.contenedor,
                        editable = x.editable,
                        formulario = x.formulario,
                        icono = x.icono,
                        modulo = x.modulo,
                        piedetalle = x.piedetalle,
                        tabla = x.tabla,
                        Vinculado = x.Vinculado,
                        fkcolumnasgrid = y.ToList()
                    }).ToList();
                else
                {
                    registros = db.Query(new menu(),
                        objeto.CadenaSelectAsignados(),
                        new[] { new DataParameter("codigo", unUsuario.id) }
                        ).Select(x => new menu()
                        {
                            id = x.id,
                            idpadre = x.idpadre,
                            nombre = x.nombre,
                            titulo = x.titulo,
                            visible = x.visible,
                            busqueda = x.busqueda,
                            contenedor = x.contenedor,
                            editable = x.editable,
                            formulario = x.formulario,
                            icono = x.icono,
                            modulo = x.modulo,
                            piedetalle = x.piedetalle,
                            tabla = x.tabla
                        }).GroupJoin(db.columnasgrids.OrderBy(x => x.identificador).ThenBy(x => x.orden), x => x.id, y => y.idmenu, (x, y) => new menu()
                        {
                            id = x.id,
                            idpadre = x.idpadre,
                            nombre = x.nombre,
                            titulo = x.titulo,
                            visible = x.visible,
                            busqueda = x.busqueda,
                            contenedor = x.contenedor,
                            editable = x.editable,
                            formulario = x.formulario,
                            icono = x.icono,
                            modulo = x.modulo,
                            piedetalle = x.piedetalle,
                            tabla = x.tabla,
                            Vinculado = x.Vinculado,
                            fkcolumnasgrid = y.ToList()
                        }).ToList();
                }


            }

            this.ListaPadres = registros.OrderBy(x => x.nombre).Where(x => x.contenedor == true).ToList();

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }
            objeto = null;
            return registros.OrderBy(x => x.nombre).ToList();
        }

        public List<menu> RegistrosActivos()
        {
            return Registros("activo == @0", true);
        }

        public menu Registro(short unId)
        {
            return Registros("id == @0", unId).SingleOrDefault();
        }

        public List<menu> Registros(string expresion = null, params object[] parametros)
        {
            Alineaciones();
            TiposColumnas();
            List<menu> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.menus.OrderBy(x => x.nombre).Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros)
                .GroupJoin(db.columnasgrids.OrderBy(x => x.identificador).ThenBy(x => x.orden), x => x.id, y => y.idmenu, (x, y) => new menu()
                    {
                        id = x.id,
                        idpadre = x.idpadre,
                        nombre = x.nombre,
                        titulo = x.titulo,
                        visible = x.visible,
                        busqueda = x.busqueda,
                        contenedor = x.contenedor,
                        editable = x.editable,
                        formulario = x.formulario,
                        icono = x.icono,
                        modulo = x.modulo,
                        piedetalle = x.piedetalle,
                        tabla = x.tabla,
                        Vinculado = x.Vinculado,
                        fkcolumnasgrid = y.ToList()
                    }).ToList();
            }

            this.ListaPadres = registros.Where(x => x.contenedor == true).ToList();

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i] = CargarRelaciones(registros[i]);
            }

            return registros;
        }

        private menu CargarRelaciones(menu unObjeto)
        {
            int ix;
            ix = this.ListaPadres.FindIndex(x => x.id == unObjeto.idpadre);
            if (ix > -1)
                unObjeto.Padre = this.ListaPadres[ix];

            columnasgrid item;
            for (int i = 0; i < unObjeto.fkcolumnasgrid.Count(); i++)
            {
                item = unObjeto.fkcolumnasgrid.ElementAt(i);

                ix = this.listaAlineaciones.FindIndex(x => x.id == item.idalineacion);
                if (ix > -1)
                    item.fkalineacion = this.listaAlineaciones[ix];

                ix = this.listaTiposColumnas.FindIndex(x => x.id == item.idtipocolumna);
                if (ix > -1)
                    item.fktiposcolumna = this.listaTiposColumnas[ix];
            }


            return unObjeto;
        }
        #endregion REGISTROS

        #region FUNCIONES DE GESTION
        public int Grabar(menu item)
        {
            return item.GrabarObjetoT(x => x.id);
        }

        public int Grabar(IEnumerable<menu> items)
        {
            int i = 0; short id = 0;
            using (ispDB db = new ispDB())
            {
                try
                {
                    id = db.menus.Max(x => (short?)x.id) ?? (short)0;
                    foreach (menu item in items.Where(x => x.Modificado))
                    {
                        //GRABAMOS MENU
                        if (item.id == 0)
                            item.id = ++id;
                        i = db.InsertOrReplace(item);
                        //GRABAMOS DETALLES
                        db.columnasgrids.Where(x => x.idmenu == item.id).Delete();
                        foreach (columnasgrid item1 in item.fkcolumnasgrid)
                        {
                            if (item1.idmenu == 0)
                                item1.idmenu = item.id;
                            i = db.InsertOrReplace(item1);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (i == 0)
                throw new Exception("Error de concurrencia, por favor vuelva a realizar la transaccion.");
            return i;
        }

        public int Borrar(menu item)
        {
            if (item.Vinculado)
            {
                General.Mensaje("No se puede puede eliminar registro actual, \ndebido a que otros registros dependen de el.");
                return 0;
            }
            else
            {
                return item.BorrarObjetoT();
            }
        }
        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
                objetoGrid.Columns.AddRange(ColumnasGrid());

            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            //objetoGrid.DataSource = SoporteList<menu>.ToBindingList(this.Registros());
            ((DataGridViewComboBoxExColumn)objetoGrid.Columns["colPadre"]).DataSource = this.ListaPadres;
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "id",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewComboBoxExColumn colPadre = new DataGridViewComboBoxExColumn()
            {
                Name = "colPadre",
                HeaderText = "Padre",
                DataPropertyName = "Padre",
                ValueMember = "Objeto",
                DisplayMember = "NombreCompleto",
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Menú",
                DataPropertyName = "nombre",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colTitulo = new DataGridViewTextBoxColumn()
            {
                Name = "colTitulo",
                HeaderText = "Titulo",
                DataPropertyName = "titulo",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colVisible = new DataGridViewCheckBoxColumn()
            {
                Name = "colVisible",
                HeaderText = "Visible",
                DataPropertyName = "visible",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colContenedor = new DataGridViewCheckBoxColumn()
            {
                Name = "colContenedor",
                HeaderText = "Contenedor",
                DataPropertyName = "contenedor",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colFormulario = new DataGridViewTextBoxColumn()
            {
                Name = "colFormulario",
                HeaderText = "Formulario",
                DataPropertyName = "formulario",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colModulo = new DataGridViewTextBoxColumn()
            {
                Name = "colModulo",
                HeaderText = "Modulo",
                DataPropertyName = "modulo",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colBusqueda = new DataGridViewTextBoxColumn()
            {
                Name = "colBusqueda",
                HeaderText = "Busqueda",
                DataPropertyName = "busqueda",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewTextBoxColumn colPieDetalle = new DataGridViewTextBoxColumn()
            {
                Name = "colPieDetalle",
                HeaderText = "PieDetalle",
                DataPropertyName = "piedetalle",
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewComboBoxExColumn colIcono = new DataGridViewComboBoxExColumn()
            {
                Name = "colIcono",
                HeaderText = "Icono",
                DataPropertyName = "icono",
                ValueMember = "ImageIndex",
                DisplayMember = "Etiqueta",
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,
            };
            colIcono.DataSource = General.ListaImagenes();

            DataGridViewImageColumn colImagen = new DataGridViewImageColumn()
            {
                Name = "colImagen",
                HeaderText = "Imagen",
                DataPropertyName = "Imagen",
                SortMode = DataGridViewColumnSortMode.Automatic,
                Width = 50
            };

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                SortMode = DataGridViewColumnSortMode.Automatic,
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colId,
                colNombre,
                colTitulo,
                colPadre,
                colVisible,
                colContenedor,
                colFormulario,
                colModulo,
                colBusqueda,
                colPieDetalle,
                colIcono,
                colImagen,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID

        #region CREAR MENU SUPERIOR #2
        public ToolStripItem[] CargarMenuSuperior()
        {
            List<ToolStripMenuItem> paneles = new List<ToolStripMenuItem>();

            //listaMenus = MenusPorUsuario(General.usuarioActivo.fkusuario);
            //List<menu> listaPadres = listaMenus.Where(x => x.Padre.id == 0).ToList();
            foreach (menu item in listaPadres)
            {
                ToolStripMenuItem unItem = CreaSubItemsSuperior(item);
                if (unItem != null)
                    paneles.Add(unItem);

            }

            return paneles.ToArray();

        }

        private ToolStripMenuItem CreaSubItemsSuperior(menu unMenu)
        {
            ToolStripMenuItem unItem = null;
            unItem = new ToolStripMenuItem()
            {
                Name = unMenu.idpadre.ToString() + unMenu.nombre.Replace(" ", "_"),
                Text = unMenu.nombre,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,

                ImageIndex = unMenu.icono,
                Visible = unMenu.visible
            };
            if (General.Imagenes != null)
                unItem.Image = General.Imagenes.Images[unMenu.icono];

            if (unMenu.contenedor)
            {
                List<menu> listaHijos = listaMenus.Where(x => x.idpadre == unMenu.id).ToList();
                if (listaHijos.Count == 0)
                    return null;
                foreach (menu item in listaHijos)
                {
                    ToolStripMenuItem unSubBoton = CreaSubItemsSuperior(item);
                    if (unSubBoton != null)
                        unItem.DropDownItems.Add(unSubBoton);
                }
            }
            else
                //unItem.Tag = unMenu.Formulario + "#" + unMenu.Modulo + "#" + unMenu.Titulo + "#" + unMenu.Editable + "#" + unMenu.Busqueda + "#" + unMenu.PieDetalle;
                unItem.Tag = unMenu.id;
            return unItem;
        }
        #endregion CREAR MENU SUPERIOR #2

        #region CREAR MENU LATERAL #1

        public BaseItem[] CargarMenuLateral()
        {
            List<BaseItem> paneles = new List<BaseItem>();

            listaMenus = MenusPorUsuario(General.usuarioActivo.fkusuario);
            //List<menu> listaPadres = listaMenus.Where(x => x.Padre.id == 0).ToList();
            foreach (menu item in listaPadres.Where(x => x.idpadre == 0).ToList())
            {
                paneles.Add(CrearPanel(item));
            }

            return paneles.ToArray();

        }

        private SideBarPanelItem CrearPanel(menu unMenu)
        {
            SideBarPanelItem unPanel = null;

            #region PROPIEDADES DEL PANEL
            unPanel = new SideBarPanelItem(unMenu.idpadre.ToString() + unMenu.nombre) { Text = unMenu.nombre, Visible = unMenu.visible };
            unPanel.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            unPanel.BackgroundStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            unPanel.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            unPanel.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            unPanel.BackgroundStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
            unPanel.FontBold = true;
            unPanel.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
            unPanel.HeaderHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            unPanel.HeaderHotStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
            unPanel.HeaderHotStyle.GradientAngle = 90;
            unPanel.HeaderSideHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
            unPanel.HeaderSideHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            unPanel.HeaderSideHotStyle.GradientAngle = 90;
            unPanel.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            unPanel.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            unPanel.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            unPanel.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            unPanel.HeaderSideStyle.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Top)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            unPanel.HeaderSideStyle.GradientAngle = 90;
            unPanel.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            unPanel.HeaderStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
            unPanel.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            unPanel.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            unPanel.HeaderStyle.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Top)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            unPanel.HeaderStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            unPanel.HeaderStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
            unPanel.HeaderStyle.GradientAngle = 90;
            unPanel.ImageIndex = unMenu.icono;
            #endregion PROPIEDADES DEL PANEL

            List<menu> listaHijos = this.listaMenus.Where(x => x.idpadre == unMenu.id).ToList();
            foreach (menu item in listaHijos)
            {
                ButtonItem unBoton = CreaSubItems(item);
                if (unBoton != null)
                    unPanel.SubItems.Add(unBoton);
            }
            return unPanel;
        }

        private ButtonItem CreaSubItems(menu unMenu)
        {
            ButtonItem unBoton = null;
            unBoton = new ButtonItem(unMenu.idpadre.ToString() + unMenu.nombre.Replace(" ", "_"))
            {
                Text = unMenu.nombre,
                ButtonStyle = eButtonStyle.ImageAndText,
                ImagePosition = eImagePosition.Left,
                ImagePaddingHorizontal = 40,
                ImagePaddingVertical = 15,
                ColorTable = eButtonColor.Blue,
                AutoExpandOnClick = true,
                ImageIndex = unMenu.icono,
                Visible = unMenu.visible
            };

            if (unMenu.contenedor)
            {
                List<menu> listaHijos = listaMenus.Where(x => x.idpadre == unMenu.id).ToList();
                if (listaHijos.Count == 0)
                    return null;
                foreach (menu item in listaHijos)
                {
                    ButtonItem unSubBoton = CreaSubItems(item);
                    if (unSubBoton != null)
                        unBoton.SubItems.Add(unSubBoton);
                }
            }
            else
                //unBoton.Tag = unMenu.Formulario + "#" + unMenu.Modulo + "#" + unMenu.Titulo + "#" + unMenu.Editable + "#" + unMenu.Busqueda + "#" + unMenu.PieDetalle;
                unBoton.Tag = unMenu.id;

            return unBoton;
        }
        #endregion CREAR MENU LATERAL #1

    }
}

