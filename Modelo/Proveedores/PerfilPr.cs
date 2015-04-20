using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using LinqToDB;
using LinqToDB.Data;
using ModeloDB;
using System.Linq.Expressions;

namespace Proveedores
{
    public class PerfilPr
    {
        #region VARIABLES
        private static PerfilPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static PerfilPr Instancia { get { if (instancia == null) instancia = new PerfilPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public PerfilPr()
        { }

        #endregion CONSTRUCTORES

        #region CARGAS PARA ASIGNACION

        public static List<perfil> RegistrosCombo()
        {
            List<perfil> lista;
            using (ispDB db = new ispDB())
            {
                lista = db.perfiles.Where(x => x.activo == true).ToList();
            }
            return lista;
        }

        public static void RegistrosDetalle(DataGridView objetoGrid, perfil unPerfil)
        {
            using (ispDB db = new ispDB())
            {
                unPerfil.fkperfilesmenus =
                    (from m in db.menus
                     from p in db.perfilesmenus
                     .Where(x => x.idmenu == m.id && (x.idperfil == unPerfil.id || x.idperfil == null)).DefaultIfEmpty()
                     orderby m.nombre
                     select new perfilmenu()
                     {
                         fkmenu = m,
                         idmenu = m.id,
                         editable = (p.editable == null ? false : p.editable),
                         fkperfiles = unPerfil,
                         idperfil = unPerfil.id,
                         Asignado = (p.idmenu == null ? false : true)
                     }).ToList();
            }
            unPerfil.fkperfilesmenus.CargarGrid(objetoGrid);
        }

        #endregion CARGAS PARA ASIGNACION

        #region CARGAS DE REGISTROS

        public perfil Registro(short unId)
        {
            return Registros("id == @0", unId).SingleOrDefault();
        }

        public List<perfil> Registros(string expresion = null, params object[] parametros)
        {
            List<perfil> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.perfiles.Where(String.IsNullOrEmpty(expresion) ? "id > -1" : expresion, parametros).OrderBy(x => x.descripcion).ToList();
            }
            return registros;
        }

        #endregion CARGAS DE REGISTROS

        #region FUNCIONES DE GESTION

        public int Grabar(perfil item)
        {
            int i = 0;
            // Grabando asociacion
            if (item.fkperfilesmenus != null)
            {
                IEnumerable<perfilmenu> items = item.fkperfilesmenus.Where(x => x.Asignado == true);
                i = items.GrabarDetalle("idperfil == @0", item.id);
            }
            else
                // Grabando objeto
                i = item.GrabarObjetoT(x=> (short?)x.id ?? 0);
            return i;
        }

        public int Grabar(IEnumerable<perfil> items)
        {
            return items.GrabarListaT(x => x.id);
        }

        public int Borrar(perfil item)
        {
            return item.BorrarObjetoT();
        }

        #endregion FUNCIONES DE GESTION

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
                objetoGrid.Columns.AddRange(ColumnasGrid());

            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn()
            {
                Name = "colDescripcion",
                HeaderText = "Perfil.",
                DataPropertyName = "descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn()
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "activo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewCheckBoxColumn colModificado = new DataGridViewCheckBoxColumn()
            {
                Name = "colModificado",
                HeaderText = "Modificado",
                DataPropertyName = "Modificado",
                Visible = false
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colId,
                colDescripcion,
                colActivo,
                colModificado
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
