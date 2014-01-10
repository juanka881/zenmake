using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Core
{
	public interface IHandler
	{
		void Handle(object args);
	}
}