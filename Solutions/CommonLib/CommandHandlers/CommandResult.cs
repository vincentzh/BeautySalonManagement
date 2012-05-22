using System.Collections.Generic;

namespace CommonLib.CommandHandlers
{
	public class CommandResult
	{
		public bool Success { get; set; }

		public ISet<string> ErrorMessages { get; set; }
	}
}