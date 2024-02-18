using AppFinanceiro.AgioBank.Domain.Entities;
using AppFinanceiro.AgioBank.Domain.Enums;
using AppFinanceiro.AgioBank.Domain.ValueObjects;

namespace AppFinanceiro.AgioBank.UnitTests.Fakers;

public static class ClienteFaker
{
    public static Cliente ObtemClienteValido()
        => new Cliente("João", "Silva", new Telefone("+55 (11) 99999-9999"), "email@email.com", "94673614003", TipoCliente.PessoaFisica, "Maria", 
            EnderecoFaker.ObtemEnderecoValido());

    public static Cliente ObtemClienteInvalido()
        => new Cliente("J", "S", new Telefone("11999999999"), "joao.silva.com", "12345678901", TipoCliente.PessoaFisica, "M", EnderecoFaker.ObtemEnderecoInvalido());
}
