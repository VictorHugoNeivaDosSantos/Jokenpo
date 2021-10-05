using Jokenpo.Models;
using System.Collections.Generic;

namespace Jokenpo.Context
{
    public class JokenpoContext : IJokenpoContext
    {
        private static readonly List<Player> players = new List<Player>();
        private static readonly List<Move> moves = new List<Move>();
        private static readonly List<Match> match = new List<Match>();

        public List<Player> PlayersList()
        {
            return players;
        }
        public List<Move> MovesList()
        {
            return moves;
        }
        public List<Match> MatchList()
        {
            return match;
        }
    }
}
