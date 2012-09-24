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
	public class AddBrandCommandHandler : CommandHandlerWithResult<AddBrandCommand, IRepository<Brand>, Brand>
	{
		public AddBrandCommandHandler(IRepository<Brand> repository) : base(repository)
		{}

		public override void HandleEntity()
		{
			Mapper.CreateMap<AddBrandCommand, Brand>().ForMember(x => x.Id, o => o.Ignore());
			CurrentEntity = Mapper.Map<AddBrandCommand, Brand>(CurrentCommand);
		}
	}
}
