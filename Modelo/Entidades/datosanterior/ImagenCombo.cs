using System;
using System.Windows.Forms;

namespace ModeloDB
{
    public class ImagenCombo
    {
        #region VARIABLES
        private short imagenIndice;
        private string etiqueta;
        private static ImageList imagenes;
        #endregion VARIABLES

        #region PROPIEDADES
        public static ImageList Imagenes { get { return imagenes; } set { imagenes = value; } }
        public string Etiqueta { get { return etiqueta; } set { etiqueta = value; } }
        public short ImageIndex { get { return imagenIndice; } set { imagenIndice = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public ImagenCombo(string etiqueta, short imageIndex)
        {
            this.Etiqueta = etiqueta;
            this.ImageIndex = imageIndex;
        }
        #endregion CONSTRUCTORES

        #region FUNCIONES LOCALES
        public override string ToString()
        {
            return Etiqueta;
        }

        #endregion FUNCIONES LOCALES
    }
}
