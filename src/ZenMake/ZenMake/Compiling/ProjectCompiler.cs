using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenMake.Compiling
{
	public class ProjectCompiler
	{
		public ProjectCompilerResult Compile(ProjectFile projectFile)
		{
			var args = new CSharpCompilerArgsBuilder()
				.Build();

			var csc = new CSharpCompiler();
			var cscResult = csc.Compile(args);

			var result = new ProjectCompilerResult();
			return result;
		}
	}
}
