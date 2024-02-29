namespace London.Api.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(int userId, string username);
}