﻿using AutoMapper;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Tasks.Commands.Articles;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Articles
{
	public class AddItemCommandHandler : CommandHandlerWithResult<AddItemCommand, IRepository<Item>, Item>
	{
		readonly IRepository<Brand> BrandRepository;

		public AddItemCommandHandler(IRepository<Item> itemRepository, IRepository<Brand> brandRepository)
				: base(itemRepository)
		{
			BrandRepository = brandRepository;
		}

		public override void HandleEntity()
		{
			Mapper.CreateMap<AddItemCommand, Item>().ForMember(x => x.Id, o => o.Ignore()).ForMember(x => x.Brand,
			                                                                                         o =>o.ResolveUsing(y=>BrandRepository.Get(y.BrandId)));
			CurrentEntity = Mapper.Map<AddItemCommand, Item>(CurrentCommand);
		}

		protected override void CustomValidationCommand(CommandResult commandResult)
		{
			if (commandResult.Success)
			{
				Brand brand = BrandRepository.Get(CurrentCommand.BrandId);
				if (brand == null)
				{
					commandResult.Success = false;
					commandResult.ModelState.AddModelError("brandId","请选择一个品牌");
				}
			}
		}
	}
}