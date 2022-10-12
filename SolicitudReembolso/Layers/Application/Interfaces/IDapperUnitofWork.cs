using AVIS.CoreBase.Interfaces;

// Dependencia de arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

// Extensión de la unidad de trabajo

public interface IDapperUnitofWork : IUnitofWork
{
    IQryRepository<SolicitudFacturacionNS> SolicitudQryRepository { get; }
    ICmdRepository<SolicitudFacturacionNS> SolicitudCmdRepository { get; }

    IInMemoryRepository<SolicitudFacturacionNS> InMemoryRepository { get; }
}