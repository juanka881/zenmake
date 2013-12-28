using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public class CommandArgs
	{
		public string ProjectFilename { get; private set; }

		public CommandArgs(string projectFilename)
		{
			if (string.IsNullOrWhiteSpace(projectFilename))
				throw new ArgumentException("projectFilename is empty. projectFilename is expected to have a non-empty string value");

			this.ProjectFilename = projectFilename;
		}
	}
}