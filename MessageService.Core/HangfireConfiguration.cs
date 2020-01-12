using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core
{
	public class HangfireConfiguration : IConfiguration
	{
		public string ConnectionString { get; set; }
		public int? RetryCount { get; set; }
	}
}
