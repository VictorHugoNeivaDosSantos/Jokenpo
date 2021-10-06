using Jokenpo.Enuns;
using Jokenpo.Models;
using System.Collections.Generic;

namespace Jokenpo.Dto
{
    public class MatchDto
    {
        public List<Move> Moves { get; set; }
        public StatusMatch Status { get; set; }
    }
}
