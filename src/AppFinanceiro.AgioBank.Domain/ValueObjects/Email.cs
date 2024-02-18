namespace AppFinanceiro.AgioBank.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; private set; }

    public Email(string endereco)
    {
        Endereco = endereco;
    }

    public static implicit operator Email(string endereco)
    {
        return new Email(endereco);
    }

    public static implicit operator string(Email email)
    {
        return email.Endereco;
    }
}
