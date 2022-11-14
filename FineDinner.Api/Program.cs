using FineDinner.Api;
using FineDinner.Application;
using FineDinner.Infrastructure;

# region Dependency Injection
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.
        AddPresentation().
        AddApplication().
        AddInfrastructure(builder.Configuration);
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

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.MapControllers();
    app.Run();
}
#endregion