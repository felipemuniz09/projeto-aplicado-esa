using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Domain.Services
{
    public class ConjugeService : IConjugeService
    {
        private readonly IConjugeRepository _conjugeRepository;

        public ConjugeService(IConjugeRepository conjugeRepository)
        {
            _conjugeRepository = conjugeRepository;
        }

        public void EditarConjuge(Conjuge conjuge)
        {
            if (conjuge.IsValid)
                _conjugeRepository.AtualizarConjuge(conjuge);
        }
    }
}
