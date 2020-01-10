using System.Collections.Generic;

namespace MessageService.Core.Test.TestObject
{
	internal class TestMessage
	{
		public static List<TestMessage> TestMessages = new List<TestMessage>();
		public string Title { get; set; }
	}
}