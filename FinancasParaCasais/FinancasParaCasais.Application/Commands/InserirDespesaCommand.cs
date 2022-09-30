using Flunt.Notifications;

namespace FinancasParaCasais.Application.Commands
{
    public class InserirDespesaCommand : Notifiable<Notification>
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public IReadOnlyCollection<PagamentoDespesaCommand>? Pagamentos { get; set; }

        public class PagamentoDespesaCommand
        {
            public Guid CodigoConjuge { get; set; }
            public decimal Valor { get; set; }
        }

        public void Validar()
        {
            if (Pagamentos == null || Pagamentos.Count != 2)
                AddNotification("Pagamentos", "Lista de pagamentos deve conter 2 elementos.");
            else
            {
                var somaPagamentos = Pagamentos.Sum(p => p.Valor);
                var diferencaEntreValorESomaPagamentos = Valor - somaPagamentos;

                if (Math.Abs(diferencaEntreValorESomaPagamentos) > 0.009M)
                    AddNotification("Pagamentos", "Soma dos pagamentos deve ser igual ao valor da despesa.");
            }
        }
    }
}
