using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public interface IRequestParser
	{
		object GetArg(IList<string> tokens);
	}
}