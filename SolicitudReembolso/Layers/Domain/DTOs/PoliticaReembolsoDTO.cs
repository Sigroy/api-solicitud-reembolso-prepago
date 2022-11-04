namespace Avis.SolicitudReembolso.Domain;

    public class PoliticaReembolsoDTO
    {
        public string Titulo { get; set; }
        public int DiasMax { get; set; }
        public int DiasMin { get; set; }
        public decimal Porcentaje { get; set; }
    }

