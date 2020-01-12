using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Core
{
	public class Configuration : IConfiguration
	{
		internal Dictionary<string, IConfiguration> Configurations { get; } = new Dictionary<string, IConfiguration>();

	}
}
