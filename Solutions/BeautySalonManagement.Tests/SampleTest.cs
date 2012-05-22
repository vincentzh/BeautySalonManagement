using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks;
using CommonLib.ControlsExtension;
using CommonLib.Util;
using NUnit.Framework;

namespace BeautySalonManagement.Tests
{
	[TestFixture]
	internal class SampleTest
	{
		[Test]
		public void Encrypt()
		{
			string salt = RandomStringGenerator.GenerateStrings(24);
			Console.WriteLine(salt);
			string password = "a";
			Console.WriteLine(EncryptionUtil.Encrypt(password, salt));
			Console.WriteLine(EncryptionUtil.Decrypt(EncryptionUtil.Encrypt(password, salt), salt));
			Assert.AreEqual(password, EncryptionUtil.Decrypt(EncryptionUtil.Encrypt(password, salt), salt));
		}
		[Test]
		public void FirstOrFirstDefault()
		{
			ICollection<object> strings=new Collection<object>()
			                            	{
			                            			"a","b","c"
			                            	};
			Assert.AreEqual("a",strings.FirstOrDefault(x=>x.ToString().Equals("a",StringComparison.OrdinalIgnoreCase)));
			Assert.IsNull(strings.FirstOrDefault(x=>x==null));
		}
	}
}