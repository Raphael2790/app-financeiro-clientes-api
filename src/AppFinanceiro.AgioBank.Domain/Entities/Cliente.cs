using AppFinanceiro.AgioBank.Domain.Enums;
using AppFinanceiro.AgioBank.Domain.Validators;
using AppFinanceiro.AgioBank.Domain.ValueObjects;

namespace AppFinanceiro.AgioBank.Domain.Entities;

public class Cliente : Entidade
{
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public Telefone Telefone { get; private set; }
    public Email Email { get; set; }
    public string Documento { get; private set; }
    public TipoCliente TipoCliente { get; private set; }
    public string NomeMae { get; private set; }
    public DateTime DataAtualizacao { get; private set; }
    public bool Ativo { get; set; }
    
    public Endereco Endereco { get; private set; }

    public Cliente(string nome, string sobrenome, Telefone telefone, string email, string documento, TipoCliente tipoCliente, string nomeMae, Endereco endereco)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Telefone = telefone;
        Email = email;
        Documento = documento;
        TipoCliente = tipoCliente;
        NomeMae = nomeMae;
        Ativo = true;
        DataAtualizacao = DateTime.Now;
        Endereco = endereco;

        Validar(ClienteValidador.Instance, this);
    }

    public void AlterarEmail(string email)
    {
        Email = email;
        Validar(ClienteValidador.Instance, this);
    }

    public void AlterarTelefone(Telefone telefone)
    {
        Telefone = telefone;
        Validar(ClienteValidador.Instance, this);
    }

    public void Inativar()
    {
        Ativo = false;
    }

    public void Reativar()
    {
        Ativo = true;
    }
}
