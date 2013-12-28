using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.RunnerModule
{
	public class RunnerHandler : CommandHandler<RunnerArgs>
	{
		public override void HandleCore(RunnerArgs args)
		{
			Console.WriteLine("running");
			Console.WriteLine("project file: \t{0}", args.ProjectFilename);
			Console.WriteLine("targets:");

			foreach (var target in args.Targets)
			{
				Console.WriteLine("target: {0}", target);
			}

			Console.WriteLine("parameters:");
			Console.WriteLine(args.Parameters);
		}
	}
}