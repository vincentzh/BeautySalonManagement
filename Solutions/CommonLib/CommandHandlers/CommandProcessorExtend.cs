#region

using System.Web.Mvc;
using SharpArch.Domain.Commands;

#endregion

namespace CommonLib.CommandHandlers
{
	public static class CommandProcessorExtend
	{
		public static void Process<TCommand, TResult>(this ICommandProcessor commandProcessor, TCommand command,
		                                              ModelStateDictionary model) where TResult : CommandResult
				where TCommand : ICommand


		{
			commandProcessor.Process<TCommand, TResult>(command, x =>
			{
				if (!x.Success)
				{
					
						model.Merge(x.ModelState);
					
				}
			});
		}
	}
}