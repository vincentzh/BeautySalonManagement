namespace BeautySalonManagement.Domain.Interfaces
{
	public interface IItem : ISaleInfo
	{
		IBrand Brand { get; set; }
		decimal Volume { get; set; }
	}
}