using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSevice.Core
{
	public interface ISubscriber
	{
		void Update(ActionContext context);
	}
}
