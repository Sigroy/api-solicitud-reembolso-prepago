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
    public IQryRepository<SolicitudesFacturacionNS> SolicitudQryRepository { get; private set; }
    public ICmdRepository<SolicitudesFacturacionNS> SolicitudCmdRepository { get; private set; }

    public IInMemoryRepository<SolicitudesFacturacionNS> InMemoryRepository { get; private set; }

    public DapperUnitofWork(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(dbTransaction)
    {
        SolicitudQryRepository =
            RepositoryResolver.GetQryRepositoryInstance<SolicitudesFacturacionNS>(sqlConnection, dbTransaction, "", false);

        SolicitudCmdRepository =
            RepositoryResolver.GetCmdRepositoryInstance<SolicitudesFacturacionNS>(sqlConnection, dbTransaction, "", false);

        InMemoryRepository = RepositoryResolver.GetInMemoryRepositoryInstance<SolicitudesFacturacionNS>();
    }
}