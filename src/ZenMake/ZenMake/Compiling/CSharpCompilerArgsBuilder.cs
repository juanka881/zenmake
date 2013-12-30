using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Compiling
{
	public class CSharpCompilerArgsBuilder
	{
		private string baseDir;
		private string buildDir;
		private string outputFilename;
		private IList<string> sourceFiles;
		private IList<string> referenceFiles;

		public CSharpCompilerArgsBuilder()
		{
			this.sourceFiles = new List<string>();
			this.referenceFiles = new List<string>();
		}

		public CSharpCompilerArgsBuilder BaseDir(string dir)
		{
			this.baseDir = dir;
			return this;
		}

		public CSharpCompilerArgsBuilder BuildDir(string dir)
		{
			this.buildDir = dir;
			return this;
		}

		public CSharpCompilerArgsBuilder OutputFilename(string filename)
		{
			this.outputFilename = filename;
			return this;
		}

		public CSharpCompilerArgsBuilder AddSourceFile(string file)
		{
			this.sourceFiles.Add(file);
			return this;
		}

		public CSharpCompilerArgsBuilder AddReferenceFile(string file)
		{
			this.referenceFiles.Add(file);
			return this;
		}
		
		public CSharpCompilerArgs Build()
		{
			return new CSharpCompilerArgs(
				this.baseDir, 
				this.buildDir, 
				this.outputFilename,
				this.sourceFiles,
				this.referenceFiles);	
		}
	}
}