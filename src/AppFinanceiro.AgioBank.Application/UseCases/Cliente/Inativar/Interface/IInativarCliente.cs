using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;
using AppFinanceiro.AgioBank.Application.UseCases.Common.Interfaces;
using AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;

namespace AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Interface;

public interface IInativarCliente : IUseCase<InativarClienteRequest, Resultado> { }