using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasParaCasais.Repository.Entities
{
    [Table("Despesas")]
    public class DespesaEF : BaseEntityEF
    {
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Valor")]
        public decimal Valor { get; set; }

        [Column("DataHoraCriacao")]
        public DateTime DataHoraCriacao { get; set; }

        public IReadOnlyCollection<DespesaConjugeEF> ListaDespesaConjuge { get; set; }

        public DespesaEF()
        {
            Descricao = string.Empty;
            ListaDespesaConjuge = new List<DespesaConjugeEF>();
        }
    }
}
