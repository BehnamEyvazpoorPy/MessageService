using MessageService.Core.Default;
using MessageService.Core.Default.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangfire;
using Hangfire.MemoryStorage;

namespace MessageService.Core
{
	public static class ConfigurationExtensions
	{
		public static Configuration AddMailServer(this Configuration configuration, Action<MailServerConfiguration> action)
		{
			var emailConfig = new MailServerConfiguration();
			action(emailConfig);
			configuration.Configurations.Add(Constants.DefaulMailServerConfigName, emailConfig);
			return configuration;
		}

		public static Configuration AddMailServer(this Configuration configuration, string name, Action<MailServerConfiguration> action)
		{
			var emailConfig = new MailServerConfiguration();
			action(emailConfig);
			configuration.Configurations.Add(name, emailConfig);
			return configuration;
		}

		public static Configuration AddConsole(this Configuration configuration)
		{
			// Check if another console already has been added
			var subscribers = (List<ISubscriber>)MessageSenderService.EnqueueSubject.Subscribers;
			subscribers.AddRange((List<ISubscriber>)MessageSenderService.ExecuteSubject.Subscribers);

			if (subscribers.Where(s => s is ConsoleSubscriber).Count() > 0)
				throw new InvalidOperationException("Console already has been added.");

			var consoleSubscriber = new ConsoleSubscriber();
			MessageSenderService.EnqueueSubject.Subscribe(consoleSubscriber);
			MessageSenderService.ExecuteSubject.Subscribe(consoleSubscriber);
			return configuration;
		}

		public static Configuration HangfireConfig(this Configuration configuration, Action<HangfireConfiguration> action)
		{

			var hangfireConfig = new HangfireConfiguration();
			action(hangfireConfig);
			GlobalConfiguration.Configuration.Configurations.TryAdd("Hangfire", configuration);
			if (!string.IsNullOrEmpty(hangfireConfig.ConnectionString))
				Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(hangfireConfig.ConnectionString);
			else
				Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();

			if (hangfireConfig.RetryCount != null)
				GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = hangfireConfig.RetryCount.Value });

			return configuration;
		}

	}
}
