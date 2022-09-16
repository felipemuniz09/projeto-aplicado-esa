using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppService;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class ConjugeAppService : IConjugeAppService
    {
        private readonly IConjugeService _conjugeService;
        private readonly IMapper _mapper;

        public ConjugeAppService(IConjugeService conjugeService, IMapper mapper)
        {
            _conjugeService = conjugeService;
            _mapper = mapper;
        }

        public void EditarConjuges(EditarConjugesCommand editarConjugesCommand)
        {
            editarConjugesCommand.Validar();

            if (!editarConjugesCommand.IsValid)     
                return;

            if (editarConjugesCommand.Conjuges != null)
            {
                foreach (var conjugeCommand in editarConjugesCommand.Conjuges)
                {
                    var conjuge = _mapper.Map<Conjuge>(conjugeCommand);

                    _conjugeService.EditarConjuge(conjuge);
                }
            }
        }
    }
}
