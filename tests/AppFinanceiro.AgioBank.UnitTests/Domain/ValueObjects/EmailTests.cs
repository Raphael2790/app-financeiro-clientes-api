using AppFinanceiro.AgioBank.UnitTests.Fakers;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Deve_PossuirNotificacao_QuandoEmailInvalido()
    {
        // Arrange e Act
        var email = ObjetoFaker.ObterenderecoInvalido();
        email.Validar();
     

        // Assert
        email.EhValido().Should().BeFalse();
        email.Notificacoes.Should().HaveCount(1);
        email.Notificacoes.Should().Contain(n => n.Mensagem == "O email está em formato inválido");
    }

    [Fact]
    public void Deve_SerValido_QuandoEmailValido()
    {
        // Arrange e Act
        var email = ObjetoFaker.ObterenderecoValido();
        email.Validar();

        // Assert
        email.EhValido().Should().BeTrue();
        email.Notificacoes.Should().BeEmpty();
    }
}
