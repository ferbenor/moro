using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using DevComponents.DotNetBar.Controls;
using ModeloDB;
using Estructura;
using CollectionLoaders;
using System.Linq.Dynamic;
using LinqToDB;
using LinqToDB.Data;

namespace Proveedores
{
    public class UsuarioSesionActivaPr : InstrumentalPr
    {
        #region VARIABLES
        private static UsuarioSesionActivaPr instancia = null;
        #endregion VARIABLES

        #region PROPIEDADES
        public static UsuarioSesionActivaPr Instancia { get { if (instancia == null) instancia = new UsuarioSesionActivaPr(); return instancia; } set { instancia = value; } }
        #endregion PROPIEDADES

        public UsuarioSesionActivaPr()
        { }

        public usuariosesionactiva Registro(object unUsuario)
        {
            return Registros("idusuario == @0", ((usuario)unUsuario).id).SingleOrDefault();
        }

        public List<usuariosesionactiva> Registros(string expresion = null, params object[] parametros)
        {
            List<usuariosesionactiva> registros = null;
            using (ispDB db = new ispDB())
            {
                registros = db.usuariossesionactivas.Where(string.IsNullOrEmpty(expresion) ? "idusuario > -1" : expresion, parametros).Select(x =>
                    x.Relacionar(x.fkusuario.Relacionar(x.fkusuario.fkpersona)
                    )).ToList();
            }
            return registros;
        }

        public int Grabar(usuariosesionactiva item)
        {
            int i = 0;
            item.fechasesion = Sql.DateTime;
            i = item.GrabarObjetoT<usuariosesionactiva, short>(null);
            if (i > 0)
                General.usuarioActivo = item;
            return i;
        }

        public int Borrar(usuariosesionactiva item)
        {
            return item.BorrarObjetoT();
        }

        #region ARMAR GRID
        public void ArmarGrid(DataGridView objetoGrid, string expresion = null, params object[] parametros)
        {
            if (objetoGrid.Columns.Count == 0)
                objetoGrid.Columns.AddRange(ColumnasGrid());

            //CARGA DE LISTAS
            this.Registros(expresion, parametros).CargarGrid(objetoGrid);
            objetoGrid.AllowUserToAddRows = false;

        }

        public DataGridViewColumn[] ColumnasGrid()
        {
            DataGridViewTextBoxColumn colIdUsuario = new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Usuario",
                DataPropertyName = "fkusuario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };


            DataGridViewTextBoxColumn colIpSesion = new DataGridViewTextBoxColumn()
            {
                Name = "colIpSesion",
                HeaderText = "IP Sesion",
                DataPropertyName = "ipsesion",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewDateTimeInputColumn colFechaSesion = new DataGridViewDateTimeInputColumn()
            {
                Name = "colFechaSesion",
                HeaderText = "Fecha Sesion",
                DataPropertyName = "fechasesion",
                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm:ss",
                MinDate = new DateTime(1901, 02, 01),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DataGridViewColumn[] listaColumnas = new DataGridViewColumn[]
            {
                colIdUsuario,
                colIpSesion,
                colFechaSesion
            };
            return listaColumnas;
        }
        #endregion ARMAR GRID
    }
}
