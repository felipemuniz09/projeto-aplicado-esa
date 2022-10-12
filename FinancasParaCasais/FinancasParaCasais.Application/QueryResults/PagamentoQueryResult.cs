namespace FinancasParaCasais.Application.QueryResults
{
    public class PagamentoQueryResult
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public PagamentoQueryResult()
        {
            Descricao = string.Empty;
        }
    }
}
