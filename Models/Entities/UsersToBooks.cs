namespace London.Api.Models.Entities;

public class UsersToBooks
{
    public int BookId { get; set; }
    public Books Book { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
}