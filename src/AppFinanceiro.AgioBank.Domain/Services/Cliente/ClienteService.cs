using AppFinanceiro.AgioBank.Domain.Services.Cliente.Interface;

namespace AppFinanceiro.AgioBank.Domain.Services.Cliente;

public class ClienteService : IClienteService
{
    public Task<bool> InativarCliente(Guid id)
    {
        throw new NotImplementedException();
    }
}