using AppFinanceiro.AgioBank.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<HeaderValidationMiddleware>();
builder.Services.AddScoped<ExceptionMiddleware>();

var app = builder.Build();

app.MapPost("/cliente", ([FromServices] IServiceProvider serviceProvider, [FromBody] string texto) => 
{
    return "Hello World!";
}).ShortCircuit();

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
