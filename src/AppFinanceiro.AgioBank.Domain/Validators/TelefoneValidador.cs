using AppFinanceiro.AgioBank.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AppFinanceiro.AgioBank.Domain.Validators;
public class TelefoneValidador : AbstractValidator<Telefone>
{
    private const string pattern = @"^\+\d{2} \(\d{2}\) \d{5}-\d{4}$";
    private Regex regex = new Regex(pattern, RegexOptions.Compiled);
    public static TelefoneValidador Instance => new();

    public TelefoneValidador()
    {
        RuleFor(t => t.CodPais)
            .NotEmpty()
            .WithMessage("O código do país deve ser informado");

        RuleFor(t => t.DDD)
            .NotEmpty()
            .WithMessage("O DDD deve ser informado");

        RuleFor(t => t.Numero)
            .NotEmpty()
            .WithMessage("O número deve ser informado");  

        RuleFor(t => t.ToString())
            .Must(Validar)
            .WithMessage("O telefone está em formato inválido");
        
    }

    private bool Validar(string telefone) => regex.IsMatch(telefone);

    

}
