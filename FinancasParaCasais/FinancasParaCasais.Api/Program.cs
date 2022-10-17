using FinancasParaCasais.Api.Middlewares;
using FinancasParaCasais.Api.Routers;
using FinancasParaCasais.DI;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDependencies();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseNotificationMiddleware();

app.UseExceptionHandler(exceptionHandler =>
{
    exceptionHandler.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = Text.Plain;

        await context.Response.WriteAsync("Ocorreu um erro.");
    });
});

app.MapConjugesRoutes();
app.MapDespesasRoutes();
app.MapTransferenciasRoutes();

app.Run();