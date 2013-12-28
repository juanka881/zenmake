using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectNewHandler : CommandHandler<ProjectNewArgs>
	{
		public override void HandleCore(ProjectNewArgs args)
		{
			if(!File.Exists(args.ProjectFilename))
				File.WriteAllText(args.ProjectFilename, "{}");
		}
	}
}