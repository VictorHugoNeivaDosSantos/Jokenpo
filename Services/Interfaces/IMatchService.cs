using Jokenpo.Dto;
using System;

namespace Jokenpo.Services.Interfaces
{
    public interface IMatchService
    {
        MatchTwoDto AddMoveInMatch(MoveDto moveDto);
        Guid CreateMatch();
    }
}