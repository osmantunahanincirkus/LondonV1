using FluentValidation;

namespace London.Api.Models.Requests;

public class SignUpRequestModel
{
	public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}

public class SignUpRequestValidator : AbstractValidator<SignUpRequestModel>
{
	public SignUpRequestValidator()
	{
		RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
		RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
		RuleFor(x => x.Name).NotEmpty().WithMessage("The name cannot be empty.");
		RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty.");
	}
}
