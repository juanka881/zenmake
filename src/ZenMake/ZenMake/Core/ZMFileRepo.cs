using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ZenMake.Core
{
	public class ZMFileRepo
	{
		public ZMFile Load(Stream stream, string filepath)
		{
			using (var reader = new StreamReader(stream))
			{
				using (var jsonReader = new JsonTextReader(reader))
				{
					var serializer = new JsonSerializer();
					var data = serializer.Deserialize<ZMFileData>(jsonReader);
					var fullpath = Path.GetFullPath(filepath);
					var pf = data.ToZMFile(fullpath);
					return pf;	
				}
			}
		}

		public void Save(ZMFile zmFile, Stream stream)
		{
			using (var writer = new StreamWriter(stream))
			{
				using (var jsonWriter = new JsonTextWriter(writer))
				{
					var serializer = new JsonSerializer();
					serializer.Formatting = Formatting.Indented;
					var data = zmFile.ToData();
					serializer.Serialize(jsonWriter, data);		
				}
			}
		}
	}
}