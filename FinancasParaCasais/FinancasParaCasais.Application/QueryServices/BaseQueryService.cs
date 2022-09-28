using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public abstract class BaseQueryService
    {
        protected readonly IConfiguration _configuration;

        protected BaseQueryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
