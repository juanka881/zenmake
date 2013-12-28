using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenMake.CommandLine;

namespace ZenMake.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var commandLine = Environment.CommandLine;
			var runner = new CommandLineRunner();
			runner.Run(commandLine);
		}
	}
}
