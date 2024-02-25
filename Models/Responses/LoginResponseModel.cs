namespace London.Api.Models.Responses;

public sealed class UserOutput
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

public sealed class LoginResponseModel
{
	public required string Username { get; set; }
	public required string AccessToken { get; set; }

	public required int Id { get; set; }
	
	// TODO: add refresh token 
}
