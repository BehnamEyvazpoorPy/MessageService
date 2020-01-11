using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSevice.Core.Default
{
	public class MailServerConfiguration : IConfiguration
	{
		public string SmtpServer { get; set; }
		public int SmtpPort { get; set; }
		public string SmtpUsername { get; set; }
		public string SmtpPassword { get; set; }
	}
}
