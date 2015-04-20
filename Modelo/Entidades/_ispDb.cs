using System;
using LinqToDB;

namespace ModeloDB
{
    public partial class ispDB : IDisposable
    {
        public ispDB()
            : base("PostgreSQL")
        {

        }

        public int Grabar<T>(T Objeto)
        {
            return this.InsertOrReplace<T>(Objeto);
        }

        void IDisposable.Dispose()
        {

            if (base.Connection.State == System.Data.ConnectionState.Open)
                base.Connection.Close();
        }
    }
}
