using Jokenpo.Models;
using System.Collections.Generic;

namespace Jokenpo.Context
{
    public class JokenpoContext : IJokenpoContext
    {
        private static readonly List<Player> players = new List<Player>();

        private static readonly List<Match> match = new List<Match>();

        public List<Player> PlayersList()
        {
            return players;
        }
        public List<Match> MatchList()
        {
            return match;
        }
    }
}
