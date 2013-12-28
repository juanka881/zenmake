using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectRemoveHandler : CommandHandler<ProjectRemoveArgs>
	{
		public override void HandleCore(ProjectRemoveArgs args)
		{
			var sourceFiles = args.Files.Where(x => x.EndsWith(".cs")).ToList();
			var referenceFiles = args.Files.Where(x => x.EndsWith(".dll")).ToList();

			var repo = new ProjectFileRepo();

			var projectFile = repo.Load(args.ProjectFilename);

			foreach (var sourceFile in sourceFiles)
				projectFile.SourceFiles.Remove(sourceFile);

			foreach (var referenceFile in referenceFiles)
				projectFile.ReferenceFiles.Remove(referenceFile);

			repo.Save(projectFile, args.ProjectFilename);
		}
	}
}