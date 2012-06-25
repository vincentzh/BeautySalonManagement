using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Customers
{
	public class AddCustomerCommandHandler : CommandHandlerWithResult<AddCustomerCommand, IRepository<Customer>, Customer>
	{
		public AddCustomerCommandHandler(IRepository<Customer> repository) : base(repository)
		{}


		public override void HandleEntity()

		{
			Mapper.CreateMap<AddCustomerCommand, Customer>().ForMember(x => x.Id, o => o.Ignore());
			CurrentEntity = Mapper.Map<AddCustomerCommand, Customer>(CurrentCommand);
		}
	}
}