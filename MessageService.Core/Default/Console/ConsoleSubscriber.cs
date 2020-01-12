using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core.Default.Console
{
	internal class ConsoleSubscriber : ISubscriber
	{
		public void Update(ActionContext context)
		{
			ConsoleLogger.WriteInfo(context);
		}
	}
}
