using AppFinanceiro.AgioBank.Domain.Common;
using AppFinanceiro.AgioBank.Domain.ValueObjects;

namespace AppFinanceiro.AgioBank.UnitTests.Fakers;

public class ObjetoFaker : ObjetoNotificavel
{
    public static Email ObterenderecoValido()
               => new("teste@gmail.com");

    public static Email ObterenderecoInvalido()
               => new("teste.com");
}
