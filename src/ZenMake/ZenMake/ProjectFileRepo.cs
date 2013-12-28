using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ZenMake
{
	public class ProjectFileRepo
	{
		public ProjectFile Load(Stream stream, string filepath)
		{
			using (var reader = new StreamReader(stream))
			{
				using (var jsonReader = new JsonTextReader(reader))
				{
					var serializer = new JsonSerializer();
					var data = serializer.Deserialize<ProjectFileData>(jsonReader);
					var pf = data.ToProjectFile(filepath);
					return pf;	
				}
			}
		}

		public void Save(ProjectFile projectFile, Stream stream)
		{
			using (var writer = new StreamWriter(stream))
			{
				using (var jsonWriter = new JsonTextWriter(writer))
				{
					var serializer = new JsonSerializer();
					serializer.Formatting = Formatting.Indented;
					var data = projectFile.ToData();
					serializer.Serialize(jsonWriter, data);		
				}
			}
		}
	}
}