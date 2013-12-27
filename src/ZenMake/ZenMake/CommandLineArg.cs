using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake
{
	public class CommandLineArg
	{
		public CommandLineArgType Type { get; private set; }
		public string Value { get; private set; }

		public CommandLineArg(CommandLineArgType type, string value)
		{
			this.Type = type;
			this.Value = value ?? string.Empty;
		}
	}
}