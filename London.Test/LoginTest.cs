using London.Api.Controllers;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
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
        // Arrange
        //var loginRequest = new LoginRequestModel { Username = "validUser", Password = "validPassword" };
        //var user = new User { Id = 1, Username = "validUser" };
        //_userServiceMock.Setup(service => service.Login(loginRequest)).ReturnsAsync(user);
        var loginRequest = new LoginRequestModel { Username = "validUser", Password = "validPassword" };
        var loginResponse = new LoginResponseModel
        {
            AccessToken = "fakeToken",
            Username = "validUser"
        };
        _userServiceMock.Setup(service => service.Login(loginRequest)).ReturnsAsync(loginResponse);
        //_jwtServiceMock.Setup(service => service.GenerateToken(user.Id, user.Username)).Returns("fakeToken");

        // Act
        var result = await _controller.Login(loginRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task Login_Should_Return_Unauthorized_For_Invalid_Username()
    {
        // Arrange
        var invalidLoginRequest = new LoginRequestModel { Username = "invalidUser", Password = "anyPassword" };
        _userServiceMock.Setup(service => service.Login(invalidLoginRequest)).ReturnsAsync((LoginResponseModel)null);
        //var loginRequest = new LoginRequestModel { Username = "invalidUser", Password = "password" };
        //_userServiceMock.Setup(service => service.Login(loginRequest)).ReturnsAsync((Func<LoginResponseModel>)null);

        // Act
        var result = await _controller.Login(invalidLoginRequest);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }

    [Fact]
    public async Task Login_Should_Return_Unauthorized_For_Wrong_Password()
    {
        // Arrange
        var wrongPasswordRequest = new LoginRequestModel { Username = "validUser", Password = "wrongPassword" };
        _userServiceMock.Setup(service => service.Login(wrongPasswordRequest)).ReturnsAsync((LoginResponseModel)null);
        //var loginRequest = new LoginRequestModel { Username = "validUser", Password = "wrongPassword" };
        //_userServiceMock.Setup(service => service.Login(loginRequest)).ReturnsAsync((Func<LoginResponseModel>)null);

        // Act
        var result = await _controller.Login(wrongPasswordRequest);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}