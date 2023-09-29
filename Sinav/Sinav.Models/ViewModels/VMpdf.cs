namespace Sinav.Models.ViewModels
{
    public class VMpdf
    {
        public string Nombre { get; set; }

        public List<VMpdfDetails> Details { get; set; }
    }

    public class VMpdfDetails
    {
        public string Vacuna { get; set; }
        public int Dosis { get; set; }
        public string Lote { get; set; }
        public DateTime Fecha { get; set; }
    }
}
