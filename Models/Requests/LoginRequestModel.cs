using FluentValidation;

namespace London.Api.Models.Requests;

public class LoginRequestModel
{
	//[EmailAddress(ErrorMessage = "Invalid Email Address")]
	public required string Username { get; set; }
	//[PasswordPropertyText]
	public required string Password { get; set; }
}

public class LoginRequestValidator : AbstractValidator<LoginRequestModel>
{
	public LoginRequestValidator()
	{
		_ = RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Kullanıcı adı boş olamaz.");
		_ = RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz.");
		// password rules 
	}
}
