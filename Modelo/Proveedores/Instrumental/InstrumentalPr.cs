using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Windows.Forms;
using ModeloDB;
using DevComponents.DotNetBar.Controls;

namespace Proveedores
{
    public enum Comparacion
    {
        Igual,
        NoIgual,
        Contiene,
        NoContiene,
        MayorQue,
        MayorIgualQue,
        MenorQue,
        MenorIgualQue,
        En
    }

    internal class Campos
    {
        #region VARIABLES

        public string Campo { get; set; }
        public object Parametro { get; set; }

        #endregion VARIABLES

        #region CONSTRUCTORES

        public Campos()
        {

        }

        #endregion CONSTRUCTORES
    }

    public class WhereBuilder : IDisposable
    {
        #region VARIABLES

        List<Campos> camp = new List<Campos>();
        StringBuilder cadena = new StringBuilder();
        public object[] parametros;

        #endregion VARIABLES

        #region METODOS
        public string Compilar()
        {
            for (int i = 0; i < camp.Count; i++)
            {
                Campos item = camp[i];
                cadena.AppendFormat(item.Campo, i);
            }
            parametros = camp.Select(x => x.Parametro).ToArray();
            return (cadena.ToString().Trim().Length > 3 ? cadena.ToString().Trim().Substring(3) : string.Empty);
        }

        public WhereBuilder Donde(string campo, Comparacion tipo, object valor)
        {
            Campos a = Build("&&", campo, tipo, valor);
            camp.Add(a);
            return this;
        }

        public WhereBuilder Y(string campo, Comparacion tipo, object valor)
        {
            Campos a = Build("&&", campo, tipo, valor);
            camp.Add(a);
            return this;
        }

        public WhereBuilder O(string campo, Comparacion tipo, object valor)
        {
            Campos a = Build("||", campo, tipo, valor);
            camp.Add(a);
            return this;
        }

        private Campos Build(string evaluador, string campo, Comparacion tipo, object valor)
        {
            Campos objeto = new Campos();
            objeto.Parametro = valor;
            switch (tipo)
            {
                case Comparacion.Igual:
                    objeto.Campo = evaluador + " " + campo + " == @{0} ";
                    break;
                case Comparacion.NoIgual:
                    objeto.Campo = evaluador + " " + campo + " != @{0} ";
                    break;
                case Comparacion.Contiene:
                    objeto.Campo = evaluador + " " + campo + ".Contains(@{0}) ";
                    break;
                case Comparacion.NoContiene:
                    objeto.Campo = evaluador + " !" + campo + ".Contains(@{0}) ";
                    break;
                case Comparacion.MayorQue:
                    objeto.Campo = evaluador + " " + campo + " > @{0} ";
                    break;
                case Comparacion.MayorIgualQue:
                    objeto.Campo = evaluador + " " + campo + " >= @{0} ";
                    break;
                case Comparacion.MenorQue:
                    objeto.Campo = evaluador + " " + campo + " < @{0} ";
                    break;
                case Comparacion.MenorIgualQue:
                    objeto.Campo = evaluador + " " + campo + " <= @{0} ";
                    break;
                case Comparacion.En:
                    objeto.Campo = evaluador + " " + campo + " == @{0} ";
                    break;
            }
            return objeto;
        }

        public void Limpiar()
        {
            this.camp.Clear();
            this.parametros = null;
            this.cadena.Clear();
        }

        public void Dispose()
        {
            this.cadena = null;
            this.camp = null;
            this.parametros = null;
        }

        #endregion METODOS
    }

    public abstract class InstrumentalPr
    {
        #region VARIABLES

        public string CadenaSqlGlobal = null;

        #endregion VARIABLES

        #region CONSTRUCTORES

        public InstrumentalPr()
        { }

        #endregion CONSTRUCTORES

        #region METODOS

        public virtual object MkConn()
        {
            if (Entidades.General.miConexion == null)
                Entidades.General.miConexion = (System.Data.IDbConnection)ProveedorAcceso.DAO.CreaConexion();
            if (Entidades.General.miConexion.State == System.Data.ConnectionState.Closed)
                Entidades.General.miConexion.Open();
            return Entidades.General.miConexion;
        }

        public virtual object MkTran(object conn)
        {
            return ProveedorAcceso.DAO.CreaTransaccion(conn);
        }

        public virtual void Commit(object tran)
        {
            ProveedorAcceso.DAO.Commit(tran);
        }

        public virtual void Rollback(object tran)
        {
            ProveedorAcceso.DAO.RollBack(tran);
        }

        public virtual void CerrarConn(object conn = null)
        {
            //if (conn == null)
            //{
            //    ProveedorAcceso.DAO.Close(Entidades.General.miConexion);
            //    Entidades.General.miConexion = null;
            //}
            //else
            //    ProveedorAcceso.DAO.Close(conn);
            LectorDatos.Instancia.Cerrar();
        }

        #endregion METODOS

        #region METODOS STATIC

        public static DataGridViewColumn[] GeneraColumnasGrid(object unColumnasGrid, short unIdentificador = 0)
        {
            List<columnasgrid> columnas = unColumnasGrid as List<columnasgrid>;
            List<DataGridViewColumn> lista = new List<DataGridViewColumn>();
            DataGridViewColumn columna = null;
            if (columnas != null)
            {
                foreach (columnasgrid item in columnas.Where(x => x.identificador == unIdentificador))
                {
                    switch (item.idtipocolumna)
                    {
                        case 0:
                            columna = new DataGridViewTextBoxColumn()
                            {
                                MaxInputLength = item.maxlength
                            };
                            break;
                        case 1:
                            columna = new DataGridViewComboBoxExColumn()
                            {
                                ValueMember = item.valuemember,
                                DisplayMember = item.displaymember,
                                FlatStyle = FlatStyle.Flat,
                                DropDownStyle = ComboBoxStyle.DropDownList
                            };
                            break;
                        case 2:
                            columna = new DataGridViewButtonXColumn()
                            {
                                Image = item.nombre.ToLower().Contains("borrar") ? General.Imagenes.Images["Eliminar.ico"] : General.Imagenes.Images["Listar.ico"],
                                ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
                            };
                            break;
                        case 3:
                            columna = new DataGridViewCheckBoxColumn()
                            {
                                SortMode = DataGridViewColumnSortMode.Automatic,

                            };
                            break;
                        case 4:
                            columna = new DataGridViewDateTimeInputColumn()
                            {
                                Format = DevComponents.Editors.eDateTimePickerFormat.Custom,
                                CustomFormat = item.formatofecha,
                                MinDate = item.fechaminima,
                            };
                            break;
                    }
                    columna.Name = "col" + item.nombre.ToUpper()/* + (columna.GetType().ToString() == "DataGridViewButtonXColumn" ? "Boton" : "")*/;
                    //columna.Name = "col" + item.nombre.ToUpper() + (item.idtipocolumna == 3 ? "Boton" : "");
                    columna.DefaultCellStyle.Format = item.formatofecha;
                    columna.HeaderText = item.cabecera;
                    columna.Visible = item.visible;
                    columna.ReadOnly = item.sololectura;
                    columna.Tag = item.tag;
                    columna.DataPropertyName = item.idtipocolumna == 2 ? "" : item.propertyname;
                    if (item.width == 0)
                        columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    else
                        columna.Width = item.width;
                    columna.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)Enum.Parse(typeof(DataGridViewContentAlignment), item.fkalineacion.nombre, true);

                    lista.Add(columna);
                }
            }

            return lista.ToArray();
        }

        #endregion METOTOS STATIC
    }
}
