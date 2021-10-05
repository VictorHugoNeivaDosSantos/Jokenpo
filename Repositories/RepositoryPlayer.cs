using AutoMapper;
using Jokenpo.Context;
using Jokenpo.Dto;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories
{
    public class RepositoryPlayer : IRepositoryPlayer
    {
        private readonly IJokenpoContext _context;
        private readonly IMapper _mapper;

        public RepositoryPlayer(IJokenpoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Guid AddPlayer(Player player)
        {
            _context.PlayersList().Add(player);
            return player.Id;
        }

        public void DeletarPlayer(Player player)
        {
            _context.PlayersList().Remove(player);
        }

        public Player GetPlayerById(Guid id)
        {
            var player = _context.PlayersList().Find(f => f.Id == id);
            return player;
        }

        public List<Player> GetPlayersAll()
        {
            return _context.PlayersList();
        }

        public Player UpdatePlayer(Guid id, PlayerDto newPlayer)
        {
            var player = _context.PlayersList().Find(f => f.Id == id);
            _mapper.Map(newPlayer, player);
            return player;
        }


    }
}
