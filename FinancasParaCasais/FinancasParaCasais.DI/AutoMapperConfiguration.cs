using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.ValueObject;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.DI
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CriarMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapFromApplicationToDomain();
                cfg.CreateMapFromDomainToRepository();
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }

        private static void CreateMapFromApplicationToDomain(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<EditarConjugesCommand.ConjugeCommand, Conjuge>();
            cfg.CreateMap<InserirDespesaCommand, Despesa>();
            cfg.CreateMap<InserirDespesaCommand.PagamentoDespesaCommand, PagamentoDespesaValueObject>();
            cfg.CreateMap<InserirPagamentoCommand, Pagamento>();
        }

        private static void CreateMapFromDomainToRepository(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Conjuge, ConjugeEF>();
            cfg.CreateMap<Despesa, DespesaEF>();
            cfg.CreateMap<PagamentoDespesaValueObject, DespesaConjugeEF>();
            cfg.CreateMap<Pagamento, PagamentoEF>();
        }
    }
}
