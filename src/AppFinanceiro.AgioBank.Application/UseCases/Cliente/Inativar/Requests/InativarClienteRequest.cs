using AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;
using MediatR;

namespace AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;

public class InativarClienteRequest : IRequest<Resultado>
{
    public Guid Id { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
}