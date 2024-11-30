using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppFinanceiro.AgioBank.Api.Filters;

public class AddHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "x-origem",
            In = ParameterLocation.Header,
            Required = true,
            Description = "Indica a origem da requisição",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}