﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Customers
{
	public class EditCustomerCommandHandler : CommandHandlerWithResult<EditCustomerCommand>
	{
		readonly IRepository<Customer> customerRepository;

		public EditCustomerCommandHandler(IRepository<Customer> repository)
		{
			customerRepository = repository;
		}

		public override CommandResult Handle()
		{
			Mapper.CreateMap<EditCustomerCommand, Customer>().ForMember(x=>x.Id,y=>y.Ignore()).ForMember(x=>x.CustomerCardNo,y=>y.Ignore());
			var customer = customerRepository.Get(CurrentCommand.Id);
		
				Mapper.Map(CurrentCommand,customer);
				var commandResult = ExtendValidation(customer);
				if (commandResult.Success)
				{
					customerRepository.SaveOrUpdate(customer);
				}
		return commandResult;
			
		}
		protected override void ValidationEntity(SharpArch.Domain.DomainModel.Entity entity, CommandResult commandResult)
		{
			base.ValidationEntity(entity, commandResult);
			var customer = entity as Customer;
			if (customer == null || customer.CustomerCardNo != CurrentCommand.CustomerCardNo||customer.Id!=CurrentCommand.Id)
			{
				commandResult.ErrorMessages.Add("提交的客户信息有误,无法更改");
				commandResult.Success = false;
			}
		}
	
	}
}