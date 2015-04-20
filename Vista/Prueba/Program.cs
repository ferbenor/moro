using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proveedores;
using Entidades;
using System.Security.Cryptography;
using ModeloDB;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Specialized;
using System.Configuration;

namespace Prueba
{
    class Program
    {
        public static String Reverse(String strParam)
        {
            if (strParam.Length == 1)
            {
                return strParam;
            }
            else
            {
                return Reverse(strParam.Substring(1)) + strParam.Substring(0, 1);
            }
        }

        private class pg
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
        }

        private class prd
        {
            public int Codigo { get; set; }
            public List<pg> TipoPago { get; set; }

        }

        class sms
        {
            public string Telefono { get; set; }
            public string Mensaje { get; set; }
        }
        static void Main(string[] args)
        {
            using (ispDB db = new ispDB())
            {
                barrio barr = db.barrios.Where(x => x.id == 1).SingleOrDefault();
                var registros =
                    (from op in db.inventarios
                     from dt in db.detallesinventarios.Where(x=> x.idperiodo == op.idperiodo && x.tipo == op.tipo && x.numero == op.numero).DefaultIfEmpty()
                     group dt by op
                         into gr
                         select gr.Key.Relacionar(gr.ToList())
                    ).ToList();


                //db.inventarios.GroupJoin(db.detallesinventarios, x => x, y => y.fkinventario, (x, y) => x).ToList();

                //(from op in db.inventarios
                // join dt in db.detallesinventarios on op equals dt.fkinventario
                // //into gr
                // join pr in db.productos on dt.fkproducto equals pr
                // select gr.ToList()

                //).ToList();
            }

            NameValueCollection conf = (NameValueCollection)ConfigurationManager.AppSettings;

            object aaaa = BuscarListaPr.BuscarObjeto(TipoConsulta.ColumnasPorTabla, true, true, "barrios");

            using (ispDB db = new ispDB())
            {
                var sp = db.DataProvider.GetSchemaProvider();
                LinqToDB.SchemaProvider.DatabaseSchema aaa = sp.GetSchema(db, new LinqToDB.SchemaProvider.GetSchemaOptions() { ExcludedSchemas = new string[] { "empresas" } });
            }
            List<prd> prod = new List<prd>() { 
                new prd() { Codigo = 1, TipoPago = new List<pg>() { new pg() { Id = 1, Descripcion = "" }, new pg() { Id = 2, Descripcion = "" } } } ,
                new prd() { Codigo = 1, TipoPago = new List<pg>() { new pg() { Id = 1, Descripcion = "" } } } 
            }
                ;

            object res = prod.Where(x => x.TipoPago.FindIndex(y => y.Id == 2) > -1).ToList();
            string a = "Hola";
            string b = Reverse(a);

            perfil uno = new perfil() { id = 0, descripcion = "no se" };
            PerfilPr.Instancia.Grabar(uno);

            using (ispDB db = new ispDB())
            {
                //var lista = (from m in db.perfiles.DefaultIfEmpty()
                //              join p in db.usuariosperfiles on m.id equals p.idperfil
                //              into pm
                //              from a in pm.DefaultIfEmpty()
                //              where a.idusuario == 1 || a.idusuario == null
                //              orderby m.descripcion
                //              select new usuarioperfil()
                //              {
                //                  fkperfile = m,
                //                  idusuario = 1,
                //                  idperfil = m.id,
                //                  Asignado = (a.idperfil == null ? false : true)
                //              }).ToList();

                //var lista1 = (from m in db.menus
                //              join p in db.perfilesmenus on m.id equals p.idmenu
                //              into pm 
                //              from a in pm.DefaultIfEmpty()
                //              where a.idperfil == 1 || a.idperfil == null
                //              orderby m.nombre
                //              select new perfilmenu()
                //              {
                //                  fkmenu = m,
                //                  editable = (a.editable == null ? false : a.editable),
                //                  idperfil = 1,
                //                  idmenu = m.id,
                //                  Asignado = (a.idmenu == null ? false : true)
                //              }).ToList();

                var lista = (from m in db.menus
                             from p in db.perfilesmenus
                             .Where(q => q.idmenu == m.id && (q.idperfil == 1 || q.idperfil == null)).DefaultIfEmpty()
                             where p.idperfil == 1
                             select new perfilmenu()
                              {
                                  fkmenu = m,
                                  editable = (p.editable == null ? false : p.editable),
                                  idperfil = 1,
                                  idmenu = m.id,
                                  Asignado = (p.idmenu == null ? false : true)
                              }).ToList();

                int it = db.GetTable<perfil>().Max(x => ((short?)x.id ?? 0) + 1);

                string ax = db.LastQuery;
            }

            PerfilPr.RegistrosCombo();

            BancoPr.Instancia.Borrar(new banco() { id = 0 });
            DocumentoPr.Instancia.Grabar(new documento() { id = 5 });

            using (ispDB db = new ispDB())
            {
                try
                {
                    db.BeginTransaction();
                    pagoregistrado pagoreg;

                    pagoreg = db.QueryProc<pagoregistrado>(pagoregistrado.funcion,
                        new DataParameter("pidentificadorpagos", 0, DataType.Int32),
                        new DataParameter("pidformapago", 1, DataType.Int16),
                        new DataParameter("pnotificacion", false, DataType.Boolean),
                        new DataParameter("pfecha", Sql.DateTime, DataType.DateTime),
                        new DataParameter("pidusuariocobranza", 1, DataType.Int16),
                        new DataParameter("pvalor", 100, DataType.Decimal),
                        new DataParameter("pdetalle", "prueba", DataType.VarChar),
                        new DataParameter("pidusuarioregistra", 2, DataType.Int16),
                        new DataParameter("pidusuarioanula", -1, DataType.Int16),
                        new DataParameter("ttran", 1, DataType.Int16)
                        ).First();


                    db.CommitTransaction();

                    List<conveniopago> pago = db.
                        pagos.Where(x => x.identificadorpagos == pagoreg.identificadorpago).Select(x =>
                            x.Relacionar(x.fkconveniospago
                                .Relacionar(x.fkconveniospago.fkidentificadorespagos
                                ).Relacionar(x.fkconveniospago.fkformaspago)
                            ).Relacionar(x.fkusuario
                            )).ToList().GroupBy(x => x.fkconveniospago, (x, y) => new conveniopago()
                        {
                            fkformaspago = x.fkformaspago,
                            fkidentificadorespagos = x.fkidentificadorespagos,
                            fkpagos = y.ToList()
                        }).ToList();

                    identificadorpago identificador = pago.GroupBy(x => x.fkidentificadorespagos,
                        (x, y) => new identificadorpago()
                            {
                                id = x.id,
                                fkconveniospago = y.ToList()
                            }).Single();

                }
                catch (Exception)
                {
                    db.RollbackTransaction();
                    throw;
                }
            }


            WhereBuilder f = new WhereBuilder();
            string ff = f
                .Donde("uno", Comparacion.Igual, 1)
                .Y("dos", Comparacion.Contiene, "f")
                .O("fkpersona.identificacion", Comparacion.NoContiene, "070").Compilar();



            var fff = f.parametros;

            LinqToDB.SchemaProvider.GetSchemaOptions GetSchemaOptions =
    new LinqToDB.SchemaProvider.GetSchemaOptions();

            LinqToDB.SqlProvider.ISqlBuilder SqlBuilder;

            using (ispDB db = new ispDB())
            {
                SqlBuilder = db.DataProvider.CreateSqlBuilder();

                var sp = db.DataProvider.GetSchemaProvider();
                LinqToDB.SchemaProvider.DatabaseSchema db1 = sp.GetSchema(db, GetSchemaOptions);
            }
            usuario ls = UsuarioPr.Instancia.RegistroPorLogin("fer fer");


            //ClientePr c = new ClientePr();
            //Cliente nombre = c.RegistroPorId(3);
            //Cliente client;// = new Cliente();
            //client = nombre;
            //client.Nombre = client.Nombre + " Registro";
            //client.Foto = System.Drawing.Image.FromFile("c:\\a.png");
            //client.IdApoderado = 2;
            //client.IdBarrio = 2;
            //client.IdBeneficiarioMortuorio = 2;
            //client.IdBeneficiarioSeguroVida = 2;
            //client.IdConyugue = 2;
            //client.IdEstadoCivil = 2;
            //client.IdEstadoPersona = 1;
            //client.IdGenero = 1;
            //client.IdNivelEstudio = 1;
            //client.IdProfesion = 1;
            //client.IdTipoSangre = 1;
            //client.Modificado = true;
            //object resp = c.Grabar(client, null, null);



            //bool res = General.ValidarCedula("0704680421");
            //res = General.ValidarCedula("0704680420001");

            //General.periodoActual = 2014;
            //ContablePr a = new ContablePr();
            //Contable b = a.RegistroPorId(0, 1, 1);
            //Console.WriteLine(b.DetalleContable[0].DescripcionDetalleContable);

            //UsuarioSesionActiva usu = new UsuarioSesionActiva(new Usuario(1));
            //MenuSistemaPr menu = new MenuSistemaPr();
            //General.usuarioActivo = usu;


            //Console.WriteLine(usu.CadenaSelect());

            //string a = General.CifrarClave("papo 123123");
            /*Console.WriteLine(EncodePassword("PRUEBA DE ENCRIPTACION").Length);
            Console.WriteLine(EncodePassword("WALTER PA$$w0rd").Length);
            Console.WriteLine(EncodePassword("DAVID PODE_SERA_MIO").Length);
            Console.WriteLine(EncodePassword("DANIEL EstaEsLa ClaveMas Grande del Mundo"));
            */


            //GC.Collect();
            Console.ReadLine();

        }

        public static string EncodePassword(string originalPassword)
        {

            SHA512CryptoServiceProvider provider = new SHA512CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(originalPassword);
            StringBuilder valorHash = new StringBuilder();
            data = provider.ComputeHash(data);
            for (int i = 0; i < data.Length; i++)
                valorHash.Append(data[i].ToString("x2").ToLower());

            return valorHash.ToString();

        }
    }
}
