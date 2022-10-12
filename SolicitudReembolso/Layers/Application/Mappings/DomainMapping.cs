using AutoMapper;

//Dependencia Arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

public class DomainMapping : Profile
{
    
    public DomainMapping()
    {
        CreateMap<SolicitudFacturacionNSDTO, SolicitudFacturacionNS>().ReverseMap();
    }
}