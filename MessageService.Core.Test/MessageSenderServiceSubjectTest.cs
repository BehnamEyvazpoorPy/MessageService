using MessageService.Core.Test.TestObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace MessageService.Core.Test
{
	[TestClass]
	public class MessageSenderServiceSubjectTest
	{
		[TestMethod]
		public void EnqueueSubjectTest()
		{
			var subscriber = new TestSubscriber();
			MessageSenderService.EnqueueSubject.Subscribe(subscriber);

			var messageSenderService = new MessageSenderService();
			var testMessage = new TestMessage
			{
				Title = "Test Message"
			};
			messageSenderService.Send<TestMessageSender, TestMessage>(testMessage);

			Thread.Sleep(TimeSpan.FromSeconds(1));
			Assert.AreEqual(1, TestSubscriber.ActionContexts.Count);
			var actionContext = TestSubscriber.ActionContexts[0];
			var data = JsonConvert.DeserializeObject<TestMessage>(actionContext.Data);
			Assert.AreEqual(testMessage.Title, data.Title);
			Assert.AreEqual("Message Enqueue", actionContext.Action);
			Assert.AreEqual(typeof(TestMessageSender), actionContext.MessageSenderType);
			Assert.AreEqual(typeof(TestMessage), actionContext.MessageType);
			Assert.AreNotEqual(null, actionContext.JobId);
		}

		[TestMethod]
		public void ExecuteSubjectTest()
		{
			var subscriber = new TestSubscriber();
			MessageSenderService.ExecuteSubject.Subscribe(subscriber);

			var messageSenderService = new MessageSenderService();
			var testMessage = new TestMessage
			{
				Title = "Test Message"
			};
			messageSenderService.Send<TestMessageSender, TestMessage>(testMessage);

			Thread.Sleep(TimeSpan.FromSeconds(1));
			Assert.AreEqual(1, TestSubscriber.ActionContexts.Count);
			var actionContext = TestSubscriber.ActionContexts[0];
			var data = JsonConvert.DeserializeObject<TestMessage>(actionContext.Data);
			Assert.AreEqual(testMessage.Title, data.Title);
			Assert.AreEqual("Message Sent", actionContext.Action);
			Assert.AreEqual(typeof(TestMessageSender), actionContext.MessageSenderType);
			Assert.AreEqual(typeof(TestMessage), actionContext.MessageType);
		}
	}
}
