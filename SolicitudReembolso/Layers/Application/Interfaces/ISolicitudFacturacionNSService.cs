using AVIS.CoreBase.Interfaces;

//Dependencia de arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

public interface ISolicitudFacturacionNSService : IGenericService
{
    Task<IList<SolicitudFacturacionNSDTO>> GetAllAsync(string filtro = "");

    Task<int> CreateAsync(SolicitudFacturacionNSDTO solicitud);

    Task<SolicitudFacturacionNSDTO> GetbyIdAsync(int id);
}