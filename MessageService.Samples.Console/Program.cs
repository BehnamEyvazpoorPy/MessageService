using MessageService.Core;
using MessageService.Core.Default;

namespace MessageService.Samples.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("The mail sender service has started...");

			GlobalConfiguration.Configuration.AddMailServer(x => { 
			
			}).AddConsole();

			var messageSenderService = new MessageSenderService();

			var email = new Email()
			{
				Subject="Test email"
			};

			messageSenderService.Send<EmailMessageSender, Email>(email);

			var key = System.Console.ReadKey();

		}
	}
}
