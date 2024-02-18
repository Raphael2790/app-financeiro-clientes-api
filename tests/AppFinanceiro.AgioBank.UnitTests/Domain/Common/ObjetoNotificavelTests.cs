using AppFinanceiro.AgioBank.Domain.Common;
using AppFinanceiro.AgioBank.UnitTests.Fakers;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.Common;

public class ObjetoNotificavelTests
{
    [Fact]
    public void DeveAdicionarNotificacao()
    {
        // Arrange
        var objeto = new ObjetoFaker();
        var notificacao = new Notificacao("Mensagem");

        // Act
        objeto.AdicionarNotificacao(notificacao);

        // Assert
        objeto.Notificacoes.Should().HaveCount(1);
    }

    [Fact]
    public void DeveAdicionarNotificacoes()
    {
        // Arrange
        var objeto = new ObjetoFaker();
        var notificacoes = new List<Notificacao>
        {
            new("Mensagem 1"),
            new("Mensagem 2")
        };

        // Act
        objeto.AdicionarNotificacoes(notificacoes);

        // Assert
        objeto.Notificacoes.Should().HaveCount(2);
    }

    [Fact]
    public void DeveLimparNotificacoes()
    {
        // Arrange
        var objeto = new ObjetoFaker();
        objeto.AdicionarNotificacao(new Notificacao("Mensagem"));

        // Act
        objeto.LimparNotificacoes();

        // Assert
        objeto.Notificacoes.Should().BeEmpty();
    }

    [Fact]
    public void DeveSerValido()
    {
        // Arrange
        var objeto = new ObjetoFaker();

        // Act
        var ehValido = objeto.EhValido();

        // Assert
        ehValido.Should().BeTrue();
        objeto.Notificacoes.Should().NotBeNull();
        objeto.Notificacoes.Should().BeEmpty();
    }

    [Fact]
    public void NaoDeveSerValido()
    {
        // Arrange
        var objeto = new ObjetoFaker();
        objeto.AdicionarNotificacao(new Notificacao("Mensagem"));

        // Act
        var ehValido = objeto.EhValido();

        // Assert
        ehValido.Should().BeFalse();
    }
}
