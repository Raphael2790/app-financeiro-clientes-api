using AppFinanceiro.AgioBank.Domain.Entities;
using FluentValidation;

namespace AppFinanceiro.AgioBank.Domain.Validators;

public sealed class EnderecoValidador : AbstractValidator<Endereco>
{
    public static EnderecoValidador Instance => new();

    public EnderecoValidador()
    {
        RuleFor(e => e.Logradouro)
            .NotEmpty()
            .WithMessage("O logradouro deve ser informado");

        RuleFor(e => e.Numero)
            .NotEmpty()
            .WithMessage("O número deve ser informado");

        RuleFor(e => e.Bairro)
            .NotEmpty()
            .WithMessage("O bairro deve ser informado");

        RuleFor(e => e.Cidade)
            .NotEmpty()
            .WithMessage("A cidade deve ser informada");

        RuleFor(e => e.Estado)
            .NotEmpty()
            .WithMessage("O estado deve ser informado");

        RuleFor(e => e.Pais)
            .NotEmpty()
            .WithMessage("O país deve ser informado");

        RuleFor(e => e.Cep)
            .NotEmpty()
            .WithMessage("O CEP deve ser informado");
    }
}
