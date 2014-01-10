using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectRemoveHandler : HandlerBase<ProjectRemoveArg>
	{
		public ProjectRemoveHandler(ZMFileRepo repo, ZMLogger log)
			: base(repo, log)
		{
			
		}

		public override void HandleCore(ProjectRemoveArg arg)
		{
			var sourceFiles = arg.Files.Where(x => x.EndsWith(".cs")).ToList();
			var referenceFiles = arg.Files.Where(x => x.EndsWith(".dll")).ToList();

			var projectFile = this.Repo.Load(arg.ProjectFilename);

			foreach (var sourceFile in sourceFiles)
				projectFile.SourceFiles.Remove(sourceFile);

			foreach (var referenceFile in referenceFiles)
				projectFile.ReferenceFiles.Remove(referenceFile);

			this.Repo.Save(projectFile, arg.ProjectFilename);
		}
	}
}