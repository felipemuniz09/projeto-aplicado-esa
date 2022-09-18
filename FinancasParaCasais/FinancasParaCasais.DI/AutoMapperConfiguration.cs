using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.DI
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CriarMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditarConjugesCommand.ConjugeCommand, Conjuge>();
                cfg.CreateMap<Conjuge, ConjugeEF>();
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
