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

        /// <summary>
        /// Rota utilizada para retornar uma lista de todas as partidas já concluída.
        /// </summary>
        [HttpGet]
        public List<MatchListDto> GetMatch()
        {
            return _serviceMatch.GetListMatch();
        }

        /// <summary>
        /// Rota utilizada para obter o ganhador de uma partida
        /// </summary>
        [HttpGet("Winner/{matchId}")]

        public PlayerDto GetWinnerByMatchId([FromRoute] Guid matchId)
        {
            return _serviceMatch.GetWinnerInMatchById(matchId);
        }
    }
}
