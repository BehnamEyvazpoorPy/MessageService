using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessageSevice.Core
{
	public interface IMessageSender<TMessage>
	{
		/// <summary>
		/// Sends a message
		/// </summary>
		/// <param name="message">Message object</param>
		void Send(TMessage message);

	}
}
