using FluentValidation;

namespace London.Api.Models.Requests;

public class LoginRequestModel
{
	public required string Username { get; set; }
	public required string Password { get; set; }
}

public class LoginRequestValidator : AbstractValidator<LoginRequestModel>
{
	public LoginRequestValidator()
	{
		_ = RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Username cannot be empty.");
		_ = RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
	}
}
