using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZenMake
{
	public static class ProjectFileRepoExtensions
	{
		public static ProjectFile Load(this ProjectFileRepo repo, string filepath)
		{
			if (repo == null)
				throw new ArgumentNullException("repo");

			using (var fs = File.OpenRead(filepath))
			{
				return repo.Load(fs, filepath);
			}
		}

		public static void Save(this ProjectFileRepo repo, ProjectFile projectFile, string filepath)
		{
			if (repo == null)
				throw new ArgumentNullException("repo");

			using (var fs = File.Open(filepath, FileMode.Create, FileAccess.Write))
			{
				repo.Save(projectFile, fs);
			}
		}
	}
}