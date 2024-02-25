using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace London.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(
    IUserService userService,
    IJwtService jwtService
) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel body)
    {
        //var token = jwtService.GenerateToken(11, "Selman");

        //return Ok(token);
        
        var user = await userService.Login(body);
        
        if (user == null)
        {
             return Unauthorized("Invalid username or password.");
        }
        
        var token = jwtService.GenerateToken(user.Id, user.Username);
        
        return Ok(new { AccessToken = token });
    }


    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequestModel body)
    {
        return Ok(await userService.signUp(body));
    }
}