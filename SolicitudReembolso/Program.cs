using AVIS.CoreBase.Middleware;
using Serilog;

//Referencias Arquitectura
using Avis.SolicitudReembolso.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Host.AddSerilog();

builder.Services.AddControllers();
builder.Services.AddAvisCoreBaseMin(configuration);
builder.Services.AddDapper(configuration);
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddApiVersioning();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseStaticFiles();
app.MapSwagger();
app.UseHttpsRedirection();
//app.UseAuthentication();
// app.UseAuthorization();
app.AddRoutes();

#region AREA DEL PROGRAMA

try
{
    Log.Information("Iniciando API para el registro de solicitudes de reembolso de prepago");

    app.Run();

    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, "TSolicitudes de Reembolso Host terminated unexpectedly");

    return 1;
}
finally
{
    Log.Information("Saliendo de API solicitudes de reembolso de prepago");
    Log.CloseAndFlush();
}

#endregion