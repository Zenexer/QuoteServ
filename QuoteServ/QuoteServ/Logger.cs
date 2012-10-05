using System;
using System.IO;


namespace QuoteServ
{
	public sealed class Logger : IDisposable
	{
		private static Logger Singleton;

		private StreamWriter Tx;

		public Logger(FileInfo logFile)
		{
			Program.Exiting += Program_Exiting;

			try
			{
				if (logFile.Exists)
				{
					Tx = logFile.AppendText();
				}
				else
				{
					Tx = logFile.CreateText();
				}
			}
			catch (Exception ex)
			{
				Error("Log IO error: {0}", ex.Message);
				Program.Exit(ExitCodes.LogIOError);
				return;
			}

			Tx.NewLine = Environment.NewLine;
		}

		~Logger()
		{
			if (Tx != null)
			{
				Dispose();
			}
		}

		#region IDisposable implementation

		public void Dispose()
		{
			try
			{
				if (Tx != null)
				{
					Tx.Dispose();
					Tx = null;
				}
			}
			catch
			{
			}
		}

		#endregion
		
		private void Program_Exiting(object sender, EventArgs e)
		{
			Dispose();
		}

		private void Log(string level, string format, object[] args)
		{
			string message = string.Format(format, args);
			message = string.Format("[{0:yyyy/MM/dd HH:mm:ss.fff} > {1}]  {2}", DateTime.UtcNow, level, message);

			if (Tx == null)
			{
				Console.WriteLine(message);
			}
			else
			{
				Tx.WriteLine(message);
				Tx.Flush();
			}
		}
		
		public void Info(string format, params object[] args)
		{
			Log("INFO", format, args);
		}
		
		public void Warning(string format, params object[] args)
		{
			Log("WARN", format, args);
		}
		
		public void Error(string format, params object[] args)
		{
			Log("!ERR", format, args);
		}
		
		public static void Info(string format, params object[] args)
		{
			Singleton.Info(format, args);
		}
		
		public static void Warning(string format, params object[] args)
		{
			Singleton.Warning(format, args);
		}
		
		public static void Error(string format, params object[] args)
		{
			Singleton.Error(format, args);
		}
	}
}

