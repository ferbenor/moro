using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using LinqToDB;
using System.Data;
using LinqToDB.Data;
using LinqToDB.SchemaProvider;

namespace Proveedores
{
    public class BuscarListaPr : InstrumentalPr
    {
        #region CONSTRUCTORES

        public BuscarListaPr()
        { }

        #endregion CONSTRUCTORES

        #region FUNCIONES DE BUSQUEDA

        public static object Buscar(string modulo, string tabla, string valorWhere, string campos, string ordenar = null, bool inicializado = false)
        {
            object unObjeto = null;
            frmBuscarL frm = new frmBuscarL();
            frm.Tabla = tabla;
            frm.ValorWhere = valorWhere;
            frm.Campos = campos;
            frm.Ordenar = ordenar;
            frm.Inicializado = inicializado;
            frm.Text = "Buscar - " + modulo;
            frm.ShowDialog();
            if (frm.FilaSeleccionada == null)
                return null;
            frm.Cursor = Cursors.WaitCursor;
            switch (modulo)
            {
                case "Barrios":
                    {
                        //Proveedores.BarrioPr proveedor = new Proveedores.BarrioPr();
                        //unObjeto = proveedor.Registro((int)frm.FilaSeleccionada.Cells[0].Value);
                        //proveedor = null;
                        unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "Clientes":
                    {
                        //ClientePr proveedor = new ClientePr();
                        //unObjeto = proveedor.RegistroPorId((int)(frm.FilaSeleccionada.Cells[0].Value));
                        //proveedor = null;
                        unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "Personas":
                    {
                        unObjeto = PersonaPr.Instancia.Registro((int)(frm.FilaSeleccionada.Cells[0].Value));
                    }
                    break;
                case "Beneficiarios":
                    {
                        unObjeto = PersonaPr.Instancia.Registro((int)frm.FilaSeleccionada.Cells[0].Value);
                    }
                    break;
                case "CuentasGrupo":
                    {
                        unObjeto = CuentaContablePr.Instancia.RegistroPorId((int)frm.FilaSeleccionada.Cells[0].Value);
                    }
                    break;
                case "CuentasMovimiento":
                    {
                        unObjeto = CuentaContablePr.Instancia.RegistroPorId((int)frm.FilaSeleccionada.Cells[0].Value);
                    }
                    break;
                case "Parroquias":
                    {
                        //ParroquiaPr proveedor = new ParroquiaPr();
                        //unObjeto = proveedor.Registro((short)frm.FilaSeleccionada.Cells[0].Value);
                        //proveedor = null;
                        unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "Profesiones":
                    {
                        //ProfesionPr proveedor = new ProfesionPr();
                        //unObjeto = proveedor.Registro((short)frm.FilaSeleccionada.Cells[0].Value);
                        //proveedor = null;
                        unObjeto = (short)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "Contratos":
                    {
                        //ContratoPr proveedor = new ContratoPr();
                        //unObjeto = proveedor.RegistroPorNumero((int)frm.FilaSeleccionada.Cells[0].Value);
                        //proveedor = null;
                        unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "OrdenesServicio":
                    {
                        //ContratoPr proveedor = new ContratoPr();
                        //unObjeto = proveedor.RegistroPorNumero((int)frm.FilaSeleccionada.Cells[0].Value);
                        //proveedor = null;
                        unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;
                case "ItemsInventario":
                    {
                        unObjeto = ItemInventarioPr.Instancia.Registro((int)frm.FilaSeleccionada.Cells[0].Value);
                        //unObjeto = (int)frm.FilaSeleccionada.Cells[0].Value;
                    }
                    break;

                case "Productos":
                    {
                        //unObjeto = ProductoPr.Instancia.Registro((int)frm.FilaSeleccionada.Cells[0].Value);

                        unObjeto = ProductoPr.Instancia.RegistroPorCodigo(frm.FilaSeleccionada.Cells[0].Value.ToString());

                        //ProductoPr proveedor = new ProductoPr();
                        //unObjeto = /*proveedor.RegistroPorId(*/(int)frm.FilaSeleccionada.Cells[0].Value/*)*/;
                    }
                    break;

                case "Marcas":
                    {
                        //unObjeto = ProductoPr.Instancia.Registro((int)frm.FilaSeleccionada.Cells[0].Value);

                        unObjeto = MarcaPr.Instancia.RegistroPorId((int)frm.FilaSeleccionada.Cells[0].Value);

                        //ProductoPr proveedor = new ProductoPr();
                        //unObjeto = /*proveedor.RegistroPorId(*/(int)frm.FilaSeleccionada.Cells[0].Value/*)*/;
                    }
                    break;

                case "FormasPago":
                    {
                        unObjeto = FormaPagoPr.Instancia.RegistroPorId((string)frm.FilaSeleccionada.Cells[0].Value);
                    }
                    break;
                default:
                    break;
            }
            frm.Cursor = Cursors.Default;
            frm.Dispose();
            return unObjeto;
        }

        public static DataGridViewRow Buscar(string titulo, string cadenaSql, bool inicializado = false)
        {
            DataGridViewRow unObjeto = null;
            frmBuscarL frm = new frmBuscarL();
            frm.cadenaSql = cadenaSql;
            frm.Inicializado = inicializado;
            frm.Text = "Buscar - " + titulo;
            frm.ShowDialog();

            frm.Cursor = Cursors.WaitCursor;

            unObjeto = frm.FilaSeleccionada;

            frm.Cursor = Cursors.Default;
            frm.Dispose();
            return unObjeto;
        }

        public static object BuscarObjeto(TipoConsulta funcionBuscar, bool inicializado = false, bool criterioVisible = true, params object[] parametros)
        {
            object unObjeto = null;
            if (funcionBuscar != TipoConsulta._NoSet)
            {
                frmBuscarL frm = new frmBuscarL();
                frm.FuncionBuscar = funcionBuscar.ToString();
                frm.gpbCabecera.Visible = criterioVisible;
                //if (frm.gpbCabecera.Visible)
                //    frm.gpbBotones.Dock = DockStyle.None;
                //else
                //    frm.gpbBotones.Dock = DockStyle.Top;
                frm.ParamsParametros = parametros;
                frm.Inicializado = inicializado;
                frm.Text = "Buscar - " + funcionBuscar.ToString();
                frm.ShowDialog();

                frm.Cursor = Cursors.WaitCursor;

                unObjeto = frm.ObjetoSeleccionado;

                frm.Cursor = Cursors.Default;
                frm.Dispose();
            }
            return unObjeto;
        }

        #endregion Funciones de busqueda

        #region Busqueda de objetos

        public static object BuscarCuentaGrupo()
        {
            return Buscar("CuentasGrupo", "cuentascontables", "esgrupo = 't' and periodo = " + General.periodoActual + " and (codigo like @nombre or upper(nombre) like @nombre )", "id as \"ID\", codigo as \"Código\", nombre as \"Nombre\"");
        }

        public static object BuscarFormaPago()
        {
            return Buscar("FormasPago", "formaspagos", "activo = 't' and (upper(id) like @nombre or upper(descripcion) like @nombre )", "id as \"ID\", descripcion as \"Forma de pago\"");
        }

        public static object BuscarCuentaMovimiento()
        {
            return Buscar("CuentasMovimiento", "cuentascontables", "esgrupo = 'f' and periodo = " + General.periodoActual + " and (codigo like @nombre or upper(nombre) like @nombre )", "id as \"ID\", codigo as \"Código\", nombre as \"Nombre\"", "order by nombre");
        }

        public static object BuscarParroquia()
        {
            return Buscar("Parroquias", "((parroquias p inner join cantones c on p.idcanton = c.id) inner join provincias v on c.idprovincia = v.id)", "(upper(p.nombre) like @nombre or upper(c.nombre) like @nombre or upper(v.nombre) like @nombre)", "p.id as \"ID\", p.nombre as \"Parroquia\", c.nombre as \"Canton\", v.nombre as \"Provincia\"", "order by p.nombre");
        }

        public static object BuscarProfesion()
        {
            return Buscar("Profesiones", "profesiones", "upper(nombre) like @nombre", "id as \"ID\", nombre as \"Profesión\", abreviatura as \"Abreviatura\"", "order by nombre");
        }

        public static int BuscarCliente()
        {
            object unObjeto = BuscarListaPr.Buscar("Clientes", "personas", "id > 0 and (id = @codigo or identificacion like @nombre or upper(nombre) like @nombre or upper(apellido) like @nombre)", "id, identificacion as \"Identificación\", apellido || ' ' || nombre as \"Nombre\"", "order by 3");
            if (unObjeto == null)
                unObjeto = -1;
            return (int)unObjeto;
        }

        public static object BuscarPersona()
        {
            return BuscarListaPr.Buscar("Personas", "personas", "id > 0 and (id = @codigo or identificacion like @nombre or upper(nombre) like @nombre or upper(apellido) like @nombre)", "id, identificacion as \"Identificación\", apellido || ' ' || nombre as \"Nombre\"", "order by 3");
        }

        public static object BuscarBarrio()
        {
            return BuscarListaPr.Buscar("Barrios", "barrios b inner join parroquias p on b.idparroquia = p.id inner join cantones c on p.idcanton = c.id inner join provincias pv on c.idprovincia = pv.id", "b.id = @codigo or upper(b.nombre) like @nombre or upper(p.nombre) like @nombre or upper(c.nombre) like @nombre or upper(pv.nombre) like @nombre", "b.id, b.nombre as \"Barrio\", p.nombre as \"Parroquia\", c.nombre as \"Canton\", pv.nombre as \"Provincia\"", "order by p.nombre");
        }

        public static object BuscarBeneficiarios()
        {
            return BuscarListaPr.Buscar("Beneficiarios", "personas", "id > 0 and (id = @codigo or identificacion like @nombre or upper(nombre) like @nombre or upper(apellido) like @nombre)", "id, identificacion as \"Identificación\", apellido || ' ' || nombre as \"Descripción\"", "order by 3");
        }

        public static object BuscarContratos()
        {
            return BuscarListaPr.Buscar("Contratos", "contratos c inner join personas p on c.idpersona = p.id", "c.id = @codigo or identificacion like @nombre or upper(nombre) like @nombre or upper(apellido) like @nombre", "c.id as \"Contrato\", identificacion as \"Identificación\", apellido || ' ' || nombre as \"Cliente\"", "order by 3");
        }

        public static object BuscarOrdenesServicio()
        {
            return BuscarListaPr.Buscar("OrdenesServicio", "tiposservicio tp inner join ordenesservicio c on tp.id = c.idtiposervicio inner join contratos d on c.idcontrato = d.id inner join personas p on d.idpersona = p.id", "c.id = @codigo or p.identificacion like @nombre or upper(p.nombre) like @nombre or upper(p.apellido) like @nombre", "c.id as \"Orden\", c.fecha as \"Fecha\", p.identificacion as \"Identificación\", p.apellido || ' ' || p.nombre as \"Cliente\", tp.descripcion as \"Tipo\", case c.estado when 'R' then 'REGISTRADA' when 'P' then 'PROCESADA' else 'ANULADA' end as \"Estado\"", "order by 3");
        }

        public static object BuscarItemInventario()
        {
            return BuscarListaPr.Buscar("ItemsInventario", "itemsinventario i ", "i.id = @codigo or upper(descripcion) like @nombre or (case tipo when 'M' then 'MATERIALES' when 'S' then 'SERVICIOS' end) like @nombre", "i.id as \"Id\", descripcion as \"Descripcion\", (case tipo when 'M' then 'MATERIALES' when 'S' then 'SERVICIOS' end) as \"Tipo\", precio as \"Precio\", grabaiva as \"GrabaIva\"", "order by 2");
        }

        public static object BuscarProducto()
        {
            return BuscarListaPr.Buscar("Productos", "productos p inner join marcas m on p.idmarca = m.id", "p.id = @codigo or upper(m.descripcion) like @nombre or upper(p.descripcion) like @nombre ", "p.id as \"Id\", m.descripcion as \"Marca\", p.descripcion as \"Descripción\", p.precio1 as \"Precio\"", "order by 3");
        }

        #endregion Busqueda de objetos

        #region Metodos de control local

        //public void LlenaGrid(string tabla, string valorWhere, string campos, string ordenar, List<CamposTabla> parametros, DataGridView objetoGrid)
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        LectorDatos.Instancia.Conexion = this.MkConn();
        //        LectorDatos.Instancia.Abrir("select " + campos + " from " + tabla + " " + valorWhere + " " + ordenar + " limit 100 ", parametros);
        //        dt.Load(LectorDatos.Instancia.Lector);
        //        objetoGrid.DataSource = dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        General.Mensaje(ex.Message);
        //    }
        //    finally
        //    {
        //        LectorDatos.Instancia.Cerrar();
        //    }
        //}

        public static void LlenaGrid(DataGridView objetoGrid, string tabla, string valorWhere, string campos, string ordenar, params DataParameter[] parametros)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                using (ispDB db = new ispDB())
                {
                    DataReader lector = db.ExecuteReader("select " + campos + " from " + tabla + " " + valorWhere + " " + ordenar + " limit 100 ", parametros);
                    dt.Load(lector.Reader);
                    objetoGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        public static void LlenaGrid(DataGridView objetoGrid, string cadenaSQL, params DataParameter[] parametros)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                using (ispDB db = new ispDB())
                {
                    DataReader lector = db.ExecuteReader(cadenaSQL, parametros);
                    dt.Load(lector.Reader);
                    objetoGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                General.Mensaje(ex.Message);
            }
        }

        #endregion Metodos de control local

        #region Busqueda de objetos parametros

        public static object BuscarRegistro(TipoConsulta funcionBuscar, object valor)
        {
            object unObjeto = null;
            switch (funcionBuscar)
            {
                case TipoConsulta._NoSet:
                    break;
                case TipoConsulta.CuentasContables:
                    unObjeto = CuentaContablePr.Instancia.RegistroPorCodigo(valor.ToString());
                    break;
                case TipoConsulta.CuentasContablesDeGrupo:
                    break;
                case TipoConsulta.Clientes:
                    unObjeto = ClientePr.Instancia.RegistroPorIdentificacion(valor.ToString());
                    break;
                case TipoConsulta.Personas:
                    break;
                case TipoConsulta.Productos:
                    unObjeto = ProductoPr.Instancia.RegistroPorCodigo((string)valor);
                    break;
                case TipoConsulta.Barrios:
                    unObjeto = BarrioPr.Instancia.RegistroPorId((int)valor);
                    break;
                case TipoConsulta.ColumnasPorTabla:
                    break;
                default:
                    break;
            }
            return unObjeto;
        }

        public static DataGridViewColumn[] CuentasContables()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colCodigo", HeaderText = "Codigo", DataPropertyName = "codigo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object CuentasContables(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.cuentascontables.Where(x => (x.codigo.Contains(valor) || x.nombre.ToUpper().Contains(valor.ToUpper())) && x.esgrupo == false).ToList();
                return a;
            }
        }

        public static DataGridViewColumn[] CuentasContablesDeGrupo()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colCodigo", HeaderText = "Codigo", DataPropertyName = "codigo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object CuentasContablesDeGrupo(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.cuentascontables.Where(x => (x.codigo.Contains(valor) || x.nombre.ToUpper().Contains(valor.ToUpper())) && x.esgrupo == true).ToList();
                return a;
            }
        }

        public static DataGridViewColumn[] Clientes()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colId", HeaderText = "Id", DataPropertyName = "id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colIdentificacion", HeaderText = "Identificacion", DataPropertyName = "identificacion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombrecompleto", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Clientes(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.clientes.OrderBy(x => x.fkpersona.apellido).ThenBy(x => x.fkpersona.nombre).Where(x => (x.fkpersona.identificacion.Contains(valor) || (x.fkpersona.apellido.ToUpper() + " " + x.fkpersona.nombre.ToUpper()).Contains(valor.ToUpper()))).Select(x => x.Relacionar(x.fkpersona, x.fkconyuge)).ToList();
                return a;
            }
        }

        public static DataGridViewColumn[] Personas()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colId", HeaderText = "Id", DataPropertyName = "id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colIdentificacion", HeaderText = "Identificacion", DataPropertyName = "identificacion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombrecompleto", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Personas(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.personas.OrderBy(x => x.apellido).ThenBy(x => x.nombre).Where(x => (x.identificacion.Contains(valor) || (x.apellido.ToUpper() + " " + x.nombre.ToUpper()).Contains(valor.ToUpper()))).ToList();
                return a;
            }
        }
        public static DataGridViewColumn[] Productos()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colCodigo", HeaderText = "Código", DataPropertyName = "codigo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colDescripcion", HeaderText = "Descripción", DataPropertyName = "descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colMarca", HeaderText = "Marca", DataPropertyName = "fkmarca", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Productos(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.productos.OrderBy(x => x.descripcion).Where(x => (x.codigo.Contains(valor) || (x.descripcion.Contains(valor) || (x.fkmarca.descripcion.Contains(valor))))).Select(x => x.Relacionar(x.fkmarca)).ToList();
                return a;
            }
        }

        public static DataGridViewColumn[] Barrios()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colId", HeaderText = "Id", DataPropertyName = "id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colUbicacion", HeaderText = "Ubicacion", DataPropertyName = "nombreubicacion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Barrios(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.barrios.OrderBy(x => x.nombre).Where(x => (x.nombre.Contains(valor) || (x.fkparroquia.nombre.ToUpper() + " " + x.fkparroquia.fkcantone.nombre.ToUpper() + " " + x.fkparroquia.fkcantone.fkprovincia.nombre.ToUpper()).Contains(valor.ToUpper()))).Select(x => x.Relacionar(x.fkparroquia.Relacionar(x.fkparroquia.fkcantone.Relacionar(x.fkparroquia.fkcantone.fkprovincia)))).Take(100).ToList();
                return a;
            }
        }
        public static DataGridViewColumn[] Usuarios()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colId", HeaderText = "Id", DataPropertyName = "id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "fkpersona", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colDescripcion", HeaderText = "Descripcion", DataPropertyName = "descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Usuarios(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.usuarios.OrderBy(x => x.descripcion).Where(x => (x.descripcion.Contains(valor) || (x.fkpersona.nombre.ToUpper()).Contains(valor.ToUpper()))).Select(x => x.Relacionar(x.fkpersona)).Take(100).ToList();
                return a;
            }
        }
        public static DataGridViewColumn[] Sucursales()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colId", HeaderText = "Id", DataPropertyName = "id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colDireccion", HeaderText = "Dirección", DataPropertyName = "direccion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Sucursales(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.sucursales.OrderBy(x => x.nombre).Where(x => (x.nombre.Contains(valor) || (x.direccion.ToUpper()).Contains(valor.ToUpper()))).Take(100).ToList();
                return a;
            }
        }
        public static DataGridViewColumn[] Bodegas()
        {
            return new DataGridViewColumn[]{ 
                new DataGridViewTextBoxColumn(){ Name = "colCodigo", HeaderText = "Código", DataPropertyName = "codigo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colDescripcion", HeaderText = "Descripción", DataPropertyName = "descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
                new DataGridViewTextBoxColumn(){ Name = "colEncargado", HeaderText = "Encargado", DataPropertyName = "fkusuario", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            };
        }
        public static object Bodegas(string valor)
        {
            using (ispDB db = new ispDB())
            {
                var a = db.bodegas.OrderBy(x => x.descripcion).Where(x => (x.descripcion.Contains(valor) || (x.codigo.ToUpper()).Contains(valor.ToUpper()) || (x.fkusuario.descripcion.ToUpper()).Contains(valor.ToUpper()))).Take(100).ToList();
                return a;
            }
        }

        public static DataGridViewColumn[] ColumnasPorTabla()
        {
            //return new DataGridViewColumn[]{ 
            //    new DataGridViewTextBoxColumn(){ Name = "colTabla", HeaderText = "Tabla", DataPropertyName = "TableName", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            //    new DataGridViewTextBoxColumn(){ Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            //    new DataGridViewTextBoxColumn(){ Name = "colUbicacion", HeaderText = "Ubicacion", DataPropertyName = "nombreubicacion", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },  
            //};
            return null;
        }
        public static object ColumnasPorTabla(string valor, params object[] parametros)
        {
            using (ispDB db = new ispDB())
            {
                LinqToDB.SchemaProvider.GetSchemaOptions GetSchemaOptions =
                new LinqToDB.SchemaProvider.GetSchemaOptions();

                LinqToDB.SchemaProvider.TableSchema ts = new LinqToDB.SchemaProvider.TableSchema();

                var sp = db.DataProvider.GetSchemaProvider();
                LinqToDB.SchemaProvider.DatabaseSchema dbs = sp.GetSchema(db, GetSchemaOptions);

                List<ColumnaSis> cols = dbs.Tables.Where(x => x.TableName == parametros[0].ToString()).SingleOrDefault().Columns.Select(x => new ColumnaSis() { ColumnName = x.ColumnName, ColumnType = x.ColumnName, DataType = x.DataType, Description = x.Description, IsIdentity = x.IsIdentity, IsNullable = x.IsNullable, IsPrimaryKey = x.IsPrimaryKey, MemberName = x.MemberName, MemberType = x.MemberType, PrimaryKeyOrder = x.PrimaryKeyOrder, SystemType = x.SystemType, SkipOnInsert = x.SkipOnInsert, SkipOnUpdate = x.SkipOnUpdate, Table = x.Table }).ToList();

                if (cols.Count > 0)
                    cols.Add(new ColumnaSis() { ColumnName = "modificado" });

                return cols;
            }
        }

        #endregion Busqueda de objetos parametros

    }

    public enum TipoConsulta
    {
        _NoSet,
        Barrios,
        Bodegas,
        Clientes,
        ColumnasPorTabla,
        CuentasContables,
        CuentasContablesDeGrupo,
        Personas,
        Productos,
        Sucursales,
        Usuarios,
    }
}