using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Interface;
using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;
using AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;

namespace AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar;

public class InativarCliente : IInativarCliente
{
    //Esse cara é reativo a uma mensagem de conta inativada
    //Fluxo de inativação do cliente pode vir de várias fontes
    public Task<Resultado> Handle(InativarClienteRequest request, CancellationToken cancellationToken)
    {
        //Inativar cliente
        return Task.FromResult(new Resultado());
    }
}