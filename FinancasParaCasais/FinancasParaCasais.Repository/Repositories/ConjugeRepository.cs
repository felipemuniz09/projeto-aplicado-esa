﻿using AutoMapper;
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
    }
}