using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Enuns;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using Jokenpo.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepositoryMatch _repositoryMatch;
        private readonly IMapper _mapper;
        private readonly IMoveService _serviceMove;
        public MatchService(IRepositoryMatch repositoryMatch, IMapper mapper, IMoveService serviceMove)
        {
            _repositoryMatch = repositoryMatch;
            _mapper = mapper;
            _serviceMove = serviceMove;
        }

        public Guid CreateMatch()
        {
            Match match = new Match();
            match.Id = Guid.NewGuid();
            match.Moves = new List<Move>();
            match.Status = StatusMatch.Aberta;
            _repositoryMatch.CreatMatch(match);
            return match.Id;
        }

        public MatchTwoDto AddMoveInMatch(MoveDto moveDto)
        {

            var matchOpenInitial = _repositoryMatch.GetMatchOpen();

            if (matchOpenInitial == null)
            {
                var matchId = CreateMatch();
                var move = _mapper.Map<Move>(moveDto);
                _serviceMove.AddMove(moveDto);
                var match = _repositoryMatch.GetMatchById(matchId);
                match.Moves.Add(move);
                return GetMatchTwoDto(matchId);
            }
            else
            {
                if (matchOpenInitial.Moves.Count < 2)
                {
                    var move = _mapper.Map<Move>(moveDto);
                    _serviceMove.AddMove(moveDto);
                    matchOpenInitial.Moves.Add(move);
                    return GetMatchTwoDto(matchOpenInitial.Id);
                }
                else
                {
                    var move = _mapper.Map<Move>(moveDto);
                    _serviceMove.AddMove(moveDto);
                    matchOpenInitial.Moves.Add(move);
                    matchOpenInitial.Status = StatusMatch.Fechada;
                    return GetMatchTwoDto(matchOpenInitial.Id);
                    //ImplementarGetResult
                }
            }

        }

        public MatchTwoDto GetMatchTwoDto(Guid id)
        {
            var list = _repositoryMatch.GetMatchById(id);
            var listDto = _mapper.Map<MatchTwoDto>(list);
            return listDto;

        }
    }
}
