using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using Jokenpo.Repositories.Interfaces;
using Jokenpo.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services
{
    public class MoveService : IMoveService
    {
        private readonly IRepositoryMove _repositoryMove;
        private readonly IRepositoryPlayer _repositoryPlayer;
        private readonly IMapper _mapper;

        public MoveService(IRepositoryMove repository, IMapper mapper, IRepositoryPlayer repositoryPlayer)
        {
            _repositoryMove = repository;
            _mapper = mapper;
            _repositoryPlayer = repositoryPlayer;
        }

        public Guid AddMove(MoveDto moveDto)
        {
            var move = new Move();
            _mapper.Map(moveDto, move);
            var ExistingPlayer = _repositoryPlayer.GetPlayerById(move.JogadorId);
            if (ExistingPlayer != null)
            {
                _repositoryMove.AddMove(move);
                return move.Id;
            }
            else
            {
                throw new Exception("Jogador não encontrado");
            }
        }
        public MoveDto GetMoveById(Guid id)
        {
            var move = _repositoryMove.GetMoveById(id);
            if (move == null)
            {
                throw new Exception("Move não encontrada");
            }
            else
            {
                var moveDto = new MoveDto();
                _mapper.Map(move, moveDto);
                return moveDto;
            }
        }

        public string DeleteMove(Guid id)
        {
            var move = _repositoryMove.GetMoveById(id);

            if (move == null)
            {
                throw new Exception("Move não encontrada");
            }
            else
            {
                _repositoryMove.DeleteMove(move);
                return "Move deletada com sucesso!";
            }
        }

        public List<MoveDto> GetListMoveAll()
        {
            var lisDto = new List<MoveDto>();
            var list = _repositoryMove.ListMoveAll();
            _mapper.Map(list, lisDto);
            return lisDto;
        }

    }
}
