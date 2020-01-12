using MessageService.Core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MessageService.Core.Test.TestObject
{
	class TestMessageSender : IMessageSender<TestMessage>
	{
		public void Send(TestMessage message)
		{
			TestMessage.TestMessages.Add(message);
			var actionContext = new ActionContext
			{
				Action = "Message Sent",
				ActionTime = DateTime.Now,
				Data = JsonConvert.SerializeObject(message),
				MessageSenderType = typeof(TestMessageSender),
				MessageType = typeof(TestMessage)
			};
			MessageSenderService.ExecuteSubject.Notify(actionContext);
		}
	}
}
