using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core.Test.TestObject
{
	internal class TestSubscriber : ISubscriber
	{
		internal static List<ActionContext> ActionContexts = new List<ActionContext>();
		public void Update(ActionContext context)
		{
			ActionContexts.Add(context);
		}
	}
}
