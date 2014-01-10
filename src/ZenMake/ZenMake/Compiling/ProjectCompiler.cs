using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Compiling
{
	public class ProjectCompiler
	{
		public ProjectCompilerResult Compile(ZMFile projectFile)
		{
			var filename = Path.GetFileNameWithoutExtension(projectFile.FileName);
			var outputFilename = string.Format("{0}.dll", filename);
			var outputFilepath = Path.Combine(projectFile.BuildDir, outputFilename);
			var workDir = projectFile.FileDir;

			if (!Directory.Exists(projectFile.BuildDir))
				Directory.CreateDirectory(projectFile.BuildDir);

			var args = new CSharpCompilerArgs(workDir, 
				outputFilepath, 
				projectFile.SourceFiles, 
				projectFile.ReferenceFiles);

			var csc = new CSharpCompiler();
			var cscResult = csc.Compile(args);

			var result = new ProjectCompilerResult(cscResult.OutputAssemblyFilepath);
			return result;
		}
	}
}
