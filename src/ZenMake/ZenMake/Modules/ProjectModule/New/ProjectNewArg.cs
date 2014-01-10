using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectNewArg : RequestArg
	{
		public ProjectNewArg(string projectFilename) : base(projectFilename)
		{
			
		}
	}
}