namespace Avis.SolicitudReembolso.Domain;

public class SolicitudesFacturacionNSDTO
{
    public string SolicitudFacturacionNSPkey { get; set; }
    public string NoEmpleado { get; set; }
    public string NombreEmpleado { get; set; }
    public string SegmentoNegocio { get; set; }
    public string TipoFactura { get; set; }
    public string MailNotificacion { get; set; }
    public string Origen { get; set; }
    public string Distrito { get; set; }
    public string NombreCliente { get; set; }
    public string ApellidoPaterno { get; set; }
    public string Estatus { get; set; }
    public decimal MontoDevolver { get; set; }
    public string MotivoDevolucion { get; set; }
    public string RequiereFacturacion { get; set; }
    public string TipoDevolucion { get; set; }
    public string CanceladaWizard { get; set; }
    public string NoReservacion { get; set; }

}