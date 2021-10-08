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
        private readonly IPlayerService _servicePlayer;

        public MatchService(IRepositoryMatch repositoryMatch, IMapper mapper, IPlayerService servicePlayer)
        {
            _repositoryMatch = repositoryMatch;
            _mapper = mapper;
            _servicePlayer = servicePlayer;
        }

        private Match CreateMatch()
        {
            Match match = new Match
            {
                Id = Guid.NewGuid(),
                Moves = new List<Move>(),
                Status = StatusMatch.Aberta
            };

            _repositoryMatch.AddMatch(match);
            return match;
        }

        public Guid AddMoveInMatch(MoveDto moveDto)
        {
            var match = _repositoryMatch.GetOpenMatch() ?? CreateMatch();
            var move = _mapper.Map<Move>(moveDto);

            if (_servicePlayer.GetPlayerById(move.JogadorId) != null)
            {

                if (CheckIfPlayerExistsAtGame(match, move.JogadorId) == false)
                {
                    move.MatchId = match.Id;
                    match.Moves.Add(move);

                    if (match.Moves.Count == 3)
                    {
                        match.Status = StatusMatch.Fechada;
                    }

                    return match.Id;
                }

                throw new Exception("Este jogador já jogou nesta partida");
            }

            throw new Exception("Jogador não encontrado");
        }

        public string AlterMoveInMatch(Guid idMatch, Guid moveId, MoveDto move)
        {
            var match = _repositoryMatch.GetMatchById(idMatch);
            if (match.Status == StatusMatch.Aberta)
            {
                var edition = match.Moves.Find(f => f.Id == moveId);
                edition.PlayPay = move.PlayPay;
            }
            else
            {
                throw new Exception("Partida já finalizada");
            }

            return "Jogada alterada";
        }

        public string DeletarJogadaInMatch(Guid matchId, Guid moveId)
        {
            var match = _repositoryMatch.GetMatchById(matchId) ?? throw new Exception("Partida não encontrada");
            match.Moves.Remove(match.Moves.Find(f => f.Id == moveId));

            return "Jogada excluída";
        }

        private bool CheckIfPlayerExistsAtGame(Match match, Guid jogadorId)
        {
            var result = match.Moves.Find(f => f.JogadorId == f.JogadorId);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public List<MatchTwoDto> GetListaMatch()
        {
            return _mapper.Map<List<MatchTwoDto>>(_repositoryMatch.ListMatch());
        }
    }
}
