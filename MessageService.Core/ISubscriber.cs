using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core
{
	public interface ISubscriber
	{
		void Update(ActionContext context);
	}
}
