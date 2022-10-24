using AVIS.CoreBase.Interfaces;
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

public interface ISolicitudFacturacionNSAggregate : IAggregate
{
    Task<int> CreateAsync(SolicitudesFacturacionNSDTO solicitud);
}