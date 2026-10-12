using Net10Api.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Puerto dinámico para entornos Cloud (como Render)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Registrar servicios y controladores
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddControllers();

// OpenAPI nativo de .NET 10 (sin dependencias externas de terceros)
builder.Services.AddOpenApi();

var app = builder.Build();

// Habilitar la interfaz OpenAPI en desarrollo o producción
app.MapOpenApi();

// Redirección opcional o mapeo directo de endpoints de la API
app.UseAuthorization();
app.MapControllers();

app.Run();
