using Jokenpo.Enuns;
using System;
using System.Collections.Generic;

namespace Jokenpo.Models
{
    public class Match
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Move> Moves { get; set; } = new List<Move>();
        public StatusMatch Status { get; set; }

    }
}
