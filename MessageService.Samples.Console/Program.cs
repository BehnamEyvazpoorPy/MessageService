using MessageService.Core;
using MessageService.Core.Default;

namespace MessageService.Samples.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("The mail sender service has started...");

			GlobalConfiguration.Configuration.AddMailServer(x =>
			{

			}).AddConsole().HangfireConfig(x =>
			{
				x.RetryCount = 5;
				x.ConnectionString = "Server=.;Initial catalog=MessageServiceTestDatabase;user id=sa;password=12345";
			});

			var messageSenderService = new MessageSenderService();

			var email = new Email()
			{
				Subject = "Test email"
			};

			messageSenderService.Send<EmailMessageSender, Email>(email);

			var key = System.Console.ReadKey();

		}
	}
}
