﻿using System;

namespace LinqToDB.Mapping
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=false)]
	public class AssociationAttribute : Attribute
	{
		public AssociationAttribute()
		{
			CanBeNull = true;
		}

		public string Configuration { get; set; }
		public string ThisKey       { get; set; }
		public string OtherKey      { get; set; }
		public string Storage       { get; set; }
		public bool   CanBeNull     { get; set; }

		public string[] GetThisKeys () { return AssociationDescriptor.ParseKeys(ThisKey);  }
		public string[] GetOtherKeys() { return AssociationDescriptor.ParseKeys(OtherKey); }
	}
}
