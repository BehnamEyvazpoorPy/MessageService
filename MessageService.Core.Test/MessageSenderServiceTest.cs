using MessageService.Core.Test.TestObject;
using MessageSevice.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MessageService.Core.Test
{
	[TestClass]
	public class MessageSenderServiceTest
	{
		[TestMethod]
		public void SendTestMessage()
		{
			var messageSenderService = new MessageSenderService();
			var testMessage = new TestMessage
			{
				Title = "Test Message"
			};
			messageSenderService.Send<TestMessageSender, TestMessage>(testMessage);

			Thread.Sleep(TimeSpan.FromSeconds(2));
			Assert.AreEqual(TestMessage.TestMessages.Count, 1);
			Assert.AreEqual(TestMessage.TestMessages[0].Title, testMessage.Title);
		}

		[TestMethod]
		public void SendTestMessages() {
			var messageSenderService = new MessageSenderService();
			var testMessages = new TestMessage[20];
			for (int i = 0; i < testMessages.Length; i++)
				testMessages[i] = new TestMessage
				{
					Title = $"Test message #{i}"
				};

			messageSenderService.Send<TestMessageSender, TestMessage>(testMessages);

			Thread.Sleep(TimeSpan.FromSeconds(2));
			Assert.AreEqual(TestMessage.TestMessages.Count, testMessages.Length);
		}
	}
}
