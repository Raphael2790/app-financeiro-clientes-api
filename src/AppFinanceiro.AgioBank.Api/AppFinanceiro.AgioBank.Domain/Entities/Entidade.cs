namespace AppFinanceiro.AgioBank.Domain.Entities;
public abstract class Entidade
{
    public Guid Id { get; }
    public DateTime DataCadastro { get; set; }

    protected Entidade()
    {
        Id = Guid.NewGuid();
        DataCadastro = DateTime.Now;
    }
}
