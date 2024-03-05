using London.Api.Models;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;
using London.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace London.Api.Services;

public class InClassName
{
    public InClassName(LoginRequestModel body)
    {
        Body = body;
    }

    public LoginRequestModel Body { get; private set; }
}

public sealed class UserService(IJwtService jwtService, MyDBContext myDbContext) : IUserService
{
    public async Task<LoginResponseModel> LoginAsync(LoginRequestModel body)
    {
        var user = await myDbContext.Users.FirstOrDefaultAsync(u => u.Username == body.Username && u.Password == body.Password);
        if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound, "User Not Found");
        
        var token = jwtService.GenerateToken(user.Id, user.Username);
        return new LoginResponseModel { Username = user.Username, AccessToken = token};
    }

    public async Task<Users> SignUp(SignUpRequestModel body)
    {
        var user = new Users
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
}