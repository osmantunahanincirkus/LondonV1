using London.Api.Models.Entities;

namespace London.Api.Models.Requests;

public class BookRequestModel
{
	public string BookName { get; set; }
	public string AuthorName { get; set; }
	public User UserId { get; set; }
}
