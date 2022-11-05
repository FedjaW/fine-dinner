// Dependency injection
using FineDinner.Application;
using FineDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.
        AddApplication().
        AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
}

// Request pipeline
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}