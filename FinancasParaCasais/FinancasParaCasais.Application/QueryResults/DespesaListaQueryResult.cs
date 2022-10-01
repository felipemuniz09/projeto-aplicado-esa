namespace FinancasParaCasais.Application.QueryResults
{
    public class DespesaListaQueryResult
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public DespesaListaQueryResult()
        {
            Descricao = string.Empty;
        }
    }
}
