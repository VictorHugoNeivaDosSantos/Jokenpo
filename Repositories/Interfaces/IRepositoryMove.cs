using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories.Interfaces
{
    public interface IRepositoryMove
    {
        Guid AddMove(Move move);
        void DeleteMove(Move move);
        Move GetMoveById(Guid id);
        List<Move> ListMoveAll();
    }
}