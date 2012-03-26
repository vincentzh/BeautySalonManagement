using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib.Domain
{
	public interface IEntityHasPassword
	{
		string Password { get; set; }
		string Salt { get;  }
	}
}
