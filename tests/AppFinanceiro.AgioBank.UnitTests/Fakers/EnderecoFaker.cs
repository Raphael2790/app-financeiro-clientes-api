using AppFinanceiro.AgioBank.Domain.Entities;

namespace AppFinanceiro.AgioBank.UnitTests.Fakers;

public static class EnderecoFaker
{
    public static Endereco ObtemEnderecoValido()
        => new("Rua das Flores", "123", "Apto 1", "Bairro", "Cidade", "Estado", "12345678", "019198-990", Guid.NewGuid());

    public static Endereco ObtemEnderecoInvalido()
        => new("", "", "", "", "", "", "", "", Guid.Empty);
}
