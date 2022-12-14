using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasParaCasais.Repository.Entities
{
    [Table("Transferencias")]
    public class TransferenciaEF : BaseEntityEF
    {
        [Column("CodigoConjugePagou")]
        public Guid CodigoConjugePagou { get; set; }

        [Column("CodigoConjugeRecebeu")]
        public Guid CodigoConjugeRecebeu { get; set; }

        [Column("Valor")]
        public decimal Valor { get; set; }

        [Column("DataHoraCriacao")]
        public DateTime DataHoraCriacao { get; set; }
    }
}
