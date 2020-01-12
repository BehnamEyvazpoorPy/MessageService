using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageService.Core
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
				if (!GlobalConfiguration.Configuration.Configurations.Keys.Contains("Hangfire"))
					Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();

				new BackgroundJobServer();
			}
		}

	}
}
