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
}
