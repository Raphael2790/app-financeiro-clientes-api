using AppFinanceiro.AgioBank.Domain.Common;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace AppFinanceiro.AgioBank.Domain.Entities;

[ExcludeFromCodeCoverage]
public abstract class Entidade : ObjetoNotificavel
{
    public Guid Id { get; }
    public DateTime DataCadastro { get; set; }

    protected Entidade()
    {
        Id = Guid.NewGuid();
        DataCadastro = DateTime.Now;
    }

    public virtual void Validar<T>(AbstractValidator<T> validator, T entidade) where T : Entidade
    {
        var result = validator.Validate(entidade);
        if (!result.IsValid)
        {
            var notificacoes = result.Errors.Select(error => new Notificacao(error.ErrorMessage));
            AdicionarNotificacoes(notificacoes);
        }
    }
}
