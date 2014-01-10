using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ZenMake.Exceptions
{
	[Serializable]
	public class HandlerArgCastException : Exception
	{
		public HandlerArgCastException()
		{
		}

		public HandlerArgCastException(string message) : base(message)
		{
		}

		public HandlerArgCastException(string message, Exception inner) : base(message, inner)
		{
		}

		protected HandlerArgCastException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}

		public static HandlerArgCastException Get(object arg, Type argType)
		{
			var ex = new HandlerArgCastException("Unable to cast arg object to type");

			ex.Data["arg-type"] = arg == null ? arg.GetType().ToString() : string.Empty;
			ex.Data["expected-arg-type"] = argType.ToString();

			return ex;
		}
	}
}