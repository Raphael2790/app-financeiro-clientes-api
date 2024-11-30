using System.Text.Json.Serialization;

namespace AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;

public class Resultado
{   
    [JsonPropertyName("sucesso")]
    public bool Sucesso { get; set; }
    
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; }
    
    [JsonPropertyName("erros")]
    public string[] Erros { get; set; }
    
    public static Resultado CriarSucesso()
    {
        return new Resultado
        {
            Sucesso = true
        };
    }
    
    public static Resultado CriarFalha(string mensagem, string[] erros)
    {
        return new Resultado
        {
            Sucesso = false,
            Mensagem = mensagem,
            Erros = erros
        };
    }
}

public class Resultado<T> : Resultado
{
    [JsonPropertyName("dados")]
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