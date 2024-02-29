using London.Api.Controllers;
using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace London.Test;

public class SignUpTest
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly UserController _controller;

    public SignUpTest()
    {
        _controller = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task SignUp_Should_Return_Ok_For_Successful_Registration()
    {
        var signUpRequest = new SignUpRequestModel { Username = "newUser", Password = "password" };
        var user = new User { Id = 1, Username = "newUser" };
        _userServiceMock
            .Setup(x => x.SignUp(signUpRequest))
            .ReturnsAsync(user);

        var result = await _controller.SignUp(signUpRequest);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task SignUp_Should_Return_Conflict_For_Already_Registered_User()
    {
        var signUpRequest = new SignUpRequestModel { Username = "existingUser", Password = "password" };
        _userServiceMock.Setup(service => service.SignUp(signUpRequest)).ReturnsAsync((User)null);

        var result = await _controller.SignUp(signUpRequest);
    }
}