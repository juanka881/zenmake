using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ZenMake.Targets
{
	public class Target
	{
		public string Name { get; private set; }

		public MethodInfo TaskMethodInfo { get; private set; }

		public Target(string name, MethodInfo taskMethodInfo)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name is empty. name is expected to have a non-empty string value");

			if (taskMethodInfo == null)
				throw new ArgumentNullException("taskMethodInfo");

			this.Name = name;
			this.TaskMethodInfo = taskMethodInfo;
		}
	}
}
