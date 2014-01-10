using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using ZenMake.Exceptions;

namespace ZenMake.Core
{
	public abstract class HandlerBase<T> : IHandler where T : class
	{
		public ZMFileRepo Repo { get; set; }
		public ZMLogger Log { get; set; }

		public HandlerBase(ZMFileRepo repo, ZMLogger log)
		{
			if (repo == null)
				throw new ArgumentNullException("repo");

			if (log == null)
				throw new ArgumentNullException("log");

			this.Repo = repo;
			this.Log = log;
		}

		public void Handle(object arg)
		{
			var typedArg = arg as T;

			if (typedArg == null)
				throw HandlerArgCastException.Get(arg, typeof(T));

			this.HandleCore(typedArg);
		}

		public abstract void HandleCore(T arg);
	}
}