using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZenMake.CommandLine;

namespace ZenMake.Tests
{
	[TestFixture]
	public class CommandLineRunnerTest
	{
		[Test]
		public void can_run()
		{
			var runner = new CommandLineRunner();
			runner.Run("zm r db/c db/run \"foo navi\"");
		}
	}
}