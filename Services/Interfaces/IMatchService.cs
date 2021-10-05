using Jokenpo.Dto;
using System;

namespace Jokenpo.Services.Interfaces
{
    public interface IMatchService
    {
        Guid AddMoveInMatch(MoveDto moveDto);
        Guid CreateMatch();
    }
}