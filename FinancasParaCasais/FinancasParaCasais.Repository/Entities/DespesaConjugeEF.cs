using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasParaCasais.Repository.Entities
{
    public class DespesaConjugeEF : BaseEntityEF
    {
        [Column("CodigoDespesa")]
        public Guid CodigoDespesa { get; set; }

        [Column("CodigoConjuge")]
        public Guid CodigoConjuge { get; set; }

        [Column("Valor")]
        public decimal Valor { get; set; }
    }
}
