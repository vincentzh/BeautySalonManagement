using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Customers
{
	public class AddCustomerCommandHandler : CommandHandlerWithResult<AddCustomerCommand>
	{
		readonly IRepository<Customer> repoCustomer;

		public AddCustomerCommandHandler(IRepository<Customer> repository)
		{
			repoCustomer = repository;
		}


		public override CommandResult Handle()
		{
			Mapper.CreateMap<AddCustomerCommand, Customer>().ForMember(x => x.Id, o => o.Ignore());
			var customer = Mapper.Map<AddCustomerCommand, Customer>(CurrentCommand);
			var commandResult = ExtendValidation(customer);
			if (commandResult.Success)
			{
				repoCustomer.SaveOrUpdate(customer);
			}
			return commandResult;
		}
	}
}