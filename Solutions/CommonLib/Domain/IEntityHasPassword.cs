namespace CommonLib.Domain
{
	public interface IEntityHasPassword
	{
		string Password { get; set; }
		string Salt { get; }
	}
}