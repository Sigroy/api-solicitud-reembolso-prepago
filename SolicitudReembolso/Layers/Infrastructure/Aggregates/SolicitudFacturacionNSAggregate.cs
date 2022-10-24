using AVIS.CoreBase.Clases;
using AVIS.CoreBase.Extensions;
using FluentValidation.Results;
using FluentValidation;
using Avis.SolicitudReembolso.Application;
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Infrastructure;

public class SolicitudFacturacionNSAggregate : ISolicitudFacturacionNSAggregate
{
    private SolicitudesFacturacionNS _solicitud;

    private readonly IValidator<SolicitudesFacturacionNSDTO> _validator;

    private readonly IDapperUnitofWork _unitofWork;

    public IList<InternalException> Errores { get; } = new List<InternalException>();

    public bool Success { get; private set; } = false;

    public SolicitudFacturacionNSAggregate(IValidator<SolicitudesFacturacionNSDTO> validator,
        IDapperUnitofWork unitofWork)
    {
        _unitofWork = unitofWork;
        _validator = validator;
    }

    public async Task<int> CreateAsync(SolicitudesFacturacionNSDTO solicitud)
    {
        Success = false;
        int id = 0;
        try
        {
            ValidationResult result = await _validator.ValidateAsync(solicitud);

            if (!result.IsValid)
            {
                Errores.ToList().AddRange(result.ToErrorList(this.GetType().ToString(), "CreateAsync"));
                Success = false;
            }
            else
            {
                _solicitud = solicitud.ToModelorVM<SolicitudesFacturacionNS>();
                var key = Guid.NewGuid().ToString();
                _solicitud.SolicitudFacturacionNSPkey = key;

                #region TRANSACCION DAPPER

                try
                {
                    id = await _unitofWork.SolicitudCmdRepository.AddAsync(_solicitud);

                    if (_unitofWork.SolicitudCmdRepository.Success)
                    {
                        if (_unitofWork.SolicitudCmdRepository.Success)
                        {
                            Success = true;
                        }
                    }

                    if (Success)
                    {
                        _unitofWork.Commit();
                    }
                    else
                    {
                        id = 0;
                        Success = false;

                        if (_unitofWork.SolicitudCmdRepository.Errores.Count > 0)
                        {
                            _unitofWork.SolicitudCmdRepository.Errores.ToCurrentList(Errores);
                        }

                        _unitofWork.Rollback();
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
                        MethodName = "Transaccion Dapper",
                        ErrorMessage = "Inner:" + extra + " Exception:" + ex.Message,
                        Ex = ex
                    };
                    Errores.Add(error);
                }

                #endregion
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