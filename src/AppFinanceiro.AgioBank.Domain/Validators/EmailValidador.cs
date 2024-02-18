using AppFinanceiro.AgioBank.Domain.ValueObjects;
using FluentValidation;

namespace AppFinanceiro.AgioBank.Domain.Validators;

public class EmailValidador : AbstractValidator<Email>
{
    public static EmailValidador Instance => new();

    public EmailValidador()
    {
        RuleFor(e => e.Endereco)
            .NotEmpty()
            .WithMessage("O email deve ser informado")
            .EmailAddress()
            .WithMessage("O email está em formato inválido");
    }
}
