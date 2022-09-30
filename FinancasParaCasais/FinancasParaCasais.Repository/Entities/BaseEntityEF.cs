using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinancasParaCasais.Repository.Entities
{
    public abstract class BaseEntityEF
    {
        [Column("Codigo")]
        [Key]
        public Guid Codigo { get; set; }
    }
}
