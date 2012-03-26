using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public class Recommendation : Entity
	{
		[Required]
		public virtual People Introduce { get; set; }
		[Required]
		public virtual People Rookie { get; set; }
	}
}