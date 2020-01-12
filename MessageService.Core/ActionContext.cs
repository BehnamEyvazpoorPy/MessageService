using System;

namespace MessageService.Core
{
	public class ActionContext
	{
		public string Action { get; set; }

		public Type MessageType { get; set; }

		public Type MessageSenderType { get; set; }

		public string JobId { get; set; }

		public string Data { get; set; }

		public DateTime ActionTime { get; set; }

		public Exception Error { get; set; }
	}
}