using AutoMapper;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.Repository.Repositories
{
    public class ConjugeRepository : BaseRepository, IConjugeRepository
    {
        private readonly IMapper _mapper;

        public ConjugeRepository(IMapper mapper, FinancasParaCasaisContext context)
            : base(context)
        {
            _mapper = mapper;
        }

        public void AtualizarConjuge(Conjuge conjuge)
        {
            var conjugeEF = _mapper.Map<ConjugeEF>(conjuge);

            _context.Conjuges.Update(conjugeEF);
        }
    }
}