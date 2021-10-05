using Jokenpo.Dto;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services.Interfaces
{
    public interface IMoveService
    {
        Guid AddMove(MoveDto move);
        string DeleteMove(Guid id);
        List<MoveDto> GetListMoveAll();
        MoveDto GetMoveById(Guid id);
    }
}