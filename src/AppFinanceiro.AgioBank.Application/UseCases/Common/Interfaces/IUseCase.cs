using MediatR;

namespace AppFinanceiro.AgioBank.Application.UseCases.Common.Interfaces;

public interface IUseCase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
}