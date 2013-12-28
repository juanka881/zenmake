using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public interface ICommandArgsParser
	{
		object GetArgs(IList<string> args);
	}
}