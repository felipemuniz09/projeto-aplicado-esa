using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Transferencia : Notifiable<Notification>
    {
        public Guid CodigoConjugePagou { get; private set; }
        public Guid CodigoConjugeRecebeu { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHoraCriacao { get; set; }

        public Transferencia(Guid codigoConjugePagou, Guid codigoConjugeRecebeu, decimal valor)
        {
            CodigoConjugePagou = codigoConjugePagou;
            CodigoConjugeRecebeu = codigoConjugeRecebeu;
            Valor = valor;
            DataHoraCriacao = DateTime.Now;

            const string mensagemCodigosIguais = "Código do cônjuge que pagou deve ser diferente do código do cônjuge que recebeu.";

            AddNotifications(new Contract<Transferencia>()
                .IsNotEmpty(CodigoConjugePagou, "CodigoConjugePagou", "Código do cônjuge que pagou deve ser informado.")
                .IsNotEmpty(CodigoConjugeRecebeu, "CodigoConjugeRecebeu", "Código do cônjuge que recebeu deve ser informado.")
                .AreNotEquals(CodigoConjugePagou, CodigoConjugeRecebeu, "CodigoConjugePagou", mensagemCodigosIguais)
                .IsGreaterThan(Valor, 0, "Valor", "Valor deve ser maior que zero."));
        }
    }
}
