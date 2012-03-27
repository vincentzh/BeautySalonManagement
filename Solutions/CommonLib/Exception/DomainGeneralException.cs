namespace CommonLib.Exception
{
	public class DomainGeneralException : System.Exception
	{
		public DomainGeneralException()
		{}

		public DomainGeneralException(string msg) : base(msg)
		{}

		public DomainGeneralException(string msg, System.Exception inner) : base(msg, inner)
		{}
	}
}