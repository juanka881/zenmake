using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ZenMake.Core
{
	public interface ICommandHandler
	{
		void Handle(object args);
	}

	public abstract class CommandHandler<T> : ICommandHandler where T : class
	{
		public void Handle(object args)
		{
			var typedArgs = args as T;

			if(typedArgs == null)
				throw new Exception(string.Format("unable to cast args to type of {0}", typeof(T)));

			this.HandleCore(typedArgs);
		}

		public abstract void HandleCore(T args);
	}
}