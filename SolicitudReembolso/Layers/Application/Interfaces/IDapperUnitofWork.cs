using AVIS.CoreBase.Interfaces;

// Dependencia de arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

// Extensión de la unidad de trabajo

public interface IDapperUnitofWork : IUnitofWork
{
    IQryRepository<SolicitudesFacturacionNS> SolicitudQryRepository { get; }
    ICmdRepository<SolicitudesFacturacionNS> SolicitudCmdRepository { get; }

    IInMemoryRepository<SolicitudesFacturacionNS> InMemoryRepository { get; }
}