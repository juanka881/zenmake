using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace ZenMake.Core
{
	public class ZMLogger
	{
		private readonly Logger log;

		public ZMLogger(Logger log)
		{
			if (log == null)
				throw new ArgumentNullException("log");

			this.log = log;
		}

		public void Info(string msg)
		{
			this.log.Info(msg);
		}
	}
}