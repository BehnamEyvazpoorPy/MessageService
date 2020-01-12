using Hangfire;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace MessageService.Core
{
	public class MessageSenderService
	{
		public MessageSenderService()
		{
			//TODO: max degree of parallelism option
			HangFireServer.Instance.Start();
		}

		public static MessageServiceSubject EnqueueSubject { get; } = new MessageServiceSubject();
		public static MessageServiceSubject ExecuteSubject { get; } = new MessageServiceSubject();

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TMessageSender"></typeparam>
		/// <typeparam name="TMessage"></typeparam>
		/// <param name="message"></param>
		/// <returns></returns>
		public void Send<TMessageSender, TMessage>(TMessage message) where TMessageSender : IMessageSender<TMessage>
		{
			var sender = Activator.CreateInstance<TMessageSender>();
			var jobId = BackgroundJob.Enqueue(() => sender.Send(message));

			// Notify message has added to the send queue
			var actionContext = new ActionContext
			{
				Action = "Message Enqueue",
				ActionTime = DateTime.Now,
				Data = JsonConvert.SerializeObject(message),
				JobId = jobId,
				MessageSenderType = typeof(TMessageSender),
				MessageType = typeof(TMessage)
			};
			EnqueueSubject.Notify(actionContext);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TMessageSender"></typeparam>
		/// <typeparam name="TMessage"></typeparam>
		/// <param name="messages"></param>
		/// <returns></returns>
		public void Send<TMessageSender, TMessage>(TMessage[] messages) where TMessageSender : IMessageSender<TMessage>
		{
			var sender = Activator.CreateInstance<TMessageSender>();

			foreach (var message in messages)
			{
				var jobId = BackgroundJob.Enqueue(() => sender.Send(message));

				// Notify message has added to the send queue
				var actionContext = new ActionContext
				{
					Action = "Enqueue message",
					ActionTime = DateTime.Now,
					Data = JsonConvert.SerializeObject(message),
					JobId = jobId,
					MessageSenderType = typeof(TMessageSender),
					MessageType = typeof(TMessage)
				};
				EnqueueSubject.Notify(actionContext);
			}
		}
	}
}
