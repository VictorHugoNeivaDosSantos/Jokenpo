using Jokenpo.Context;
using Jokenpo.Models;
using Jokenpo.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories
{
    public class RepositoryMove : IRepositoryMove
    {
        private readonly IJokenpoContext _context;

        public RepositoryMove(IJokenpoContext context)
        {
            _context = context;
        }

        public Guid AddMove(Move move)
        {
            _context.MovesList().Add(move);
            return move.Id;
        }

        public void DeleteMove(Move move)
        {
            _context.MovesList().Add(move);
        }
        public List<Move> ListMoveAll()
        {
            return _context.MovesList();
        }

        public Move GetMoveById(Guid id)
        {
            return _context.MovesList().Find(f => f.Id == id);
        }

    }
}
