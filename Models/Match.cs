using Jokenpo.Enuns;
using System;
using System.Collections.Generic;

namespace Jokenpo.Models
{
    public class Match
    {
        public Guid Id { get; set; }
        public List<Move> Moves { get; set; }
        public StatusMatch Status { get; set; }

    }
}
