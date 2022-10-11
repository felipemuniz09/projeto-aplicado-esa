namespace FinancasParaCasais.Application.Commands
{
    public class InserirPagamentoCommand
    {
        public Guid CodigoConjugePagou { get; set; }
        public Guid CodigoConjugeRecebeu { get; set; }
        public decimal Valor { get; set; }
    }
}
