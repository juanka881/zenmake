using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ZenMake
{
	public class ProjectFile
	{
		public static readonly string DefaultFilename = "project.zm";

		public string Filepath { get; private set; }

		public string Name { get; private set; }

		public string Directory { get; private set; }

		public IList<string> SourceFiles { get; private set; }

		public IList<string> ReferenceFiles { get; private set; }

		public ProjectFile(string filepath, IEnumerable<string> sourceFiles, IEnumerable<string> referenceFiles)
		{
			if (string.IsNullOrWhiteSpace(filepath))
				throw new ArgumentException("filepath is empty. filepath is expected to have a non-empty string value");

			if (sourceFiles == null)
				throw new ArgumentNullException("sourceFiles");

			if (referenceFiles == null)
				throw new ArgumentNullException("referenceFiles");

			this.Filepath = filepath;
			this.Name = Path.GetFileName(this.Filepath);
			this.SourceFiles = new List<string>(sourceFiles);
			this.ReferenceFiles = new List<string>(referenceFiles);
		}
	}
}