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
		RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
		RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz.");
		RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş olamaz.");
		RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz.");
	}
}
