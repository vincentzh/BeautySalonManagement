using AutoMapper;
using BeautySalonManagement.Tasks.Commands.Customer;
using SharpArch.Domain.Commands;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Customer
{
	public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
	{
		readonly IRepository<Domain.Peoples.Customer> repoCustomer;

		public AddCustomerCommandHandler(IRepository<Domain.Peoples.Customer> repository)
		{
			repoCustomer = repository;
		}

		#region ICommandHandler<AddCustomerCommand> Members

		public void Handle(AddCustomerCommand command)
		{
			var customer = new Domain.Peoples.Customer();
			Mapper.CreateMap<AddCustomerCommand, Domain.Peoples.Customer>().ForMember(x=>x.Id,o=>o.Ignore());
			Mapper.Map(command, customer);
			repoCustomer.SaveOrUpdate(customer);
		}

		#endregion
	}
}