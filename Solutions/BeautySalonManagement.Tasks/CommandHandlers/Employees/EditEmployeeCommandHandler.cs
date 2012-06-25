#region

using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Employees;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

#endregion

namespace BeautySalonManagement.Tasks.CommandHandlers.Employees
{
	public class EditEmployeeCommandHandler : CommandHandlerWithResult<EditEmployeeCommand,IRepository<Employee>,Employee>
	{
		public EditEmployeeCommandHandler(IRepository<Employee> repository ):base(repository)
		{
			
		}
		public override void  HandleEntity()

		{
			Mapper.CreateMap<EditEmployeeCommand, Employee>().ForMember(x => x.Id, y => y.Ignore());
			CurrentEntity = CurrentRepostiory.Get(CurrentCommand.Id);
			Mapper.Map(CurrentCommand, CurrentEntity);
		
		}

		protected override void CustomValidationEntity(CommandResult commandResult)
		{

			if (CurrentEntity == null || CurrentEntity.Id != CurrentCommand.Id)
			{
				commandResult.ErrorMessages.Add("提交的客户信息有误,修改失败");
				commandResult.Success = false;
			}
		}
	}
}