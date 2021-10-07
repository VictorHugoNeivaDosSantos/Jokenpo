using Jokenpo.Models;
using System.Collections.Generic;

namespace Jokenpo.Context
{
    public interface IJokenpoContext
    {
        List<Player> PlayersList();
        List<Match> MatchList();
    }
}