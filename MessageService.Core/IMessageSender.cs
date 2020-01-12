namespace MessageService.Core
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
