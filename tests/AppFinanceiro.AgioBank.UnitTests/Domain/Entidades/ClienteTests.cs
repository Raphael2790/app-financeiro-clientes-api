using AppFinanceiro.AgioBank.Domain.ValueObjects;
using AppFinanceiro.AgioBank.UnitTests.Fakers;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.Entidades;

public class ClienteTests
{
    [Fact]
    public void Deve_PossuirNotificacao_QuandoClienteInvalido()
    {
        // Arrange e Act
        var cliente = ClienteFaker.ObtemClienteInvalido();
       
        // Assert
        cliente.EhValido().Should().BeFalse();
        cliente.Notificacoes.Should().HaveCount(7);
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O nome deve conter no mínimo 3 caracteres");
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O sobrenome deve conter no mínimo 3 caracteres");
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O email está em formato inválido");
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O nome da mãe deve conter no mínimo 3 caracteres");
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O documento está em formato inválido");
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O telefone está em formato inválido");
    }

    [Fact]
    public void Deve_SerValido_QuandoClienteValido()
    {
        // Arrange e Act
        var cliente = ClienteFaker.ObtemClienteValido();

        // Assert
        cliente.EhValido().Should().BeTrue();
        cliente.Notificacoes.Should().BeEmpty();
    }

    [Fact]
    public void Quando_InativarCliente_Deve_EstarInativo()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();

        cliente.Inativar();

        // Assert
        cliente.Ativo.Should().BeFalse();
    }

    [Fact]
    public void Quando_ReativarCliente_Deve_EstarAtivo()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();
        cliente.Inativar();

        cliente.Reativar();

        // Assert
        cliente.Ativo.Should().BeTrue();
    }

    [Fact]
    public void Quando_AlterarEmail_QuandoEmailInvalido_Deve_PossuirNotificacao()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();
        var email = "";

        // Act
        cliente.AlterarEmail(email);

        // Assert
        cliente.EhValido().Should().BeFalse();
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O email deve ser informado");
    }

    [Fact]
    public void Quando_AlterarEmail_QuandoEmailValido_Deve_SerAlterado()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();
        var email = "email@google.com";

        // Act
        cliente.AlterarEmail(email);

        // Assert
        cliente.Email.Endereco.Should().Be(email);
        cliente.Notificacoes.Should().BeEmpty();
        cliente.EhValido().Should().BeTrue();
    }

    [Fact]
    public void Quando_AlterarTelefone_QuandoTelefoneInvalido_Deve_PossuirNotificacao()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();
        var telefone = new Telefone("123");

        // Act
        cliente.AlterarTelefone(telefone);

        // Assert
        cliente.EhValido().Should().BeFalse();
        cliente.Notificacoes.Should().Contain(n => n.Mensagem == "O telefone está em formato inválido");
    }

    [Fact]
    public void Quando_AlterarTelefone_QuandoTelefoneValido_Deve_SerAlterado()
    {
        // Arrange
        var cliente = ClienteFaker.ObtemClienteValido();
        var telefone = new Telefone("+55 (11) 11111-1111");

        // Act
        cliente.AlterarTelefone(telefone);

        // Assert
        cliente.Telefone.DDD.Should().Be(telefone.DDD);
        cliente.Telefone.Numero.Should().Be(telefone.Numero);
        cliente.Notificacoes.Should().BeEmpty();
        cliente.EhValido().Should().BeTrue();
    }
}
