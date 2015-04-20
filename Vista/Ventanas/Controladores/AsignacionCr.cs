using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using Entidades;
using Proveedores;
using System.Reflection;
using Delegados;

namespace WindowsApp
{
    public class AsignacionCr
    {
        #region PROPIEDADES
        DelegadosFn objetoDelegado = new DelegadosFn();
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
        public void RaiseLlenaCombo(string unModulo, ComboBoxEx unCombo)
        {
            unCombo.ValueMember = "Id";
            unCombo.DisplayMember = "Objeto";
            Type untipo = Type.GetType("Proveedores." + unModulo + ", Proveedores");
            MethodInfo metodo = untipo.GetMethod("RegistrosCombo");
            if (metodo == null)
                throw new Exception("Metodo 'RegistrosCombo' no definido para el tipo '" + unModulo + "'");
            unCombo.DataSource = metodo.Invoke(null, null);
        }

        public void RaiseLlenaGrid(ref DataGridViewX unObjetoGrid, string unModulo, object unObjeto)
        {
            Type untipo = Type.GetType("Proveedores." + unModulo + ", Proveedores");
            MethodInfo metodo = untipo.GetMethod("RegistrosDetalle");
            if (metodo == null)
                throw new Exception("Metodo 'RegistrosCombo' no definido para el tipo '" + unModulo + "'");
            metodo.Invoke(null, new[] { unObjetoGrid, unObjeto });
        }
        #endregion LLENAR OBJETOS

        public bool RaiseGrabar(object unObjeto, string unModulo)
        {
            bool res = false;
            try
            {
                res = objetoDelegado.ObtenerGrabarLista().Invoke(unModulo, unObjeto);
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
