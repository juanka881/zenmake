using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public static class ZMFileRepoExtensions
	{
		public static ZMFile Load(this ZMFileRepo repo, string filepath)
		{
			if (repo == null)
				throw new ArgumentNullException("repo");

			using (var fs = File.OpenRead(filepath))
			{
				return repo.Load(fs, filepath);
			}
		}

		public static void Save(this ZMFileRepo repo, ZMFile zmFile, string filepath)
		{
			if (repo == null)
				throw new ArgumentNullException("repo");

			using (var fs = File.Open(filepath, FileMode.Create, FileAccess.Write))
			{
				repo.Save(zmFile, fs);
			}
		}
	}
}