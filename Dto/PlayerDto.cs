using System;

namespace Jokenpo.Dto
{
    public class PlayerDto
    {
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
