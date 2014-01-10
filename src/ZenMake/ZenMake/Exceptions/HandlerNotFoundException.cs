using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ZenMake.Exceptions
{
	[Serializable]
	public class HandlerNotFoundException : Exception
	{
		public HandlerNotFoundException()
		{
		}

		public HandlerNotFoundException(string message) : base(message)
		{
		}

		public HandlerNotFoundException(string message, Exception inner) : base(message, inner)
		{
		}

		protected HandlerNotFoundException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}

		public static HandlerNotFoundException Get(object arg)
		{
			var ex = new HandlerNotFoundException("Unable to get handler for argument");

			ex.Data["arg"] = arg != null ? arg.ToString() : string.Empty;
			
			return ex;
		}
	}
}