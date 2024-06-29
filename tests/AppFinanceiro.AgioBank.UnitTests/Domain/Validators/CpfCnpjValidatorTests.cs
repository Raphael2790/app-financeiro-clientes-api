using AppFinanceiro.AgioBank.Domain.Validators;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.Validators;

public class CpfCnpjValidatorTests
{
    [Fact]
    public void DeveRetornarErroQuandoCpfCnpjForInvalido()
    {
        // Arrange
        var cpfCnpj = "12345678901";

        // Act
        var result = CpfCnpjValidador.Validar(cpfCnpj);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void DeveRetornarSucessoQuandoCpfCnpjForValido()
    {
        // Arrange
        var cpfCnpj = "12345678909";

        // Act
        var result = CpfCnpjValidador.Validar(cpfCnpj);

        // Assert
        result.Should().BeTrue();
    }
}
