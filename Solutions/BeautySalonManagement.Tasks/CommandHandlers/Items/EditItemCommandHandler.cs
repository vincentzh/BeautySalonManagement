using AutoMapper;
using BeautySalonManagement.Domain.Items;
using BeautySalonManagement.Tasks.Commands.Items;
using CommonLib.CommandHandlers;
using SharpArch.Domain.PersistenceSupport;

namespace BeautySalonManagement.Tasks.CommandHandlers.Items
{
	public class EditItemCommandHandler : CommandHandlerWithResult<EditItemCommand, IRepository<Item>, Item>
	{
		readonly IRepository<Brand> BrandRepository;

		public EditItemCommandHandler(IRepository<Item> repository, IRepository<Brand> brandRepository) : base(repository)
		{
			BrandRepository = brandRepository;
		}

		public override void HandleEntity()
		{
			Mapper.CreateMap<EditItemCommand, Item>().ForMember(x => x.Id, o => o.Ignore()).ForMember(x => x.Brand,
			                                                                                          o =>
			                                                                                          o.ResolveUsing(
			                                                                                          		y =>
			                                                                                          		BrandRepository.Get(
			                                                                                          				y.BrandId)));
			CurrentEntity = CurrentRepostiory.Get(CurrentCommand.Id);
			Mapper.Map(CurrentCommand,CurrentEntity);
		}
		protected override void CustomValidationCommand(CommandResult commandResult)
		{
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