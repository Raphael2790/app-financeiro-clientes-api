using AppFinanceiro.AgioBank.Domain.Common;
using System.Text.RegularExpressions;

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
        if (!Regex.IsMatch(Endereco, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            AdicionarNotificacao(new Notificacao("O email está em formato inválido"));
        }
    }
}
