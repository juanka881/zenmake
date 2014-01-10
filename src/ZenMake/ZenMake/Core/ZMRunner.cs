using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Autofac;
using NLog;
using ZenMake.Exceptions;
using ZenMake.Modules.ProjectModule;
using ZenMake.Modules.RunModule;

namespace ZenMake.Core
{
	public class ZMRunner
	{
		private readonly IContainer container;
		private readonly ZMLogger log;

		public ZMRunner()
		{
			this.container = this.GetContainer();
			this.log = this.container.Resolve<ZMLogger>();
		}

		private void ShowHelp()
		{
			this.log.Info("!help goes here");
		}

		public void Run(string requestString)
		{
			var tokenizer = new RequestTokenizer();
			var tokens = tokenizer.GetTokens(requestString).Skip(1).ToList();

			if (tokens.Count == 0)
			{
				this.ShowHelp();
				return;
			}

			var request = tokens.FirstOrDefault();
			tokens.RemoveAt(0);

			var parser = this.GetRequestParser(request);

			var arg = parser.GetArg(tokens);

			if(arg == null)
				throw new NullReferenceException("request parser returned a null arg");

			var handler = this.GetHandlerForArg(arg);

			handler.Handle(arg);
		}

		private IRequestParser GetRequestParser(string request)
		{
			if (string.IsNullOrWhiteSpace(request))
				throw new ArgumentException("request is empty. request is expected to have a non-empty string value");

			var parser = null as object;

			if (!this.container.TryResolveNamed(request, typeof(IRequestParser), out parser))
			{
				throw RequestParserNotFoundException.Get(request);
			}

			return parser as IRequestParser;
		}

		private IHandler GetHandlerForArg(object arg)
		{
			if (arg == null)
				throw new ArgumentNullException("arg");

			var handler = null as object;

			if (!this.container.TryResolveKeyed(arg.GetType(), typeof(IHandler), out handler))
				throw HandlerNotFoundException.Get(arg);

			return handler as IHandler;
		}

		private IContainer GetContainer()
		{
			var builder = new ContainerBuilder();

			// core services
			builder.Register(c => new ZMLogger(LogManager.GetLogger("zen-make"))).AsSelf();
			builder.Register(c => new ZMFileRepo()).AsSelf();

			// parsers
			builder.Register(c => new ProjectRequestParser()).Named<IRequestParser>("p");
			builder.Register(c => new RunRequestParser()).Named<IRequestParser>("r");

			// handlers
			// project
			builder.RegisterType<ProjectNewHandler>().Keyed<IHandler>(typeof(ProjectNewArg));
			builder.RegisterType<ProjectAddHandler>().Keyed<IHandler>(typeof(ProjectAddArg));
			builder.RegisterType<ProjectRemoveHandler>().Keyed<IHandler>(typeof(ProjectRemoveArg));

			// runner
			builder.RegisterType<RunHandler>().Keyed<IHandler>(typeof(RunArg));
			
			return builder.Build();
		}
	}
}
