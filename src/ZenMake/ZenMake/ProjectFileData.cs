using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ZenMake
{
	public class ProjectFileData
	{
		[JsonProperty("source-files")]
		public IList<string> SourceFiles { get; set; }

		[JsonProperty("reference-files")]
		public IList<string> ReferenceFiles { get; set; }

		public ProjectFileData()
		{
			this.SourceFiles = new List<string>();
			this.ReferenceFiles = new List<string>();
		}
	}
}