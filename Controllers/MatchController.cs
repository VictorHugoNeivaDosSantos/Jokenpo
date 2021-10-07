using Jokenpo.Dto;
using Jokenpo.Models;
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

        [HttpPut("{matchId,moveId}")]
        public string AddMatch([FromRoute]Guid matchId, [FromRoute]Guid moveId, [FromBody]MoveDto move)
        {
            return _service.AlterMoveInMatch(matchId, moveId ,move);
        }

        [HttpDelete("{matchId,moveId}")]
        public string DeleteMoveInMatch([FromRoute] Guid matchId, [FromRoute] Guid moveId)
        {
            return _service.DeletarJogadaInMatch(matchId, moveId);
        }

        [HttpGet]
        public List<MatchTwoDto> GetMatch()
        {
            return _service.GetListaMatch();
        }


    }
}
