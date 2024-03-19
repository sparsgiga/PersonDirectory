using PersonDirectory.API.Middlewares;
using PersonDirectory.Application;
using PersonDirectory.Infrastructure;
using PersonDirectory.Persistence;
using PersonDirectory.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContextInitializer = scope.ServiceProvider.GetRequiredService<PersonDirectoryDbInitializer>();
        await dbContextInitializer.InitialDataAsync();
    }
}

app.UseMiddleware<ExceptionHandler>();

app.UseMiddleware<LocalizationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
