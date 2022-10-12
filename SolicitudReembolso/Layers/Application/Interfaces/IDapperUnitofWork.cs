using AVIS.CoreBase.Interfaces;

// Dependencia de arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

// Extensión de la unidad de trabajo

public interface IDapperUnitofWork : IUnitofWork
{
    IQryRepository<SolicitudFacturacionNS> AutoQryRepository { get; }
    ICmdRepository<SolicitudFacturacionNS> AutoCmdRepository { get; }

    IInMemoryRepository<SolicitudFacturacionNS> InMemoryRepository { get; }
}