using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZenMake.Compiling
{
	public class FrameworkVersion40Info
	{
		private static readonly string DotNetDir = @"%WINDIR%\Microsoft.NET\Framework";
		private static readonly string FrameworkVersion40Dir = "v4.0.30319";
		private static readonly string CSharpCompilerBinFilename = "csc.exe";

		public string FrameworkRootDir { get; private set; }
		public string CSharpCompilerBinFilepath { get; private set; }
		
		public FrameworkVersion40Info()
		{
			this.FrameworkRootDir = this.GetFrameworkRootDir();
			this.CSharpCompilerBinFilepath = this.GetCSharpCompilerBinFilepath(this.FrameworkRootDir);
		}

		private string GetFrameworkRootDir()
		{
			var expandedDotNetDir = Environment.ExpandEnvironmentVariables(DotNetDir);
			var frameworkDir = Path.Combine(expandedDotNetDir, FrameworkVersion40Dir);
			return frameworkDir;
		}

		private string GetCSharpCompilerBinFilepath(string frameworkDir)
		{
			var filepath = Path.Combine(frameworkDir, CSharpCompilerBinFilename);
			return filepath;
		}
	}
}