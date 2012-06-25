#region

using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

#endregion

namespace BeautySalonManagement.Tasks.CommandHandlers.Customers
{
	public class EditCustomerCommandHandler : CommandHandlerWithResult<EditCustomerCommand,IRepository<Customer>,Customer>
	{

		public EditCustomerCommandHandler(IRepository<Customer> repository):base(repository)
		{
		}

		public override void  HandleEntity()

		{
			Mapper.CreateMap<EditCustomerCommand, Customer>().ForMember(x => x.Id, y => y.Ignore()).ForMember(
					x => x.CustomerCardNo, y => y.Ignore());
			CurrentEntity  = CurrentRepostiory.Get(CurrentCommand.Id);

			Mapper.Map(CurrentCommand, CurrentEntity);
		
		}

		protected override void ValidationEntity( CommandResult commandResult)
		{
			base.ValidationEntity( commandResult);

			if (CurrentEntity == null || CurrentEntity.CustomerCardNo != CurrentCommand.CustomerCardNo || CurrentEntity.Id != CurrentCommand.Id)
			{
				commandResult.ErrorMessages.Add("提交的客户信息有误,修改失败");
				commandResult.Success = false;
			}
		}
	}
}