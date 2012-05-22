using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.Commands;
using SharpArch.Domain.DomainModel;

namespace CommonLib.CommandHandlers
{
	public abstract class CommandHandlerWithResult<TCommand> : ICommandHandler<TCommand, CommandResult>
			where TCommand : ICommand
	{
		protected TCommand CurrentCommand;

		#region ICommandHandler<TCommand,CommandResult> Members

		public CommandResult Handle(TCommand command)
		{
			CurrentCommand = command;
			return Handle();
		}

		#endregion

		public abstract CommandResult Handle();

		protected virtual CommandResult ExtendValidation(Entity entity)
		{
			var commandResult = new CommandResult();

			commandResult.Success = true;
			ValidationCommand(commandResult);
			ValidationEntity(entity, commandResult);

			return commandResult;
		}

		protected virtual void ValidationEntity(Entity entity, CommandResult commandResult)
		{
			foreach (ValidationResult entityValidationResults in entity.ValidationResults())
			{
				commandResult.ErrorMessages.Add(entityValidationResults.ErrorMessage);
				if (commandResult.Success)
					commandResult.Success = false;
			}
		}

		protected virtual void ValidationCommand(CommandResult commandResult)
		{
			foreach (ValidationResult commandValidationResults in CurrentCommand.ValidationResults())
			{
				commandResult.ErrorMessages.Add(commandValidationResults.ErrorMessage);
				if (commandResult.Success)
					commandResult.Success = false;
			}
		}
	}
}