using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Tasks.Commands.Articles;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Articles
{
	public class AddEquipmentCommandHandler : CommandHandlerWithResult<AddEquipmentCommand, IRepository<Equipment>, Equipment>
	{
		public AddEquipmentCommandHandler(IRepository<Equipment> repository) : base(repository)
		{}
		public override void HandleEntity()
		{
			Mapper.CreateMap<AddEquipmentCommand, Equipment>().ForMember(x => x.Id, o => o.Ignore());
			CurrentEntity = Mapper.Map<AddEquipmentCommand, Equipment>(CurrentCommand);
		}
	}
}
