using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Compiling;
using ZenMake.Core;

namespace ZenMake.Modules.RunModule
{
	public class RunHandler : HandlerBase<RunArg>
	{
		public RunHandler(ZMFileRepo repo, ZMLogger log)
			: base(repo, log)
		{
			
		}

		public override void HandleCore(RunArg arg)
		{
			Console.WriteLine("running");
			Console.WriteLine("project file: \t{0}", arg.ProjectFilename);
			Console.WriteLine("targets:");

			foreach (var target in arg.Targets)
			{
				Console.WriteLine("target: {0}", target);
			}

			Console.WriteLine("parameters:");
			Console.WriteLine(arg.Parameters);

			var repo = new ZMFileRepo();

			var projectFile = repo.Load(arg.ProjectFilename);

			var compiler = new ProjectCompiler();
			
			compiler.Compile(projectFile);

			Console.WriteLine("all targets completed");
		}
	}
}