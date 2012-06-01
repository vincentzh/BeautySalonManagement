#region

using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Employees;
using CommonLib.CommandHandlers;
using SharpArch.Domain.DomainModel;
using SharpArch.Domain.PersistenceSupport;

#endregion

namespace BeautySalonManagement.Tasks.CommandHandlers.Employees
{
	public class EditEmployeeCommandHandler : CommandHandlerWithResult<EditEmployeeCommand>
	{
		readonly IRepository<Employee> employeeRepository;

		public override CommandResult Handle()
		{
			Mapper.CreateMap<EditEmployeeCommand, Employee>().ForMember(x => x.Id, y => y.Ignore());
			var employee = employeeRepository.Get(CurrentCommand.Id);

			Mapper.Map(CurrentCommand, employee);
			var commandResult = ExtendValidation(employee);
			if (commandResult.Success)
			{
				employeeRepository.SaveOrUpdate(employee);
			}
			return commandResult;
		}

		protected override void ValidationEntity(Entity entity, CommandResult commandResult)
		{
			base.ValidationEntity(entity, commandResult);
			var employee = entity as Employee;
			if (employee == null || employee.Id != CurrentCommand.Id)
			{
				commandResult.ErrorMessages.Add("提交的客户信息有误,修改失败");
				commandResult.Success = false;
			}
		}
	}
}