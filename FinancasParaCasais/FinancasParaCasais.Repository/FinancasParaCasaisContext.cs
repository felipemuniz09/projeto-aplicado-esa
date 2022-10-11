using FinancasParaCasais.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Repository
{
    public class FinancasParaCasaisContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ConjugeEF> Conjuges { get; set; }
        public DbSet<DespesaEF> Despesas { get; set; }
        public DbSet<DespesaConjugeEF> DespesaConjuge { get; set; }
        public DbSet<PagamentoEF> Pagamentos { get; set; }

        public FinancasParaCasaisContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FinancasParaCasaisDB"));
        }
    }
}
