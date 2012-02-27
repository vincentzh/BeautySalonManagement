﻿#region

using BeautySalonManagement.Domain.Permissions;
using SharpArch.Domain.DomainModel;

#endregion

namespace BeautySalonManagement.Domain.Peoples
{
	public class Employee : Person
	{
		public virtual ContactInfo ContactInfo { get; set; }
	}
}