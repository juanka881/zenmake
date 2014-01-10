using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public static class ZMFileExtensions
	{
		public static ZMFileData ToData(this ZMFile pf)
		{
			if (pf == null)
				throw new ArgumentNullException("pf");

			var data = new ZMFileData();
			data.SourceFiles = pf.SourceFiles;
			data.ReferenceFiles = pf.ReferenceFiles;
			data.BuildDir = pf.BuildDir;

			return data;
		}

		public static ZMFile ToZMFile(this ZMFileData data, string filepath)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			var pf = new ZMFile(filepath, data.BuildDir, data.SourceFiles, data.ReferenceFiles);
			
			return pf;
		}
	}
}