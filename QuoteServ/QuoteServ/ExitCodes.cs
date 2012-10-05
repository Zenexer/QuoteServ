using System;


namespace QuoteServ
{
	public enum ExitCodes : int
	{
		Normal = 0,

		// Not errors; action required from user before relaunch
		InitializedConfiguration = -1,
		ConfigurationEditRequired = -2,

		// Errors
		ConfigurationIOError = 1,
		LogIOError = 2,
	}
}
