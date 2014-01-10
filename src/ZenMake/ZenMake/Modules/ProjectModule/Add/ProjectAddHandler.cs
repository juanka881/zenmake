using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;
using ZenMake.Helpers;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectAddHandler : HandlerBase<ProjectAddArg>
	{
		public ProjectAddHandler(ZMFileRepo repo, ZMLogger log) : base(repo, log)
		{
			
		}

		public override void HandleCore(ProjectAddArg arg)
		{
			var sourceFiles = arg.Files.Where(x => x.EndsWith(".cs")).ToList();
			var referenceFiles = arg.Files.Where(x => x.EndsWith(".dll")).ToList();
			var projectFile = this.Repo.Load(arg.ProjectFilename);

			var sourceFilesToAdd = sourceFiles.Except(projectFile.SourceFiles);
			var referenceFilesToAdd = referenceFiles.Except(projectFile.ReferenceFiles);

			projectFile.SourceFiles.AddMany(sourceFilesToAdd);
			projectFile.ReferenceFiles.AddMany(referenceFilesToAdd);

			this.Repo.Save(projectFile, projectFile.FilePath);
		}
	}
}
