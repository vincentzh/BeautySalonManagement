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
	public class EditEquipmentCommandHandler:CommandHandlerWithResult<EditEquipmentCommand,IRepository<Equipment>,Equipment>
	{
		public EditEquipmentCommandHandler(IRepository<Equipment> repository) : base(repository)
		{}

		public override void HandleEntity()
		{
			CurrentEntity = CurrentRepostiory.Get(CurrentCommand.Id);
			Mapper.CreateMap<EditEquipmentCommand, Equipment>().ForMember(x => x.Id, o => o.Ignore());
			 Mapper.Map(CurrentCommand,CurrentEntity);
		}
	}
}
