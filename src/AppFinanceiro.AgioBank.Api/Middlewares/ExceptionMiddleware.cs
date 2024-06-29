
namespace AppFinanceiro.AgioBank.Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		var logger = context.RequestServices.GetService<ILogger<ExceptionMiddleware>>();

        try
		{   
            await next(context);
        }
        catch (Exception ex)
		{
			logger?.LogError(ex, ex.Message);
        }
    }
}
