using MessageSevice.Core;
using System.Threading.Tasks;

namespace MessageService.Core.Test.TestObject
{
	class TestMessageSender : IMessageSender<TestMessage>
	{
		public void Send(TestMessage message)
		{
			TestMessage.TestMessages.Add(message);
		}
	}
}
