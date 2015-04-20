using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using Entidades;
using Proveedores;

namespace Controladores
{
    public class AsignacionCr
    {
        #region PROPIEDADES
        private static AsignacionCr instancia;
        public static AsignacionCr Instancia
        {
            get
            {
                if (instancia == null) instancia = new AsignacionCr();
                return instancia;
            }
        }
        #endregion PROPIEDADES

        #region LLENAR OBJETOS
        public void RaiseLlenaCombo(string modulo, ComboBoxEx unCombo)
        {
            unCombo.ValueMember = "id";
            unCombo.DisplayMember = "nombre";
            AsignacionPr proveedor = new AsignacionPr();
            unCombo.DataSource = proveedor.ListaCombo(ref modulo);
            proveedor = null;
        }

        public void RaiseLlenaGrid(ref DataGridViewX unObjeto, string unModulo, short unId)
        {
            AsignacionPr proveedor = new AsignacionPr();
            unObjeto.DataSource = proveedor.ListaDetalle(unId, ref unModulo);
            proveedor = null;
        }
        #endregion LLENAR OBJETOS

        public bool RaiseGrabar(ref DataGridViewX unObjeto, string unModulo, short unIdMaestra)
        {
            bool res = false;
            try
            {
                AsignacionPr proveedor = new AsignacionPr();
                switch (unModulo)
                {
                    case "Perfil":
                        proveedor.GrabarPerfiles(unObjeto.DataSource, unIdMaestra);
                        break;
                    case "Usuario":
                        proveedor.GrabarUsuarios(unObjeto.DataSource, unIdMaestra);
                        break;
                    default:
                        break;
                }
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                General.Mensaje(ex.Message, MessageBoxIcon.Error);

            }
            return res;
        }
    }
}
