using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Dto
{
    public class MatchTwoDto
    {
        public Guid Id { get; set; }
        public List<Move> Moves { get; set; }
    }
}
