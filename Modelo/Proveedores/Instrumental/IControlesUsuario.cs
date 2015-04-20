using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proveedores
{
    #region INTERFAZ PARA CONTROLES DE USUARIOS

    //INTERFAZ PARA CONTROLES DE USUARIOS
    public interface IControlesUsuario
    {
        object Columnas { get; set; }
        string Modulo { get; set; }
        object Objeto { get; set; }
        void Cargar(ref object unObjeto, string unModulo = null, object listaValores = null);
        bool Verificar();
    }

    #endregion INTERFAZ PARA CONTROLES DE USUARIOS
}
