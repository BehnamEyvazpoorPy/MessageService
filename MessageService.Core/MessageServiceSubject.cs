using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.Core
{
	public class MessageServiceSubject
	{
		private List<ISubscriber> _subscribers = new List<ISubscriber>();

		public void Subscribe(ISubscriber subscriber)
		{
			_subscribers.Add(subscriber);
		}

		public void UnSubscribe(ISubscriber subscriber)
		{
			_subscribers.Remove(subscriber);
		}

		public void Notify(ActionContext context)
		{
			_subscribers.ForEach((subscriber) => Task.Factory.StartNew(() => subscriber.Update(context)));
		}

		internal IEnumerable<ISubscriber> Subscribers => _subscribers;
	}
}
