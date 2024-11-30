using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Interface;
using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar.Requests;
using AppFinanceiro.AgioBank.Application.UseCases.Common.Responses;
using AppFinanceiro.AgioBank.Domain.Services.Cliente.Interface;
using AppFinanceiro.AgioBank.Utils.Notifications.Interfaces;
using AppFinanceiro.AgioBank.Utils.Notifications.Extensions;
using Microsoft.Extensions.Logging;

namespace AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar;

public class InativarCliente(IClienteService clienteService, ILogger<InativarCliente> logger, INotificationContext notificationContext)
    : IInativarCliente
{
    private readonly IClienteService _clienteService = clienteService;
    private readonly ILogger<InativarCliente> _logger = logger;
    private readonly INotificationContext _notificationContext = notificationContext;
    
    //Esse cara é reativo a uma mensagem de conta inativada
    //Fluxo de inativação do cliente pode vir de várias fontes
    public async Task<Resultado> Handle(InativarClienteRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Inativando cliente...");
        
        var inativado = await _clienteService.InativarCliente(request.Id);
        
        if (inativado)
        {
            _logger.LogInformation("Cliente inativado com sucesso.");
            return Resultado.CriarSucesso();
        }
        
        _logger.LogError("Erro ao inativar cliente.");
        
        var messages = _notificationContext.GetMessagesFromContext();
        
        return Resultado.CriarFalha("Erro ao inativar cliente.", messages);
    }
}