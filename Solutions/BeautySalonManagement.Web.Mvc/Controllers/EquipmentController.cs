using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Tasks.Commands.Articles;
using BeautySalonManagement.Tasks.Commands.Employees;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.Util;
using MvcContrib;
using MvcContrib.UI.Grid;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class EquipmentController : CustomControllerBase
	{
		readonly IEquipmentTasks _equipmentTasks;
		ICommandProcessor _commandProcessor;
		public EquipmentController(IEquipmentTasks equipmentTasks,ICommandProcessor commandProcessor)
		{
			_equipmentTasks = equipmentTasks;
			_commandProcessor = commandProcessor;
		}
       
		[HttpGet]
		public ActionResult Index(int? pageIndex, GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			return View(new CustomPaginationHelper<Equipment>(_equipmentTasks).Pagination(pageIndex, sort));
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[Transaction]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Create(EquipmentViewModel equipmentViewModel)
		{
			if (ModelState.IsValid)
			{
				//var addEquipmentCommand = new AddEquipmentCommand();
				Mapper.CreateMap<EquipmentViewModel, AddEquipmentCommand>().ForMember(view => view.Id, o => o.Ignore());
				var addEquipmentCommand=Mapper.Map<EquipmentViewModel, AddEquipmentCommand>(equipmentViewModel);

				_commandProcessor.Process<AddEquipmentCommand, CommandResult>(addEquipmentCommand, ModelState);
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var equipment= _equipmentTasks.Get(id);
			if (equipment != null)
			{
				Mapper.CreateMap<Equipment, EquipmentViewModel>();
				var brandViewModel = Mapper.Map<Equipment, EquipmentViewModel>(equipment);
				return View(brandViewModel);
			}
			return new HttpNotFoundResult();
		}

		[HttpPost]
		[Transaction]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EquipmentViewModel equipmentViewModel)
		{
			if (ModelState.IsValid)
			{
				var editEquipmentCommand = new EditEquipmentCommand();
				Mapper.CreateMap<EquipmentViewModel, EditEquipmentCommand>();
				Mapper.Map(equipmentViewModel, editEquipmentCommand);
				_commandProcessor.Process<EditEquipmentCommand, CommandResult>(editEquipmentCommand, ModelState);

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
			var brand = _equipmentTasks.Get(id);
			if (brand != null)
			{
				_equipmentTasks.Delete(brand);
				return this.RedirectToAction(x => x.Index(null, null));
			}
			return new HttpNotFoundResult();
		}
	}
}
