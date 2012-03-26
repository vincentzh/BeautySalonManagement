using System;
using System.ComponentModel.DataAnnotations;
using BeautySalonManagement.Domain.Peoples;
using SharpArch.Domain.Commands;

namespace BeautySalonManagement.Tasks.Commands.People
{
	public class PeopleCommandBase : CommandBase
	{

		[Required]
		public string Name { get; set; }

		[Required]
		public Gender Gender { get; set; }

		public int PermissionGroupId { get; set; }

		[Required]
		public string Password { get; set; }

		public DateTime? Birthday { get; set; }

		[Required]
		public string MobilePhone { get; set; }

		public string Address { get; set; }
	}
}