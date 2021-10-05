using Jokenpo.Dto;
using Jokenpo.Enuns;
using Jokenpo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public Guid AddMatch([FromBody] MoveDto move)
        {
            return _service.AddMoveInMatch(move);
        }
      
    }
}
