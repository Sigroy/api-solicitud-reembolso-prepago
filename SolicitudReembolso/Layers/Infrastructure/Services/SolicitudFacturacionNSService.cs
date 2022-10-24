using AVIS.CoreBase.Clases;
using AVIS.CoreBase.Extensions;
using AVIS.CoreBase.Interfaces;
using System.Data.SqlClient;
using System.Data;

//Dependencia Arquitectura
using Avis.SolicitudReembolso.Application;
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Infrastructure;

public class SolicitudFacturacionNSService : ISolicitudFacturacionNSService
{
    private readonly ISolicitudFacturacionNSAggregate _solicitud;

    public readonly IQryRepository<SolicitudesFacturacionNS> _qryRepository;
    public readonly ICmdRepository<SolicitudesFacturacionNS> _cmdRepository;

    public IList<InternalException> Errores { get; } = new List<InternalException>();

    public bool Success { get; private set; } = false;

    public SolicitudFacturacionNSService(
        ISolicitudFacturacionNSAggregate solicitud,
        SqlConnection sqlConnection,
        IDbTransaction dbTransaction
    )
    {
        _solicitud = solicitud;
        //_unitofWork = unitofWork;
        _qryRepository = RepositoryResolver.GetQryRepositoryInstance<SolicitudesFacturacionNS>(sqlConnection, dbTransaction);
        _cmdRepository = RepositoryResolver.GetCmdRepositoryInstance<SolicitudesFacturacionNS>(sqlConnection, dbTransaction);
    }

    public async Task<IList<SolicitudesFacturacionNSDTO>> GetAllAsync(string filtro = "")
    {
        Success = true;
        IList<SolicitudesFacturacionNSDTO> lista = new List<SolicitudesFacturacionNSDTO>();
        try
        {
            //Dapper
            var temp = await _qryRepository.GetAllAsync();

            if (_qryRepository.Success)
            {
                lista = temp.ToListOfDestination<SolicitudesFacturacionNSDTO>();
            }
            else
            {
                Errores.ToList().AddRange(_qryRepository.Errores);
                Success = false;
            }
        }
        catch (Exception ex)
        {
            Success = false;
            string extra = "";
            if (ex.InnerException != null)
            {
                extra = ex.InnerException.Message;
            }

            InternalException error = new InternalException()
            {
                ClassName = this.GetType().ToString(),
                MethodName = "Index",
                ErrorMessage = "Inner:" + extra + " Exception:" + ex.Message,
                Ex = ex
            };
            Errores.Add(error);
        }

        return lista;
    }

    public async Task<SolicitudesFacturacionNSDTO> GetbyIdAsync(int id)
    {
        Success = true;
        SolicitudesFacturacionNSDTO item = null;
        try
        {
            var elemento = await _qryRepository.GetByIdAsync(id);
            if (_qryRepository.Success)
            {
                item = elemento.ToModelorVM<SolicitudesFacturacionNSDTO>();
            }
            else
            {
                Errores.ToList().AddRange(_qryRepository.Errores);
                Success = false;
            }
        }
        catch (Exception ex)
        {
            Success = false;
            string extra = "";
            if (ex.InnerException != null)
            {
                extra = ex.InnerException.Message;
            }

            InternalException error = new InternalException()
            {
                ClassName = this.GetType().ToString(),
                MethodName = "Get",
                ErrorMessage = "Inner:" + extra + " Exception:" + ex.Message,
                Ex = ex
            };
            Errores.Add(error);
        }

        return item;
    }

    public async Task<int> CreateAsync(SolicitudesFacturacionNSDTO solicitud)
    {
        Success = true;
        int id = 0;
        try
        {
            id = await _solicitud.CreateAsync(solicitud);
            if (!_solicitud.Success)
            {
                Errores.ToList().AddRange(_solicitud.Errores);
                Success = false;
            }
        }
        catch (Exception ex)
        {
            Success = false;
            string extra = "";
            if (ex.InnerException != null)
            {
                extra = ex.InnerException.Message;
            }

            InternalException error = new InternalException()
            {
                ClassName = this.GetType().ToString(),
                MethodName = "Add",
                ErrorMessage = "Inner:" + extra + " Exception:" + ex.Message,
                Ex = ex
            };
            Errores.Add(error);
        }

        return id;
    }
}