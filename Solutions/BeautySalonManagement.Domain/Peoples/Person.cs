using System;
using System.ComponentModel.DataAnnotations;
using BeautySalonManagement.Domain.Permissions;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public abstract class Person : Entity
	{
		[Required]
		public virtual string Name { get; set; }

		[Required]
		public virtual string Password { get; set; }

		[Required]
		public virtual string Salt { get; set; }

		public virtual PermissionGroup PermissionGroup { get; set; }

		[Required]
		public virtual DateTime? Birthday { get; set; }

		public virtual string MobilePhone { get; set; }
		public virtual string Address { get; set; }
		public virtual DateTime CreateDate { get; set; }

	}
}