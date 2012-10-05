using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Xml.Serialization;
using System.IO;


namespace QuoteServ
{
	[Serializable]
	public sealed class ProgramConfiguration : MarshalByRefObject
	{
		private static readonly XmlSerializer Serializer;

		[NonSerialized]
		private FileInfo SerializationFile;

		static ProgramConfiguration()
		{
			Serializer = new XmlSerializer(typeof(ProgramConfiguration), new XmlRootAttribute());
		}
		
		public static ProgramConfiguration Load(FileInfo file)
		{
			using (FileStream fs = file.OpenRead())
			{
				ProgramConfiguration config = Serializer.Deserialize(fs) as ProgramConfiguration;

				if (config != null)
				{
					config.SerializationFile = file;
				}

				return config;
			}
		}

		public void Initialize(FileInfo serializationFile)
		{
			SerializationFile = serializationFile;
			LogFile = "QuoteServ.log";

			Servers = new List<ServerConfiguration>()
			{
				new ServerConfiguration(),
			};
		}

		public void Save()
		{
			// Buffer to memory in case there is an error (don't delete file first).
			using (MemoryStream memory = new MemoryStream())
			{
				Serializer.Serialize(memory, this);

				memory.Position = 0;
				using (FileStream fs = SerializationFile.Create())
				{
					memory.CopyTo(fs);
					fs.Flush();
				}
			}
		}

		public List<ServerConfiguration> Servers { get; set; }

		public string LogFile { get; set; }

		public bool ChangeThisToTrue { get; set; }
	}
}
