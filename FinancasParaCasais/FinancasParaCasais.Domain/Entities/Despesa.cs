using FinancasParaCasais.Domain.ValueObject;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Despesa : BaseEntity
    {
        private readonly List<PagamentoDespesaValueObject> _pagamentos;

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public IReadOnlyCollection<PagamentoDespesaValueObject> Pagamentos => _pagamentos;

        public Despesa(Guid codigo, string descricao, decimal valor) 
            : base(codigo)
        {
            _pagamentos = new List<PagamentoDespesaValueObject>();

            Descricao = descricao;
            Valor = valor;
            DataHoraCriacao = DateTime.Now;

            AddNotifications(new Contract<Despesa>()
                .IsLowerOrEqualsThan(Descricao.Length, 200, "Descricao", "Descrição possui tamanho máximo de 200 caracteres.")
                .IsGreaterOrEqualsThan(Valor, 0, "Valor", "Valor deve ser maior ou igual a zero."));
        }

        public PagamentoDespesaValueObject AdicionarPagamento(Guid codigoConjuge, decimal valor)
        {
            var pagamentoDespesaValueObject = new PagamentoDespesaValueObject(codigoConjuge, valor);

            if (pagamentoDespesaValueObject.IsValid)
                _pagamentos.Add(pagamentoDespesaValueObject);

            return pagamentoDespesaValueObject;
        }

        public void Validar()
        {
            if (_pagamentos.Count != 2)
                AddNotification("Pagamentos", "Lista de pagamentos deve conter 2 elementos.");
            else
            {
                var somaPagamentos = _pagamentos.Sum(p => p.Valor);
                var diferencaEntreValorESomaPagamentos = Valor - somaPagamentos;

                if (Math.Abs(diferencaEntreValorESomaPagamentos) > 0.009M)
                    AddNotification("Pagamentos", "Soma dos pagamentos deve ser igual ao valor da despesa.");
            }
        }
    }
}
