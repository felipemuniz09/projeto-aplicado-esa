namespace FinancasParaCasais.Application.DTOs
{
    public class ConjugeDTO
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Percentual { get; set; }

        public ConjugeDTO()
        {
            Nome = string.Empty;
        }
    }
}
