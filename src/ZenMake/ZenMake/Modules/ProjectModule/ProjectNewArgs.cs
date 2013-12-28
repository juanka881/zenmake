using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectNewArgs : CommandArgs
	{
		public ProjectNewArgs(string projectFilename) : base(projectFilename)
		{
			
		}
	}
}