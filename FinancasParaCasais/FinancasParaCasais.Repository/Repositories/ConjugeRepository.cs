using AutoMapper;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.Repository.Repositories
{
    public class ConjugeRepository : BaseRepository, IConjugeRepository
    {
        public ConjugeRepository(FinancasParaCasaisContext context, IMapper mapper)
            : base(context, mapper) { }

        public void AtualizarConjuge(Conjuge conjuge)
        {
            var conjugeEF = _mapper.Map<ConjugeEF>(conjuge);

            _context.Conjuges.Update(conjugeEF);

            _context.SaveChanges();
        }

        public IReadOnlyCollection<Conjuge> ObterConjuges()
        {
            var conjugesEF = _context.Conjuges.ToList();

            return conjugesEF.Select(c => _mapper.Map<Conjuge>(c)).ToList();
        }
    }
}