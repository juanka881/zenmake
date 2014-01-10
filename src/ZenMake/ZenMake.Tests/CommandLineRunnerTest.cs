using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZenMake.Core;

namespace ZenMake.Tests
{
	[TestFixture]
	public class CommandLineRunnerTest
	{
		[Test]
		public void can_run()
		{
			var runner = new ZMRunner();
			runner.Run("zm p new");
			runner.Run("zm r db/c db/run \"foo navi\"");
		}
	}
}