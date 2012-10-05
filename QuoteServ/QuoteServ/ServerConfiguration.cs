using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace QuoteServ
{
	[Serializable]
	public sealed class ServerConfiguration : MarshalByRefObject, IEquatable<ServerConfiguration>
	{
		public void Initialize()
		{
			Channels = new List<Channel>();
		}

		#region IEquatable implementation

		public bool Equals(ServerConfiguration other)
		{
			return other.Id == Id;
		}

		#endregion

		public override string ToString()
		{
			return string.Format("[ServerConfiguration: Id={0}]", Id);
		}

		public override bool Equals(object obj)
		{
			if (obj is ServerConfiguration)
			{
				return Equals((ServerConfiguration)obj);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			if (Id == null)
			{
				return 0;
			}
			else
			{
				return Id.GetHashCode();
			}
		}

		public string Id { get; set; }

		public string Host { get; set; }

		public ushort Port { get; set; }

		public bool Secure { get; set; }

		public string Nickname { get; set; }

		public string Username { get; set; }

		public string Gecos { get; set; }

		public List<Channel> Channels { get; set; }

		public Regex IdentifyTrigger { get; set; }

		public Regex GhostedTrigger { get; set; }

		public string IdentifyCommand { get; set; }

		public string GhostCommand { get; set; }
	}
}
