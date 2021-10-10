using Jokenpo.Dto;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services.Interfaces
{
    public interface IMatchService
    {
        Guid AddMoveInMatch(MoveDto moveDto);       
        List<MatchListDto> GetListMatch();
        PlayerDto GetWinnerInMatchById(Guid matchId);
    }
}