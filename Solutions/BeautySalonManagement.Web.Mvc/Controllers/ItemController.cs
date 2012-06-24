using System.Web.Mvc;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Items;
using BeautySalonManagement.Web.Mvc.Base;
using CommonLib.Util;
using MvcContrib.UI.Grid;
using SharpArch.Domain.Commands;

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
		// GET: /Item/Details/5

		public ActionResult Details(int id)
		{
			return View();
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
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
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

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Item/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}