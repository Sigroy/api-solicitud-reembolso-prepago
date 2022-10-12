namespace Avis.SolicitudReembolso.Domain;

public class SolicitudFacturacionNSDTO
{
    public virtual string SolicitudFacturacionNSPkey { get; set; }
    public virtual string NoEmpleado { get; set; }
    public virtual string NombreEmpleado { get; set; }
    public virtual string SegmentoNegocio { get; set; }
    public virtual string TipoFactura { get; set; }
    public virtual string MailNotificacion { get; set; }
    public virtual string Origen { get; set; }
    public virtual string Distrito { get; set; }
    public virtual string NombreCliente { get; set; }
    public virtual string ApellidoPaterno { get; set; }
    public virtual string Estatus { get; set; }
    public virtual decimal MontoDevolver { get; set; }
    public virtual string MotivoDevolucion { get; set; }
    public virtual string RequiereFacturacion { get; set; }
    public virtual string TipoDevolucion { get; set; }
    public virtual string CanceladaWizard { get; set; }
    public virtual string NoReservacion { get; set; }
}