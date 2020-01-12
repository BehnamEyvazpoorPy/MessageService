using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core.Default
{
	public class Email
	{
		public List<EmailAddress> From { get; set; }
		public List<EmailAddress> To { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public List<EmailAttachment> Attachments { get; set; }
		public string MailServerConfigName { get; set; }
	}

	public class EmailAttachment {
		public string Name { get; set; }
		public string ContentType { get; set; }
		public byte[] Content { get; set; }
	}

	public class EmailAddress {
		public string Name { get; set; }
		public string Address { get; set; }
	}
}
