using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;
using AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AppFinanceiro.AgioBank.Api.Controllers;

public static class ClienteApi
{
    public static void MapClientRoutes(this IEndpointRouteBuilder app)
    {
        var clientGroup = app.MapGroup("api/clientes")
            .WithTags("Clientes");
        
        
        clientGroup.MapDelete("inativar/{id:guid}", async Task<Results<NoContent, BadRequest<Resultado>>> (Guid id, [FromServices] IMediator mediator, [FromBody] InativarClienteRequest request) =>
        {
            request.Id = id;
            var response = await mediator.Send(request);
            
            if(response.Sucesso)
                return TypedResults.NoContent();
            
            return TypedResults.BadRequest(response);
        });
    }
}