using Jokenpo.Dto;
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

        /// <summary>
        /// Rota utilizada para adicionar jogada do jogador em uma partida.
        /// </summary>
        [HttpPost]
        public Guid AddMoveInMatch([FromBody] MoveDto move)
        {
            return _serviceMatch.AddMoveInMatch(move);
        }   

        [HttpGet]
        public List<MatchListDto> GetMatch()
        {
            return _serviceMatch.GetListMatch();
        }

        [HttpGet("Winner/{matchId}")]

        public PlayerDto GetWinnerByMatchId([FromRoute] Guid matchId)
        {
            return _serviceMatch.GetWinnerInMatchById(matchId);
        }
    }
}
