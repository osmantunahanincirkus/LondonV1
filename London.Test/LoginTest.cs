using London.Api.Controllers;
using London.Api.Models.Requests;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using London.Api.Models.Responses;
using Xunit;

namespace London.Test;

public class LoginTest
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IJwtService> _jwtServiceMock = new();
    private readonly UserController _controller;

    public LoginTest()
    {
        _controller = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task Login_Should_Return_Ok_With_Token_For_Valid_Credentials()
    {
        var loginRequest = new LoginRequestModel { Username = "validUser", Password = "validPassword" };
        var loginResponse = new LoginResponseModel
        {
            AccessToken = "fakeToken",
            Username = "validUser"
        };
        _userServiceMock.Setup(service => service.Login(loginRequest)).ReturnsAsync(loginResponse);

        var result = await _controller.Login(loginRequest);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task Login_Should_Return_Unauthorized_For_Invalid_Username()
    {
        var invalidLoginRequest = new LoginRequestModel { Username = "invalidUser", Password = "anyPassword" };
        _userServiceMock.Setup(service => service.Login(invalidLoginRequest)).ReturnsAsync((LoginResponseModel)null);

        var result = await _controller.Login(invalidLoginRequest);

        Assert.IsType<UnauthorizedObjectResult>(result);
    }

    [Fact]
    public async Task Login_Should_Return_Unauthorized_For_Wrong_Password()
    {
        var wrongPasswordRequest = new LoginRequestModel { Username = "validUser", Password = "wrongPassword" };
        _userServiceMock.Setup(service => service.Login(wrongPasswordRequest)).ReturnsAsync((LoginResponseModel)null);

        var result = await _controller.Login(wrongPasswordRequest);

        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}