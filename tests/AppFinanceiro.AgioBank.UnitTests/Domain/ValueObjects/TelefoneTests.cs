using AppFinanceiro.AgioBank.Domain.ValueObjects;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.ValueObjects;

public class TelefoneTests
{
    [Theory]
    [InlineData("", false, 4)]
    [InlineData(null, false, 4)]
    [InlineData("+55 11 abcd-defs", false, 4)]
    [InlineData("+55 (11) 91234-5678", true, 0)]
    public void Deve_ValidarTelefone_QuandoTelefoneInvalido_Deve_Notificar(string textoTelefone, bool ehValido, int qtdErros)
    {
        // Arrange e Act
        var telefone = new Telefone(textoTelefone);
        telefone.Validar();

        // Assert
        telefone.EhValido().Should().Be(ehValido);
        telefone.Notificacoes.Should().HaveCount(qtdErros);

        if (!ehValido)
            telefone.Notificacoes.Should().Contain(n => n.Mensagem == "O telefone está em formato inválido");
    }
}
