using System;
using BeautySalonManagement.Domain.Permissions;
using CommonLib.Domain;
using CommonLib.Util;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public abstract class People : Entity, IEntityHasPassword
	{
		DateTime createDate = DateTime.Now;
		string password;
		string salt = RandomStringGenerator.GenerateStrings(24);


		public virtual string Name { get; set; }

		public virtual Gender Gender { get; set; }
		public virtual PermissionGroup PermissionGroup { get; set; }

		public virtual DateTime? Birthday { get; set; }

		public virtual string MobilePhone { get; set; }
		public virtual string Address { get; set; }

		public virtual DateTime CreateDate
		{
			get { return createDate; }
			protected set { createDate = value; }
		}

		#region IEntityHasPassword Members

		public virtual string Password
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(password))
				{
					return EncryptionUtil.Decrypt(password, Salt);
				}
				return null;
			}
			set { password = EncryptionUtil.Encrypt(value, Salt); }
		}

		public virtual string Salt
		{
			get { return salt; }
			protected set { salt = value; }
		}

		#endregion
	}
}