using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ZenMake.Tests
{
	[TestFixture]
    public class CommandLineParserTest
    {
		[Test]
		public void can_new()
		{
			var parser = new CommandLineParser();
		}

		[TestCase("")]
		[TestCase(null)]
		public void can_parse_empty_str(string str)
		{
			var parser = new CommandLineParser();
			var args = parser.GetArguments(str);
			Assert.AreEqual(false, args.Any());
		}
		
		[TestCase("test1 test2")]
		public void can_parse_symbols(string str)
		{
			var parser = new CommandLineParser();
			var args = parser.GetArguments(str).ToList();
			Assert.AreEqual(2, args.Count);
			Assert.AreEqual("test1", args[0]);
			Assert.AreEqual("test2", args[1]);
		}

		[TestCase("\"test1\" \"test2\"", TestName = "double quotes")]
		[TestCase("\"test1\" \"test2\"", TestName = "single quotes")]
		public void can_parse_string(string str)
		{
			var parser = new CommandLineParser();
			var args = parser.GetArguments(str).ToList();
			Assert.AreEqual(2, args.Count);
			Assert.AreEqual("test1", args[0]);
			Assert.AreEqual("test2", args[1]);
		}

		[Test]
		public void can_parse_string_with_quote()
		{
			var parser = new CommandLineParser();
			var args = parser.GetArguments("\"hello there \\\"juanka\\\"\"").ToList();
			Assert.AreEqual("hello there \"juanka\"", args[0]);
		}

		[TestCase("{}", ExpectedResult = "{}", TestName = "empty object")]
		[TestCase("{ age: 5 }", ExpectedResult = "{ age: 5 }", TestName = "object with property")]
		[TestCase("{ name: \"ruby\" }", ExpectedResult = "{ name: \"ruby\" }", TestName = "object property string")]
		public string can_parse_object(string str)
		{
			var parser = new CommandLineParser();
			var arg = parser.GetArguments(str).ToList().FirstOrDefault();
			return arg;
		}

		[Test]
		public void can_parse_all()
		{
			var parser = new CommandLineParser();
			var str = "kb a7 db/bounce { db: 'localhost', store: \"c:\\program files\\mssqlserver\\db.dat\"}";
			var args = parser.GetArguments(str).ToList();
			Assert.AreEqual("kb", args[0]);
			Assert.AreEqual("a7", args[1]);
			Assert.AreEqual("db/bounce", args[2]);
			Assert.AreEqual("{ db: 'localhost', store: \"c:\\program files\\mssqlserver\\db.dat\"}", args[3]);
		}
    }
}
