using AVIS.CoreBase.Interfaces;

//Dependencia de arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

public interface ISolicitudFacturacionNSService : IGenericService
{
    Task<IList<SolicitudesFacturacionNSDTO>> GetAllAsync(string filtro = "");

    Task<int> CreateAsync(SolicitudesFacturacionNSDTO solicitud);

    Task<SolicitudesFacturacionNSDTO> GetbyIdAsync(int id);
}