using AutoMapper;
using BeautySalonManagement.Domain.Items;
using BeautySalonManagement.Tasks.Commands.Items;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Items
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
			                                                                                         o => o.Ignore());
			CurrentEntity = Mapper.Map<AddItemCommand, Item>(CurrentCommand);
			CurrentEntity.Brand = BrandRepository.Get(CurrentCommand.BrandId);
		}

		protected override void ValidationCommand(CommandResult commandResult)
		{
			base.ValidationCommand(commandResult);
			if (commandResult.Success)
			{
				Brand brand = BrandRepository.Get(CurrentCommand.BrandId);
				if (brand == null)
				{
					commandResult.Success = false;
					commandResult.ErrorMessages.Add("请选择一个品牌");
				}
			}
		}
	}
}