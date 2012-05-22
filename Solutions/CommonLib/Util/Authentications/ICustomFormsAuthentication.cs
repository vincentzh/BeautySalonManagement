namespace CommonLib.Util.Authentications
{
	public interface ICustomFormsAuthentication
	{
		void SetAuthCookie(string userName, bool createPersistentCookie);
	}
}
