using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

Console.WriteLine("Starting dotnet web server");

// Define API endpoints
app.MapGet("/", () => "Hello, World!");

app.MapGet("/api/greet/{name}", (string name) =>
    $"Hello, {name}!");

app.MapPost("/api/echo", (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = reader.ReadToEndAsync().Result;
    return $"You sent: {body}";
});

app.Run();
