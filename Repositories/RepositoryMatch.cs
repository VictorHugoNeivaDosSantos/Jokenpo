using Jokenpo.Context;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Jokenpo.Repositories
{
    public class RepositoryMatch : IRepositoryMatch
    {
        private readonly IJokenpoContext _context;

        public RepositoryMatch(IJokenpoContext context)
        {
            _context = context;
        }

        public Guid CreatMatch(Match match)
        {
            _context.MatchList().Add(match);
            return match.Id;
        }

        public Match GetMatchById(Guid id)
        {
            return _context.MatchList().Find(f => f.Id == id);
        }

        public List<Match> ListaMathAll()
        {
            return _context.MatchList();
        }
        public Match MatchOpen()
        {
            return _context.MatchList().FirstOrDefault(f => f.Status == Enuns.StatusMatch.Aberta);
        }
    }
}
