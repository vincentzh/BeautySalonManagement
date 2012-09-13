namespace BeautySalonManagement.Domain.Interfaces
{
	public interface ISaleInfo
	{
		string Name { get; set; }
		string Description { get; set; }
		decimal Price { get; set; }
		bool Disable { get; set; }
		
		
	}
}