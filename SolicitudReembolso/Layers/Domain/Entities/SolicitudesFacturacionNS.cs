using AVIS.CoreBase.Clases;
using AVIS.CoreBase.Interfaces;

namespace Avis.SolicitudReembolso.Domain;

/// <summary>
/// Respresentacion de un registro de solicitud de reembolso
/// </summary>
public class SolicitudesFacturacionNS
{
    [IdentityField] public virtual int SolicitudFacturacionNSId { get; set; }
    public virtual string SolicitudFacturacionNSPkey { get; set; }
    public virtual string NoEmpleado { get; set; }
    public virtual string NombreEmpleado { get; set; }
    public virtual string AreaEmpleado { get; set; }
    public virtual string SegmentoNegocio { get; set; }
    public virtual string MotivoSolicitud { get; set; }
    public virtual string TipoFactura { get; set; }
    public virtual string MailNotificacion { get; set; }
    public virtual string RA { get; set; }
    public virtual string MVA { get; set; }
    public virtual string Origen { get; set; }
    public virtual string Distrito { get; set; }
    public virtual string NombreCliente { get; set; }
    public virtual string ApellidoPaterno { get; set; }
    public virtual string ApellidoMaterno { get; set; }
    public virtual string RazonSocial { get; set; }
    public virtual string RegimenFiscal { get; set; }
    public virtual string RFC { get; set; }
    public virtual string CalleCliente { get; set; }
    public virtual string NumInteriorCliente { get; set; }
    public virtual string NumExteriorCliente { get; set; }
    public virtual string ColoniaCliente { get; set; }
    public virtual string LocalidadCliente { get; set; }
    public virtual string MunicipioCliente { get; set; }
    public virtual string EstadoCliente { get; set; }
    public virtual string PaisCliente { get; set; }
    public virtual string CPCliente { get; set; }
    public virtual decimal MontoCobrado { get; set; }
    public virtual decimal MontoFacturado { get; set; }
    public virtual decimal Subtotal { get; set; }
    public virtual decimal IVA { get; set; }
    public virtual decimal Descuento { get; set; }
    public virtual decimal Total { get; set; }
    public virtual decimal TasaIva { get; set; }
    public virtual string UsoCFDI { get; set; }
    public virtual string FormaPago { get; set; }
    public virtual string MetodoPago { get; set; }
    public virtual string EmpresaRCH { get; set; }
    public virtual string UsuarioFinalRCH { get; set; }
    public virtual string MesRCH { get; set; }
    public virtual int ClienteNS { get; set; }
    public virtual string ComentariosAdicionales { get; set; }
    public virtual string Estatus { get; set; }
    public virtual DateTime FechaAlta { get; set; }
    public virtual DateTime FechaFinalizacion { get; set; }
    public virtual string UsuarioAtiendeCEA { get; set; }
    public virtual string DiagnosticoCEA { get; set; }
    public virtual string MotivoRechazo { get; set; }
    public virtual DateTime FechaAtiendeCEA { get; set; }
    public virtual string ComentarioCEA { get; set; }
    public virtual string UsuarioCEACaptura { get; set; }
    public virtual decimal MontoDevolver { get; set; }
    public virtual string TDCDevolver { get; set; }
    public virtual string MotivoDevolucion { get; set; }
    public virtual string Banco { get; set; }
    public virtual string RequiereFacturacion { get; set; }
    public virtual string TipoDevolucion { get; set; }
    public virtual string CanceladaWizard { get; set; }
    public virtual string NoReservacion { get; set; }
    public virtual string ArchivoEvidencia { get; set; }
    public virtual string ArchivoEvidencia2 { get; set; }
    public virtual string ArchivoEvidencia3 { get; set; }
    public virtual string cuenta { get; set; }
    public virtual DateTime FechaCI { get; set; }
    public virtual decimal ImporteCI { get; set; }
    public virtual DateTime FechaCO { get; set; }
    public virtual decimal ImporteCO { get; set; }
    public virtual string TipoDep { get; set; }
    public virtual string Autorizacion { get; set; }
    public virtual string Afiliacion { get; set; }

    public SolicitudesFacturacionNS()
    {
        AreaEmpleado = "";
        MotivoSolicitud = "";
        RA = "";
        MVA = "";
        ApellidoMaterno = "";
        RazonSocial = "";
        RegimenFiscal = "";
        RFC = "";
        CalleCliente = "";
        NumInteriorCliente = "";
        NumExteriorCliente = "";
        ColoniaCliente = "";
        LocalidadCliente = "";
        MunicipioCliente = "";
        EstadoCliente = "";
        PaisCliente = "";
        CPCliente = "";
        MontoCobrado = 0;
        MontoFacturado = 0;
        Subtotal = 0;
        IVA = 0;
        Descuento = 0;
        Total = 0;
        TasaIva = 0;
        UsoCFDI = "";
        FormaPago = "";
        MetodoPago = "";
        EmpresaRCH = "";
        UsuarioFinalRCH = "";
        MesRCH = "";
        ClienteNS = 0;
        FechaAlta = DateTime.Now;
        FechaFinalizacion = new DateTime(1900, 1, 1);
        UsuarioAtiendeCEA = "";
        DiagnosticoCEA = "";
        MotivoRechazo = "";
        FechaAtiendeCEA = new DateTime(1900, 1, 1);
        ComentarioCEA = "";
        UsuarioCEACaptura = "";
        TDCDevolver = "";
        Banco = "";
        ArchivoEvidencia = "";
        ArchivoEvidencia2 = "";
        ArchivoEvidencia3 = "";
        cuenta = "";
        ImporteCI = 0;
        ImporteCO = 0;
        TipoDep = "";
        Autorizacion = "";
        Afiliacion = "";
    }

    public void UpdateInfo(SolicitudesFacturacionNS info)
    {
        NoEmpleado = info.NoEmpleado;
        NombreEmpleado = info.NombreEmpleado;
        SegmentoNegocio = info.SegmentoNegocio;
        TipoFactura = info.TipoFactura;
        MailNotificacion = info.MailNotificacion;
        Origen = info.Origen;
        Distrito = info.Distrito;
        NombreCliente = info.NombreCliente;
        ApellidoPaterno = info.ApellidoPaterno;
        Estatus = info.Estatus;
        MontoDevolver = info.MontoDevolver;
        MotivoDevolucion = info.MotivoDevolucion;
        RequiereFacturacion = info.RequiereFacturacion;
        TipoDevolucion = info.TipoDevolucion;
        CanceladaWizard = info.CanceladaWizard;
        NoReservacion = info.NoReservacion;
    }
}