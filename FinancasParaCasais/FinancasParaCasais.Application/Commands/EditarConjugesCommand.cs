using Flunt.Notifications;

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
            if (Conjuges == null || Conjuges.Count != 2)
                AddNotification("Conjuges", "Lista de conjuges deve conter 2 elementos.");
            else if (Conjuges.Sum(c => c.Percentual) != 100)
                AddNotification("Conjuges", "Somatório dos percentuais deve ser igual a 100.");
        }
    }
}
