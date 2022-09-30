using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.ValueObject
{
    public class PagamentoDespesaValueObject : Notifiable<Notification>
    {
        public Guid CodigoConjuge { get; private set; }
        public decimal Valor { get; private set; }

        public PagamentoDespesaValueObject(Guid codigoConjuge, decimal valor)
        {
            CodigoConjuge = codigoConjuge;
            Valor = valor;

            AddNotifications(new Contract<PagamentoDespesaValueObject>()
                .IsNotEmpty(CodigoConjuge, "CodigoConjuge", "Código do cônjuge deve ser informado.")
                .IsGreaterOrEqualsThan(Valor, 0, "Valor", "Valor deve ser maior ou igual a zero."));
        }
    }
}
