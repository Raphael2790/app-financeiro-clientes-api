namespace AppFinanceiro.AgioBank.Domain.ValueObjects;

public class Email(string endereco)
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
}
