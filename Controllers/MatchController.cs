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
        private readonly IMatchService _serviceMatch;

        public MatchController(IMatchService service)
        {
            _serviceMatch = service;
        }

        [HttpPost]
        public Guid AddMatch([FromBody] MoveDto move)
        {
            return _serviceMatch.AddMoveInMatch(move);
        }

        [HttpPut("{matchId,moveId}")]
        public string AddMatch([FromRoute]Guid matchId, [FromRoute]Guid moveId, [FromBody]MoveDto move)
        {
            return _serviceMatch.AlterMoveInMatch(matchId, moveId ,move);
        }

        [HttpDelete("{matchId,moveId}")]
        public string DeleteMoveInMatch([FromRoute] Guid matchId, [FromRoute] Guid moveId)
        {
            return _serviceMatch.DeletarJogadaInMatch(matchId, moveId);
        }

        [HttpGet]
        public List<MatchTwoDto> GetMatch()
        {
            return _serviceMatch.GetListaMatch();
        }

        [HttpGet("Winner/{matchId}")]

        public PlayerDto GetWinnerByMatchId([FromRoute]Guid matchId)
        {
           return _serviceMatch.GetWinnerInMatchById(matchId);
        }
    }
}
