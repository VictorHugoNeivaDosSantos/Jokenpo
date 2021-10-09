using Jokenpo.Context;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories
{
    public class RepositoryMatch : IRepositoryMatch
    {
        private readonly IJokenpoContext _context;

        public RepositoryMatch(IJokenpoContext context)
        {
            _context = context;
        }

        public Guid AddMatch(Match match)
        {
            _context.MatchList().Add(match);
            return match.Id;
        }

        public Match GetMatchById(Guid id)
        {
            return _context.MatchList().Find(f => f.Id == id);
        }

        public List<Match> ListMatch()
        {
            return _context.MatchList().FindAll(f => f.Status == Enuns.StatusMatch.Fechada);
        }
        public Match GetOpenMatch()
        {
            return _context.MatchList().Find(f => f.Status == Enuns.StatusMatch.Aberta);
        }

    }
}
