using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppFinanceiro.AgioBank.Api.Controllers;

public static class ClienteController
{
    public static void MapClientRoutes(this IEndpointRouteBuilder app)
    {
        var clientGroup = app.MapGroup("api/clientes")
            .WithTags("Clientes");
        
        clientGroup.MapDelete("inativar/{id:guid}", async (Guid id, [FromServices] IMediator mediator, [FromBody] InativarClienteRequest request) =>
        {
            request.Id = id;
            var response = await mediator.Send(request);
            
            return response.Sucesso ? Results.NoContent() : Results.BadRequest(response);
        });
    }
}