using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ZenMake.Helpers;

namespace ZenMake.Targets
{
	public class TargetFinder
	{
		private readonly LispyNamer lispyNamer;

		public TargetFinder()
		{
			this.lispyNamer = new LispyNamer();
		}

		public IEnumerable<Target> GetTasks(Assembly assembly)
		{
			if (assembly == null)
				throw new ArgumentNullException("assembly");

			var methodFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;

			var taskMethods = from type in assembly.GetTypes()
				from method in type.GetMethods(methodFlags)
				let attr = this.TryGetTaskAttribute(method)
				where attr != null
				select new { method, attr };

			var tasks = from taskMethod in taskMethods
				let name = this.GetTaskName(taskMethod.attr, taskMethod.method)
				let method = taskMethod.method
				select new Target(name, method);

			return tasks;
		}

		private string GetTaskNamespace(MethodInfo method)
		{
			if (method == null)
				throw new ArgumentNullException("method");

			var type = method.DeclaringType;

			var typeNamespace = type.Namespace ?? string.Empty;

			var fixedTypeNamespace = typeNamespace.Replace('.', '/');

			var ns = this.lispyNamer.GetName(fixedTypeNamespace);

			return ns;
		}

		private string GetTaskName(TargetAttribute attr, MethodInfo method)
		{
			if (attr == null)
				throw new ArgumentNullException("attr");

			if (method == null)
				throw new ArgumentNullException("method");

			var type = method.DeclaringType;

			var className = this.lispyNamer.GetName(type.Name);

			var attrName = this.lispyNamer.GetName(attr.Name);

			var taskName = string.Format("{0}/{1}", className, attrName);

			return taskName;
		}

		private TargetAttribute TryGetTaskAttribute(MethodInfo methodInfo)
		{
			if (methodInfo == null)
				throw new ArgumentNullException("methodInfo");

			var attr = methodInfo.GetCustomAttributes(typeof(TargetAttribute), false)
				.OfType<TargetAttribute>()
				.FirstOrDefault();

			return attr;
		}
	}
}