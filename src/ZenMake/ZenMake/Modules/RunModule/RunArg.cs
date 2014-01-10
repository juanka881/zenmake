using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ZenMake.Core;

namespace ZenMake.Modules.RunModule
{
	public class RunArg : RequestArg
	{
		public IList<string> Targets { get; private set; }
		public JObject Parameters { get; private set; }

		public RunArg(string projectFilename, IEnumerable<string> targets, JObject parameters)
			: base(projectFilename)
		{
			if (targets == null)
				throw new ArgumentNullException("targets");

			if (parameters == null)
				throw new ArgumentNullException("parameters");

			this.Targets = new List<string>(targets);
			this.Parameters = parameters;
		}
	}
}