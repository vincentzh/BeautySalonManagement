using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib.Util;
using NUnit.Framework;

namespace BeautySalonManagement.Tests
{
	[TestFixture]
	class SampleTest
	{
		[Test]
		public void Encrypt()
		{
			
			string salt = RandomStringGenerator.GenerateStrings(24); ;
			Console.WriteLine(salt);
			string password = "a";
			Console.WriteLine(EncryptionUtil.Encrypt(password, salt));
			Console.WriteLine(EncryptionUtil.Decrypt(EncryptionUtil.Encrypt(password, salt),salt));
			Assert.AreEqual(password, EncryptionUtil.Decrypt(EncryptionUtil.Encrypt(password, salt), salt));

		}
	}
}
