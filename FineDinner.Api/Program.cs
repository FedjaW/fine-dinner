using FineDinner.Application;
using FineDinner.Infrastructure;

# region Dependency Injection
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.
        AddApplication().
        AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
}
# endregion

# region Request Pipeline
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
#endregion