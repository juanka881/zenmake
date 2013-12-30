using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenMake.Compiling
{
	public class CSharpCompiler
	{
		public CSharpCompilerResult Compile(CSharpCompilerArgs args)
		{
			if (args == null)
				throw new ArgumentNullException("args");

			var exitCode = 0;
			var outputText = string.Empty;
			var invocationError = null as Exception;
			var outputAssemblyFile = "project.dll";
			var warnings = new List<string>();
			var errors = new List<string>();

			var fw = new FrameworkVersion40Info();

			var psi = new ProcessStartInfo(fw.CSharpCompilerBinFilepath, "file1.cs /out:file1.dll /target:library");
			psi.WorkingDirectory = @"C:\Users\gogo\Desktop\zenmake\src\ZenMake\ZenMake.App\bin\Debug";
			
			Process.Start(psi);

			return new CSharpCompilerResult(exitCode, 
				invocationError, 
				outputText, 
				outputAssemblyFile,
				warnings,
				errors);	
		}
	}
}
