using Jokenpo.Enuns;
using Jokenpo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokenpo.Dto
{
    public class MatchDto
    {
        public List<Move> Moves { get; set; }
        public StatusMatch Status { get; set; }
    }
}
