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
            var player = new Player();
            _mapper.Map(playerDto, player);
            return _repositoryPlayer.AddPlayer(player);
        }

        public PlayerDto GetPlayer(Guid id)
        {
            var playerDto = new PlayerDto();
            var player = _repositoryPlayer.GetPlayerById(id);

            if (player == null)
            {
                throw new Exception("Player não encontrado!");
            }
            else
            {
                _mapper.Map(player, playerDto);
                return playerDto;
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
