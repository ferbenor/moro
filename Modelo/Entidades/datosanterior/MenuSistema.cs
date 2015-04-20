using System;
using System.Collections.Generic;
using System.Text;
using Estructura;

namespace Entidades
{
    public class MenuSistema : Instrumental
    {
        #region VARIABLES
        private short id;
        private MenuSistemaAux padre;
        private string nombre;
        private string titulo;
        private bool visible;
        private bool contenedor;
        private string formulario;
        private string modulo;
        private string busqueda;
        private bool pieDetalle;
        private short icono;
        private bool editable = true;
        private bool vinculado = false;
        private const string nombreTabla = "menus";
        #endregion VARIABLES

        #region PROPIEDADES
        public short Id { get { return this.id; } }
        public short IdPadre { get; set; }
        public MenuSistemaAux Padre
        {
            get
            {
                if (this.padre == null)
                    return General.menuSistemaAuxCero;
                else
                    return this.padre;
            }
            set { this.padre = value; }
        }
        public string IdNombre { get { if (this.id == 0) return General.itemCero; else return this.id.ToString() + "-" + this.nombre; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }
        public string Formulario
        {
            get { return this.formulario; }
            set
            {
                this.formulario = null;
                if (this.contenedor)
                    this.formulario = "";
                else
                {
                    this.formulario = value;

                }
            }
        }

        public bool Visible { get { return this.visible; } set { this.visible = value; } }
        public bool Contenedor
        {
            get { return this.contenedor; }
            set
            {
                //this.contenedor = value;

                if (this.contenedor)
                {
                    this.formulario = null;
                    this.formulario = "";
                }

                if (this.vinculado)
                    this.contenedor = true;
                else
                {
                    this.contenedor = value;

                }
            }
        }

        public string Modulo { get { return this.modulo; } set { this.modulo = value; } }
        public string Busqueda { get { return this.busqueda; } set { this.busqueda = value; } }
        public bool PieDetalle { get { return this.pieDetalle; } set { this.pieDetalle = value; } }
        public short Icono { get { return this.icono; } set { this.icono = value; } }
        public System.Drawing.Image Imagen { get { return ModeloDB.ImagenCombo.Imagenes.Images[this.icono]; } }
        public bool Editable { get { return this.editable; } set { this.editable = value; } }
        public bool Vinculado { get { return this.vinculado; } }

        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public MenuSistema() { }

        public MenuSistema(short Id) { this.id = Id; }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        protected override List<CamposTabla> GetCampos(List<CamposTabla> lc)
        {
            lc.Clear();
            lc.Add(new CamposTabla("id", true, System.Data.DbType.Int16, 0, this.Id, true));
            lc.Add(new CamposTabla("idpadre", false, System.Data.DbType.Int16, 0, this.Padre.Id));
            lc.Add(new CamposTabla("nombre", false, System.Data.DbType.String, 50, this.nombre));
            lc.Add(new CamposTabla("titulo", false, System.Data.DbType.String, 80, this.titulo));
            lc.Add(new CamposTabla("visible", false, System.Data.DbType.Boolean, 0, this.visible));
            lc.Add(new CamposTabla("contenedor", false, System.Data.DbType.Boolean, 0, this.contenedor));
            lc.Add(new CamposTabla("formulario", false, System.Data.DbType.String, 50, this.formulario));
            lc.Add(new CamposTabla("modulo", false, System.Data.DbType.String, 20, this.modulo));
            lc.Add(new CamposTabla("busqueda", false, System.Data.DbType.String, 20, this.busqueda));
            lc.Add(new CamposTabla("piedetalle", false, System.Data.DbType.Boolean, 0, this.pieDetalle));
            lc.Add(new CamposTabla("icono", false, System.Data.DbType.Int16, 0, this.icono));
            lc.Add(new CamposTabla("True as editable", false, System.Data.DbType.Int16, 0, -1, false, true));
            lc.Add(new CamposTabla("case when (select count(m.id) from menus m where m.idpadre = " + nombreTabla + ".id) = 0 then false else true end vinculado", false, System.Data.DbType.Boolean, 0, -1, false, true));
            lc.ForEach(x => { if (string.IsNullOrEmpty(x.NombreTabla) && !x.SoloSelect) x.NombreTabla = nombreTabla; });
            return lc;
        }

        public string CadenaSelect()
        {
            return GeneraCadenaSelect(nombreTabla);
        }

        public string CadenaSelect(string condicion)
        {
            return GeneraCadenaSelect(nombreTabla, condicion);
        }

        public string CadenaBorrar()
        {
            return GeneraCadenaBorrar(nombreTabla);
        }

        public string CadenaGuardar()
        {
            return GeneraCadenaGuardar(nombreTabla, this.id);
        }

        public string CadenaSelectAsignados(Usuario unUsuario)
        {
            List<CamposTabla> lista = new List<CamposTabla>();
            lista.Add(new CamposTabla("codigo", unUsuario.Id));
            this.ListaParametros = lista;
            return "select menus.*, false as editable from menus where id in(select idpadre from menus " +
            "where id in(select idpadre from menus where id in(select idpadre from menus " +
            "where id in(select idpadre from menus where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo))))) " +
            "union " +
            "select menus.*, false as editable from menus where id in(select idpadre from menus " +
            "where id in(select idpadre from menus " +
            "where id in(select idpadre from menus " +
            "where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo)))) " +
            "union " +
            "select menus.*, false as editable  from menus where id in(select padre from menus " +
            "where id in(select idpadre from menus " +
            "where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo))) " +
            "union " +
            "select menus.*, false as editable from menus where id in(select idpadre from menus " +
            "where id in (select idmenu from perfilesmenus p, usuariosperfiles u where u.idperfil = p.idperfil and u.idusuario = @codigo)) " +
            "union " +
            "select m.*, cast(min(cast(editable as int)) as boolean) editable from menus m, perfilesmenus p, usuariosperfiles u where m.id = p.idmenu and p.idperfil = u.idperfil and u.idusuario=@codigo " +
            "group by m.id,m.idpadre,m.nombre,m.titulo,m.formulario,m.visible,m.contenedor,m.modulo,m.icono order by nombre";
        }

        public override string ToString()
        {
            return this.IdNombre;
        }

        public override int CompareTo(object obj)
        {
            if (obj is MenuSistema)
            {
                MenuSistema oVar = obj as MenuSistema;
                return String.Compare(this.ToString(), oVar.ToString(), true);
            }
            else if (obj is string)
            {
                return String.Compare(this.ToString(), obj as string);
            }
            else
            {
                return -1;
            }
        }
        #endregion FUNCIONES LOCALES


    }
}
