using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Tasks;
using BeautySalonManagement.Tasks.Commands.Articles;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.Util;
using MvcContrib.UI.Grid;
using SharpArch.Domain.Commands;
using MvcContrib;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class ItemController : CustomControllerBase
	{
		IItemTasks ItemTask;
		IBrandTasks BrandTasks;
		ICommandProcessor CommandProcessor;
		//
		// GET: /Item/

		public ItemController(IItemTasks itemRepository,IBrandTasks brandRepository, ICommandProcessor commandProcessor)
		{
			ItemTask = itemRepository;
			BrandTasks = brandRepository;
			CommandProcessor = commandProcessor;
			
		}
		[HttpGet]
		public ActionResult Index(int? pageIndex, GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			


			return View(new CustomPaginationHelper<Item>(ItemTask).Pagination(pageIndex, sort));
		}


		//
		// GET: /Item/Create
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Brands = BrandTasks.FindByAll();
			ViewBag.Items =new[]{ ItemType.Product, ItemType.Consumble };
			return View();
		}

		//
		// POST: /Item/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transaction]
		public ActionResult Create(ItemViewModel itemViewModel)
		{
			if (ModelState.IsValid)
			{
				var addItemCommand = new AddItemCommand();
				Mapper.CreateMap<ItemViewModel, AddItemCommand>();
				Mapper.Map(itemViewModel, addItemCommand);

				CommandProcessor.Process<AddItemCommand, CommandResult>(addItemCommand, ModelState);
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}

		//
		// GET: /Item/Edit/5
		[HttpGet]
		public ActionResult Edit(int id)
		{
			Item item = ItemTask.Get(id);
			if (item != null)
			{
				Mapper.CreateMap<Item, ItemViewModel>();
				var itemViewModel = Mapper.Map<Item, ItemViewModel>(item);
				
				return View(itemViewModel);
			}
			return new HttpNotFoundResult();
		}

		//
		// POST: /Item/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transaction]
		public ActionResult Edit(ItemViewModel itemViewModel)
		{
			if (ModelState.IsValid)
			{
				var editItemCommand = new EditItemCommand();
				Mapper.CreateMap<ItemViewModel, EditItemCommand>();
				Mapper.Map(itemViewModel, editItemCommand);

				CommandProcessor.Process<EditItemCommand, CommandResult>(editItemCommand, ModelState);
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}

		//
		// GET: /Item/Delete/5
		[HttpGet]
		[Transaction]
		public ActionResult Delete(int id)
		{
			Item item = ItemTask.Get(id);
			if(item!=null)
			{
				ItemTask.Delete(item);
				return this.RedirectToAction(x=>x.Index(null,null));
			}
			return new HttpNotFoundResult();
		}

		
	}
}