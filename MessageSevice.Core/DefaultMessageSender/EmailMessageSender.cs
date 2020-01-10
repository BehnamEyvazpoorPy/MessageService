using MessageSevice.Core.MessageModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessageSevice.Core.DefaultMessageSender
{
	public class EmailMessageSender : IMessageSender<Email>
	{
		public void Send(Email message)
		{
			throw new NotImplementedException();
		}
	}
}
