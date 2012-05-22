namespace BeautySalonManagement.Domain.Interfaces
{
	public interface IEntityHasPassword
	{
		string Password { get; set; }
		string Salt { get; }
	}
}