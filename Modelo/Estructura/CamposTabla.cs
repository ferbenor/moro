using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Estructura
{
    public class CamposTabla
    {
        #region VARIABLES
        string nombre;
        bool clave = false;
        bool autonumerico = false;
        bool _soloSelect = false;
        bool _esVersion = false;
        bool _noUpdate = false;
        bool _esBuscar = false;
        string _nombreTabla;
        DbType tipo;
        bool tipoEstablecido;
        int tamaño;
        object valor;
        ParameterDirection direccion = ParameterDirection.Input;
        #endregion VARIABLES

        #region PROPIEDADES
        public string NombreTabla { get { return _nombreTabla; } set { _nombreTabla = value; } }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public bool Clave { get { return clave; } set { clave = value; } }

        public bool Autonumerico { get { return autonumerico; } set { autonumerico = value; } }

        public bool SoloSelect { get { return _soloSelect; } set { _soloSelect = value; } }

        public bool EsVersion { get { return _esVersion; } set { _esVersion = value; } }

        public bool NoUpdate { get { return _noUpdate; } set { _noUpdate = value; } }

        public bool EsBuscar { get { return _esBuscar; } set { _esBuscar = value; } }

        public DbType Tipo { get { return tipo; } set { tipo = value; this.tipoEstablecido = true; } }

        public bool TipoEstablecido { get { return tipoEstablecido; } }
        
        public int Tamaño { get { return tamaño; } set { tamaño = value; } }

        public object Valor { get { return valor; } set { valor = value; } }

        public ParameterDirection Direccion { get { return direccion; } set { direccion = value; } }
        #endregion PROPIEDADES

        #region CONSTRUCTORES
        public CamposTabla() { }

        public CamposTabla(string unCampo, object unValor, bool soloSelect = false)
        {
            this.nombre = unCampo;
            this.valor = unValor;
            this._soloSelect = soloSelect;
        }
        public CamposTabla(string unCampo, bool esClave, DbType unTipo, int unTamaño)
        {
            nombre = unCampo;
            clave = esClave;
            Tipo = unTipo;
            tamaño = unTamaño;
        }
        public CamposTabla(string unCampo, bool esClave, DbType unTipo, int unTamaño, object unValor)
        {
            nombre = unCampo;
            clave = esClave;
            Tipo = unTipo;
            tamaño = unTamaño;
            valor = unValor;
        }
        public CamposTabla(string unCampo, bool esClave, DbType unTipo, int unTamaño, object unValor, ParameterDirection unaDireccion, bool soloSelect = false)
        {
            nombre = unCampo;
            clave = esClave;
            Tipo = unTipo;
            tamaño = unTamaño;
            direccion = unaDireccion;
            valor = unValor;
            this._soloSelect = soloSelect;
        }
        public CamposTabla(string unCampo, bool esClave, DbType unTipo, int unTamaño, object unValor, bool esAutonumerico, bool soloSelect = false)
        {
            nombre = unCampo;
            clave = esClave;
            Tipo = unTipo;
            tamaño = unTamaño;
            valor = unValor;
            autonumerico = esAutonumerico;
            this._soloSelect = soloSelect;
        }
        public CamposTabla(string unCampo, bool esClave, DbType unTipo, int unTamaño, object unValor, ParameterDirection unaDireccion, bool esAutonumerico, bool soloSelect = false)
        {
            nombre = unCampo;
            clave = esClave;
            Tipo = unTipo;
            tamaño = unTamaño;
            direccion = unaDireccion;
            valor = unValor;
            autonumerico = esAutonumerico;
            this._soloSelect = soloSelect;
        }
        #endregion CONSTRUCTORES

        public override string ToString()
        {
            return this.tipo.ToString() + " " + this.nombre + " = " + this.valor;
        }
    }
}
