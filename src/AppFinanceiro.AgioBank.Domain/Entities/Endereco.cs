namespace AppFinanceiro.AgioBank.Domain.Entities;

public class Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string pais, string cep, Guid idCliente) : Entidade
{
    public string Logradouro { get; private set; } = logradouro;
    public string Numero { get; private set; } = numero;
    public string Complemento { get; private set; } = complemento;
    public string Bairro { get; private set; } = bairro;
    public string Cidade { get; private set; } = cidade;
    public string Estado { get; private set; } = estado;
    public string Pais { get; private set; } = pais;
    public string Cep { get; private set; } = cep;
    public Guid IdCliente { get; private set; } = idCliente;
}
