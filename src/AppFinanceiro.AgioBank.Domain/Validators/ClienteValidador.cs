using AppFinanceiro.AgioBank.Domain.Entities;
using FluentValidation;

namespace AppFinanceiro.AgioBank.Domain.Validators;
public class ClienteValidador : AbstractValidator<Cliente>
{
    public static ClienteValidador Instance => new();

    public ClienteValidador()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("O nome do cliente deve ser informado")
            .MaximumLength(255)
            .WithMessage("O nome deve conter no máximo 255 caracteres")
            .MinimumLength(3)
            .WithMessage("O nome deve conter no mínimo 3 caracteres");

        RuleFor(c => c.Sobrenome)
            .NotEmpty()
            .WithMessage("O sobrenome do cliente deve ser informado")
            .MaximumLength(255)
            .WithMessage("O sobrenome deve conter no máximo 255 caracteres")
            .MinimumLength(3)
            .WithMessage("O sobrenome deve conter no mínimo 3 caracteres");

        RuleFor(c => c.Telefone)
            .NotNull()
            .WithMessage("O telefone do cliente deve ser informado")
            .Must(c => c.EValido)
            .WithMessage("O telefone está em formato inválido");

        RuleFor(c => c.Email)
            .SetValidator(EmailValidador.Instance);

        RuleFor(c => c.NomeMae)
            .NotEmpty()
            .WithMessage("O nome da mãe deve ser informado")
            .MaximumLength(255)
            .WithMessage("O nome da mãe deve conter no máximo 255 caracteres")
            .MinimumLength(3)
            .WithMessage("O nome da mãe deve conter no mínimo 3 caracteres");

        RuleFor(c => c.Documento)
            .NotEmpty()
            .WithMessage("O documento do cliente deve ser informado")
            .Must(CpfCnpjValidador.Validar)
            .WithMessage("O documento está em formato inválido");

        RuleFor(c => c.TipoCliente)
            .IsInEnum()
            .WithMessage("O tipo do cliente é inválido");

        RuleFor(c => c.Endereco)
            .NotNull()
            .WithMessage("O endereço do cliente deve ser informado")
            .SetValidator(EnderecoValidador.Instance);
    }
}
