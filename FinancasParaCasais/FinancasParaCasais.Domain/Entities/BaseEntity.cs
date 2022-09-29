using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public Guid Codigo { get; private set; }

        public BaseEntity(Guid codigo)
        {
            Codigo = codigo;

            AddNotifications(new Contract<Conjuge>()
                .IsNotEmpty(Codigo, "Codigo", "Código deve ser informado."));
        }
    }
}
