using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

using ModeloDB;

namespace ModeloDB
[Table(Schema="public", Name="statbase")]
	public partial class statbase
	{
		#region PROPIEDADES

		[Column(SkipOnUpdate=true), Nullable] public int?     datid           { get; set; }            // oid
		[Column(SkipOnUpdate=true), Nullable] public string   bdd             { get; set; }            // name
		[Column(SkipOnUpdate=true), Nullable] public int?     pid             { get; set; }            // integer
		[Column(SkipOnUpdate=true), Nullable] public int?     usesysid        { get; set; }            // oid
		[Column(SkipOnUpdate=true), Nullable] public string   usename         { get; set; }            // name
		[Column(SkipOnUpdate=true), Nullable] public object   dirip           { get; set; }            // inet
		[Column(SkipOnUpdate=true), Nullable] public string   client_hostname { get; set; }            // text
		[Column(SkipOnUpdate=true), Nullable] public int?     client_port     { get; set; }            // integer
		[Column(SkipOnUpdate=true), Nullable] public bool?    waiting         { get; set; }            // boolean
		[Column(SkipOnUpdate=true), Nullable] public string   state           { get; set; }            // text
		[Column(SkipOnUpdate=true), Nullable] public string   query           { get; set; }            // text
		                                      public statbase Objeto          { get { return this; } }

		#endregion
	}
}