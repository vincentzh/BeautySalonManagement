using System;
using BeautySalonManagement.Domain.Interfaces;
using BeautySalonManagement.Domain.Permissions;
using CommonLib.Util;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public abstract class People : Entity, IEntityHasPassword
	{
		DateTime _createDate = DateTime.Now;
		string _password;
		string _salt = RandomStringGenerator.GenerateStrings(24);


		public virtual string Name { get; set; }

		public virtual Gender Gender { get; set; }
		public virtual PermissionGroup PermissionGroup { get; set; }

		public virtual DateTime? Birthday { get; set; }

		public virtual string MobilePhone { get; set; }
		public virtual string Address { get; set; }

		public virtual DateTime CreateDate
		{
			get { return _createDate; }
			protected set { _createDate = value; }
		}

		#region IEntityHasPassword Members

		public virtual string Password
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(_password))
				{
					return EncryptionUtil.Decrypt(_password, Salt);
				}
				return null;
			}
			set { _password = EncryptionUtil.Encrypt(value, Salt); }
		}

		public virtual string Salt
		{
			get { return _salt; }
			protected set { _salt = value; }
		}

		#endregion
	}
}