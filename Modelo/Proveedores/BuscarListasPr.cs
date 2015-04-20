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

namespace Proveedores
{
    public class BuscarListasPr : InstrumentalPr
    {
        public BuscarListasPr()
        { }

        #region Funciones de busqueda
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

        public void LlenaGrid(DataGridView objetoGrid, string tabla, string valorWhere, string campos, string ordenar, params DataParameter[] parametros)
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

        #endregion Metodos de control local
    }
}
