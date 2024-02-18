namespace AppFinanceiro.AgioBank.Domain.Common;

public sealed class Notificacao(string mensagem)
{
    public string Mensagem { get; } = mensagem;
}
