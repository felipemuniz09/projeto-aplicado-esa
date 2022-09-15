using Flunt.Notifications;
using Flunt.Validations;

namespace FinancasParaCasais.Application.Commands
{
    public class EditarConjugesCommand : Notifiable<Notification>
    {
        public List<ConjugeCommand>? Conjuges { get; set; }

        public class ConjugeCommand
        {
            public Guid Codigo { get; set; }
            public string? Nome { get; set; }
            public int Percentual { get; set; }
        }

        public void Validar()
        {
            AddNotifications(new Contract<EditarConjugesCommand>()
                .IsNotNull(Conjuges, "Conjuges", "Lista de conjuges deve ser informada.")
                .IsNotEmpty(Conjuges, "Conjuges", "Lista de conjuges deve ser informada."));

            if (Conjuges != null && Conjuges.Count != 2) 
                AddNotification("Conjuges", "Lista de conjuges deve conter 2 elementos.");
        }
    }
}
