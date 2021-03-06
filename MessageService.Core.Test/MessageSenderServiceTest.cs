﻿using MessageService.Core.Test.TestObject;
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
			Assert.AreEqual(1, TestMessage.TestMessages.Count);
			Assert.AreEqual(testMessage.Title, TestMessage.TestMessages[0].Title);
		}

		[TestMethod]
		public void SendTestMessages()
		{
			var messageSenderService = new MessageSenderService();
			var testMessages = new TestMessage[20];
			for (int i = 0; i < testMessages.Length; i++)
				testMessages[i] = new TestMessage
				{
					Title = $"Test message #{i}"
				};

			messageSenderService.Send<TestMessageSender, TestMessage>(testMessages);

			Thread.Sleep(TimeSpan.FromSeconds(2));
			Assert.AreEqual(testMessages.Length, TestMessage.TestMessages.Count);
		}

		[TestMethod]
		public void ScheduleTestMessage()
		{
			var messageSenderService = new MessageSenderService();
			var testMessage = new TestMessage
			{
				Title = "Test Message"
			};
			messageSenderService.Schedule<TestMessageSender, TestMessage>(testMessage, DateTimeOffset.Now.AddSeconds(-2));

			Thread.Sleep(TimeSpan.FromSeconds(2));
			Assert.AreEqual(1, TestMessage.TestMessages.Count);
			Assert.AreEqual(testMessage.Title, TestMessage.TestMessages[0].Title);
		}

		[TestMethod]
		public void ScheduleMessages()
		{
			var messageSenderService = new MessageSenderService();
			var testMessages = new TestMessage[20];
			for (int i = 0; i < testMessages.Length; i++)
				testMessages[i] = new TestMessage
				{
					Title = $"Test message #{i}"
				};

			messageSenderService.Schedule<TestMessageSender, TestMessage>(testMessages, DateTimeOffset.Now.AddSeconds(-2));

			Thread.Sleep(TimeSpan.FromSeconds(2));
			Assert.AreEqual(testMessages.Length, TestMessage.TestMessages.Count);
		}
	}
}
