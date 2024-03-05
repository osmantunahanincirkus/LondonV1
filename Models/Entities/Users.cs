namespace London.Api.Models.Entities;

public class Users
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public virtual ICollection<UsersToBooks> UsersToBooks { get; set; } = new List<UsersToBooks>();

}
