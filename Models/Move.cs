using Jokenpo.Enuns;
using System;

namespace Jokenpo.Models
{
    public class Move
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MatchId { get; set; }
        public Guid JogadorId { get; set; }
        public GameParts PlayPay { get; set; }
    }
}
