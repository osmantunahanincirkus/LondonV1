using London.Api.Models;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;
using London.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace London.Api.Services;

public sealed class UserService(IJwtService jwtService, MyDBContext myDbContext) : IUserService
{
    public async Task<LoginResponseModel> Login(LoginRequestModel body)
    {
        var user = await myDbContext.Users.FirstOrDefaultAsync(u => u.Username == body.Username);
        if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound, "User Not Found");

        var token = jwtService.GenerateToken(user.Id, user.Username);
        return new LoginResponseModel { Username = user.Username, AccessToken = token, Id = user.Id};
    }

    public async Task<User> signUp(SignUpRequestModel body)
    {
        var user = new User
        {
            Name = body.Name,
            Surname = body.Surname,
            Password = body.Password,
            Username = body.Username,
        };
        await myDbContext.Users.AddAsync(user);
        await myDbContext.SaveChangesAsync();
        return user;
    }

    public void SignUp(SignUpRequestModel signUpRequest)
    {
        throw new NotImplementedException();
    }

    public void SignUpAsync(SignUpRequestModel signUpRequest)
    {
        throw new NotImplementedException();
    }
}