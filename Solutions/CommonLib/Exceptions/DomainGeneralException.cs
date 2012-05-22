using System;

namespace CommonLib.Exceptions
{
	public class DomainGeneralException : Exception
	{
		public DomainGeneralException()
		{}

		public DomainGeneralException(string msg) : base(msg)
		{}

		public DomainGeneralException(string msg, Exception inner) : base(msg, inner)
		{}
	}
}