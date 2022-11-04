using FluentValidation;

//Dependencia Arquitectura
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Application;

/// <summary>
/// Implementa el validador para el DTO
/// </summary>
public class SolicitudFacturacionNSDTOValidator : AbstractValidator<SolicitudesFacturacionNSDTO>
{
    /// <summary>
    /// Contiene las reglas de validacion
    /// </summary>
    public SolicitudFacturacionNSDTOValidator()
    {
        //RuleFor(x => x.SolicitudFacturacionNSPkey)
        //    .NotNull().WithMessage("La llave no puede ser nula.")
        //    .NotEmpty().WithMessage("La llave no puede estar vacia.");
        //RuleFor(x => x.NoEmpleado);
        //RuleFor(x => x.NombreEmpleado);
        //RuleFor(x => x.SegmentoNegocio);
        //RuleFor(x => x.TipoFactura);
        RuleFor(x => x.MailNotificacion);
        //RuleFor(x => x.Origen);
        RuleFor(x => x.Distrito);
        RuleFor(x => x.NombreCliente);
        RuleFor(x => x.ApellidoPaterno);
        //RuleFor(x => x.Estatus);
        //RuleFor(x => x.MontoDevolver);
        //RuleFor(x => x.MotivoDevolucion);
        //RuleFor(x => x.RequiereFacturacion);
        //RuleFor(x => x.TipoDevolucion);
        //RuleFor(x => x.CanceladaWizard);
        RuleFor(x => x.NoReservacion);
    }
}