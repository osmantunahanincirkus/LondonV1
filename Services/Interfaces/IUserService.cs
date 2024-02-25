using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;

namespace London.Api.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponseModel> Login(LoginRequestModel body);
    Task<User> signUp(SignUpRequestModel body);
    void SignUp(SignUpRequestModel signUpRequest);
    void SignUpAsync(SignUpRequestModel signUpRequest);
}