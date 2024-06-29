using AppFinanceiro.AgioBank.Domain.Entities;
using AppFinanceiro.AgioBank.UnitTests.Fakers;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.Entidades;

public class EnderecoTests
{
    [Fact]
    public void EnderecoValido()
    {
        // Arrange
        var logradouro = "Rua das Flores";
        var numero = "123";
        var complemento = "Apto 1";
        var bairro = "Bairro";
        var cidade = "Cidade";
        var estado = "Estado";
        var pais = "Pais";
        var cep = "12345678";
        var idCliente = Guid.NewGuid();

        // Act
        var endereco = new Endereco(logradouro, numero, complemento, bairro, cidade, estado, pais, cep, idCliente);

        // Assert
        endereco.Should().NotBeNull();
        endereco.Logradouro.Should().Be(logradouro);
        endereco.Numero.Should().Be(numero);
        endereco.Complemento.Should().Be(complemento);
        endereco.Bairro.Should().Be(bairro);
        endereco.Cidade.Should().Be(cidade);
        endereco.Estado.Should().Be(estado);
        endereco.Pais.Should().Be(pais);
        endereco.Cep.Should().Be(cep);
        endereco.IdCliente.Should().Be(idCliente);
        endereco.Notificacoes.Should().BeEmpty();
        endereco.EhValido().Should().BeTrue();
    }

    [Fact]
    public void EnderecoInvalido()
    {
        //Act
        var endereco = EnderecoFaker.ObtemEnderecoInvalido();
        endereco.Validar();

        // Assert
        endereco.EhValido().Should().BeFalse();
        endereco.Notificacoes.Should().HaveCount(7);
    }
}
