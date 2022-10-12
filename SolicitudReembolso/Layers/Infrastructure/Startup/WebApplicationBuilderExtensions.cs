using Serilog;
using Serilog.Events;

namespace Avis.SolicitudReembolso.Infrastructure
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddSerilog(this ConfigureHostBuilder host)
        {
            #region CONFIGURACION DEL LOG

            var dir = Directory.GetCurrentDirectory() + "\\Logs\\";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var name = "API solicitud de reembolso de prepago-" + DateTime.Now.Year.ToString() +
                       DateTime.Now.Month.ToString() +
                       DateTime.Now.Day.ToString() + ".txt";
            //CONFIGURAMOS EL SERVICIO DE LOG
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(dir + name, retainedFileCountLimit: 30)
                .CreateLogger();

            host.UseSerilog();

            #endregion
        }
    }
}