﻿using London.Api.Models.Entities;
using London.Api.Models.Requests;
using London.Api.Models.Responses;

namespace London.Api.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponseModel> Login(LoginRequestModel body);
    Task<User> SignUp(SignUpRequestModel body);
}