using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Conjuge : BaseEntity
    {
        public string Nome { get; private set; }
        public int Percentual { get; private set; }

        public Conjuge(Guid codigo, string nome, int percentual)
            : base(codigo)
        {
            Nome = nome;
            Percentual = percentual;

            AddNotifications(new Contract<Conjuge>()
                .IsNotNullOrWhiteSpace(Nome, "Nome", "Nome deve ser informado.")
                .IsLowerOrEqualsThan(Nome.Length, 100, "Nome", "Nome possui tamanho máximo de 100 caracteres.")
                .IsBetween(Percentual, 0, 100, "Percentual", "O percentual deve ser um valor entre 0 e 100."));
        }
    }
}
