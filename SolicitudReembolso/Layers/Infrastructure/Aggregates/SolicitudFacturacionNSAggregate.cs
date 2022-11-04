using AVIS.CoreBase.Clases;
using AVIS.CoreBase.Extensions;
using FluentValidation.Results;
using FluentValidation;
using Avis.SolicitudReembolso.Application;
using Avis.SolicitudReembolso.Domain;
using Newtonsoft.Json;

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

                var nombreEmpleado = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["NombreEmpleado"];
                _solicitud.NombreEmpleado = nombreEmpleado.ToUpper();

                var noEmpleado = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["NoEmpleado"];
                _solicitud.NoEmpleado = noEmpleado;

                var segmentoNegocio = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["SegmentoNegocio"];
                _solicitud.SegmentoNegocio = segmentoNegocio;

                var tipoFactura = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["TipoFactura"];
                _solicitud.TipoFactura = tipoFactura;

                var origen = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["Origen"];
                _solicitud.Origen = origen;

                var estatus = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["Estatus"];
                _solicitud.Estatus = estatus;

                var motivoDevolucion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["MotivoDevolucion"];
                _solicitud.MotivoDevolucion = motivoDevolucion;

                var tipoDevolucion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["TipoDevolucion"];
                _solicitud.TipoDevolucion = tipoDevolucion;

                var requiereFacturacion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["RequiereFacturacion"];
                _solicitud.RequiereFacturacion = requiereFacturacion;

                var canceladaWizard = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["CanceladaWizard"];
                _solicitud.CanceladaWizard = canceladaWizard;

                var politicaReembolso = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiParameters")["PoliticaReembolso"];
                List<PoliticaReembolsoDTO> lPoliticaReembolso = JsonConvert.DeserializeObject<List<PoliticaReembolsoDTO>>(politicaReembolso);

                var hoy = DateTime.Today;
                var intervaloHoyFechaCO = solicitud.FechaCO - hoy;
                var diferenciaDeDias = intervaloHoyFechaCO.Days;
                string tituloPoliticaReembolso = "";
                string porcentajePoliticaReembolso = "";

                if (diferenciaDeDias <= lPoliticaReembolso[0].DiasMax)
                {
                    _solicitud.MontoDevolver = solicitud.MontoTotalPrepago * lPoliticaReembolso[0].Porcentaje;
                    _solicitud.TipoDevolucion = "Parcial";
                    tituloPoliticaReembolso = lPoliticaReembolso[0].Titulo;
                    porcentajePoliticaReembolso = lPoliticaReembolso[0].Porcentaje.ToString("0%");
                } else if (diferenciaDeDias <= lPoliticaReembolso[1].DiasMax)
                {
                    _solicitud.MontoDevolver = solicitud.MontoTotalPrepago * lPoliticaReembolso[1].Porcentaje;
                    _solicitud.TipoDevolucion = "Parcial";
                    tituloPoliticaReembolso = lPoliticaReembolso[1].Titulo;
                    porcentajePoliticaReembolso = lPoliticaReembolso[1].Porcentaje.ToString("0%");
                } else if (diferenciaDeDias <= lPoliticaReembolso[2].DiasMax)
                {
                    _solicitud.MontoDevolver = solicitud.MontoTotalPrepago * lPoliticaReembolso[2].Porcentaje;
                    _solicitud.TipoDevolucion = "Parcial";
                    tituloPoliticaReembolso = lPoliticaReembolso[2].Titulo;
                    porcentajePoliticaReembolso = lPoliticaReembolso[2].Porcentaje.ToString("0%");
                } else
                {
                    _solicitud.MontoDevolver = solicitud.MontoTotalPrepago * lPoliticaReembolso[3].Porcentaje;
                    _solicitud.TipoDevolucion = "Total";
                    tituloPoliticaReembolso = lPoliticaReembolso[3].Titulo;
                    porcentajePoliticaReembolso = lPoliticaReembolso[3].Porcentaje.ToString("0%");
                }

                _solicitud.ComentariosAdicionales = $"Nombre del cliente: {solicitud.NombreCliente} {solicitud.ApellidoPaterno}<br>" +
                                                    $"Email del cliente: {solicitud.MailNotificacion}<br>" +
                                                    $"Teléfono del cliente: {solicitud.TelefonoCliente}<br>" +
                                                    $"Importe total del prepago: {solicitud.MontoTotalPrepago}<br>" +
                                                    $"Fecha de check in: {solicitud.FechaCI.ToString("dd/MM/yyyy")}<br>" +
                                                    $"Fecha de check out: {solicitud.FechaCO.ToString("dd/MM/yyyy")}<br>" +
                                                    $"Política de reembolso aplicada: {porcentajePoliticaReembolso} - {tituloPoliticaReembolso}";

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