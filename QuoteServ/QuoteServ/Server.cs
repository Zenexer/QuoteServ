using System;


namespace QuoteServ
{
	public sealed class Server
	{
		public Server(ServerConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void Run()
		{
		}

		public ServerConfiguration Configuration { get; private set; }
	}
}

