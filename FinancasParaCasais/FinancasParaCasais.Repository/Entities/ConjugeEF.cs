using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasParaCasais.Repository.Entities
{
    [Table("Conjuges")]
    public class ConjugeEF
    {
        [Column("Codigo")]
        public Guid Codigo { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Percentual")]
        public int Percentual { get; set; }
    }
}
