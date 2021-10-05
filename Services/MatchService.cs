using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Enuns;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using Jokenpo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokenpo.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepositoryMatch _repositoryMatch;
        private readonly IMapper _mapper;
        private readonly IMoveService _serviceMove;
        public MatchService(IRepositoryMatch repositoryMatch, IMapper mapper)
        {
            _repositoryMatch = repositoryMatch;
            _mapper = mapper;
        }

        public Guid CreateMatch()
        {
            var match = new Match();
            match.Status = StatusMatch.Aberta;
            return match.Id;
        }


        public Guid AddMoveInMatch(MoveDto moveDto)
        {
            var move = new Move();

            var matchOpen = _repositoryMatch.MatchOpen();
            if (matchOpen == null)
            {
                CreateMatch();
            }
            else
            {
                if (matchOpen.Moves.Count < 3)
                {
                    _mapper.Map(moveDto, move);
                    matchOpen.Moves.Add(move);
                    return move.Id;
                }
                else
                {
                    _mapper.Map(moveDto, move);
                    matchOpen.Moves.Add(move);
                    matchOpen.Status = StatusMatch.Fechada;
                    return move.Id;
                    //Chamar metodo de Win
                }
            }
            matchOpen = _repositoryMatch.MatchOpen();
            _mapper.Map(moveDto, move);
            matchOpen.Moves.Add(move);
            return move.Id;
        }
    }
}
