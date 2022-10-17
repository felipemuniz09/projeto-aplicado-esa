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
                cfg.CreateMapFromRepositoryToDomain();
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }

        private static void CreateMapFromApplicationToDomain(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<EditarConjugesCommand.ConjugeCommand, Conjuge>();
            cfg.CreateMap<InserirDespesaCommand, Despesa>();
            cfg.CreateMap<InserirDespesaCommand.PagamentoDespesaCommand, PagamentoDespesaValueObject>();
            cfg.CreateMap<InserirTransferenciaCommand, Transferencia>();
        }

        private static void CreateMapFromDomainToRepository(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Conjuge, ConjugeEF>();
            cfg.CreateMap<Despesa, DespesaEF>();
            cfg.CreateMap<PagamentoDespesaValueObject, DespesaConjugeEF>();
            cfg.CreateMap<Transferencia, TransferenciaEF>();
        }

        private static void CreateMapFromRepositoryToDomain(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ConjugeEF, Conjuge>();
            cfg.CreateMap<TransferenciaEF, Transferencia>();
            cfg.CreateMap<DespesaEF, Despesa>()
                .ForMember(d => d.Pagamentos, opt => opt.MapFrom(src => src.ListaDespesaConjuge));
            cfg.CreateMap<DespesaConjugeEF, PagamentoDespesaValueObject>();
        }
    }
}
