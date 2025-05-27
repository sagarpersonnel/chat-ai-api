using ChatSearchApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; // ✅ Add this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // ✅ Needed for Swagger
builder.Services.AddSwaggerGen(c =>          // ✅ Swagger configuration
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Chat Search API",
        Version = "v1",
        Description = "A simple API for searching and posting chat messages"
    });
});

builder.Services.AddSingleton<ChatService>();

var app = builder.Build();

// ✅ Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat Search API v1");
        c.RoutePrefix = string.Empty; // Swagger UI will be at root URL
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
