using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectArgsParser : ICommandArgsParser
	{
		public object GetArgs(IList<string> args)
		{
			if(args.Count == 0)
				throw new Exception("too few arguments!");

			var result = null as object;

			var command = args.FirstOrDefault();
			args.RemoveAt(0);

			var projectFilename = ProjectFile.DefaultFilename;

			if (command == "new")
			{
				result = this.GetProjectNewArgs(args, projectFilename);
			}
			else if (command.EndsWith(".zm"))
			{
				if (args.Count > 0)
				{
					projectFilename = command;
					command = args.FirstOrDefault();
					args.RemoveAt(0);	
				}
				else
				{
					throw new Exception("expected more parameters after project filename");
				}
			}
			
			if (command == "add")
			{
				result = this.GetProjectAddArgs(projectFilename, args);
			}
			else if (command == "rm")
			{
				result = this.GetProjectRemoveArgs(projectFilename, args);
			}

			if(result == null)
			{
				throw new Exception("unable to determine command for project");
			}

			return result;
		}

		private object GetProjectAddArgs(string projectFilename, IList<string> args)
		{
			if (args.Count == 0)
			{
				throw new Exception("expected at least 1 file when adding to a project");
			}

			return new ProjectAddArgs(projectFilename, args);
		}

		private object GetProjectRemoveArgs(string projectFilename, IList<string> args)
		{
			if (args.Count == 0)
			{
				throw new Exception("expected at least 1 file when adding to a project");
			}

			return new ProjectRemoveArgs(projectFilename, args);
		}

		private object GetProjectNewArgs(IList<string> args, string defaultProjectFilename)
		{
			var projectFilename = defaultProjectFilename;

			if (args.Count > 0)
			{
				projectFilename = args.FirstOrDefault();
			}

			return new ProjectNewArgs(projectFilename);
		}
	}
}