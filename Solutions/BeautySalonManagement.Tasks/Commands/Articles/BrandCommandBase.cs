﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.Commands;

namespace BeautySalonManagement.Tasks.Commands.Articles
{
	public class BrandCommandBase:CommandBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
