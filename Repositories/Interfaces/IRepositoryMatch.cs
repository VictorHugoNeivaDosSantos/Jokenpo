using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories.Interface
{
    public interface IRepositoryMatch
    {
        Guid AddMatch(Match match);
        Match GetMatchById(Guid id);
        List<Match> ListMatch();
        Match GetOpenMatch();

    }
}