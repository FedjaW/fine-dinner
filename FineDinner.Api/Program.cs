// Dependency injection
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
}

// Request pipeline
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}