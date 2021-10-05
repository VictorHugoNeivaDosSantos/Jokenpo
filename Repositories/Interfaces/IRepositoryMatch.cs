using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories.Interface
{
    public interface IRepositoryMatch
    {
        Guid CreatMatch(Match match);
        Match GetMatchById(Guid id);
        List<Match> ListaMathAll();
        Match MatchOpen();

    }
}