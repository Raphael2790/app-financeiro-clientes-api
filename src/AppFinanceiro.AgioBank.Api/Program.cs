using AppFinanceiro.AgioBank.Api.Controllers;
using AppFinanceiro.AgioBank.Api.Filters;
using AppFinanceiro.AgioBank.Api.Middlewares;
using AppFinanceiro.AgioBank.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AddHeaderOperationFilter>();
    // Configure outras opções, se necessário
});

builder.Services.AddScoped<HeaderValidationMiddleware>();
builder.Services.AddScoped<ExceptionMiddleware>();
builder.Services.ConfigureDependencies();

var app = builder.Build();

app.MapClientRoutes();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<HeaderValidationMiddleware>();

app.Run();
