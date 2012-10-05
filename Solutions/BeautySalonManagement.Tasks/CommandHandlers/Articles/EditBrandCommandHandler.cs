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
	public class EditBrandCommandHandler: CommandHandlerWithResult<EditBrandCommand, IRepository<Brand>, Brand>
	{
		public EditBrandCommandHandler(IRepository<Brand> repository) : base(repository)
		{}

		public override void HandleEntity()
		{
			
			Mapper.CreateMap<EditBrandCommand, Brand>().ForMember(x => x.Id, o => o.Ignore()).ForMember(x=>x.Name,o=>o.Ignore());
			CurrentEntity = CurrentRepostiory.Get(CurrentCommand.Id);
			Mapper.Map(CurrentCommand,CurrentEntity);
		}
	}
}
