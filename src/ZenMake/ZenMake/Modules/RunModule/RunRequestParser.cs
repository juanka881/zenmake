using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ZenMake.Core;

namespace ZenMake.Modules.RunModule
{
	public class RunRequestParser : IRequestParser
	{
		public object GetArg(IList<string> args)
		{
			if(args.Count == 0)
				throw new Exception("too few arguments");

			var first = args.FirstOrDefault();
			
			var projectFilename = ZMFile.DefaultFilename;

			if (first.EndsWith(".zm"))
			{
				projectFilename = first;
				args.RemoveAt(0);
			}

			var targets = args.Where(x => !x.StartsWith("{")).ToList();
			var parameterString = args.FirstOrDefault(x => x.StartsWith("{")) ?? string.Empty;
			var parameters = new JObject();

			if(!string.IsNullOrWhiteSpace(parameterString))
				parameters = JObject.Parse(parameterString);

			var result = new RunArg(projectFilename, targets, parameters);
			return result;
		}
	}
}
