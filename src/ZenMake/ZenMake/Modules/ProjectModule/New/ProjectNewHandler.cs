using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectNewHandler : HandlerBase<ProjectNewArg>
	{
		public ProjectNewHandler(ZMFileRepo repo, ZMLogger log)
			: base(repo, log)
		{
			
		}

		public override void HandleCore(ProjectNewArg arg)
		{
			if (File.Exists(arg.ProjectFilename))
				return;

			var currentDir = Directory.GetCurrentDirectory();
			var filepath = Path.Combine(currentDir, arg.ProjectFilename);
			var buildDir = ZMFile.DefaultBuildDir;

			var projectFile = new ZMFile(filepath, buildDir);

			this.Repo.Save(projectFile, filepath);
		}
	}
}