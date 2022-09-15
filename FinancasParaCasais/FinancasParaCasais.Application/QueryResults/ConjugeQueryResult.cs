namespace FinancasParaCasais.Application.QueryResults
{
    public class ConjugeQueryResult
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public int Percentual { get; set; }

        public ConjugeQueryResult()
        {
            Nome = string.Empty;
        }
    }
}
