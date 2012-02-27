using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Peoples
{
	public class Recommendation : Entity
	{
		[Required]
		public virtual Person Introduce { get; set; }
		[Required]
		public virtual Person Rookie { get; set; }
	}
}