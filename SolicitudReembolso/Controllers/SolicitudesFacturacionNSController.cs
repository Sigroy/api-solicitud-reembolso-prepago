using AVIS.CoreBase.Extensions;
using AVIS.CoreBase.Security;
using Microsoft.AspNetCore.Mvc;
using System.Net;

//Dependencia Arquitectura
using Avis.SolicitudReembolso.Application;
using Avis.SolicitudReembolso.Domain;

namespace Avis.SolicitudReembolso.Presentation;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class SolicitudesFacturacionNSController : ControllerBase
{
    private ISolicitudFacturacionNSService _service;

    public SolicitudesFacturacionNSController(ISolicitudFacturacionNSService service)
    {
        _service = service;
    }

    [HttpGet]
    [JwtAuthorizeAttributeV2(true)] //--> Ojo debe tener el valor inicial en true para usar con Medotos de Api
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var lista = await _service.GetAllAsync();
            if (_service.Success)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest(_service.Errores.ToHttpResponse(HttpStatusCode.UnprocessableEntity));
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToHttpResponse(HttpStatusCode.UnprocessableEntity));
        }
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        try
        {
            //string filtro = $" AutoId = {id}";
            var elemento = await _service.GetbyIdAsync(id);
            return Ok(elemento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }


    [HttpPost("Create")]
    [JwtAuthorizeAttributeV2(true)]
    public async Task<IActionResult> CreateAsync([FromBody] SolicitudFacturacionNSDTO solicitud)
    {
        try
        {
            int id = await _service.CreateAsync(solicitud);

            if (_service.Success)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(_service.Errores.ToHttpResponse(HttpStatusCode.UnprocessableEntity));
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToHttpResponse(HttpStatusCode.UnprocessableEntity));
        }
    }
}