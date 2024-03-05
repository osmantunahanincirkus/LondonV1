using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;

namespace London.Api.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponseModel> LoginAsync(LoginRequestModel body);
    Task<Users> SignUp(SignUpRequestModel body);
}