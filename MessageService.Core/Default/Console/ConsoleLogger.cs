using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MessageService.Core.Default.Console
{
	internal static class ConsoleLogger
	{
		private static readonly object ConsoleWriterLock = new object();
		public static void WriteInfo(ActionContext actionContext)
		{
			lock (ConsoleWriterLock)
			{
				var defaultColor = ForegroundColor;
				if (actionContext.Error != null)
				{
					ForegroundColor = ConsoleColor.Red;
					WriteLine($"Error on {actionContext.Action} - time {actionContext.ActionTime}");
					ForegroundColor = defaultColor;
					WriteLine($"Data: {actionContext.Data}");
					WriteLine($"Error message: {actionContext.Error.Message}");
					return;
				}

				ForegroundColor = ConsoleColor.Green;
				WriteLine($"{actionContext.Action} has done - time {actionContext.ActionTime}");
				ForegroundColor = defaultColor;
				WriteLine($"Data: {actionContext.Data}");
			}
		}
	}
}
