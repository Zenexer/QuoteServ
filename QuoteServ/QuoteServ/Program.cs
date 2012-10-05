using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;


namespace QuoteServ
{
	public static class Program
	{
		private const string CONFIGURATION_FILE = "Configuration.xml";

		public static event EventHandler<EventArgs> Exiting;

		[MTAThread]
		public static void Main(string[] args)
		{
			if (!ReadConfiguration())
			{
				return;
			}

			Servers = new Server[Configuration.Servers.Count];
			for (int i = 0; i < Configuration.Servers.Count; i++)
			{
				try
				{
					Servers[i] = new Server(Configuration.Servers[i]);
					Logger.Info("Server {0} instantiated.", Servers[i].Configuration.Id);
				}
				catch (Exception ex)
				{
					Logger.Error("Could not instantiate server {0}: {1}", Configuration.Servers[i].Id, ex.Message);
				}
			}

			Task[] tasks = new Task[Servers.Length];
			for (int i = 0; i < Servers.Length; i++)
			{
				if (Servers[i] == null)
				{
					continue;
				}

				Task.Factory.StartNew(() => {
					Logger.Info("Server {0} task running.", Servers[i].Configuration.Id);

					try
					{
						Servers[i].Run();
						Logger.Info("Server {0} stopped normally.", Servers[i].Configuration.Id);
					}
					catch (Exception ex)
					{
						Logger.Info("Server {0} aborted: {1}", Servers[i].Configuration.Id, ex.Message)
					}
				});
			}

			Logger.Info("Waiting on all server tasks.");
			Task.WaitAll(tasks);

			Logger.Info("Exiting normally.");
			Exit(ExitCodes.Normal);
		}

		public static void Exit(ExitCodes reason)
		{
			if (Exiting != null)
			{
				EventHandler<EventArgs>[] delegates = (EventHandler<EventArgs>[])Exiting.GetInvocationList();
				if (delegates != null)
				{
					EventArgs e = new EventArgs();
					for (int i = 0; i < delegates.Length; i++)
					{
						try
						{
							delegates[i].Invoke(null, e);
						}
						catch
						{
						}
					}
				}
			}

			Environment.Exit((int)reason);
		}

		private static bool ReadConfiguration()
		{
			try
			{
				FileInfo file = new FileInfo(CONFIGURATION_FILE);
				ProgramConfiguration config;
				if (file.Exists)
				{
					config = ProgramConfiguration.Load(file);

					if (config.ChangeThisToTrue)
					{
						Configuration = config;
						return true;
					}
					else
					{
						Logger.Warning("Initial configuration not completely edited. \"ChangeThisToTrue\" is false.");
						Exit(ExitCodes.ConfigurationEditRequired);
						return false;
					}
				}
				else
				{
					config = new ProgramConfiguration();
					config.Initialize(file);
					config.Save();

					Logger.Info("Initial configuration created.  Edit it, then re-run program.");
					Exit(ExitCodes.InitializedConfiguration);
					return false;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Unable to read/write configuration file: {0}", ex.Message);
				Exit(ExitCodes.ConfigurationIOError);
				return false;
			}
		}

		public ProgramConfiguration Configuration { get; private set; }

		public Server[] Servers { get; private set; }
	}
}
