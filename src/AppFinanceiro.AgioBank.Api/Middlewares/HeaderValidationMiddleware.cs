namespace AppFinanceiro.AgioBank.Api.Middlewares;

public class HeaderValidationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var logger = context.RequestServices.GetService<ILogger<HeaderValidationMiddleware>>();

       
        var request = context.Request;

        if (request.Headers["x-origem"].Count == 0)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Header x-origem não informado");
            logger?.LogInformation("Header x-origem não informado");
            return;
        }

        await next(context);
    }
}
