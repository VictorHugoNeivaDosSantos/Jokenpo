using Jokenpo.Dto;
using Jokenpo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("Jokenpo/Match")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchController(IMatchService service)
        {
            _service = service;
        }

        [HttpPost]
        public MatchTwoDto AddMatch([FromBody] MoveDto move)
        {
            return _service.AddMoveInMatch(move);
        }

    }
}
