using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;
using ZenMake.Modules.RunnerModule;
using ZenMake.Modules.ProjectModule;

namespace ZenMake.CommandLine
{
	public class CommandLineRunner
	{
		public void Run(string commandLine)
		{
			var cliParser = new CommandLineParser();
			var cliArgs = cliParser.GetArguments(commandLine).Skip(1).ToList();

			if(cliArgs.Count == 0)
				Console.WriteLine("no args passed!");

			var command = cliArgs.FirstOrDefault();
			cliArgs.RemoveAt(0);

			var parser = this.TryGetCommandArgsParserForCommand(command);
			
			if(parser == null)
				throw new Exception("unable to get command args parser for command line args");

			var args = parser.GetArgs(cliArgs);

			var handler = this.TryGetCommandHandlerForArgs(args);

			if(handler == null)
				throw new Exception("unable to get command handler for args");

			handler.Handle(args);
		}

		private ICommandArgsParser TryGetCommandArgsParserForCommand(string command)
		{
			if (string.IsNullOrWhiteSpace(command))
				return null;

			var parser = null as ICommandArgsParser;

			switch (command)
			{
				case "p":
					parser = new ProjectArgsParser();
					break;

				case "r":
					parser = new RunnerArgsParser();
					break;
			}

			return parser;
		}

		private ICommandHandler TryGetCommandHandlerForArgs(object args)
		{
			if (args == null)
				throw new ArgumentNullException("args");

			var type = args.GetType();

			var handler = null as ICommandHandler;

			if(type == typeof(ProjectNewArgs))
				handler = new ProjectNewHandler();

			if(type == typeof(ProjectAddArgs))
				handler = new ProjectAddHandler();

			if(type == typeof(ProjectRemoveArgs))
				handler = new ProjectRemoveHandler();

			if(type == typeof(RunnerArgs))
				handler = new RunnerHandler();

			return handler;
		}
	}
}