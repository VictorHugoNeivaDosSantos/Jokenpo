using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using Jokenpo.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepositoryPlayer _repositoryPlayer;
        private readonly IMapper _mapper;

        public PlayerService(IRepositoryPlayer repositoryPlayer, IMapper mapper)
        {
            _repositoryPlayer = repositoryPlayer;
            _mapper = mapper;
        }

        public Guid AddPlayer(PlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            _repositoryPlayer.AddPlayer(player);
            return player.Id;
        }

        public PlayerDto GetPlayerById(Guid id)
        {
            var player = _repositoryPlayer.GetPlayerById(id);

            if (player == null)
            {
                throw new Exception("Player não encontrado!");
            }
            else
            {
                return _mapper.Map<PlayerDto>(player);
            }
        }

        public string DeletePlayer(Guid id)
        {
            var player = _repositoryPlayer.GetPlayerById(id);
            if (player == null)
            {
                throw new Exception("Player não encontrado!");
            }
            else
            {
                _repositoryPlayer.DeletarPlayer(player);
                return "Player deletada com sucesso!";
            }
        }

        public List<PlayerDto> GetPlayersAll()
        {
            List<PlayerDto> playersDto = new List<PlayerDto>();
            var player = _repositoryPlayer.GetPlayersAll();
            _mapper.Map(player, playersDto);
            return playersDto;
        }
    }
}
