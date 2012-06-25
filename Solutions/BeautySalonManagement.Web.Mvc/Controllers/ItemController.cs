using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Items;
using BeautySalonManagement.Tasks.Commands.Items;
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
		ICommandProcessor CommandProcessor;
		//
		// GET: /Item/

		public ItemController(IItemTasks itemRepository, ICommandProcessor commandProcessor)
		{
			ItemTask = itemRepository;
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

		public ActionResult Create()
		{
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

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Item/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transaction]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Item/Delete/5
		[HttpGet]
		public ActionResult Delete(int id)
		{
			Item item = ItemTask.Get(id);
			if(item!=null)
			{
				ItemTask.Delete(item);
				return this.RedirectToAction(x=>x.Index(null,null));
			}
			return View();
		}

		
	}
}