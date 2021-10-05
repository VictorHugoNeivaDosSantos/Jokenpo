using Jokenpo.Enuns;
using System;

namespace Jokenpo.Dto
{
    public class MoveDto
    {
        public Guid JogadorId { get; set; }
        public GameParts PlayPay { get; set; }
    }
}
