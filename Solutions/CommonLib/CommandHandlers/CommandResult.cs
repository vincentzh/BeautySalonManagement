using System.Collections.Generic;
using System.Web.Mvc;

namespace CommonLib.CommandHandlers
{
	public class CommandResult
	{
		private ModelStateDictionary modelState=new ModelStateDictionary();
		public bool Success { get; set; }

		public ModelStateDictionary ModelState
		{
			get { return modelState; }
		}


	}
}