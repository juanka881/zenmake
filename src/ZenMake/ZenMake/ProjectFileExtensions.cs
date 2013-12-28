using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake
{
	public static class ProjectFileExtensions
	{
		public static ProjectFileData ToData(this ProjectFile pf)
		{
			if (pf == null)
				throw new ArgumentNullException("pf");

			var data = new ProjectFileData();
			data.SourceFiles = pf.SourceFiles;
			data.ReferenceFiles = pf.ReferenceFiles;

			return data;
		}

		public static ProjectFile ToProjectFile(this ProjectFileData data, string filepath)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			var pf = new ProjectFile(filepath, data.SourceFiles, data.ReferenceFiles);
			
			return pf;
		}
	}
}