using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSevice.Core
{
	internal class HangFireServer
	{
		private static readonly Lazy<HangFireServer> _singleInstance = new Lazy<HangFireServer>(() => new HangFireServer());
		public static HangFireServer Instance => _singleInstance.Value;

		private bool _isRuning = false;
		private HangFireServer()
		{

		}

		public void Start()
		{
			if (!_isRuning)
			{
				Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();
				new BackgroundJobServer();
			}
		}

	}
}
