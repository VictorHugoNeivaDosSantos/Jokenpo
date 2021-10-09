using Jokenpo.Dto;
using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services.Interfaces
{
    public interface IMatchService
    {
        Guid AddMoveInMatch(MoveDto moveDto);
        string AlterMoveInMatch(Guid idMatch, Guid moveId,MoveDto move);
        string DeletarJogadaInMatch(Guid matchId, Guid moveId);
        List<MatchTwoDto> GetListaMatch();
        PlayerDto GetWinnerInMatchById(Guid matchId);
    }
}