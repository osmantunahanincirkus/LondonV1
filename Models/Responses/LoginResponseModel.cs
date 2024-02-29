using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string AccessToken { get; set; }
}