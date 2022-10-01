namespace FinancasParaCasais.Application.QueryResults
{
    public class DespesaDetalhesQueryResult
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public IReadOnlyCollection<PagamentoQueryResult> Pagamentos { get; set; }

        public DespesaDetalhesQueryResult()
        {
            Descricao = string.Empty;
            Pagamentos = new List<PagamentoQueryResult>();
        }

        public class PagamentoQueryResult
        {
            public string NomeConjuge { get; set; }
            public decimal Valor { get; set; }

            public PagamentoQueryResult()
            {
                NomeConjuge = string.Empty;
            }
        }
    }
}
