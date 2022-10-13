namespace FinancasParaCasais.Application.DTOs
{
    public class SaldoPorConjugeDTO
    {
        public string NomeConjuge { get; set; }
        public decimal Valor { get; set; }

        public SaldoPorConjugeDTO()
        {
            NomeConjuge = string.Empty;
        }
    }
}
