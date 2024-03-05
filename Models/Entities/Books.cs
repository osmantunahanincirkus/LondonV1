namespace London.Api.Models.Entities;

public class Books
{
    public int Id { get; set; }
	public string Name { get; set; }
	public string Author { get; set; }
	public virtual ICollection<UsersToBooks> UsersToBooks { get; set; } = new List<UsersToBooks>();
}