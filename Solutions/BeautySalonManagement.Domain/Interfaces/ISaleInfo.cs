using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySalonManagement.Domain.Interfaces
{
	public interface ISaleInfo
	{
		string Name { get; set; }
		decimal Price { get; set; }
		decimal Cost { get; set; }
	}
}
