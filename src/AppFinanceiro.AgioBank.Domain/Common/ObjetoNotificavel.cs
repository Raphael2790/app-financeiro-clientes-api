using AppFinanceiro.AgioBank.Domain.Entities;
using FluentValidation;

namespace AppFinanceiro.AgioBank.Domain.Common;

public abstract class ObjetoNotificavel
{
    public List<Notificacao> Notificacoes { get; private set; }

    public ObjetoNotificavel()
    {
        Notificacoes = [];
    }

    public void AdicionarNotificacao(Notificacao notificacao)
    {
        Notificacoes.Add(notificacao);
    }

    public void AdicionarNotificacoes(IEnumerable<Notificacao> notificacoes)
    {
        Notificacoes.AddRange(notificacoes);
    }

    public void LimparNotificacoes()
    {
        Notificacoes.Clear();
    }

    public bool EhValido()
    {
        return !Notificacoes.Any();
    }

    public virtual void Validar<T>(AbstractValidator<T> validator, T entidade) where T : ObjetoNotificavel
    {
        var result = validator.Validate(entidade);
        if (!result.IsValid)
        {
            var notificacoes = result.Errors.Select(error => new Notificacao(error.ErrorMessage));
            AdicionarNotificacoes(notificacoes);
        }
    }
}
