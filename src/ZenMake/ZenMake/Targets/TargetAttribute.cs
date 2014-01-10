using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Targets
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class TargetAttribute : Attribute
	{
		public TargetAttribute(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name is empty. name is expected to have a non-empty string value");

			this.Name = name;
		}

		public string Name { get; private set; }
	}
}