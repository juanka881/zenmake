using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectAddHandler : CommandHandler<ProjectAddArgs>
	{
		public override void HandleCore(ProjectAddArgs args)
		{
			var sourceFiles = args.Files.Where(x => x.EndsWith(".cs")).ToList();
			var referenceFiles = args.Files.Where(x => x.EndsWith(".dll")).ToList();
			var repo = new ProjectFileRepo();
			var projectFile = repo.Load(args.ProjectFilename);

			var sourceFilesToAdd = sourceFiles.Except(projectFile.SourceFiles);
			var referenceFilesToAdd = referenceFiles.Except(projectFile.ReferenceFiles);

			projectFile.SourceFiles.AddMany(sourceFilesToAdd);
			projectFile.ReferenceFiles.AddMany(referenceFilesToAdd);

			repo.Save(projectFile, projectFile.Filepath);
		}
	}
}
