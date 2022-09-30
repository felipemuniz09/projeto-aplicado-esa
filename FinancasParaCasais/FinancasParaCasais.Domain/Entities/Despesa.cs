using FinancasParaCasais.Domain.ValueObject;
using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Despesa : Notifiable<Notification>
    {
        private readonly List<PagamentoDespesaValueObject> _pagamentos;

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public IReadOnlyCollection<PagamentoDespesaValueObject> Pagamentos => _pagamentos;

        public Despesa(string descricao, decimal valor) 
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
    }
}
