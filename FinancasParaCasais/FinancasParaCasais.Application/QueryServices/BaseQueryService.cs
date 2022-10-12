using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public abstract class BaseQueryService
    {
        private readonly IConfiguration _configuration;

        protected BaseQueryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection ObterNovaConexao() => new(_configuration.GetConnectionString("FinancasParaCasaisDB"));
    }
}
