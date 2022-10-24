using AutoMapper;
using AVIS.CoreBase.Extensions;
using Avis.SolicitudReembolso.Application;

namespace Avis.SolicitudReembolso.Infrastructure
{
    public static class WebApplicationExtensions
    {
        private static void AddAutomapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<DomainMapping>(); });

            var mapper = config.CreateMapper();
            MapperFactory.AddMapper(mapper);
        }

        public static WebApplication MapSwagger(this WebApplication app)
        {
            AddAutomapper();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API registro de solicitud de reembolso de prepago");

                c.InjectStylesheet("/swaggerext/swagger-ui.css");
                c.InjectJavascript("/swaggerext/swagger-ui.js", "text/javascript");
            });

            return app;
        }
    }
}