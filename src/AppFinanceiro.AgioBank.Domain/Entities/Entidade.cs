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

    
}
