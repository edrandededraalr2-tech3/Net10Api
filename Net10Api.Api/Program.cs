using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.OpenApi;
using Net10Api.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Puerto dinámico para entornos Cloud (como Render)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Registrar servicios y controladores
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddControllers();

// OpenAPI nativo de .NET 10
builder.Services.AddOpenApi();

var app = builder.Build();

// Habilitar la interfaz OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
