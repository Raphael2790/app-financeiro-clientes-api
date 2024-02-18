using AppFinanceiro.AgioBank.Domain.Validators;
using FluentAssertions;

namespace AppFinanceiro.AgioBank.UnitTests.Domain.Validators;

public class EmailValidadorTests
{
    [Fact]
    public void Deve_RetornarValido_Quando_EmailEmFormatoValido()
    {
        // Arrange
        var email = "email@email.com";
        var emailValidador = EmailValidador.Instance;

        // Act
        var resultado = emailValidador.Validate(email);

        // Assert
        resultado.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Deve_RetornarInvalido_Quando_EmailEmBranco()
    {
        // Arrange
        var email = string.Empty;
        var emailValidador = EmailValidador.Instance;

        // Act
        var resultado = emailValidador.Validate(email);

        // Assert
        resultado.IsValid.Should().BeFalse();
        resultado.Errors.Should().Contain(e => e.ErrorMessage == "O email deve ser informado");
    }

    [Fact]
    public void Deve_RetornarInvalido_Quando_EmailEmFormatoInvalido()
    {
        // Arrange
        var email = "email";
        var emailValidador = EmailValidador.Instance;

        // Act
        var resultado = emailValidador.Validate(email);

        // Assert
        resultado.IsValid.Should().BeFalse();
        resultado.Errors.Should().Contain(e => e.ErrorMessage == "O email está em formato inválido");
    }
}
