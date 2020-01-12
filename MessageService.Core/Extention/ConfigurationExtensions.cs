using MessageService.Core.Default;
using MessageService.Core.Default.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageService.Core
{
	public static class ConfigurationExtensions
	{
		public static Configuration AddMailServer(this Configuration configuration, Action<MailServerConfiguration> func)
		{
			var emailConfig = new MailServerConfiguration();
			func(emailConfig);
			configuration.Configurations.Add(Constants.DefaulMailServerConfigName, emailConfig);
			return configuration;
		}

		public static Configuration AddMailServer(this Configuration configuration, string name, Action<MailServerConfiguration> func)
		{
			var emailConfig = new MailServerConfiguration();
			func(emailConfig);
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

	}
}
