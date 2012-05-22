using System.Web.Security;

namespace CommonLib.Util.Authentications
{
	public class CustomFormsAuthentication : ICustomFormsAuthentication
	{
		#region ICustomFormsAuthentication Members

		public void SetAuthCookie(string userName, bool createPersistentCookie)
		{
			FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
		}

		#endregion
	}
}