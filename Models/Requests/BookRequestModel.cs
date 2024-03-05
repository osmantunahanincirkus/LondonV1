using System.ComponentModel.DataAnnotations;

namespace London.Api.Models.Requests;

public class BookRequestModel
{
	[MaxLength(200)]
	public required string BookName { get; set; }
	public required string AuthorName { get; set; }
	public int UserId { get; set; }
}
