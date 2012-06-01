using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Employees;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Employees
{
	public class AddEmployeeCommandHandler : CommandHandlerWithResult<AddEmployeeCommand>
	{
		readonly IRepository<Employee> _repoEmployee;
		public AddEmployeeCommandHandler(IRepository<Employee> repository)
		{
			_repoEmployee = repository;
		}
		public override CommandResult Handle()
		{
			Mapper.CreateMap<AddEmployeeCommand, Employee>().ForMember(x => x.Id, o => o.Ignore());
			var employee = Mapper.Map<AddEmployeeCommand, Employee>(CurrentCommand);
			var commandResult = ExtendValidation(employee);
			if (commandResult.Success)
			{
				_repoEmployee.SaveOrUpdate(employee);
			}
			return commandResult;
		}
	}
}
