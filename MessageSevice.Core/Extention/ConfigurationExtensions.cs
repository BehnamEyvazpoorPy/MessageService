using MessageSevice.Core.Default;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSevice.Core
{
	public static class ConfigurationExtensions
	{
		public static Configuration AddMailServer(this Configuration configuration, string name, Action<MailServerConfiguration> func)
		{
			var emailConfig = new MailServerConfiguration();
			func(emailConfig);
			configuration.Configurations.Add(name, emailConfig);
			return configuration;
		}

		public static Configuration AddMailServer(this Configuration configuration, Action<MailServerConfiguration> func)
		{
			var emailConfig = new MailServerConfiguration();
			func(emailConfig);
			configuration.Configurations.Add(Constants.DefaulMailServerConfigName, emailConfig);
			return configuration;
		}
	}
}
