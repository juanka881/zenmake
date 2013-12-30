using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Compiling
{
	public class CSharpCompilerArgs
	{
		public string BaseDir { get; private set; }
		public string BuildDir { get; private set; }
		public string OutputFilename { get; private set; }
		public IList<string> SourceFiles { get; private set; }
		public IList<string> ReferenceFiles { get; private set; }

		public CSharpCompilerArgs(
			string baseDir, 
			string buildDir, 
			string outputFilename,
			IEnumerable<string> sourceFiles, 
			IEnumerable<string> referenceFiles)
		{
			if (string.IsNullOrWhiteSpace(baseDir))
				throw new ArgumentException("baseDir is empty. baseDir is expected to have a non-empty string value");

			if (string.IsNullOrWhiteSpace(buildDir))
				throw new ArgumentException("buildDir is empty. buildDir is expected to have a non-empty string value");

			if (string.IsNullOrWhiteSpace(outputFilename))
				throw new ArgumentException("outputFilename is empty. outputFilename is expected to have a non-empty string value");

			if (sourceFiles == null)
				throw new ArgumentNullException("sourceFiles");

			if (referenceFiles == null)
				throw new ArgumentNullException("referenceFiles");

			this.BaseDir = baseDir;
			this.BuildDir = buildDir;
			this.OutputFilename = outputFilename;
			this.SourceFiles = new List<string>(sourceFiles);
			this.ReferenceFiles = new List<string>(referenceFiles);
		}
	}
}