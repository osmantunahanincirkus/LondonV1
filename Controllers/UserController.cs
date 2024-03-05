using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace London.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel body)
    {
        var response = await userService.LoginAsync(body);
        if (response == null)
        {
            return Unauthorized("Invalid username or password.");
        }
        return Ok(response);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequestModel body)
    {
        return Ok(await userService.SignUp(body));
    }
}