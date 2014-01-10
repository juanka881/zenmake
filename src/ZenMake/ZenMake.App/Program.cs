using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenMake.Core;

namespace ZenMake.App
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Any(x => !string.IsNullOrEmpty(x) && x.Contains("-d")))
			{
				while (!Debugger.IsAttached) { }
			}

			var commandLine = Environment.CommandLine;
			var runner = new ZMRunner();
			runner.Run(commandLine);
		}
	}
}
