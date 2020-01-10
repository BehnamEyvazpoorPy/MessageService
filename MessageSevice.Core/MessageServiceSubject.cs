using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessageSevice.Core
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
			_subscribers.ForEach((subscriber) => subscriber.Update(context));
		}
	}
}
