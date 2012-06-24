using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.Commands;
using SharpArch.Domain.DomainModel;
using SharpArch.Domain.PersistenceSupport;

namespace CommonLib.CommandHandlers
{
	public abstract class CommandHandlerWithResult<TCommand, TRepository, T> : ICommandHandler<TCommand, CommandResult>
			where TCommand : ICommand
			where TRepository : IRepository<T>
			where T : Entity
	{
		public TCommand CurrentCommand { get; set; }
		public TRepository CurrentRepostiory { get; set; }
		public T CurrentEntity { get; set; }

		public CommandHandlerWithResult(TRepository repository)
		{
			CurrentRepostiory = repository;


		}

		#region ICommandHandler<TCommand,CommandResult> Members

		public CommandResult Handle(TCommand command)
		{

			CurrentCommand = command;
			HandleEntity();
			CommandResult commandResult = ExtendValidation();
			if (commandResult.Success)
			{
				CurrentRepostiory.SaveOrUpdate(CurrentEntity);
			}
			return commandResult;

		}

		#endregion

		public abstract void HandleEntity();

		protected virtual CommandResult ExtendValidation()
		{
			var commandResult = new CommandResult();

			commandResult.Success = true;
			ValidationCommand(commandResult);
			ValidationEntity(commandResult);

			return commandResult;
		}

		protected virtual void ValidationEntity(CommandResult commandResult)
		{
			foreach (ValidationResult entityValidationResults in CurrentEntity.ValidationResults())
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