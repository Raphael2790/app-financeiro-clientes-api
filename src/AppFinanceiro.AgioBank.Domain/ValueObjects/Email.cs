using AppFinanceiro.AgioBank.Domain.Common;
using System.Text.RegularExpressions;
using AppFinanceiro.AgioBank.Domain.Validators;

namespace AppFinanceiro.AgioBank.Domain.ValueObjects;

public class Email(string endereco) : ObjetoNotificavel
{
    public string Endereco { get; private set; } = endereco;

    public static implicit operator Email(string endereco)
    {      
        return new Email(endereco);
    }

    public static implicit operator string(Email email)
    {
        return email.Endereco;
    }

    public void Validar()
    {
        base.Validar(EmailValidador.Instance, this);
    }
}
