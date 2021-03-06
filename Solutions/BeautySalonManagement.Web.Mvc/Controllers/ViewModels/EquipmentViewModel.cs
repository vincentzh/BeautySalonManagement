﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class EquipmentViewModel
	{
		[HiddenInput]
		public int Id { get; set; }
		[Display(Name = "名称")]
		[Required(ErrorMessage = "输入名称")]
		public string Name { get; set; }
		[Display(Name = "描述")]
		public string Description { get; set; }
	}
}