using AVIS.CoreBase;
using AVIS.CoreBase.Interfaces;
using System.Data;
using System.Data.SqlClient;

//Dependencia Arquitectura
using Avis.SolicitudReembolso.Domain;
using Avis.SolicitudReembolso.Application;

namespace Avis.SolicitudReembolso.Infrastructure;

/// <summary>
/// Extensión e implementación de Unit of Work
/// </summary>
public class DapperUnitofWork : UnitofWorkBase, IDapperUnitofWork
{
    public IQryRepository<SolicitudFacturacionNS> SolicitudQryRepository { get; private set; }
    public ICmdRepository<SolicitudFacturacionNS> SolicitudCmdRepository { get; private set; }

    public IInMemoryRepository<SolicitudFacturacionNS> InMemoryRepository { get; private set; }

    public DapperUnitofWork(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(dbTransaction)
    {
        SolicitudQryRepository =
            RepositoryResolver.GetQryRepositoryInstance<SolicitudFacturacionNS>(sqlConnection, dbTransaction);
        SolicitudCmdRepository =
            RepositoryResolver.GetCmdRepositoryInstance<SolicitudFacturacionNS>(sqlConnection, dbTransaction);

        InMemoryRepository = RepositoryResolver.GetInMemoryRepositoryInstance<SolicitudFacturacionNS>();
    }
}