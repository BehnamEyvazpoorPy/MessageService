using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MessageSevice.Core
{
	public class GlobalConfiguration
	{
		public static Configuration Configuration { get; } = new Configuration();
	}
}
