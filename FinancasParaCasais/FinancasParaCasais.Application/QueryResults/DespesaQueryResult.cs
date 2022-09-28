namespace FinancasParaCasais.Application.QueryResults
{
    public class DespesaQueryResult
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public DespesaQueryResult()
        {
            Descricao = string.Empty;
        }
    }
}
