namespace AppFinanceiro.AgioBank.Domain.Services.Cliente.Interface;

public interface IClienteService
{
    Task<bool> InativarCliente(Guid id);
}