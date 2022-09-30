using FinancasParaCasais.Domain.ValueObject;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Despesa : BaseEntity
    {
        private List<PagamentoDespesaValueObject> _pagamentos;

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public Despesa(Guid codigo, string descricao, decimal valor) 
            : base(codigo)
        {
            _pagamentos = new List<PagamentoDespesaValueObject>();

            Descricao = descricao;
            Valor = valor;
            DataHoraCriacao = DateTime.Now;

            AddNotifications(new Contract<Despesa>()
                .IsGreaterOrEqualsThan(Valor, 0, "Valor", "Valor deve ser maior ou igual a zero."));
        }

        public PagamentoDespesaValueObject AdicionarPagamento(Guid codigoConjuge, decimal valor)
        {
            var pagamentoDespesaValueObject = new PagamentoDespesaValueObject(codigoConjuge, valor);

            if (pagamentoDespesaValueObject.IsValid)
                _pagamentos.Add(pagamentoDespesaValueObject);

            return pagamentoDespesaValueObject;
        }
    }
}
