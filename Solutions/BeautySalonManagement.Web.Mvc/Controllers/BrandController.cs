using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Tasks.Commands.Articles;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.Util;
using MvcContrib.UI.Grid;
using MvcContrib;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class BrandController : CustomControllerBase
    {
		IBrandTasks BrandTasks;
		ICommandProcessor CommandProcessor;
		public BrandController(IBrandTasks brandTasks, ICommandProcessor commandProcessor)
		{
			BrandTasks = brandTasks;
			CommandProcessor = commandProcessor;
		}
     
	    [HttpGet]
		public ActionResult Create()
	    {
		    return View();
	    }
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transaction]
		public ActionResult Create(BrandViewModel brandViewModel)
		{
			if(ModelState.IsValid)
			{
				var addBrandCommand = new AddBrandCommand();
				Mapper.CreateMap<BrandViewModel, AddBrandCommand>();
				Mapper.Map(brandViewModel, addBrandCommand);

				CommandProcessor.Process<AddBrandCommand, CommandResult>(addBrandCommand, ModelState);
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}
			return View();
		}

		[HttpGet]
		public ActionResult Index(int? pageIndex, GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			return View(new CustomPaginationHelper<Brand>(BrandTasks).Pagination(pageIndex, sort));
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var brand = BrandTasks.Get(id);
			if(brand!=null)
			{
				Mapper.CreateMap<Brand, BrandViewModel>();
				var brandViewModel = Mapper.Map<Brand, BrandViewModel>(brand);
				return View(brandViewModel);
			}
			return new HttpNotFoundResult();
		}
		[HttpPost]
		[Transaction]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(BrandViewModel brandViewModel)
		{
			if (ModelState.IsValid)
			{
				var editBrandCommand = new EditBrandCommand();
				Mapper.CreateMap<BrandViewModel, EditBrandCommand>();
				Mapper.Map(brandViewModel, editBrandCommand);
				CommandProcessor.Process<EditBrandCommand, CommandResult>(editBrandCommand, ModelState);

				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
		[HttpGet]
		[Transaction]
	    public ActionResult Delete(int id)
	    {
			var brand = BrandTasks.Get(id);
			if (brand != null)
			{
				BrandTasks.Delete(brand);
				return this.RedirectToAction(x => x.Index(null, null));
			}
			return new HttpNotFoundResult();
	    }
    }
}
