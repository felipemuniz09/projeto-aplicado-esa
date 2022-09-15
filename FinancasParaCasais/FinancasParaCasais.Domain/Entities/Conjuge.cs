using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Conjuge : Notifiable<Notification>
    {
        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public int Percentual { get; private set; }

        public Conjuge(Guid codigo, string nome, int percentual)
        {
            Codigo = codigo;
            Nome = nome;
            Percentual = percentual;

            AddNotifications(new Contract<Conjuge>()
                .IsNotEmpty(Codigo, "Codigo", "Código deve ser informado")
                .IsNotNullOrWhiteSpace(Nome, "Nome", "Nome deve ser informado")
                .IsLowerOrEqualsThan(Nome.Length, 100, "Nome", "Nome possui tamanho máximo de 100 caracteres")
                .IsBetween(Percentual, 0, 100, "Percentual", "O percentual deve ser um valor entre 0 e 100"));
        }
    }
}
