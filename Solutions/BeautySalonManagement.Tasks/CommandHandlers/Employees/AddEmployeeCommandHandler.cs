using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Employees;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Employees
{
	public class AddEmployeeCommandHandler : CommandHandlerWithResult<AddEmployeeCommand,IRepository<Employee>,Employee>
	{
		public AddEmployeeCommandHandler(IRepository<Employee> repository):base(repository)
		{
		}
		public override void  HandleEntity()

		{
			Mapper.CreateMap<AddEmployeeCommand, Employee>().ForMember(x => x.Id, o => o.Ignore());
			CurrentEntity = Mapper.Map<AddEmployeeCommand, Employee>(CurrentCommand);
			
		}
	}
}
