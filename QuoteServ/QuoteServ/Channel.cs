using System;


namespace QuoteServ
{
	[Serializable]
	public sealed class Channel : MarshalByRefObject, IEquatable<Channel>
	{
		#region IEquatable implementation

		public bool Equals(Channel other)
		{
			return other.Name == Name;
		}

		#endregion

		public override bool Equals(object obj)
		{
			if (obj is Channel)
			{
				return Equals((Channel)obj);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public override int GetHashCode()
		{
			if (Name == null)
			{
				return 0;
			}
			else
			{
				return Name.GetHashCode();
			}
		}

		public string Name { get; set; }

		public string Key { get; set; }
	}
}

