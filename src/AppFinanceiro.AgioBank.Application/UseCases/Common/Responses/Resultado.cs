namespace AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;

public class Resultado
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public string[] Erros { get; set; }
}

public class Resultado<T> : Resultado
{
    public T Dados { get; set; }
    
    public static Resultado<T> CriarSucesso(T dados)
    {
        return new Resultado<T>
        {
            Sucesso = true,
            Dados = dados
        };
    }
    
    public static Resultado<T> CriarFalha(string mensagem, string[] erros)
    {
        return new Resultado<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            Erros = erros
        };
    }
}